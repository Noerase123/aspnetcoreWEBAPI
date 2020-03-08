using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.services;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        ProductService _productService;
        public ProductController(ProductService prodServ)
        {
            this._productService = prodServ;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(this._productService.GetProducts());
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            this._productService.AddProduct(product);
            return Ok();
        }
    }
}