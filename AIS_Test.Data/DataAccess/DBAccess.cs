using AIS_Test.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Test.Data.DataAccess
{
    public class DBAccess:IDBAccess
    {
        private IFileProvider _provider;
        public DBAccess(IFileProvider fileProvider)
        {
            _provider = fileProvider;
        }
        public void Create(IBase Item)
        {
            var items = this.GetAll();
            List<int> ids = new List<int>();
            ids.Add(0);
            foreach(var item in items)
            {
                if(item!=string.Empty)
                {
                    ids.Add(Convert.ToInt32(item.Split(',')[0]));
                }
            }
            Item.Id = ids.Max() + 1;
            _provider.WriteData(Item);
        }

        public void Edit(IBase Item)
        {
            _provider.UpdateData(Item.Id, Item);
        }

        public void Delete(int id)
        {
            _provider.DeleteData(id);
        }

        public List<string> GetAll()
        {
            var data = _provider.getData();
            return data;
        }


    }
    public enum ModelType
    {
        Student,
        Course,
        CourseStudent
    }
}
