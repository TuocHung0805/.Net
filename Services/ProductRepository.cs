using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Services
{
    public class ProductRepository : IProductsRepository
    {
        private readonly MyDBContext _context;

        public ProductRepository(MyDBContext context)
        {
            _context = context;
        }

        public ProductVM CreateNew(ProductVM product)
        {
            var _product = new Data.Product
            {
                TenSP = product.TenSP,
                MauSac = product.MauSac,
                DungLuong = product.DungLuong,
                Gia = product.Gia
            };
            _context.Products.Add(_product);
            _context.SaveChanges();

            return new ProductVM
            {
                TenSP = product.TenSP,
                MauSac = product.MauSac,
                DungLuong = product.DungLuong,
                Gia = product.Gia
            };
        }

        public void DeleteByID(string id)
        {
            var product = _context.Products.SingleOrDefault(p => p.MaSP == Guid.Parse(id));
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<ProductVM> GetAll(int page, int pageSize)
        {
            var totalProducts = _context.Products.Count();
            var totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
            var ProductList = _context.Products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var productList = _context.Products.Select(p => new ProductVM
            {
                TenSP = p.TenSP,
                MauSac = p.MauSac,
                DungLuong = p.DungLuong,
                Gia = p.Gia
            });
            return productList.ToList();
        }

        public ProductVM GetByID(string id)
        {
            var product = _context.Products.SingleOrDefault(p => p.MaSP == Guid.Parse(id));
            if (product == null)
            {
                return null;
            }
            return new ProductVM
            {
                TenSP = product.TenSP,
                MauSac = product.MauSac,
                DungLuong = product.DungLuong,
                Gia = product.Gia
            };
        }

        public ProductVM GetByName(string name)
        {
            var product = _context.Products.SingleOrDefault(p => p.TenSP == name);
            if (product == null)
            {
                return null;
            }
            return new ProductVM
            {
                TenSP = product.TenSP,
                MauSac = product.MauSac,
                DungLuong = product.DungLuong,
                Gia = product.Gia
            };
        }

        public void UpdateByID(Models.Product product)
        {
            var _product = _context.Products.SingleOrDefault(p => p.MaSP == product.MaSP);
            if (_product != null) 
            {
                _product.TenSP = product.TenSP;
                _product.MauSac= product.MauSac;
                _product.DungLuong= product.DungLuong;
                _product.Gia = product.Gia;
                _context.SaveChanges();
            }
        }
    }
}
