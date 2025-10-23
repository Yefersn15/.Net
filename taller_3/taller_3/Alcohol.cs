using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller_3
{
    internal class Alcohol
    {
        public List<Camion> camiones { get; set; } = new List<Camion>();
        public const int CAMIONES_DIARIOS = 20;
        public const int MIN_CAPACIDAD_CAMION = 18000;
        public const int MAX_CAPACIDAD_CAMION = 28000;
        public const int MIN_CAPACIDAD_TANQUE = 3000;
        public const int MAX_CAPACIDAD_TANQUE = 9000;

        public class Camion
        {
            public int numero { get; set; }
            public int capacidad { get; set; }
            public int cargaActual { get; set; }
            public List<int> tanques { get; set; } = new List<int>();
            public bool completo { get; set; }

            public bool AgregarTanque(int litros)
            {
                if (cargaActual + litros <= capacidad)
                {
                    tanques.Add(litros);
                    cargaActual += litros;

                    // Verificar si está completo o casi completo
                    if (cargaActual == capacidad)
                    {
                        completo = true;
                    }

                    return true;
                }
                return false;
            }

            public double PorcentajeCarga()
            {
                return (double)cargaActual / capacidad * 100;
            }
        }

        public void MenuAlcohol()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== SISTEMA DE DISTRIBUCIÓN DE ALCOHOL ===");
                Console.WriteLine("1. Iniciar carga diaria de camiones");
                Console.WriteLine("2. Mostrar estado actual de camiones");
                Console.WriteLine("3. Ver resumen del día");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Seleccione una opción:");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        IniciarCargaDiaria();
                        break;
                    case 2:
                        MostrarEstadoCamiones();
                        break;
                    case 3:
                        MostrarResumenDia();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del sistema de distribución...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        public void IniciarCargaDiaria()
        {
            camiones.Clear();
            Console.WriteLine("\n=== INICIANDO CARGA DIARIA ===");
            Console.WriteLine($"Meta: Cargar {CAMIONES_DIARIOS} camiones hoy");
            Console.WriteLine($"Capacidad camiones: {MIN_CAPACIDAD_CAMION}-{MAX_CAPACIDAD_CAMION} litros");
            Console.WriteLine($"Capacidad tanques: {MIN_CAPACIDAD_TANQUE}-{MAX_CAPACIDAD_TANQUE} litros");

            for (int i = 1; i <= CAMIONES_DIARIOS; i++)
            {
                Console.WriteLine($"\n--- CAMIÓN #{i} ---");
                CargarCamion(i);

                if (i < CAMIONES_DIARIOS)
                {
                    Console.WriteLine("\n¿Continuar con el siguiente camión? (s/n):");
                    string continuar = Console.ReadLine();
                    if (continuar.ToLower() != "s")
                    {
                        Console.WriteLine("Carga diaria interrumpida.");
                        break;
                    }
                }
            }

            Console.WriteLine($"\n✅ CARGA DIARIA COMPLETADA: {camiones.Count} camiones cargados");
        }

        public void CargarCamion(int numeroCamion)
        {
            Console.WriteLine($"Ingrese la capacidad del camión #{numeroCamion} ({MIN_CAPACIDAD_CAMION}-{MAX_CAPACIDAD_CAMION} litros):");
            int capacidad = int.Parse(Console.ReadLine());

            while (capacidad < MIN_CAPACIDAD_CAMION || capacidad > MAX_CAPACIDAD_CAMION)
            {
                Console.WriteLine($"Capacidad inválida. Debe estar entre {MIN_CAPACIDAD_CAMION} y {MAX_CAPACIDAD_CAMION} litros:");
                capacidad = int.Parse(Console.ReadLine());
            }

            Camion camion = new Camion
            {
                numero = numeroCamion,
                capacidad = capacidad,
                cargaActual = 0,
                completo = false
            };

            Console.WriteLine($"\nIniciando carga del camión #{numeroCamion} (Capacidad: {capacidad} litros)");

            while (!camion.completo)
            {
                Console.WriteLine($"\nCapacidad disponible: {capacidad - camion.cargaActual} litros");
                Console.WriteLine("Ingrese los litros del próximo tanque de alcohol (0 para terminar carga):");
                int litrosTanque = int.Parse(Console.ReadLine());

                if (litrosTanque == 0)
                {
                    Console.WriteLine("Carga terminada por el operario.");
                    break;
                }

                // Validar capacidad del tanque
                if (litrosTanque < MIN_CAPACIDAD_TANQUE || litrosTanque > MAX_CAPACIDAD_TANQUE)
                {
                    Console.WriteLine($"❌ ERROR: El tanque debe tener entre {MIN_CAPACIDAD_TANQUE} y {MAX_CAPACIDAD_TANQUE} litros");
                    continue;
                }

                // Verificar si el tanque cabe en el camión
                if (camion.cargaActual + litrosTanque <= camion.capacidad)
                {
                    bool agregado = camion.AgregarTanque(litrosTanque);
                    if (agregado)
                    {
                        Console.WriteLine($"✅ Tanque de {litrosTanque} litros cargado exitosamente");
                        Console.WriteLine($"Carga actual: {camion.cargaActual}/{camion.capacidad} litros ({camion.PorcentajeCarga():F1}%)");

                        if (camion.completo)
                        {
                            Console.WriteLine("🚛 ¡CAMION COMPLETO! Listo para despachar.");
                        }
                    }
                }
                else
                {
                    int espacioDisponible = camion.capacidad - camion.cargaActual;
                    Console.WriteLine($"❌ NO CARGAR: Este tanque de {litrosTanque} litros excede la capacidad.");
                    Console.WriteLine($"   Espacio disponible: {espacioDisponible} litros");
                    Console.WriteLine($"   🚛 DESPACHAR CAMION #{camion.numero} e iniciar nuevo camión");
                    break;
                }
            }

            camiones.Add(camion);
            Console.WriteLine($"\n📦 RESUMEN CAMIÓN #{camion.numero}:");
            Console.WriteLine($"   Capacidad: {camion.capacidad} litros");
            Console.WriteLine($"   Carga final: {camion.cargaActual} litros");
            Console.WriteLine($"   Eficiencia: {camion.PorcentajeCarga():F1}%");
            Console.WriteLine($"   Tanques cargados: {camion.tanques.Count}");
        }

        public void MostrarEstadoCamiones()
        {
            if (camiones.Count == 0)
            {
                Console.WriteLine("No hay camiones cargados hoy.");
                return;
            }

            Console.WriteLine("\n=== ESTADO ACTUAL DE CAMIONES ===");
            foreach (var camion in camiones)
            {
                Console.WriteLine($"\n🚛 CAMIÓN #{camion.numero}:");
                Console.WriteLine($"   Capacidad: {camion.capacidad} litros");
                Console.WriteLine($"   Carga actual: {camion.cargaActual} litros");
                Console.WriteLine($"   Porcentaje: {camion.PorcentajeCarga():F1}%");
                Console.WriteLine($"   Tanques: {camion.tanques.Count}");
                Console.WriteLine($"   Estado: {(camion.completo ? "COMPLETO ✅" : "PARCIAL ⚠️")}");

                if (camion.tanques.Count > 0)
                {
                    Console.WriteLine($"   Detalle tanques: {string.Join(" + ", camion.tanques)} = {camion.cargaActual} litros");
                }
            }
        }

        public void MostrarResumenDia()
        {
            if (camiones.Count == 0)
            {
                Console.WriteLine("No hay camiones cargados hoy.");
                return;
            }

            Console.WriteLine("\n=== RESUMEN DEL DÍA - DISTRIBUCIÓN ALCOHOL ===");

            int totalCamiones = camiones.Count;
            int totalLitrosTransportados = camiones.Sum(c => c.cargaActual);
            int totalCapacidad = camiones.Sum(c => c.capacidad);
            double eficienciaPromedio = camiones.Average(c => c.PorcentajeCarga());
            int camionesCompletos = camiones.Count(c => c.completo);
            int totalTanques = camiones.Sum(c => c.tanques.Count);

            Console.WriteLine($"📊 ESTADÍSTICAS GENERALES:");
            Console.WriteLine($"   Camiones cargados: {totalCamiones}/{CAMIONES_DIARIOS}");
            Console.WriteLine($"   Camiones completos: {camionesCompletos}");
            Console.WriteLine($"   Total tanques transportados: {totalTanques}");
            Console.WriteLine($"   Litros transportados: {totalLitrosTransportados} litros");
            Console.WriteLine($"   Capacidad total: {totalCapacidad} litros");
            Console.WriteLine($"   Eficiencia promedio: {eficienciaPromedio:F1}%");

            Console.WriteLine($"\n📈 DISTRIBUCIÓN POR CAMIÓN:");
            var camionMasEficiente = camiones.OrderByDescending(c => c.PorcentajeCarga()).First();
            var camionMenosEficiente = camiones.OrderBy(c => c.PorcentajeCarga()).First();

            Console.WriteLine($"   Camión más eficiente: #{camionMasEficiente.numero} ({camionMasEficiente.PorcentajeCarga():F1}%)");
            Console.WriteLine($"   Camión menos eficiente: #{camionMenosEficiente.numero} ({camionMenosEficiente.PorcentajeCarga():F1}%)");

            Console.WriteLine($"\n🏭 PRODUCCIÓN:");
            int tanquesRango3000_5000 = camiones.Sum(c => c.tanques.Count(t => t >= 3000 && t <= 5000));
            int tanquesRango5001_7000 = camiones.Sum(c => c.tanques.Count(t => t > 5000 && t <= 7000));
            int tanquesRango7001_9000 = camiones.Sum(c => c.tanques.Count(t => t > 7000 && t <= 9000));

            Console.WriteLine($"   Tanques 3000-5000 litros: {tanquesRango3000_5000}");
            Console.WriteLine($"   Tanques 5001-7000 litros: {tanquesRango5001_7000}");
            Console.WriteLine($"   Tanques 7001-9000 litros: {tanquesRango7001_9000}");

            if (totalCamiones >= CAMIONES_DIARIOS)
            {
                Console.WriteLine($"\n🎯 META DIARIA ALCANZADA: {CAMIONES_DIARIOS} camiones cargados");
            }
            else
            {
                Console.WriteLine($"\n⚠️  META DIARIA PENDIENTE: {totalCamiones}/{CAMIONES_DIARIOS} camiones");
            }
        }
    }
}