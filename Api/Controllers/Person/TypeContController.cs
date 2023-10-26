using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Person;
using AutoMapper;
using Core.Entities.Person;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Person;

public class TypeContController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TypeContController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TypeContDto>>> Get()
    {
        var typeContats = await _unitOfWork.TypeContacts.GetAllAsync();
        /* return Ok(typeContats); */
        return _mapper.Map<List<TypeContDto>>(typeContats);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TypeContDto>> Get(int id)
    {
        var typeContact = await _unitOfWork.TypeContacts.GetByIdAsync(id);
        if (typeContact == null)
        {
            return NotFound();
        }
        return _mapper.Map<TypeContDto>(typeContact);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TypeContact>> Post(TypeContDto typeContDto)
    {
        var typeContact = _mapper.Map<TypeContact>(typeContDto);

        this._unitOfWork.TypeContacts.Add(typeContact);
        await _unitOfWork.SaveAsync();
        if (typeContact == null)
        {
            return BadRequest();
        }
        typeContDto.Id = typeContact.Id;
        return CreatedAtAction(nameof(Post), new { id = typeContDto.Id }, typeContDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TypeContDto>> Put(int id, [FromBody] TypeContDto typeContDto)
    {
        var typeContact = _mapper.Map<TypeContact>(typeContDto);
        if (typeContact.Id == 0)
        {
            typeContact.Id = id;
        }
        if (typeContact.Id != id)
        {
            return BadRequest();
        }
        if (typeContact == null)
        {
            return NotFound();
        }

        typeContDto.Id = typeContact.Id;
        _unitOfWork.TypeContacts.Update(typeContact);
        await _unitOfWork.SaveAsync();
        return typeContDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var typeContact = await _unitOfWork.TypeContacts.GetByIdAsync(id);
        if (typeContact == null)
        {
            return NotFound();
        }
        _unitOfWork.TypeContacts.Remove(typeContact);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}