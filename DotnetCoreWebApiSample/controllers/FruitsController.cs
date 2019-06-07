using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fruits.model;
using Microsoft.AspNetCore.Mvc;

namespace Fruits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : Controller
    {

        private FruitsContext db;

        public FruitsController(FruitsContext context)
        {
            this.db = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            var fruits = db.Fruits.ToList();
            return Ok(fruits);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var fruit = db.Fruits.Where(x => x.Id == 1).FirstOrDefault();
            return Ok(fruit);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post(Fruitscls fruits)
        {
            if (ModelState.IsValid)
            {
                Fruitscls fruit = new Fruitscls
                {
                    Name = fruits.Name,
                    Weight = fruits.Weight
                };

                db.Add(fruit);
                db.SaveChanges();
            }
            return Ok("Record is created");
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<string> Put(Fruitscls fruits)
        {
            Fruitscls data = db.Fruits.Where(s => s.Id == fruits.Id).FirstOrDefault();
            data.Name = fruits.Name;
            data.Weight = fruits.Weight;
            db.SaveChanges();
            return Ok("Record is updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var fruit = db.Fruits.FirstOrDefault(m => m.Id == id);
            db.Entry(fruit).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            return Ok("Record is deleted");
        }
    }
}
