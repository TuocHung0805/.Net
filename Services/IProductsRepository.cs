using Store.Models;
using System;
using System.Collections.Generic;

namespace Store.Services
{
    public interface IProductsRepository
    {
        List<ProductVM> GetAll(int page, int pagesize);
        ProductVM GetByID(string id);
        ProductVM GetByName (string name);
        ProductVM CreateNew (ProductVM product);
        void UpdateByID (Product product);
        void DeleteByID (string id);
    }
}
