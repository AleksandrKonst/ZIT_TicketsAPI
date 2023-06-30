# TicketsAPI
Вариации реализации:
| Репозиторий | Описание  |
| ------------ | ------------ |
| TicketsAPI | реализация без репозиториев, только с сервисами `(Controller-Serviece-DataBase)`|
| TicketsAPI-Repo  | реализация с асинхронными репозиториями `(Controller-Serviece-Repository-DataBase)`|
|  TicketsAPI-Unit-Repo |  реализация с асинхронными репозиториями через паттерн Unit of Work `(Controller-Serviece-UnitOfWork-Repository-DataBase)`|
# Тестовый JSON
```json
{
    "operation_type": "sale",
    "operation_time": "2022-01-02T03:25+03:00",
    "operation_place": "Pobeda",
    "passenger": {
        "name": "Aleksandr",
        "surname": "Alexsandr",
        "patronymic": "Alexsandrovich",
        "doc_type": "00",
        "doc_number": "3108111446",
        "birthdate": "2002-12-11",
        "gender": "M",
        "passenger_type": "youth",
        "ticket_number": "5552139265678",
        "ticket_type": 1
    },
    "routes": [{
            "airline_code": "SU",
            "flight_num": 1713,
            "depart_place": "AAQ",
            "depart_datetime": "2022-01-03T09:20+10:00",
            "arrive_place": "NSK",
            "arrive_datetime": "2022-01-03T11:25+03:00",
            "pnr_id": "THALSZ"
        }, {
            "airline_code": "SU",
            "flight_num": 1714,
            "depart_place": "NSK",
            "depart_datetime": "2022-01-08T16:10+03:00",
            "arrive_place": "AAQ",
            "arrive_datetime": "2022-01-08T07:40+10:00",
            "pnr_id": "THALSZ"
        }
    ]
}
```
