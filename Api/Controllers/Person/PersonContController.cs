using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Person;
using Api.Dtos.Post.Person;
using AutoMapper;
using Core.Entities.Person;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Person;

public class PersonContController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonContController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonContDto>>> Get()
    {
        var perContats = await _unitOfWork.PersContacts.GetAllAsync();
        /* return Ok(perContats); */
        return _mapper.Map<List<PersonContDto>>(perContats);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonContDto>> Get(int id)
    {
        var perContact = await _unitOfWork.PersContacts.GetByIdAsync(id);
        if (perContact == null)
        {
            return NotFound();
        }
        return _mapper.Map<PersonContDto>(perContact);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonContact>> Post(PersonContPDto personContPDto)
    {
        var perContact = _mapper.Map<PersonContact>(personContPDto);

        this._unitOfWork.PersContacts.Add(perContact);
        await _unitOfWork.SaveAsync();
        if (perContact == null)
        {
            return BadRequest();
        }
        personContPDto.Id = perContact.Id;
        return CreatedAtAction(nameof(Post), new { id = personContPDto.Id }, personContPDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonContPDto>> Put(int id, [FromBody] PersonContPDto personContPDto)
    {
        var perContact = _mapper.Map<PersonContact>(personContPDto);
        if (perContact.Id == 0)
        {
            perContact.Id = id;
        }
        if (perContact.Id != id)
        {
            return BadRequest();
        }
        if (perContact == null)
        {
            return NotFound();
        }

        personContPDto.Id = perContact.Id;
        _unitOfWork.PersContacts.Update(perContact);
        await _unitOfWork.SaveAsync();
        return personContPDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var perContact = await _unitOfWork.PersContacts.GetByIdAsync(id);
        if (perContact == null)
        {
            return NotFound();
        }
        _unitOfWork.PersContacts.Remove(perContact);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}