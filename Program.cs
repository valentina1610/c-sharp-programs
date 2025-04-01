using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace ejdia2
{
    public class MaterialBibliografico
    {
        public int anio { get; set; }
        public string autor { get; set; }
        public string titulo { get; set; }

        public MaterialBibliografico(int anio, string autor, string titulo)
        {
            this.anio = anio;
            this.autor = autor;
            this.titulo = titulo;
        }

        public virtual void MostrarDatosLibro()
        {
            Console.WriteLine($"Año del libro: {anio}");
            Console.WriteLine($"Autor del libro: {autor}");
            Console.WriteLine($"Titulo del libro: {titulo}");

        }
    }

    public class Ebook : MaterialBibliografico
    {
        public double pesoMB { get; set; }

        public Ebook(int anio, string autor, string titulo, double pesoMB): base(anio, autor, titulo)
        {
            this.pesoMB = pesoMB;
        }

        public override void MostrarDatosLibro()
        {
            base.MostrarDatosLibro();
            Console.WriteLine("Tipo: Ebook");
            Console.WriteLine($"Peso: {pesoMB} MB");
            Console.WriteLine("-----------------------------------");
        }


    }
    public class LibroFisico : MaterialBibliografico
    {
        public int cantidadDePag { get; set; }

        public LibroFisico(int anio, string autor, string titulo, int cantidadDePag) : base(anio, autor, titulo)
        {
            this.cantidadDePag = cantidadDePag;
        }

        public override void MostrarDatosLibro()
        {
            base.MostrarDatosLibro();
            Console.WriteLine("Tipo: Libro fisico");
            Console.WriteLine($"Cantidad de paginas: {cantidadDePag}");
            Console.WriteLine("-----------------------------------");
        }


    }

    internal class Program
    {
        static List<MaterialBibliografico> biblioteca = new List<MaterialBibliografico>();
        static void Main(string[] args)
        {
            string opcion;
            do
            {
                Menu();
                Opciones();
                opcion = Console.ReadLine();
            } while (opcion != "3");
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("=== MENU BIBLIOTECA ===");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Mostrar libros");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opcion: ");
        }

        static void Opciones()
        {
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    {
                        Agregar();
                        break;
                    }
                case "2":
                    {
                        Mostrar();
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Saliendo...");
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Opcion no valida, intente de nuevo");
                        break;
                    }
            }
        }

        static void Agregar()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR LIBRO ===");
            Console.WriteLine("Es un libro fisico o un ebook? (E/L)");
            string tipo = Console.ReadLine().ToUpper();

            if (tipo == "E")
            {
                Console.Write("Ingrese el titulo:  ");
                string titulo = Console.ReadLine();
                Console.Write("Ingrese el autor: ");
                string autor = Console.ReadLine();
                Console.Write("Ingrese el año de publicación: ");
                int anio = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el peso en MB: ");
                double peso = double.Parse(Console.ReadLine());
                biblioteca.Add(new Ebook(anio, autor, titulo, peso));
                Console.WriteLine("Libro ingresado con exito, presione cualquier tecla menos 3 para regresar al menu");
            }
            else if (tipo == "L")
            {
                Console.Write("Ingrese el titulo:  ");
                string titulo = Console.ReadLine();
                Console.Write("Ingrese el autor: ");
                string autor = Console.ReadLine();
                Console.Write("Ingrese el año de publicación: ");
                int anio = int.Parse(Console.ReadLine());
                Console.Write("Ingrese la cantidad de páginas: ");
                int paginas = int.Parse(Console.ReadLine());
                biblioteca.Add(new LibroFisico(anio, autor, titulo, paginas));
                Console.WriteLine("Libro ingresado con exito, presione cualquier tecla menos 3 para regresar al menu");

            }
            else
            {
                Console.WriteLine("Opción inválida, no se agregará el libro.");
                return;
            }
        }

        static void Mostrar()
        {
            Console.Clear();
            Console.WriteLine("=== LIBROS DE LA BIBLIOTECA ===");
            if (biblioteca.Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
            }
            else
            {
                Console.WriteLine("Lista de libros:");
                foreach (var i in biblioteca)
                {

                  i.MostrarDatosLibro();


                }
            }

            Console.WriteLine("Presione cualquier tecla menos 3 para regresar al menu");


        }



    }
}
