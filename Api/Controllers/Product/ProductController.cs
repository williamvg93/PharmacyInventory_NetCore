using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Product;
using Api.Dtos.Post.Product;
using AutoMapper;
using Core.Entities.Product;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Product;

public class ProductController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
    {
        var people = await _unitOfWork.Products.GetAllAsync();
        /* return Ok(people); */
        return _mapper.Map<List<ProductDto>>(people);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return _mapper.Map<ProductDto>(product);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CProduct>> Post(ProductPDto productPDto)
    {
        var product = _mapper.Map<CProduct>(productPDto);

        this._unitOfWork.Products.Add(product);
        await _unitOfWork.SaveAsync();
        if (product == null)
        {
            return BadRequest();
        }
        productPDto.Id = product.Id;
        return CreatedAtAction(nameof(Post), new { id = productPDto.Id }, productPDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductPDto>> Put(int id, [FromBody] ProductPDto productPDto)
    {
        var product = _mapper.Map<CProduct>(productPDto);
        if (product.Id == 0)
        {
            product.Id = id;
        }
        if (product.Id != id)
        {
            return BadRequest();
        }
        if (product == null)
        {
            return NotFound();
        }

        productPDto.Id = product.Id;
        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveAsync();
        return productPDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        _unitOfWork.Products.Remove(product);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}