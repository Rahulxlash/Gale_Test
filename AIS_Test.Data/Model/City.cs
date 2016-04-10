using AIS_Test.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Test.Data.Model
{
    public class City: IBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public string StationCode { get; set; }
        public string getData()
        {
            return Id + "," + Name + "," + StateId + "," + StationCode;
        }
        public void setData(string data)
        {
            string[] obj = data.Split(',');
            Id = Convert.ToInt32(obj[0]);
            Name = obj[1];
            StateId = Convert.ToInt32(obj[2]);
            StationCode = obj[3];
        }
    }

    public class CityRepository : DBAccess
    {
        public CityRepository(IFileProvider provider)
            : base(provider)
        {
            
        }
        public new List<City> GetAll()
        {
            List<City> result = new List<City>();
            var list = base.GetAll();
            foreach (var item in list)
            {
                City obj = new City();
                obj.setData(item);
                result.Add(obj);
            }
            return result;
        }

        public City GetById(int id)
        {
            var list = base.GetAll();
            foreach (var item in list)
            {
                City obj = new City();
                obj.setData(item);
                if (obj.Id == id)
                    return obj;
            }
            return null;
        }
    }
}
