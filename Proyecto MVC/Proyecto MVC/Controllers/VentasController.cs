using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_MVC.Data;
using Proyecto_MVC.Models;

namespace Proyecto_MVC.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VentasController
        public async Task<IActionResult> Index()
        {
            var ventas = await _context.Ventas.ToListAsync();

            // Obtener todos los clientes y productos para mostrar nombres y detalles
            var clientes = await _context.Clientes.ToListAsync();
            var productos = await _context.Productos.ToListAsync();
            ViewBag.Clientes = clientes;
            ViewBag.Productos = productos;

            return View(ventas);
        }

        // GET: VentasController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            // Obtener el cliente y el producto específicos
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == venta.ClienteId);
            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == venta.ProductoId);
            ViewBag.Cliente = cliente;
            ViewBag.Producto = producto;

            return View(venta);
        }

        // GET: VentasController/Create
        public IActionResult Create()
        {
            ViewData["Clientes"] = new SelectList(_context.Clientes, "Id", "Nombres");
            ViewData["Productos"] = new SelectList(_context.Productos, "Id", "Nombre");
            ViewData["FechaVenta"] = DateTime.Now.ToString("yyyy-MM-dd");
            return View();
        }

        // POST: VentasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,ProductoId,Cantidad,Precio,FechaVenta,Total")] Ventas venta)
        {
            // Validaciones básicas
            if (venta == null)
            {
                return BadRequest();
            }

            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == venta.ProductoId);
            if (producto == null)
            {
                ModelState.AddModelError("ProductoId", "Producto no válido.");
            }
            else
            {
                // Asignar el precio para que la vista lo muestre incluso si hay errores
                venta.Precio = producto.Precio;

                if (venta.Cantidad <= 0)
                {
                    ModelState.AddModelError("Cantidad", "La cantidad debe ser mayor que cero.");
                }
                else if (venta.Cantidad > producto.Stock)
                {
                    ModelState.AddModelError("Cantidad", $"La cantidad solicitada ({venta.Cantidad}) supera el stock disponible ({producto.Stock}).");
                }
            }

            if (ModelState.IsValid)
            {
                // Precio ya asignado; Total se calcula en el modelo

                // Reducir stock del producto
                producto.Stock -= venta.Cantidad;
                _context.Update(producto);

                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Clientes"] = new SelectList(_context.Clientes, "Id", "Nombres", venta.ClienteId);
            ViewData["Productos"] = new SelectList(_context.Productos, "Id", "Nombre", venta.ProductoId);
            ViewData["FechaVenta"] = venta.FechaVenta.ToString("yyyy-MM-dd");
            return View(venta);
        }

        // GET: VentasController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["Clientes"] = new SelectList(_context.Clientes, "Id", "Nombres", venta.ClienteId);
            ViewData["Productos"] = new SelectList(_context.Productos, "Id", "Nombre", venta.ProductoId);
            return View(venta);
        }

        // POST: VentasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,ProductoId,Cantidad,Precio,FechaVenta,Total")] Ventas venta)
        {
            if (id != venta.Id)
            {
                return NotFound();
            }

            // Obtener venta anterior para ajustar stock correctamente
            var ventaAnterior = await _context.Ventas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
            if (ventaAnterior == null)
            {
                return NotFound();
            }

            var productoNuevo = await _context.Productos.FirstOrDefaultAsync(p => p.Id == venta.ProductoId);
            if (productoNuevo == null)
            {
                ModelState.AddModelError("ProductoId", "Producto no válido.");
            }
            else
            {
                // Asignar el precio para que la vista lo muestre incluso si hay errores
                venta.Precio = productoNuevo.Precio;

                if (venta.Cantidad <= 0)
                {
                    ModelState.AddModelError("Cantidad", "La cantidad debe ser mayor que cero.");
                }
                else
                {
                    if (ventaAnterior.ProductoId == venta.ProductoId)
                    {
                        // Si es el mismo producto, el stock disponible es el stock actual más la cantidad que se liberaría de la venta anterior
                        var disponible = productoNuevo.Stock + ventaAnterior.Cantidad;
                        if (venta.Cantidad > disponible)
                        {
                            ModelState.AddModelError("Cantidad", $"La cantidad solicitada ({venta.Cantidad}) supera el stock disponible ({disponible}).");
                        }
                    }
                    else
                    {
                        // Si cambió de producto, hay que verificar contra el stock del producto nuevo
                        if (venta.Cantidad > productoNuevo.Stock)
                        {
                            ModelState.AddModelError("Cantidad", $"La cantidad solicitada ({venta.Cantidad}) supera el stock disponible del producto seleccionado ({productoNuevo.Stock}).");
                        }
                    }
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Ajustar stocks
                    var productoAnterior = await _context.Productos.FirstOrDefaultAsync(p => p.Id == ventaAnterior.ProductoId);

                    if (productoAnterior != null && ventaAnterior.ProductoId != venta.ProductoId)
                    {
                        // Restaurar stock del producto anterior
                        productoAnterior.Stock += ventaAnterior.Cantidad;
                        _context.Update(productoAnterior);
                    }

                    // Actualizar stock del producto nuevo (o el mismo)
                    if (productoNuevo != null)
                    {
                        if (ventaAnterior.ProductoId == venta.ProductoId)
                        {
                            // liberar la cantidad anterior y restar la nueva
                            productoNuevo.Stock = productoNuevo.Stock + ventaAnterior.Cantidad - venta.Cantidad;
                        }
                        else
                        {
                            productoNuevo.Stock -= venta.Cantidad;
                        }
                        _context.Update(productoNuevo);

                        // Actualizar precio (Total se calcula en el modelo)
                        venta.Precio = productoNuevo.Precio;
                    }

                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Clientes"] = new SelectList(_context.Clientes, "Id", "Nombres", venta.ClienteId);
            ViewData["Productos"] = new SelectList(_context.Productos, "Id", "Nombre", venta.ProductoId);
            return View(venta);
        }

        // GET: VentasController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            // Obtener el cliente y producto específicos
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == venta.ClienteId);
            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == venta.ProductoId);
            ViewBag.Cliente = cliente;
            ViewBag.Producto = producto;

            return View(venta);
        }

        // POST: VentasController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                // Restaurar el stock del producto al eliminar la venta
                var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == venta.ProductoId);
                if (producto != null)
                {
                    producto.Stock += venta.Cantidad;
                    _context.Update(producto);
                }

                _context.Ventas.Remove(venta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.Id == id);
        }
    }
}