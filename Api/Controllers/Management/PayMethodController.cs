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

public class PayMethodController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PayMethodController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PayMethodDto>>> Get()
    {
        var payMethods = await _unitOfWork.PayMethods.GetAllAsync();
        /* return Ok(payMethods); */
        return _mapper.Map<List<PayMethodDto>>(payMethods);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PayMethodDto>> Get(int id)
    {
        var payMethod = await _unitOfWork.PayMethods.GetByIdAsync(id);
        if (payMethod == null)
        {
            return NotFound();
        }
        return _mapper.Map<PayMethodDto>(payMethod);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaymentMethod>> Post(PayMethodDto payMethodDto)
    {
        var payMethod = _mapper.Map<PaymentMethod>(payMethodDto);

        this._unitOfWork.PayMethods.Add(payMethod);
        await _unitOfWork.SaveAsync();
        if (payMethod == null)
        {
            return BadRequest();
        }
        payMethodDto.Id = payMethod.Id;
        return CreatedAtAction(nameof(Post), new { id = payMethodDto.Id }, payMethodDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PayMethodDto>> Put(int id, [FromBody] PayMethodDto payMethodDto)
    {
        var payMethod = _mapper.Map<PaymentMethod>(payMethodDto);
        if (payMethod.Id == 0)
        {
            payMethod.Id = id;
        }
        if (payMethod.Id != id)
        {
            return BadRequest();
        }
        if (payMethod == null)
        {
            return NotFound();
        }

        payMethodDto.Id = payMethod.Id;
        _unitOfWork.PayMethods.Update(payMethod);
        await _unitOfWork.SaveAsync();
        return payMethodDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var payMethod = await _unitOfWork.PayMethods.GetByIdAsync(id);
        if (payMethod == null)
        {
            return NotFound();
        }
        _unitOfWork.PayMethods.Remove(payMethod);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}