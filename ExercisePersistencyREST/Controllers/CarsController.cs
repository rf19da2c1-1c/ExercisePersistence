using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExercisePersistenceLib.model;
using ExercisePersistencyREST.DBUtil;

namespace ExercisePersistencyREST.Controllers
{
    public class CarsController : ApiController
    {
        private static readonly ManageCar mgr = new ManageCar();

        // GET: api/Cars
        public IEnumerable<Car> Get()
        {
            return mgr.GetAll();
        }

        // GET: api/Cars/5
        public Car Get(int id)
        {
            return mgr.GetOne(id);
        }

        // POST: api/Cars
        public bool Post([FromBody]Car car)
        {
            return mgr.CreateOne(car);
        }

        // PUT: api/Cars/5
        public bool Put(int id, [FromBody]Car car)
        {
            return mgr.UpdateOne(id,car);
        }

        // DELETE: api/Cars/5
        public Car Delete(int id)
        {
            return mgr.DeleteOne(id);
        }
    }
}
