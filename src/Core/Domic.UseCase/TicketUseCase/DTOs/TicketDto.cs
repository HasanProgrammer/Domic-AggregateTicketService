﻿using Domic.Domain.Ticket.Enumerations;

namespace Domic.UseCase.TicketUseCase.DTOs;

public class TicketDto
{
    //ticket
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required Priority Priority { get; init; }
    public required Status Status { get; init; }
    
    //comment
    public List<TicketCommentDto> Comments { get; init; }
    
    //user
    public required string Username { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    
    //category
    public required string CategoryName { get; init; }
}