﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private Models.ProductsDbContext context;
        public ProductsController(Models.ProductsDbContext context)
        {
            this.context = context;
        }

        // GET: api/Flowers
        [HttpGet]
        public IEnumerable<Models.Product> Get()
        {
            return context.Products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = context.Products.FirstOrDefault(product => product.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            //if (!ModelState.IsValid)
            //{

            //}
            context.Products.Add(product);
            context.SaveChanges();
        }

        // PUT: api/Flowers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var existing = context.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return Ok(product);
            }
            product.Id = id;
            context.Products.Update(product);
            context.SaveChanges();
            return Ok(product);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Products.FirstOrDefault(product => product.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Products.Remove(existing);
            context.SaveChanges();
            return Ok();
        }
    }
}