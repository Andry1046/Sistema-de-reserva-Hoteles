using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
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

    public enum Estadohabitacion
    {
        Disponible,
        Ocupada
    }

    class Habitacion
    {

        private int Numero;
        private string Tipo;


        public int Num { get { return Numero; } set; }
        public string Type { get { return Tipo; } set; }
        public Estadohabitacion Estado { get; set; } = Estadohabitacion.Disponible;


        
        public Habitacion(int Numero, string Tipo)
        {
            this.Numero = Numero;
            this.Tipo = Tipo;

        }

        public void InfoHab() => Console.WriteLine($"Habitacion #{Numero} Clase/Tipo: {Tipo} Estado: {Estado}");

        public bool Reservar()
        {
            if(Estado == Estadohabitacion.Disponible)
            {
                Estado = Estadohabitacion.Ocupada;
                return true;
            }
            else
            { 
                return false;
            }
        }

        public bool Cancelar()
        {
            if(Estado == Estadohabitacion.Ocupada)
            {
                Estado = Estadohabitacion.Disponible;
                return true;
            }
            else
            {
                return false;
            }
        }

    }


    class Reserva
    {

        private string NombreCliente;
        private bool Habitacion = false;
        private string Fecha; 

        public string Nombrecliente { get { return NombreCliente; } set; }
        public bool habitacion { get { return Habitacion; } set; }

        public Reserva(string NombreCliente, string Fecha)
        {
            this.NombreCliente = NombreCliente;
            this.Fecha = Fecha;
            
        }
        public void Infocliente() =>  Console.WriteLine($"Nombre: {Nombrecliente} Habitacion: {habitacion} fecha: {Fecha}");

        public void ReservacionHabitacion(Habitacion hab)
        {
            if(hab.Reservar() == true)
            {
                Console.WriteLine($"La habitacion esta Ocupada por {NombreCliente}");
                Console.WriteLine($"La fecha de entrada es: {Fecha}");
                habitacion = true; //Posible utilizacion en futuro
            }
            else
            {
                Console.WriteLine("La habitacion ya esta ocupada");
            }
        }


        public void CancelacionReservacion(Habitacion hab)
        {
            if(hab.Cancelar() == true)
            {
                Console.WriteLine("La habitacion ahora esta disponible");
            }
            else
            {
                Console.WriteLine("Habitacion vacia");
            }
        }
    }
    

    class Hotel
    {
        private List<Habitacion> Habitaciones;

        public Hotel()
        {
            Habitaciones = new List<Habitacion>();
        }

        public void ListarEstadoHabitaciones()
        {
            Console.WriteLine("----------HABITACIONES-----------");


            foreach (Habitacion hab in Habitaciones)
            {
                if (hab.Estado == Estadohabitacion.Disponible)
                {

                    Console.WriteLine($"Numero: {hab.Num} Tipo: {hab.Type} estado: {hab.Estado}");
                }
                else
                {
                    Console.WriteLine($"Numero: {hab.Num} Tipo: {hab.Type} estado: {hab.Estado}");
                }

            }
        }




        //ListarHabitacionesPorEstado(estado) : Muestra habitaciones disponibles o ocupadas.
        //BuscarHabitaciónPorTipo(tipo): Encuentra una habitación específica.
        //ReservarHabitación(Reserva reserva): Realiza una reserva.
    }

}
