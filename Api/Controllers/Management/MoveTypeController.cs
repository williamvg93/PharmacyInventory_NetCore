using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Management;
using AutoMapper;
using Core.Entities.Management;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Management;

public class MoveTypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MoveTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MoveTypeDto>>> Get()
    {
        var moveTypes = await _unitOfWork.MovemTypes.GetAllAsync();
        /* return Ok(moveTypes); */
        return _mapper.Map<List<MoveTypeDto>>(moveTypes);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MoveTypeDto>> Get(int id)
    {
        var moveType = await _unitOfWork.MovemTypes.GetByIdAsync(id);
        if (moveType == null)
        {
            return NotFound();
        }
        return _mapper.Map<MoveTypeDto>(moveType);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovementType>> Post(MoveTypeDto moveTypeDto)
    {
        var moveType = _mapper.Map<MovementType>(moveTypeDto);

        this._unitOfWork.MovemTypes.Add(moveType);
        await _unitOfWork.SaveAsync();
        if (moveType == null)
        {
            return BadRequest();
        }
        moveTypeDto.Id = moveType.Id;
        return CreatedAtAction(nameof(Post), new { id = moveTypeDto.Id }, moveTypeDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MoveTypeDto>> Put(int id, [FromBody] MoveTypeDto moveTypeDto)
    {
        var moveType = _mapper.Map<MovementType>(moveTypeDto);
        if (moveType.Id == 0)
        {
            moveType.Id = id;
        }
        if (moveType.Id != id)
        {
            return BadRequest();
        }
        if (moveType == null)
        {
            return NotFound();
        }

        moveTypeDto.Id = moveType.Id;
        _unitOfWork.MovemTypes.Update(moveType);
        await _unitOfWork.SaveAsync();
        return moveTypeDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var moveType = await _unitOfWork.MovemTypes.GetByIdAsync(id);
        if (moveType == null)
        {
            return NotFound();
        }
        _unitOfWork.MovemTypes.Remove(moveType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}