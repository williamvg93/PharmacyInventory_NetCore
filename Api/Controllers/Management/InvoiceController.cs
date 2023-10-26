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

public class InvoiceController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InvoiceController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InvoiceDto>>> Get()
    {
        var invoices = await _unitOfWork.Invoices.GetAllAsync();
        /* return Ok(invoices); */
        return _mapper.Map<List<InvoiceDto>>(invoices);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InvoiceDto>> Get(int id)
    {
        var invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
        if (invoice == null)
        {
            return NotFound();
        }
        return _mapper.Map<InvoiceDto>(invoice);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Invoice>> Post(InvoiceDto invoiceDto)
    {
        var invoice = _mapper.Map<Invoice>(invoiceDto);

        this._unitOfWork.Invoices.Add(invoice);
        await _unitOfWork.SaveAsync();
        if (invoice == null)
        {
            return BadRequest();
        }
        invoiceDto.Id = invoice.Id;
        return CreatedAtAction(nameof(Post), new { id = invoiceDto.Id }, invoiceDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InvoiceDto>> Put(int id, [FromBody] InvoiceDto invoiceDto)
    {
        var invoice = _mapper.Map<Invoice>(invoiceDto);
        if (invoice.Id == 0)
        {
            invoice.Id = id;
        }
        if (invoice.Id != id)
        {
            return BadRequest();
        }
        if (invoice == null)
        {
            return NotFound();
        }

        invoiceDto.Id = invoice.Id;
        _unitOfWork.Invoices.Update(invoice);
        await _unitOfWork.SaveAsync();
        return invoiceDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
        if (invoice == null)
        {
            return NotFound();
        }
        _unitOfWork.Invoices.Remove(invoice);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}