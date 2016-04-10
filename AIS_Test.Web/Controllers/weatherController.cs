using AIS_Test.Data.DataAccess;
using AIS_Test.Data.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AIS_Test.Web.Controllers
{
    public class weatherController : ApiController
    {

        private StationDataRepository repo;
        private IFileProvider _provider;

        public weatherController()
        {
            string file = ConfigurationManager.AppSettings["StationDataFile"];
            string source = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
            _provider = new TextFileProvider(source + "/" + file);
            repo = new StationDataRepository(_provider);
        }

        public IHttpActionResult Get()
        {
            var result = repo.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Post(StationData obj)
        {
            var data = repo.GetAll();
            if(data.Any(x=> x.StationCode == obj.StationCode && x.Date.ToShortDateString() == obj.Date.ToShortDateString()))
            {
                var old = data.Where(x => x.StationCode == obj.StationCode && x.Date.ToShortDateString() == obj.Date.ToShortDateString()).FirstOrDefault();
                obj.Id = old.Id;
                repo.Edit(obj);
            }
            else
            {
                repo.Create(obj);
            }
            
            return Ok();
        }

    }
}
