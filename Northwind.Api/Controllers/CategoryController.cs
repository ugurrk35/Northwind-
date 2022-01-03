using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Northwind.Entities.Dtos;
using Northwind.Services.Abstract;
using Northwind.Shared.Utilities.Results.Abstract;
using Northwind.Shared.Utilities.Results.ComplexTypes;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Northwind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [HttpGet("get/{categoryId}")]
        public async Task<IActionResult> Get(int categoryId)
        {
            var result = await _categoryServices.Get(categoryId);
            /*  var categories = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
              {
                  ReferenceHandler = ReferenceHandler.Preserve
              });*/

            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            {
            var result=await _categoryServices.GetAll();
          /*  var categories = JsonSerializer.Serialize(result.Data.Categories, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });  */
            return Ok(result.Data.Categories);
            }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {        
           var result = await _categoryServices.Add(categoryAddDto);
         

            return Ok(result);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var result= await _categoryServices.Delete(categoryId);
           
            return Ok(result);
        }

    }
}
