using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Inventory;
using Api.Dtos.Post.Inventory;
using AutoMapper;
using Core.Entities.Inventory;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Inventory;

public class InventoryManaController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InventoryManaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InventManagDto>>> Get()
    {
        var invenManags = await _unitOfWork.InvenManags.GetAllAsync();
        /* return Ok(invenManags); */
        return _mapper.Map<List<InventManagDto>>(invenManags);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InventManagDto>> Get(int id)
    {
        var inveMana = await _unitOfWork.InvenManags.GetByIdAsync(id);
        if (inveMana == null)
        {
            return NotFound();
        }
        return _mapper.Map<InventManagDto>(inveMana);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InventoryManagement>> Post(InventManagPDto inventManagPDto)
    {
        var inveMana = _mapper.Map<InventoryManagement>(inventManagPDto);

        this._unitOfWork.InvenManags.Add(inveMana);
        await _unitOfWork.SaveAsync();
        if (inveMana == null)
        {
            return BadRequest();
        }
        inventManagPDto.Id = inveMana.Id;
        return CreatedAtAction(nameof(Post), new { id = inventManagPDto.Id }, inventManagPDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InventManagPDto>> Put(int id, [FromBody] InventManagPDto inventManagPDto)
    {
        var inveMana = _mapper.Map<InventoryManagement>(inventManagPDto);
        if (inveMana.Id == 0)
        {
            inveMana.Id = id;
        }
        if (inveMana.Id != id)
        {
            return BadRequest();
        }
        if (inveMana == null)
        {
            return NotFound();
        }

        inventManagPDto.Id = inveMana.Id;
        _unitOfWork.InvenManags.Update(inveMana);
        await _unitOfWork.SaveAsync();
        return inventManagPDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var inveMana = await _unitOfWork.InvenManags.GetByIdAsync(id);
        if (inveMana == null)
        {
            return NotFound();
        }
        _unitOfWork.InvenManags.Remove(inveMana);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}