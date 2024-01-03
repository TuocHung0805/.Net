using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ProductsController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1, int pageSize = 10)
        {
            try
            {
                var totalProducts = _context.Products.Count();
                var totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);

                var ProductList = _context.Products
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var result = new
                {
                    TotalPages = totalPages,
                    CurrentPage = page,
                    PageSize = pageSize,
                    Products = ProductList
                };

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                var _product = new Product
                {
                    MaSP= Guid.NewGuid(),
                    TenSP = product.TenSP,
                    DungLuong = product.DungLuong,
                    MauSac = product.MauSac,
                    Gia = product.Gia,
                };
                _context.Add(_product);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:guid}", Name = "GetProductById")]
        public IActionResult GetById(string id)
        {
            var product = _context.Products.SingleOrDefault(p => p.MaSP == Guid.Parse(id));
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            var product = _context.Products.SingleOrDefault(p =>p.MaSP == Guid.Parse(id));
            if(product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(string id, Product product)
        {
            var _product = _context.Products.SingleOrDefault(p => p.MaSP == Guid.Parse(id));
            if(_product == null)
            {
                return NotFound();
            }
            _product.TenSP = product.TenSP;
            _product.MauSac = product.MauSac;
            _product.DungLuong = product.DungLuong;
            _product.Gia = product.Gia;
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{name}", Name = "GetProductByName")]
        public IActionResult GetByName(string name)
        {
            var product = _context.Products.SingleOrDefault(p => p.TenSP == name);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}

