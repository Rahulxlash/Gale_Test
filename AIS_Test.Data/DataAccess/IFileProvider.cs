using AIS_Test.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Test.Data.DataAccess
{
    public interface IFileProvider
    {
        void WriteData(IBase obj);
        void UpdateData(int id, IBase obj);
        void DeleteData(int id);
        List<string> getData();
    }
}
