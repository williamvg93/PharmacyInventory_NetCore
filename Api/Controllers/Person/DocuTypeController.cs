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

public class DocuTypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DocuTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DocuTypeDto>>> Get()
    {
        var docuTypes = await _unitOfWork.DocumTypes.GetAllAsync();
        /* return Ok(docuTypes); */
        return _mapper.Map<List<DocuTypeDto>>(docuTypes);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DocuTypeDto>> Get(int id)
    {
        var docuType = await _unitOfWork.DocumTypes.GetByIdAsync(id);
        if (docuType == null)
        {
            return NotFound();
        }
        return _mapper.Map<DocuTypeDto>(docuType);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentType>> Post(DocuTypeDto docuTypeDto)
    {
        var docuType = _mapper.Map<DocumentType>(docuTypeDto);

        this._unitOfWork.DocumTypes.Add(docuType);
        await _unitOfWork.SaveAsync();
        if (docuType == null)
        {
            return BadRequest();
        }
        docuTypeDto.Id = docuType.Id;
        return CreatedAtAction(nameof(Post), new { id = docuTypeDto.Id }, docuTypeDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocuTypeDto>> Put(int id, [FromBody] DocuTypeDto docuTypeDto)
    {
        var docuType = _mapper.Map<DocumentType>(docuTypeDto);
        if (docuType.Id == 0)
        {
            docuType.Id = id;
        }
        if (docuType.Id != id)
        {
            return BadRequest();
        }
        if (docuType == null)
        {
            return NotFound();
        }

        docuTypeDto.Id = docuType.Id;
        _unitOfWork.DocumTypes.Update(docuType);
        await _unitOfWork.SaveAsync();
        return docuTypeDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var docuType = await _unitOfWork.DocumTypes.GetByIdAsync(id);
        if (docuType == null)
        {
            return NotFound();
        }
        _unitOfWork.DocumTypes.Remove(docuType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}