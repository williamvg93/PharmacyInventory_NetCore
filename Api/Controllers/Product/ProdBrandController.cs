using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Product;
using AutoMapper;
using Core.Entities.Product;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Product;

public class ProdBrandController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProdBrandController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProdBrandDto>>> Get()
    {
        var prodBrands = await _unitOfWork.ProdBrands.GetAllAsync();
        /* return Ok(prodBrands); */
        return _mapper.Map<List<ProdBrandDto>>(prodBrands);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProdBrandDto>> Get(int id)
    {
        var prodBrand = await _unitOfWork.ProdBrands.GetByIdAsync(id);
        if (prodBrand == null)
        {
            return NotFound();
        }
        return _mapper.Map<ProdBrandDto>(prodBrand);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductBrand>> Post(ProdBrandDto prodBrandDto)
    {
        var prodBrand = _mapper.Map<ProductBrand>(prodBrandDto);

        this._unitOfWork.ProdBrands.Add(prodBrand);
        await _unitOfWork.SaveAsync();
        if (prodBrand == null)
        {
            return BadRequest();
        }
        prodBrandDto.Id = prodBrand.Id;
        return CreatedAtAction(nameof(Post), new { id = prodBrandDto.Id }, prodBrandDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProdBrandDto>> Put(int id, [FromBody] ProdBrandDto prodBrandDto)
    {
        var prodBrand = _mapper.Map<ProductBrand>(prodBrandDto);
        if (prodBrand.Id == 0)
        {
            prodBrand.Id = id;
        }
        if (prodBrand.Id != id)
        {
            return BadRequest();
        }
        if (prodBrand == null)
        {
            return NotFound();
        }

        prodBrandDto.Id = prodBrand.Id;
        _unitOfWork.ProdBrands.Update(prodBrand);
        await _unitOfWork.SaveAsync();
        return prodBrandDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var prodBrand = await _unitOfWork.ProdBrands.GetByIdAsync(id);
        if (prodBrand == null)
        {
            return NotFound();
        }
        _unitOfWork.ProdBrands.Remove(prodBrand);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}