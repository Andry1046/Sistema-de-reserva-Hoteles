using System;
using System.Collections.Generic;
using System.Xml;


namespace Sistemas_de_reservas_Hoteles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Habitacion hab = new Habitacion(10,"sencilla");
            Habitacion hab2 = new Habitacion(17,"sencilla");

            Habitacion habhigh = new Habitacion(20,"doble");
            Habitacion habhigh2 = new Habitacion(30,"doble");

            Habitacion hablevel = new Habitacion(50,"suite");
            Habitacion hablevel2 = new Habitacion(70,"suite");

            Hotel infinito = new();

            infinito.anadir(hab);
            infinito.anadir(hab2);
            infinito.anadir(habhigh);
            infinito.anadir(habhigh2);
            infinito.anadir(hablevel);
            infinito.anadir(hablevel2);


            //infinito.Buscarhaitacionportipo("suite");
            Reserva reser1 = new("Andry Martinez","20/1/2025");
            Reserva reser2 = new("Luz","22/1/2025");

            

            reser1.ReservacionHabitacion(hab);

            reser2.ReservacionHabitacion(habhigh);

            infinito.ListarEstadoHabitaciones();

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

        public void InfoHab()
        {
            Console.WriteLine();
            Console.WriteLine($"Habitacion: #{Numero} \nClase/Tipo: {Tipo} \nEstado:     {Estado}");
        }
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
        public void Infocliente() =>  Console.WriteLine($"Nombre: {Nombrecliente} \nHabitacion: {habitacion} \nfecha in: {Fecha}");

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

        public void anadir(Habitacion entrada)
        {
            Habitaciones.Add(entrada);
        }

        //Lista habitaciones por estados
        public void ListarEstadoHabitaciones()
        {
            Console.WriteLine("-------------HABITACIONES--------------");
            Console.WriteLine();

            foreach (Habitacion hab in Habitaciones)
            {
                if (hab.Estado == Estadohabitacion.Disponible)
                {

                    Console.WriteLine($"Numero: #{hab.Num} \nTipo: {hab.Type} \nestado: {hab.Estado}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Numero: #{hab.Num} \nTipo: {hab.Type} \nestado: {hab.Estado}");
                }

            }
        }

        //BuscarHabitaciónPorTipo(tipo): Encuentra una habitación específica.
        public void Buscarhaitacionportipo(string tipo)
        {
            int j = 0;

            for (int i = 0; i < Habitaciones.Count; i++)
            {
                Habitacion busqueda = Habitaciones[i];

                if (busqueda.Type != tipo)
                {
                   
                    j++;

                    if(j == i)
                    {
                        Console.WriteLine("Tipo de habitacion no disponible");
                        Console.WriteLine(j);
                    }
                    
                }
                else
                {
                    busqueda.InfoHab();
                }
            }

        }
        public void Reservarhabitacion(Reserva reserva)
        {
    

        }
       
        
    }

}
