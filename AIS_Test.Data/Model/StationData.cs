using AIS_Test.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Test.Data.Model
{
    public class StationData:IBase
    {
        public int Id { get; set; }
        public string StationCode { get; set; }
        public DateTime Date { get; set; }
        public decimal PredictedSpeed { get; set; }
        public decimal ActualSpeed { get; set; }
        
        public string getData()
        {
            return Id + "," + StationCode + "," + Date.ToShortDateString() + "," + PredictedSpeed + "," + ActualSpeed;
        }
        public void setData(string data)
        {
            string[] obj = data.Split(',');
            Id = Convert.ToInt32(obj[0]);
            StationCode = obj[1];
            Date = Convert.ToDateTime(obj[2]).Date;
            PredictedSpeed = Convert.ToInt32(obj[3]);
            ActualSpeed = Convert.ToInt32(obj[4]);
        }
    }

    public class StationDataRepository : DBAccess
    {
        public StationDataRepository(IFileProvider provider)
            : base(provider)
        {

        }
        public new List<StationData> GetAll()
        {
            List<StationData> result = new List<StationData>();
            var list = base.GetAll();
            foreach (var item in list)
            {
                StationData obj = new StationData();
                obj.setData(item);
                result.Add(obj);
            }
            return result;
        }

        public StationData GetById(int id)
        {
            var list = base.GetAll();
            foreach (var item in list)
            {
                StationData obj = new StationData();
                obj.setData(item);
                if (obj.Id == id)
                    return obj;
            }
            return null;
        }
    }
}
