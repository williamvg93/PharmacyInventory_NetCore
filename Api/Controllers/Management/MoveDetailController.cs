using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Management;
using Api.Dtos.Post.Management;
using AutoMapper;
using Core.Entities.Management;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Management;

public class MoveDetailController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MoveDetailController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MoveDetailDto>>> Get()
    {
        var movementDetails = await _unitOfWork.MovemDetails.GetAllAsync();
        /* return Ok(movementDetails); */
        return _mapper.Map<List<MoveDetailDto>>(movementDetails);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MoveDetailDto>> Get(int id)
    {
        var movementDetail = await _unitOfWork.MovemDetails.GetByIdAsync(id);
        if (movementDetail == null)
        {
            return NotFound();
        }
        return _mapper.Map<MoveDetailDto>(movementDetail);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovementDetail>> Post(MoveDetailPDto moveDetailPDto)
    {
        var movementDetail = _mapper.Map<MovementDetail>(moveDetailPDto);

        this._unitOfWork.MovemDetails.Add(movementDetail);
        await _unitOfWork.SaveAsync();
        if (movementDetail == null)
        {
            return BadRequest();
        }
        moveDetailPDto.Id = movementDetail.Id;
        return CreatedAtAction(nameof(Post), new { id = moveDetailPDto.Id }, moveDetailPDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MoveDetailPDto>> Put(int id, [FromBody] MoveDetailPDto moveDetailPDto)
    {
        var movementDetail = _mapper.Map<MovementDetail>(moveDetailPDto);
        if (movementDetail.Id == 0)
        {
            movementDetail.Id = id;
        }
        if (movementDetail.Id != id)
        {
            return BadRequest();
        }
        if (movementDetail == null)
        {
            return NotFound();
        }

        moveDetailPDto.Id = movementDetail.Id;
        _unitOfWork.MovemDetails.Update(movementDetail);
        await _unitOfWork.SaveAsync();
        return moveDetailPDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var movementDetail = await _unitOfWork.MovemDetails.GetByIdAsync(id);
        if (movementDetail == null)
        {
            return NotFound();
        }
        _unitOfWork.MovemDetails.Remove(movementDetail);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}