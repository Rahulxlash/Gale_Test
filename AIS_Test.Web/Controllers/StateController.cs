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
    public class StateController : ApiController
    {
        private StateRepository repo;
        private IFileProvider _provider;
        IFileProvider _cityProvider ;
        CityRepository cityRepo;
        public StateController()
        {
            string file = ConfigurationManager.AppSettings["stateFile"];
            string source = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
            _provider = new TextFileProvider(source + "/" + file);
            repo = new StateRepository(_provider);
            _cityProvider = new TextFileProvider(source + "/" + ConfigurationManager.AppSettings["cityFile"]);
            cityRepo = new CityRepository(_cityProvider);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = repo.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = repo.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult City(int id)
        {
            return Ok(repo.Cities(id, cityRepo));
        }

        [HttpPost]
        public IHttpActionResult Post(State obj)
        {
            repo.Create(obj);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(State obj)
        {
            repo.Edit(obj);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repo.Delete(id);
            return Ok();
        }
    }
}
