using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
        public static void Add()
        {
            ML.Libro libro = new ML.Libro();
            Console.WriteLine("\nNombre del libro:");
            libro.Nombre = Console.ReadLine();

            Console.WriteLine("\nAutor:\t1) M. de Cervantes\t2) G. García Marquez\t3) J. Austen\t4) E. Hemingway\t5) W. Shakespeare");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            Console.WriteLine("\nN° de página:");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("\nFecha de publicación:\tDD-MM-YYYY");
            libro.FechaPublicacion = Console.ReadLine();

            Console.WriteLine("\nEditorial:\t1) Atalanta\t2) Crítica\t3) Siglo XXI\t4) Olañeta\t5) Herder");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEdición:");
            libro.Edicion = Console.ReadLine();

            Console.WriteLine("\nGénero:\t1) Ciencia\t2) Tecnología\t3) Terror\t4) Romance\t5) Aventuras");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Add(libro);

            if (result.Correct)
            {
                Console.WriteLine("\n**** Libro añadido con éxito. ****");
            }
            else
            {
                Console.WriteLine($"\n**** Error: {result.Message}");
            }
        }

        public static void Update()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("\nID del libro:");
            libro.IdLibro = int.Parse(Console.ReadLine());

            Console.WriteLine("\nNombre del libro:");
            libro.Nombre = Console.ReadLine();

            Console.WriteLine("\nAutor:\t1) M. de Cervantes\t2) G. García Marquez\t3) J. Austen\t4) E. Hemingway\t5) W. Shakespeare");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            Console.WriteLine("\nN° de páginas:");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("\nFecha de publicación:\tDD-MM-YYYY");
            libro.FechaPublicacion = Console.ReadLine();

            Console.WriteLine("\nEditorial:\t1) Atalanta\t2) Crítica\t3) Siglo XXI\t4) Olañeta\t5) Herder");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEdición:");
            libro.Edicion = Console.ReadLine();

            Console.WriteLine("\nGénero:\t1) Ciencia\t2) Tecnología\t3) Terror\t4) Romance\t5) Aventuras");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Update(libro);

            if (result.Correct)
            {
                Console.WriteLine("\n**** Libro modificado con éxito. ****");
            }
            else
            {
                Console.WriteLine($"\n**** Error: {result.Message}");
            }
        }

        public static void Delete()
        {
            Console.WriteLine("\nID del libro:");
            int idLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Delete(idLibro);

            if (result.Correct)
            {
                Console.WriteLine("\n**** Libro eliminado con éxito. ****");
            }
            else
            {
                Console.WriteLine($"\n**** Error: {result.Message}");
            }
        }

        public static void GetAll()
        {
            ML.Result result = BL.Libro.GetAll();

            if (result.Correct)
            {
                foreach (ML.Libro libro in result.Objects)
                {
                    Console.WriteLine("====================================");
                    Console.WriteLine($"ID:\t{libro.IdLibro}");
                    Console.WriteLine($"Nombre:\t{libro.Nombre}");
                    Console.WriteLine($"Autor:\t{libro.Autor.Nombre}");
                    Console.WriteLine($"N° de páginas:\t{libro.NumeroPaginas}");
                    Console.WriteLine($"Fecha de publicación:\t{libro.FechaPublicacion}");
                    Console.WriteLine($"Editorial:\t{libro.Editorial.Nombre}");
                    Console.WriteLine($"Edición:\t{libro.Edicion}");
                    Console.WriteLine($"Género:\t{libro.Genero.Nombre}");
                }
            }
            else
            {
                Console.WriteLine($"\n**** Error: {result.Message}");
            }
        }

        public static void GetById()
        {
            Console.WriteLine("\nID del libro:");
            int idLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.GetById(idLibro);

            if (result.Correct)
            {
                ML.Libro libro = (ML.Libro)result.Object;

                Console.WriteLine("====================================");
                Console.WriteLine($"ID:\t{libro.IdLibro}");
                Console.WriteLine($"Nombre:\t{libro.Nombre}");
                Console.WriteLine($"Autor:\t{libro.Autor.Nombre}");
                Console.WriteLine($"N° de páginas:\t{libro.NumeroPaginas}");
                Console.WriteLine($"Fecha de publicación:\t{libro.FechaPublicacion}");
                Console.WriteLine($"Editorial:\t{libro.Editorial.Nombre}");
                Console.WriteLine($"Edición:\t{libro.Edicion}");
                Console.WriteLine($"Género:\t{libro.Genero.Nombre}");
            }
            else
            {
                Console.WriteLine($"\n**** Error: {result.Message}");
            }
        }
    }
}
