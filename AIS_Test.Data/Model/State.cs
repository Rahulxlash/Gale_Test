using AIS_Test.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Test.Data.Model
{
    public class State: IBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string getData()
        {
            return Id + "," + Name;
        }
        public void setData(string data)
        {
            string[] obj = data.Split(',');
            Id = Convert.ToInt32(obj[0]);
            Name = obj[1];
        }
    }

    public class StateRepository:DBAccess
    {
        public StateRepository(IFileProvider provider)
            : base(provider)
        {
            
        }
        public new List<State> GetAll()
        {
            List<State> result = new List<State>();
            var list = base.GetAll();
            foreach(var item in list)
            {
                State obj = new State();
                obj.setData(item);
                result.Add(obj);
            }
            return result;
        }

        public State GetById(int id)
        {
            var list = base.GetAll();
            foreach (var item in list)
            {
                State obj = new State();
                obj.setData(item);
                if(obj.Id == id)
                return obj;
            }
            return null;
        }

        public List<City> Cities(int StateId, CityRepository cityRepo)
        {
            return cityRepo.GetAll().Where(x => x.StateId == StateId).ToList();
        }
    }
}
