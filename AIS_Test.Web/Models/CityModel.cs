using AIS_Test.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIS_Test.Web.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public string StationCode { get; set; }
        public State State { get; set; }
    }
}