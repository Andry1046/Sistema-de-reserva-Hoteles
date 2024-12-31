using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Sistemas_de_reservas_Hoteles
{
    internal class Program
    {
        static void Main(string[] args)
        {



        }
    }

    class Habitacion
    {

        private int Numero;
        private string Tipo;
        private string Estado;

        public string State { get { return Estado; } set; }
        
        public Habitacion(int Numero, string Tipo, string Estado)
        {
            this.Numero = Numero;
            this.Tipo = Tipo;
            this.Estado = Estado;

        }

        public void ActualizarEstado(string nuevoestado) => Estado = nuevoestado;

        public void MostrarInfo() => Console.WriteLine($"Habitacion #{Numero} Clase/Tipo: {Tipo} Estado: {Estado}");

    }


    class Reserva
    {

        private string NombreCliente;
        private string Habitacion;
        private string Fecha;

        public string Nombrecliente { get { return NombreCliente; } set; }

        public Reserva(string NombreCliente, string Habitacion, string Fecha)
        {
            this.NombreCliente = NombreCliente;
            this.Habitacion = Habitacion;
            this.Fecha = Fecha;
            
        }

        //Asocia una habitacion al cliente
        public void RegistrarReserva(Habitacion hab)
        {
           if(hab.State == "Disponible")
            {
                hab.State = "Ocupada";
                Console.WriteLine($"La habitacion esta ocupada por el Cliente: {Nombrecliente}");
            }
           else
            {

                Console.WriteLine("La habitacion esta disponible");
            }

           //Usa el campo habitacion de la clase reserva para asociarlo al registro del metodo registrar reserva.
        }

        //LIbera la habitacion reservada
        public void CancelarReserva()
        {

        }
    }
}
