using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Location;
using Api.Dtos.Post.Location;
using AutoMapper;
using Core.Entities.Location;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Location;

public class CityController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CityController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CityDto>>> Get()
    {
        var cities = await _unitOfWork.Cities.GetAllAsync();
        /* return Ok(cities); */
        return _mapper.Map<List<CityDto>>(cities);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CityDto>> Get(int id)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(id);
        if (city == null)
        {
            return NotFound();
        }
        return _mapper.Map<CityDto>(city);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<City>> Post(CityPDto cityPDto)
    {
        var city = _mapper.Map<City>(cityPDto);

        this._unitOfWork.Cities.Add(city);
        await _unitOfWork.SaveAsync();
        if (city == null)
        {
            return BadRequest();
        }
        cityPDto.Id = city.Id;
        return CreatedAtAction(nameof(Post), new { id = cityPDto.Id }, cityPDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CityPDto>> Put(int id, [FromBody] CityPDto cityPDto)
    {
        var city = _mapper.Map<City>(cityPDto);
        if (city.Id == 0)
        {
            city.Id = id;
        }
        if (city.Id != id)
        {
            return BadRequest();
        }
        if (city == null)
        {
            return NotFound();
        }

        cityPDto.Id = city.Id;
        _unitOfWork.Cities.Update(city);
        await _unitOfWork.SaveAsync();
        return cityPDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(id);
        if (city == null)
        {
            return NotFound();
        }
        _unitOfWork.Cities.Remove(city);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}