﻿namespace TicketsAPI.Middleware.Exceptions;

public class RefundTicketNumberIsNotFound : Exception
{
    public RefundTicketNumberIsNotFound(string message) : base(message)
    {
    }
}