# Music Collection API
A simple RESTful API for managing your music collection, built with ASP.NET using the Entity Framework and SQLServer.

## Setup
- Inside *appsettings.Development.json* make sure you change the value of *Server* in the *MusicCollectionDB* string to the name of your server.
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
| GET    | `/format`     | Get all formats |
| GET    | `/format/{id}` | Get format by ID   |
| POST   | `/format`     | Add a new format|
| PUT    | `/format/{id}` | Update an existing format|
| DELETE | `/format/{id}` | Delete a format |

### Frontend Showcase
There is also a simple frontend option to create entries.
![Showcase](Assets/APIShowcase.gif)