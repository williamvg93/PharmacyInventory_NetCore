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

public class PresenTypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PresenTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PresenTypeDto>>> Get()
    {
        var preseTypes = await _unitOfWork.PresType.GetAllAsync();
        /* return Ok(preseTypes); */
        return _mapper.Map<List<PresenTypeDto>>(preseTypes);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PresenTypeDto>> Get(int id)
    {
        var presenType = await _unitOfWork.PresType.GetByIdAsync(id);
        if (presenType == null)
        {
            return NotFound();
        }
        return _mapper.Map<PresenTypeDto>(presenType);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PresentationType>> Post(PresenTypeDto presenTypeDto)
    {
        var presenType = _mapper.Map<PresentationType>(presenTypeDto);

        this._unitOfWork.PresType.Add(presenType);
        await _unitOfWork.SaveAsync();
        if (presenType == null)
        {
            return BadRequest();
        }
        presenTypeDto.Id = presenType.Id;
        return CreatedAtAction(nameof(Post), new { id = presenTypeDto.Id }, presenTypeDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PresenTypeDto>> Put(int id, [FromBody] PresenTypeDto presenTypeDto)
    {
        var presenType = _mapper.Map<PresentationType>(presenTypeDto);
        if (presenType.Id == 0)
        {
            presenType.Id = id;
        }
        if (presenType.Id != id)
        {
            return BadRequest();
        }
        if (presenType == null)
        {
            return NotFound();
        }

        presenTypeDto.Id = presenType.Id;
        _unitOfWork.PresType.Update(presenType);
        await _unitOfWork.SaveAsync();
        return presenTypeDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var presenType = await _unitOfWork.PresType.GetByIdAsync(id);
        if (presenType == null)
        {
            return NotFound();
        }
        _unitOfWork.PresType.Remove(presenType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}