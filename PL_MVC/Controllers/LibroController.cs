using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Libro.GetAllEF();

            return View(result);
        }

        [HttpGet]
        public ActionResult Form (int? idLibro)
        {
            ML.Libro libro = new ML.Libro();

            ML.Result resultAutor = BL.Autor.GetAllEF();
            ML.Result resultEditorial = BL.Editorial.GetAllEF();
            ML.Result resultGenero = BL.Genero.GetAllEF();

            if (idLibro == null)
            {
                libro.Autor = new ML.Autor();
                libro.Editorial = new ML.Editorial();
                libro.Genero = new ML.Genero();

                libro.NumeroPaginas = 1;
            }
            else
            {
                ML.Result result = BL.Libro.GetByIdEF(idLibro.Value);

                if (result.Correct)
                {
                    libro = (ML.Libro)result.Object;
                }
                else
                {
                    ViewBag.Message = $"Error: {result.Message}";
                }
            }

            libro.Autor.Autores = resultAutor.Objects;
            libro.Editorial.Editoriales = resultEditorial.Objects;
            libro.Genero.Generos = resultGenero.Objects;

            return View(libro);
        }

        [HttpPost]
        public ActionResult Form (ML.Libro libro)
        {
            if (libro.IdLibro == 0)
            {
                ML.Result result = BL.Libro.AddEF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = "Libro agregado con éxito.";
                }
                else
                {
                    ViewBag.Message = $"Error: {result.Message}";
                }
            }
            else
            {
                ML.Result result = BL.Libro.UpdateEF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = "Libro modificado con éxito.";
                }
                else
                {
                    ViewBag.Message = $"Error: {result.Message}";
                }
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int? idLibro)
        {
            if (idLibro==null)
            {
                ViewBag.Message = "Error al intentar encontrar al usuario.";
            }
            else
            {
                ML.Result result = BL.Libro.DeleteEF(idLibro.Value);

                if (result.Correct)
                {
                    ViewBag.Message = "Libro eliminado con éxito.";
                }
                else
                {
                    ViewBag.Message = $"Error: {result.Message}";
                }
            }

            return PartialView("Modal");
        }
    }
}