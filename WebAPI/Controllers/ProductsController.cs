using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Extensions;
using Core.Others.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        private IHeader _header;
    //   private IUserService _userService;
        private IAuthService _authService;
        public ProductsController(IProductService productService, IHeader header/*, IUserService userService*/, IAuthService authService)
        {
            _productService = productService;
            _header = header;
            _authService = authService;
            //_userService = userService;
        }

        [HttpGet("getall")]
       // [Authorize(Roles = "Product.List")]
        public IActionResult GetList()
        {
           /* var aa = _userService.GetUserNameByToken(HttpContext);
           // return Ok("a");
           // var result = _header.GetToken(HttpContext);
            if (!aa.Success)
            {
                return BadRequest(aa);
            }*/
            return Ok("aa");
           /* var request = HttpContext.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader == "")
                return BadRequest("token yok");
            return Ok(authHeader);*/
            /*  var result = _productService.GetList();
              if (result.Success)
              {
                  return Ok(result);
              }

              return BadRequest(result.Message);*/
        }
     
        [HttpGet("getlistbycategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

     /*   [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("transaction")]
        public IActionResult TransactionTest(Product product)
        {
            var result = _productService.TransactionalOperation(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
     */
    }
}