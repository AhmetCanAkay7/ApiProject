using ApiProject.WebApi.Context;
using ApiProject.WebApi.DTOs.MessageDtos;
using ApiProject.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ApiContext _context;

    public MessagesController(IMapper mapper,ApiContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet(nameof(GetMessages))]
    public IActionResult GetMessages()
    {
        var values = _context.Messages.ToList();
        return Ok(_mapper.Map<ResultMessageDtos>(values));
    }

    [HttpPost(nameof(CreateMessage))]
    public IActionResult CreateMessage(CreateMessageDtos createMessageDto)
    {
        var message = _mapper.Map<Message>(createMessageDto);
        _context.Messages.Add(message);
        _context.SaveChanges();
        return Ok("Message was created");
    }

    [HttpDelete(nameof(DeleteMessage))]
    public IActionResult DeleteMessage(int messageId)
    {
        var message = _context.Messages.Find(messageId);
        _context.Messages.Remove(message);
        _context.SaveChanges();
        return Ok("Message was deleted");
    }

    [HttpPut(nameof(UpdateMessage))]
    public IActionResult UpdateMessage(UpdateMessageDtos updateMessageDto)
    {
        var messageToUpdate = _mapper.Map<Message>(updateMessageDto);
        _context.Messages.Update(messageToUpdate);
        _context.SaveChanges();
        return Ok("Message was updated");
    }

    [HttpGet(nameof(GetMessage))]
    public IActionResult GetMessage(int id)
    {
        var value = _context.Messages.Find(id);
        return Ok(_mapper.Map<GetByIdMessageDtos>(value));
    }
}