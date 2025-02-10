using System.ComponentModel.DataAnnotations;

namespace MusicCollectionAPI.DTOs.AlbumDTOs
{
    public record class CreateAlbumDTO
    (
        [Required][StringLength(80)] string Title,
        [Required][StringLength(80)] string Artist,
        int GenreId,
        DateOnly ReleaseDate,
        int FormatId
    );
}
