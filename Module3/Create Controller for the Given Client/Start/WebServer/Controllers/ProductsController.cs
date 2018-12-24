using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers {
    [Route("api/[controller]")]
    public class ProductsController : Controller {
        //Actions

        [HttpGet]
        public ActionResult Get() {
            if(FakeData.Products !=null) {
                return Ok(FakeData.Products.Values.ToArray());
            } else {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id) {
            if(FakeData.Products.ContainsKey(id))
                return Ok(FakeData.Products[id]);
            else
                return NotFound();
        }

        [HttpGet("price/{from}/{to}")]
        public ActionResult Get(int from, int to){
            var products = FakeData.Products.Values
            .Where(p => p.Price >= from && p.Price <= to).ToArray();
            if(products.Length > 0){
                return Ok(products);
            } else {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            if (FakeData.Products.ContainsKey(id)) {
                FakeData.Products.Remove(id);
                return Ok();
            } else {
                return NotFound();
            }
        }

        [HttpPost]

        public ActionResult Post([FromBody]Product product){
            product.ID = FakeData.Products.Keys.Max() + 1;
            FakeData.Products.Add(product.ID, product);
            return Created($"api/products/{product.ID}", product);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            if (FakeData.Products.ContainsKey(id)) {
                var target = FakeData.Products[id];
                target.ID = product.ID;
                target.Name = product.Name;
                target.Price = product.Price;
                return Ok();
            }
            else {
                return NotFound();
            }
        }

        [HttpPut("raise/{price}")]
        public ActionResult Put(int price)
        {
            var products = FakeData.Products.Values.ToArray();
            for(int productscount = 0; productscount < products.Length; productscount++){
                FakeData.Products[productscount].Price = (FakeData.Products[productscount].Price * price);
            }
            return Ok();       
        }

    }
}