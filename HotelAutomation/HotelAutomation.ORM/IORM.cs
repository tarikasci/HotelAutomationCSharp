using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM
{
    public interface IORM<T> where T : class
    {
        DataTable Select();
        bool Insert(T entity);
        object InsertScalar(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
