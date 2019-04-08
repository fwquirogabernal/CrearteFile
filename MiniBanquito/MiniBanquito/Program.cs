using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace MiniBanquito
{
    class Program
    {
        public static void Menu(Banquito banquito)
        {
            int opc = 0;
            
            string cliente;
            CuentaCorriente cc;
            double monto;
            do
            {
                Console.Clear();
                Console.WriteLine($"BIENVENIDO AL MINI BANQUITO: {Reloj.Hora}\n");
                Console.WriteLine("Que operacion realizara?");
                Console.WriteLine("1- Listar cuentas");
                Console.WriteLine("2- Depositar");
                Console.WriteLine("3- Extraer");
                Console.WriteLine("4- Actualizar Descubierto");
                Console.WriteLine("5- Salir");
                Console.WriteLine("6- Guardar");
                Console.WriteLine("7- Cargar");


                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        banquito.Listar();
                        break;
                    case 2:
                        Console.WriteLine("Escribir el nombre del cliente");
                        Console.WriteLine("-----Clientes-------");
                        banquito.ListarClientes();
                        Console.WriteLine("---------------------");
                        cliente = Console.ReadLine();
                        Console.WriteLine("Ingrese el monto a depositar");
                         monto = double.Parse(Console.ReadLine());
                         cc = banquito.Depositar(cliente, monto);

                        Console.WriteLine("Su saldo es:"+ cc.Saldo());
                        break;
                    case 3:
                        Console.WriteLine("Escribir el nombre del cliente");
                        Console.WriteLine("-----Clientes-------");
                        banquito.ListarClientes();
                        Console.WriteLine("---------------------");
                        cliente = Console.ReadLine();
                        Console.WriteLine("Ingrese el monto a Extraer");
                         monto = double.Parse(Console.ReadLine());
                         cc = banquito.Extraer(cliente, monto);

                        Console.WriteLine("Su saldo es:" + cc.Saldo());
                        break;
                    case 4:
                        Console.WriteLine("Escribir el nombre del cliente");
                        Console.WriteLine("-----Clientes-------");
                        banquito.ListarClientes();
                        Console.WriteLine("---------------------");
                        cliente = Console.ReadLine();
                        Console.WriteLine("Ingrese el monto a Extraer");
                        monto = double.Parse(Console.ReadLine());
                        cc = banquito.ActualizarDesc(cliente, monto);

                        Console.WriteLine("Su saldo es:" + cc.Desc());
                        break;
                    case 6:
                        banquito.Guardar();
                        Console.WriteLine("Se guardo en un archivo JSON");
                        break;
                    case 7:
                        banquito = banquito.Cargar();
                        banquito.CalcularHora();
                        Console.WriteLine("Se cargo en un archivo JSON");
                        break;
                    default:
                        if(opc!=5) Console.WriteLine("Ingrese una opcion valida.");
                        break;
                }

                Console.ReadLine();

            } while (opc != 5);
        }

        static void Main(string[] args)
        {
            Banquito banquito = new Banquito();

            //var cc1 = new CuentaCorriente("Juan");
            //var cc2 = new CuentaCorriente("Pedro");
            //var cc3 = new CuentaCorriente("Luis");

            //cc1.Depositar(100);
            //cc1.Extraer(75);
            //cc1.ActualizarDescubierto(1000);
            //cc1.ActualizarDescubierto(1500);

            //cc2.Depositar(100);
            //cc2.Extraer(150);
            //cc2.ActualizarDescubierto(1000);
            //cc2.ActualizarDescubierto(3000);

            //cc3.Depositar(100);
            //cc3.Extraer(100);
            //cc3.ActualizarDescubierto(2000);
            //cc3.ActualizarDescubierto(1500);

            //banquito.Agregar(cc1);
            //banquito.Agregar(cc2);
            //banquito.Agregar(cc3);

            //banquito.Listar();

            Menu(banquito);
            //Console.WriteLine("sh1"+cc1.Saldo(1));

            //banquito.Cargar().Listar();
            Console.ReadLine();


        }
    }
}
