using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectArchitecture.Application.DTOs;
using ProjectArchitecture.Application.Interfaces;
using ProjectArchitecture.Application.Requests;
using ProjectArchitecture.Domain.Entities;
using System.Net.Mime;

namespace ProjectArchitecture.WebApi.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /* Conferir se o [ProducesResponseType(StatusCodes.Status200OK)] consegue inferir que é uma lista
         * Pois estou utilizando o IEnumerable que é uma interface. 
         * Para fazer a inferencia de tipo deveria haver um tipo concreto ao inves de uma interface
         */
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById([FromRoute] int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if(category == null)
                return NotFound($"Category with id {id} not found.");
            
            return Ok(category);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDTO>> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var categoryCreatedDTO = await _categoryService.Add(request);
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryCreatedDTO.Id }, categoryCreatedDTO);
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory([FromBody] UpdateCategoryRequest request)
        {
            var categoryDTO = await _categoryService.GetCategoryById(request.Id);
            if (categoryDTO == null) return NotFound($"Category with id {request.Id} not found.");

            var changedCategory = await _categoryService.Update(request);
            return Ok(changedCategory);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> DeleteCategory([FromRoute] int id)
        {
            var categoryDTO = await _categoryService.GetCategoryById(id);
            if (categoryDTO == null) return NotFound($"Category with id {id} not found.");

            await _categoryService.Remove(id);
            return Ok(categoryDTO);
        }
    }
}
