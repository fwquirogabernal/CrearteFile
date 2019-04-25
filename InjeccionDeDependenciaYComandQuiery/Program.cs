using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34
{
    public interface IComando
    {
        string Tabla { get; set; }
        void Agregar(string a, object b);
        void Ejecutar();
    }
    public interface IAgregarComando : IComando { }
    public interface IActualizarComando : IComando { }
    public interface IBorrarComando : IComando { }
    public interface IConexion
    {
        void Ejecutar(string sql);
    }
    public abstract class Comando : IComando
    {
        public string Tabla { get; set; }
        protected IDictionary<string, object> Valores = new Dictionary<string, object>();
        private readonly IConexion _conexion;

        public Comando(IConexion conexion)
        {
            _conexion = conexion;
        }
        public void Agregar(string a, object b)
        {
            if (b is string) b = $"'{b}'";


            Valores[a] = b;
        }

        public void Ejecutar()
        {
            _conexion.Ejecutar(GenerarSql);
        }

        public abstract string GenerarSql { get; }
        public string RegValues() => string.Join(",", Valores.Values);

        public string RegNombre() => string.Join(",", Valores.Keys);

    }

    public class AgregarComando : Comando, IAgregarComando
    {
        public AgregarComando(IConexion conexion) : base(conexion) { }
        public override string GenerarSql => $"INSERT INTO {Tabla} {RegNombre()} VALUES {RegValues()}";
    }

    public class ActualizarComando : Comando, IActualizarComando
    {
        public ActualizarComando(IConexion conexion) : base(conexion) { }
        public override string GenerarSql => $"UPDATE {Tabla} SET";
    }
    public class BorrarComando : Comando, IBorrarComando
    {
        public BorrarComando(IConexion conexion) : base(conexion) { }
        public override string GenerarSql => $"DELETE FROM {Tabla} WHERE ID: {Valores["Id"]}";
    }

    public class Conexion : IConexion
    {
        public void Ejecutar(string sql)
        {
            Console.WriteLine($"Ejecutando: {sql}");
        }
    }

    public class Producto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double Precio { get; set; }

        public Producto(Guid id, string descrip, double precio)
        {
            Id = id;
            Description = descrip;
            Precio = precio;
        }

        public void Guardar()
        {
            IComando cmd;
            if (Id.Equals(Guid.Empty))
            {
               cmd = Demo.container.GetInstance<IAgregarComando>();
               Id = Guid.NewGuid();
            }
            else
                cmd = Demo.container.GetInstance<IActualizarComando>();

            cmd.Tabla = nameof(Producto);
            cmd.Agregar("Id", Id);
            cmd.Agregar("Descripcion", Description);
            cmd.Agregar("Precio", Precio);
            cmd.Ejecutar();

        }

        public void Borrar()
        {
            var cmd = Demo.container.GetInstance<IBorrarComando>();
            cmd.Tabla = nameof(Producto);
            cmd.Agregar("Id", Id);
            cmd.Ejecutar();
        }
    }
    public static class Demo
    {
        public static readonly Container container;
        static Demo()
        {
            container = new Container();
            container.Register<IActualizarComando, ActualizarComando>();
            container.Register<IAgregarComando, AgregarComando>();
            container.Register<IBorrarComando, BorrarComando>();
            container.RegisterSingleton<IConexion, Conexion>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INICIO");
            var producto = new Producto(Guid.Empty, "Coca-Cola", 22.5f);

            producto.Guardar();

            Console.ReadLine();

            producto.Guardar();

            Console.ReadLine();

            producto.Borrar();

            Console.ReadLine();

        }
    }
}
