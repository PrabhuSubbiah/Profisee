using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedDAL.Abstraction
{
    public interface IMaintainRepo<T>
    {
        T GetById(int id);

        void Create (T obj);

        void Update(T obj);

        void Delete(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetFilteredList(DateTime startDate, DateTime endDate);

    }
}
