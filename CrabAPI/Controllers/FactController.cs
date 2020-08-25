using CrabFactsLibrary.Models;
using CrabFactsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrabAPI.Controllers
{
    public class FactController : ApiController
    {
        private readonly List<Fact> _facts;
        private readonly Random _rand = new Random();
        public FactController(ISqliteDataAccess repo)
        {
            _facts = repo.LoadFacts();
        }
        // GET api/values
        public IEnumerable<Fact> Get()
        {
            return _facts;
        }
        
        [Route("api/Fact/Random")]
        [HttpGet]
        public Fact RandomFact()
        {
            try { 
                var index = _rand.Next(_facts.Count);
                return _facts[index];
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Facts table is empty");
                return new Fact() {description = "There are no facts - everything is subjective!" };
            }

        }
        
        // GET api/values/5
        public Fact Get(int id)
        {
            return _facts.FirstOrDefault(x => x.id == id);
        }

        //[Route("api/Fact/GetOfType/{type:string}")]
        //public Fact GetOfType(string crab)
        //{
        //    return facts.Where(x => x.id == id).FirstOrDefault();
        //}

        // POST api/values
        public void Post(Fact fact)
        {
            //validation
            _facts.Add(fact);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
