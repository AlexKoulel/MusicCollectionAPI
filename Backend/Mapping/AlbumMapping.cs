using MusicCollectionAPI.Backend.DTOs.AlbumDTOs;
using MusicCollectionAPI.Backend.Entities;

namespace MusicCollectionAPI.Backend.Mapping
{
    public static class AlbumMapping
    {
        public static Album AlbumToEntity(this CreateAlbumDTO album)
        {
            return new Album()
            {
                Title = album.Title,
                Artist = album.Artist,
                GenreId = album.GenreId,
                ReleaseDate = album.ReleaseDate,
                FormatId = album.FormatId
            };
        }

        public static Album AlbumToEntity(this UpdateAlbumDTO album, int id)
        {
            return new Album()
            {
                Id = id,
                Title = album.Title,
                Artist = album.Artist,
                GenreId = album.GenreId,
                ReleaseDate = album.ReleaseDate,
                FormatId = album.FormatId
            };
        }
        public static AlbumSummaryDTO ToAlbumSummaryDTO(this Album album)
        {
            return new(
                album.Id,
                album.Title,
                album.Artist,
                album.Genre!.Name,
                album.ReleaseDate,
                album.Format!.Name);
        }
        public static AlbumDetailsDTO ToAlbumDetailsDTO(this Album album)
        {
            return new(
                album.Id,
                album.Title,
                album.Artist,
                album.GenreId,
                album.ReleaseDate,
                album.FormatId);
        }
    }
}
