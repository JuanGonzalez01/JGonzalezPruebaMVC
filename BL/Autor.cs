using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JGonzalezPruebaMVCEntities1 context = new DL.JGonzalezPruebaMVCEntities1())
                {
                    var query = context.AutorGetAll().ToList();

                    if (query.Count >= 1)
                    {
                        result.Objects = new List<object>();

                        foreach (var fila in query)
                        {
                            ML.Autor autor = new ML.Autor();

                            autor.IdAutor = fila.IdAutor;
                            autor.Nombre = fila.Nombre;

                            result.Objects.Add(autor);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros.";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
