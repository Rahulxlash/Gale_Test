using AIS_Test.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Test.Data.DataAccess
{
    public interface IDBAccess
    {
        void Create(IBase Item);
        void Edit(IBase Item);
        void Delete(int id);
    }
}
