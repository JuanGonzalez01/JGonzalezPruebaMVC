using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add (ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnectionString()))
                {
                    string query = "LibroAdd";

                    context.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText= query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] parametros = new SqlParameter[7];

                        parametros[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        parametros[0].Value = libro.Nombre;

                        parametros[1] = new SqlParameter("IdAutor", System.Data.SqlDbType.Int);
                        parametros[1].Value = libro.Autor.IdAutor;

                        parametros[2] = new SqlParameter("NumeroPaginas", System.Data.SqlDbType.Int);
                        parametros[2].Value = libro.NumeroPaginas;

                        parametros[3] = new SqlParameter("FechaPublicacion", System.Data.SqlDbType.VarChar);
                        parametros[3].Value = libro.FechaPublicacion;

                        parametros[4] = new SqlParameter("IdEditorial", System.Data.SqlDbType.Int);
                        parametros[4].Value = libro.Editorial.IdEditorial;

                        parametros[5] = new SqlParameter("Edicion", System.Data.SqlDbType.VarChar);
                        parametros[5].Value = libro.Edicion;

                        parametros[6] = new SqlParameter("IdGenero", System.Data.SqlDbType.Int);
                        parametros[6].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(parametros);

                        var rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >=1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se agregaron registros.";
                        }
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

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnectionString()))
                {
                    string query = "LibroUpdate";

                    context.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] parametros = new SqlParameter[8];

                        parametros[0] = new SqlParameter("IdLibro", System.Data.SqlDbType.Int);
                        parametros[0].Value = libro.IdLibro;

                        parametros[1] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        parametros[1].Value = libro.Nombre;

                        parametros[2] = new SqlParameter("IdAutor", System.Data.SqlDbType.Int);
                        parametros[2].Value = libro.Autor.IdAutor;

                        parametros[3] = new SqlParameter("NumeroPaginas", System.Data.SqlDbType.Int);
                        parametros[3].Value = libro.NumeroPaginas;

                        parametros[4] = new SqlParameter("FechaPublicacion", System.Data.SqlDbType.VarChar);
                        parametros[4].Value = libro.FechaPublicacion;

                        parametros[5] = new SqlParameter("IdEditorial", System.Data.SqlDbType.Int);
                        parametros[5].Value = libro.Editorial.IdEditorial;

                        parametros[6] = new SqlParameter("Edicion", System.Data.SqlDbType.VarChar);
                        parametros[6].Value = libro.Edicion;

                        parametros[7] = new SqlParameter("IdGenero", System.Data.SqlDbType.Int);
                        parametros[7].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(parametros);

                        var rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se modificaron registros.";
                        }
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

        public static ML.Result Delete(int idLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnectionString()))
                {
                    string query = "LibroDelete";

                    context.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parametro = new SqlParameter("IdLibro", System.Data.SqlDbType.Int);
                        parametro.Value = idLibro;

                        cmd.Parameters.Add(parametro);

                        var rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se eliminaron registros.";
                        }
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnectionString()))
                {
                    string query = "LibroGetAll";

                    context.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        DataTable tablaLibro = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaLibro);

                        if (tablaLibro.Rows.Count >= 1)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow fila in tablaLibro.Rows)
                            {
                                ML.Libro libro = new ML.Libro();

                                libro.IdLibro = (int)fila[0];
                                libro.Nombre = fila[1].ToString();
                                
                                libro.Autor = new ML.Autor();
                                libro.Autor.IdAutor = (int)fila[2];
                                libro.Autor.Nombre = fila[3].ToString();

                                libro.NumeroPaginas = (int)fila[4];
                                libro.FechaPublicacion = fila[5].ToString();

                                libro.Editorial = new ML.Editorial();
                                libro.Editorial.IdEditorial = (int)fila[6];
                                libro.Editorial.Nombre = fila[7].ToString();

                                libro.Edicion = fila[8].ToString();

                                libro.Genero = new ML.Genero();
                                libro.Genero.IdGenero = (int)fila[9];
                                libro.Genero.Nombre = fila[10].ToString();

                                result.Objects.Add(libro);
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
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public static ML.Result GetById(int idLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnectionString()))
                {
                    string query = "LibroGetById";

                    context.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter para = new SqlParameter("IdLibro", SqlDbType.Int);
                        para.Value = idLibro;
                        cmd.Parameters.Add(para);

                        DataTable tablaLibro = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaLibro);

                        if (tablaLibro.Rows.Count >= 1)
                        {
                            DataRow fila = tablaLibro.Rows[0];

                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = (int)fila[0];
                            libro.Nombre = fila[1].ToString();

                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = (int)fila[2];
                            libro.Autor.Nombre = fila[3].ToString();

                            libro.NumeroPaginas = (int)fila[4];
                            libro.FechaPublicacion = fila[5].ToString();

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = (int)fila[6];
                            libro.Editorial.Nombre = fila[7].ToString();

                            libro.Edicion = fila[8].ToString();

                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = (int)fila[9];
                            libro.Genero.Nombre = fila[10].ToString();

                            result.Object = libro;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se encontraron registros.";
                        }
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

    //------------------------ Entity Framework ---------------------------
        
        public static ML.Result AddEF (ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JGonzalezPruebaMVCEntities1 context = new DL.JGonzalezPruebaMVCEntities1())
                {
                    var query = context.LibroAdd(libro.Nombre, libro.Autor.IdAutor, libro.NumeroPaginas, libro.FechaPublicacion, libro.Editorial.IdEditorial, libro.Edicion, libro.Genero.IdGenero);

                    if (query >= 1)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se agregaron registros.";
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

        public static ML.Result UpdateEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JGonzalezPruebaMVCEntities1 context = new DL.JGonzalezPruebaMVCEntities1())
                {
                    var query = context.LibroUpdate(libro.IdLibro, libro.Nombre, libro.Autor.IdAutor, libro.NumeroPaginas, libro.FechaPublicacion, libro.Editorial.IdEditorial, libro.Edicion, libro.Genero.IdGenero);

                    if (query >= 1)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se modificaron registros.";
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

        public static ML.Result DeleteEF(int idLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JGonzalezPruebaMVCEntities1 context = new DL.JGonzalezPruebaMVCEntities1())
                {
                    var query = context.LibroDelete(idLibro);

                    if (query >= 1)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se eliminaron registros.";
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

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JGonzalezPruebaMVCEntities1 context = new DL.JGonzalezPruebaMVCEntities1())
                {
                    var query = context.LibroGetAll().ToList();

                    if (query.Count>=1)
                    {
                        result.Objects = new List<object>();

                        foreach (var fila in query)
                        {
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = fila.IdLibro;
                            libro.Nombre = fila.Nombre;

                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = fila.IdAutor.Value;
                            libro.Autor.Nombre = fila.AutorNombre;

                            libro.NumeroPaginas = fila.NumeroPaginas.Value;
                            libro.FechaPublicacion = fila.FechaPublicacion.Value.ToString("dd-MM-yyyy");

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = fila.IdEditorial.Value;
                            libro.Editorial.Nombre = fila.EditorialNombre;

                            libro.Edicion = fila.Edicion;

                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = fila.IdGenero.Value;
                            libro.Genero.Nombre = fila.GeneroNombre;

                            result.Objects.Add(libro);
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

        public static ML.Result GetByIdEF(int idLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JGonzalezPruebaMVCEntities1 context = new DL.JGonzalezPruebaMVCEntities1())
                {
                    var query = context.LibroGetById(idLibro).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Libro libro = new ML.Libro();

                        libro.IdLibro = query.IdLibro;
                        libro.Nombre = query.Nombre;

                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = query.IdAutor.Value;
                        libro.Autor.Nombre = query.AutorNombre;

                        libro.NumeroPaginas = query.NumeroPaginas.Value;
                        libro.FechaPublicacion = query.FechaPublicacion.Value.ToString("dd-MM-yyyy");

                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = query.IdEditorial.Value;
                        libro.Editorial.Nombre = query.EditorialNombre;

                        libro.Edicion = query.Edicion;

                        libro.Genero = new ML.Genero();
                        libro.Genero.IdGenero = query.IdGenero.Value;
                        libro.Genero.Nombre = query.GeneroNombre;

                        result.Object = libro;
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
