using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using FluentValidation;
using Store.Services;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IValidator<ProductVM> _productValidator;
        private readonly ProductRepository _productRepository;

        public ProductsController(MyDBContext context, IValidator<ProductVM> productValidator, ProductRepository productRepository)
        {
            _context = context;
            _productValidator = productValidator;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1, int pageSize = 10)
        {
            try
            {
                var data =_productRepository.GetAll(page, pageSize);
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(ProductVM product)
        {
            try
            {
                ValidationResult validationResult = _productValidator.Validate(product);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                return Ok(_productRepository.CreateNew(product));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:guid}", Name = "GetProductById")]
        public IActionResult GetById(string id)
        {
            try
            {
                var data = _productRepository.GetByID(id);
                if(data != null)
                {
                    return Ok(data);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            try
            {
                _productRepository.DeleteByID(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(string id, Models.Product product)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                _productRepository.UpdateByID(product);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{name}", Name = "GetProductByName")]
        public IActionResult GetByName(string name)
        {
            try
            {
                var data = _productRepository.GetByName(name);
                if (data != null)
                {
                    return Ok(data);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

