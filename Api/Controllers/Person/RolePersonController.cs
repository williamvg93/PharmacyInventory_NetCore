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

public class RolePersonController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolePersonController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolePersonDto>>> Get()
    {
        var rolePeople = await _unitOfWork.RolePeople.GetAllAsync();
        /* return Ok(rolePeople); */
        return _mapper.Map<List<RolePersonDto>>(rolePeople);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolePersonDto>> Get(int id)
    {
        var rolePerson = await _unitOfWork.RolePeople.GetByIdAsync(id);
        if (rolePerson == null)
        {
            return NotFound();
        }
        return _mapper.Map<RolePersonDto>(rolePerson);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolePerson>> Post(RolePersonDto rolePersonDto)
    {
        var rolePerson = _mapper.Map<RolePerson>(rolePersonDto);

        this._unitOfWork.RolePeople.Add(rolePerson);
        await _unitOfWork.SaveAsync();
        if (rolePerson == null)
        {
            return BadRequest();
        }
        rolePersonDto.Id = rolePerson.Id;
        return CreatedAtAction(nameof(Post), new { id = rolePersonDto.Id }, rolePersonDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolePersonDto>> Put(int id, [FromBody] RolePersonDto rolePersonDto)
    {
        var rolePerson = _mapper.Map<RolePerson>(rolePersonDto);
        if (rolePerson.Id == 0)
        {
            rolePerson.Id = id;
        }
        if (rolePerson.Id != id)
        {
            return BadRequest();
        }
        if (rolePerson == null)
        {
            return NotFound();
        }

        rolePersonDto.Id = rolePerson.Id;
        _unitOfWork.RolePeople.Update(rolePerson);
        await _unitOfWork.SaveAsync();
        return rolePersonDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var rolePerson = await _unitOfWork.RolePeople.GetByIdAsync(id);
        if (rolePerson == null)
        {
            return NotFound();
        }
        _unitOfWork.RolePeople.Remove(rolePerson);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}