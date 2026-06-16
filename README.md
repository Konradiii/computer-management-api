# PC Components API

REST API do zarządzania komputerami i ich komponentami, zbudowane w **ASP.NET Core** z wykorzystaniem **Entity Framework Core** w podejściu **Code First**. Struktura bazy danych generowana jest na podstawie klas encji za pomocą migracji EF Core.

## Opis

Aplikacja umożliwia zarządzanie komputerami (PCs) oraz przypisanymi do nich komponentami. Model danych obejmuje komputery, komponenty, ich typy i producentów, z odwzorowaniem relacji jeden-do-wielu oraz wiele-do-wielu (komputer ↔ komponenty poprzez tabelę łączącą z ilością).

## Model danych

Encje: `PC`, `Component`, `PCComponent` (tabela łącząca z kluczem złożonym i ilością), `ComponentType`, `ComponentManufacturer`.

Konfiguracja modelu obejmuje:
- klucze główne i obce,
- klucze złożone,
- pola wymagane i maksymalne długości danych tekstowych,
- relacje jeden-do-wielu i wiele-do-wielu wraz z właściwościami nawigacyjnymi.

Struktura bazy tworzona jest **migracjami EF Core**, a dane startowe ładowane mechanizmem **seed data** (`HasData()`).

## Endpointy

| Metoda | Ścieżka | Opis |
|--------|---------|------|
| `GET` | `/api/pcs` | Lista wszystkich komputerów |
| `GET` | `/api/pcs/{id}/components` | Komponenty danego komputera wraz z ilością (404, gdy komputer nie istnieje) |
| `POST` | `/api/pcs` | Dodanie nowego komputera (201 Created) |
| `PUT` | `/api/pcs/{id}` | Edycja istniejącego komputera |
| `DELETE` | `/api/pcs/{id}` | Usunięcie komputera (204 No Content, 404 gdy nie istnieje) |

Endpointy zwracają statusy HTTP zgodne z rezultatem operacji (200, 201, 204, 400, 404, 500).

## Zastosowane praktyki

- **Architektura warstwowa** - rozdzielenie logiki biznesowej od warstwy API/prezentacji.
- **DTO** - osobne klasy dla danych przychodzących, zwracanych oraz operacji tworzenia/aktualizacji (encje bazy nie są udostępniane bezpośrednio przez API).
- **Operacje asynchroniczne** (`async/await`) w komunikacji z bazą danych.
- **Migracje EF Core** dołączone do repozytorium.
- Czytelny podział na katalogi, zgodny z konwencjami C# i ASP.NET Core.

## Technologie

- C# / .NET - ASP.NET Core Web API
- Entity Framework Core (Code First, migracje, seed data)
- Microsoft SQL Server

## Uruchomienie

1. Skonfiguruj connection string w pliku konfiguracyjnym aplikacji.
2. Zastosuj migracje, aby utworzyć bazę danych: `dotnet ef database update`.
3. Uruchom aplikację (`dotnet run`) i korzystaj z endpointów poprzez Swagger lub klienta HTTP.
