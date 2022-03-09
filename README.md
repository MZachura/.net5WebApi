# .net5WebApi
Proste Web Api 
Użyto bazy dokumentowej MongoDB.

Api umożliwia: 

Utworzenie spotkania:
POST /events

Usunięcie spotkania:
DELETE /events/{id}

Zwrócenie listy spotkań:
GET /events

Zwrócenie listy uczestników która jest zawarta w spotkaniu:
GET /events/id

Dodanie użytkownika do spotkania:
PUT /events/user/{id}

Zmiana nazwy spotkania:
PUT /events

Dodatkowo:
- uczestników może zostać zapisanych jedynie 25 do pojedynczego spotkania, wymagane są unikatowe maile
