# Music Collection API
A simple RESTful API for managing your music collection, built with ASP.NET using the Entity Framework and SQLite.

## Endpoints

### Albums
| Method | Endpoint      | Description         |
|:-|:-|:-|
| GET    | `/albums`     | Get all albums |
| GET    | `/albums/{id}` | Get album by ID   |
| POST   | `/albums`     | Add a new album|
| PUT    | `/albums/{id}` | Update an existing album|
| DELETE | `/albums/{id}` | Delete an album |

### Genres
| Method | Endpoint| Description|
|:-|:-|:-|
| GET    | `/genres`     | Get all genres |
| GET    | `/genres/{id}` | Get genre  by ID   |
| POST   | `/genres`     | Add a new genre|
| PUT    | `/genres/{id}` | Update an existing genre|
| DELETE | `/genres/{id}` | Delete a genre |

### Formats
| Method | Endpoint| Description|
|:-|:-|:-|
| GET    | `/format`     | Get all albums |
| GET    | `/format/{id}` | Get album by ID   |
| POST   | `/format`     | Add a new album|
| PUT    | `/format/{id}` | Update an existing album|
| DELETE | `/format/{id}` | Delete an album |