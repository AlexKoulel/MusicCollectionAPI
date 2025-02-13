using MusicCollectionAPI.Backend.DTOs.GenreDTOs;
using MusicCollectionAPI.Backend.Entities;
using System.Runtime.CompilerServices;

namespace MusicCollectionAPI.Backend.Mapping
{
    public static class GenreMapping
    {
        public static Genre GenreToEntity(this CreateGenreDTO genre)
        {
            return new Genre()
            {
                Name = genre.Name
            };
        }

        public static Genre GenreToEntity(this UpdateGenreDTO genre, int id)
        {
            return new Genre()
            {
                Id = id,
                Name = genre.Name
            };
        }
        public static GenreDTO ToDTO(this Genre genre)
        {
            return new GenreDTO(genre.Id, genre.Name);
        }
    }
}
