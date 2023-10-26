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

public class InventoryController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InventoryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InventoryDto>>> Get()
    {
        var inventories = await _unitOfWork.Inventories.GetAllAsync();
        /* return Ok(inventories); */
        return _mapper.Map<List<InventoryDto>>(inventories);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InventoryDto>> Get(int id)
    {
        var inventory = await _unitOfWork.Inventories.GetByIdAsync(id);
        if (inventory == null)
        {
            return NotFound();
        }
        return _mapper.Map<InventoryDto>(inventory);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CInventory>> Post(InventoryPDto inventoryPDto)
    {
        var inventory = _mapper.Map<CInventory>(inventoryPDto);

        this._unitOfWork.Inventories.Add(inventory);
        await _unitOfWork.SaveAsync();
        if (inventory == null)
        {
            return BadRequest();
        }
        inventoryPDto.Id = inventory.Id;
        return CreatedAtAction(nameof(Post), new { id = inventoryPDto.Id }, inventoryPDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InventoryPDto>> Put(int id, [FromBody] InventoryPDto inventoryPDto)
    {
        var inventory = _mapper.Map<CInventory>(inventoryPDto);
        if (inventory.Id == 0)
        {
            inventory.Id = id;
        }
        if (inventory.Id != id)
        {
            return BadRequest();
        }
        if (inventory == null)
        {
            return NotFound();
        }

        inventoryPDto.Id = inventory.Id;
        _unitOfWork.Inventories.Update(inventory);
        await _unitOfWork.SaveAsync();
        return inventoryPDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CInventory>> Delete(int id)
    {
        var inventory = await _unitOfWork.Inventories.GetByIdAsync(id);
        if (inventory == null)
        {
            return NotFound();
        }
        _unitOfWork.Inventories.Remove(inventory);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}