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

public class TypePersonController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TypePersonController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TypePersonDto>>> Get()
    {
        var typePeople = await _unitOfWork.TypePeople.GetAllAsync();
        /* return Ok(typePeople); */
        return _mapper.Map<List<TypePersonDto>>(typePeople);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TypePersonDto>> Get(int id)
    {
        var typePerson = await _unitOfWork.TypePeople.GetByIdAsync(id);
        if (typePerson == null)
        {
            return NotFound();
        }
        return _mapper.Map<TypePersonDto>(typePerson);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TypePerson>> Post(TypePersonDto typePersonDto)
    {
        var typePerson = _mapper.Map<TypePerson>(typePersonDto);

        this._unitOfWork.TypePeople.Add(typePerson);
        await _unitOfWork.SaveAsync();
        if (typePerson == null)
        {
            return BadRequest();
        }
        typePersonDto.Id = typePerson.Id;
        return CreatedAtAction(nameof(Post), new { id = typePersonDto.Id }, typePersonDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TypePersonDto>> Put(int id, [FromBody] TypePersonDto typePersonDto)
    {
        var typePerson = _mapper.Map<TypePerson>(typePersonDto);
        if (typePerson.Id == 0)
        {
            typePerson.Id = id;
        }
        if (typePerson.Id != id)
        {
            return BadRequest();
        }
        if (typePerson == null)
        {
            return NotFound();
        }

        typePersonDto.Id = typePerson.Id;
        _unitOfWork.TypePeople.Update(typePerson);
        await _unitOfWork.SaveAsync();
        return typePersonDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var typePerson = await _unitOfWork.TypePeople.GetByIdAsync(id);
        if (typePerson == null)
        {
            return NotFound();
        }
        _unitOfWork.TypePeople.Remove(typePerson);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}