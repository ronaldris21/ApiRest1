

namespace ApiRest_1.Repository
{
    using ApiRest_1.Models;
    using System.Collections.Generic;
    public interface ICliente
    {
        //Definicion de metodos

        IEnumerable<Cliente> GetAll();
        Cliente GetByID(int id);
        Cliente Post(Cliente item);
        bool Delete(int i);
        bool Put(int id,Cliente item);



    }
}
