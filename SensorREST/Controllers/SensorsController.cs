using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;

namespace SensorREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private static List<SensorData> objList = new List<SensorData>()
        {
            new SensorData(1, DateTime.Now, 24.0)
        };
        
        [HttpGet]
        public IEnumerable<SensorData> GetAll()
        {
            return objList;
        }
        
        [HttpGet("{id}", Name = "Get")]
        public SensorData GetOne(int id)
        {
            return objList.Find(i => i.ID == id);
        }
        
        [HttpPost]
        public void Post([FromBody] SensorData obj)
        {
            int newKey = objList.Last().ID + 1;
            SensorData newObj = new SensorData(newKey, obj.Time, obj.Temperature);
            objList.Add(newObj);
        }
    }
}
