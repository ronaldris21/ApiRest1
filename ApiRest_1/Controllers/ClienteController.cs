using ApiRest_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRest_1.Controllers
{
    public class ClienteController : ApiController
    {
        //Objeto solo de lectura para acceder al repositorio
        static readonly Repository.ICliente c = new Repository.RCliente();

        //Metodo post
        
        public HttpResponseMessage Post(Cliente item) //No confundir con HttpRequestMessage
        {
            item = c.Post(item);
            if (item==null)
            {
                //Contruyendo respuesta del servidor
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Los datos del cliente no pueden ser nulos");
            }
            return Request.CreateResponse(HttpStatusCode.Created,item);
        }

        //Metodo GET

        public HttpResponseMessage GetAll() //No confundir con HttpRequestMessage
        {
            var items = c.GetAll();
            if (items == null)
            {
                //Contruyendo respuesta del servidor
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nula, no hay registros en la base de datos sobre cliente");
            }
            return Request.CreateResponse(HttpStatusCode.OK, items);
        }

        public HttpResponseMessage GetByID(int id) //No confundir con HttpRequestMessage
        {
            var item = c.GetByID(id);
            if (item == null)
            {
                //Contruyendo respuesta del servidor
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay registros en la base de datos sobre cliente "+id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        public HttpResponseMessage Delete(int id) //No confundir con HttpRequestMessage
        {
            var item = c.GetByID(id);
            if (item == null)
            {
                //Contruyendo respuesta del servidor
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay registro con ID: " + id);
            }
            var isDelete = c.Delete(id);
            if (!isDelete)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotModified, "No se pudo eliminar");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Registro eliminado");
        }

        public HttpResponseMessage Put(int id, Cliente nuevoCliente) //No confundir con HttpRequestMessage
        {
            var item = c.GetByID(id);
            if (item == null)
            {
                //Contruyendo respuesta del servidor
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay registro con ID: " + id+" Para actualizar");
            }

            var isPut = c.Put(id, nuevoCliente);
            if (!isPut)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotModified, "No fue posible la actualización");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Registro actualizado");
        }

    }
}
