using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiRest_1.Models;

namespace ApiRest_1.Repository
{
    public class RCliente : ICliente
    {
        //OBJETO DE TIPO MODEL1 para acceder a la base de datos
        private Model1 conn = new Model1();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool Delete(int i)
        {
            var item = conn.Cliente.Find(i);
            if (item==null)
            {
                return false;
            }
            conn.Cliente.Remove(item);
            conn.SaveChanges();
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cliente> GetAll()
        {
            //Vamos a crear una conexión unica en cada GET
            //Con la siguiente linea bastaría
            //return conn.Cliente.ToList();


            //Pero hacerlo así
            using (var db = new Model1())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Cliente.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cliente GetByID(int id)
        {
            using (var db = new Model1())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Cliente.Find(id);
            }
        }

        public Cliente Post(Cliente item)
        {
            if (item==null)
            {
                return null;
            }
            conn.Cliente.Add(item);
            conn.SaveChanges();
            return item;
        }

        public bool Put(int id, Cliente item)
        {
            var oldClient = conn.Cliente.Find(id);
            if (oldClient==null)
            {
                return false;
            }

            oldClient.direccion = item.direccion;
            oldClient.edad = item.edad;
            oldClient.nombre = item.nombre;

            //Modifico el estado en la base de datos y guardo cambios
            conn.Entry(oldClient).State = System.Data.Entity.EntityState.Modified;
            conn.SaveChanges();
            return true;

        }
    }
}