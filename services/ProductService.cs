using System.Collections.Generic;
using RestApi.Models;

namespace RestApi.services
{
    public class ProductService
    {
        List<Product> _productList = null;
        public ProductService() 
        {
            _productList = new List<Product>();
        }

        public List<Product> GetProducts()
        {
            return _productList;
        }

        public void AddProduct(Product product)
        {
            _productList.Add(product);
        }
    }
}