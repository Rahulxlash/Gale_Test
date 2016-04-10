using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Test.Data.Model
{
    public interface IBase
    {
        int Id { get; set; }
        string getData();
        void setData(string data);
    }
}
