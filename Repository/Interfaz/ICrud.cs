using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaz
{
    public interface ICrud<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T input);
        T Update(T input);
        int Delete(int id);
    }
}
