using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Genero
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JGonzalezPruebaMVCEntities1 context = new DL.JGonzalezPruebaMVCEntities1())
                {
                    var query = context.GeneroGetAll().ToList();

                    if (query.Count >= 1)
                    {
                        result.Objects = new List<object>();

                        foreach (var fila in query)
                        {
                            ML.Genero genero = new ML.Genero();

                            genero.IdGenero = fila.IdGenero;
                            genero.Nombre = fila.Nombre;

                            result.Objects.Add(genero);
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
