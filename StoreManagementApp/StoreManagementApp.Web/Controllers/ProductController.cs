using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreManagementApp.BLL.Interface;
using StoreManagementApp.DTO;
using StoreManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManagementApp.Controllers
{

    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductBLL _productBLL;
        private readonly IMapper _mapper;
        public ProductController(IProductBLL producBLL, IMapper mapper)
        {
            _productBLL = producBLL;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getProducts")]
        public async Task<IActionResult> GetProducts()
        {
            List<ProductDTO> productDTOs;
            try
            {
                List<Product> products = await _productBLL.GetProducts();
                productDTOs = _mapper.Map<List<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(productDTOs);
        }


        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            ProductDTO productDTOResponse;
            try
            {
                Product product = _mapper.Map<Product>(productDTO);
                var response = await _productBLL.AddProduct(product);
                productDTOResponse = _mapper.Map<ProductDTO>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(productDTOResponse);
        }


        [HttpPut]
        [Route("editProduct")]
        public async Task<IActionResult> EditAsset([FromBody] ProductDTO productDTO)
        {
            ProductDTO productDTOResponse;

            try
            {
                Product product = _mapper.Map<Product>(productDTO);
                var response = await _productBLL.EditProduct(product);
                productDTOResponse = _mapper.Map<ProductDTO>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return base.Ok(productDTOResponse);
        }

        [HttpPut]
        [Route("deleteProduct")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            ProductDTO productDTOResponse;

            try
            {
                var response = await _productBLL.DeleteProduct(productId);
                productDTOResponse = _mapper.Map<ProductDTO>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return base.Ok(productDTOResponse);
        }

    }
}
