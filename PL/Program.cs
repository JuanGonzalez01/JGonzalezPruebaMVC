using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            do
            {
                Console.WriteLine("======== CRUD Libro =========");
                Console.WriteLine("Seleccione la opción deseada:\n1) Añadir\n2) Actualizar\n3) Mostrar registro\n4) Mostrar todos\n5) Eliminar");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Libro.Add();
                        break;
                    case 2:
                        Libro.Update();
                        break;
                    case 3:
                        Libro.GetById();
                        break;
                    case 4:
                        Libro.GetAll();
                        break;
                    case 5:
                        Libro.Delete();
                        break;
                }

                Console.WriteLine("\n¿Deseas regresar al menú?\n1) Si\nOtra) No");
            } while (int.Parse(Console.ReadLine())==1);
        }
    }
}
