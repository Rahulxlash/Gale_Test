using AIS_Test.Data.DataAccess;
using AIS_Test.Data.Model;
using AIS_Test.Web.Models;
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
    public class CityController : ApiController
    {
        private CityRepository repo;
        private StateRepository stateRepo;
        private IFileProvider _stateProvider;
        private IFileProvider _provider;
        public CityController()
        {
            string file = ConfigurationManager.AppSettings["cityFile"];
            string source = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
            _provider = new TextFileProvider(source + "/" + file);
            _stateProvider = new TextFileProvider(source + "/" + ConfigurationManager.AppSettings["stateFile"]);
            repo = new CityRepository(_provider);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            stateRepo = new StateRepository(_stateProvider);
            var states = stateRepo.GetAll();
            var cities = repo.GetAll();
            List<CityModel> result = new List<CityModel>();
            foreach (City city in cities)
            {
                result.Add(new CityModel()
                {
                    Id = city.Id,
                    Name = city.Name,
                    State = stateRepo.GetById(city.StateId),
                    StateId = city.StateId,
                    StationCode = city.StationCode
                });
            }
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = repo.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Post(City obj)
        {
            repo.Create(obj);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(City obj)
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
