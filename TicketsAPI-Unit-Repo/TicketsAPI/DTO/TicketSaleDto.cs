﻿using TicketsAPI.Validation.DtoValidation;
using TicketsAPI.Validation.JsonValidation;

namespace TicketsAPI.DTO;

[JsonSale]
public class TicketSaleDto
{
    public string operation_type { get; set; }
    public string operation_time { get; set; }
    public string operation_place { get; set; }
    public Passenger passenger { get; set; }
    public Route[] routes { get; set; }
}

public class Passenger
{
    public string name { get; set; }
    public string surname { get; set; }
    public string patronymic { get; set; }
    [DocTypeValidation]
    public string doc_type { get; set; }
    [DocNumberValidation]
    public string doc_number { get; set; }
    public string birthdate { get; set; }
    [GenderValidation]
    public string gender { get; set; }
    public string passenger_type { get; set; }
    [TicketNumberValidation]
    public string ticket_number { get; set; }
    public int ticket_type { get; set; }
}

public class Route
{
    public string airline_code { get; set; }
    public int flight_num { get; set; }
    public string depart_place { get; set; }
    public string depart_datetime { get; set; }
    public string arrive_place { get; set; }
    public string arrive_datetime { get; set; }
    public string pnr_id { get; set; }
}