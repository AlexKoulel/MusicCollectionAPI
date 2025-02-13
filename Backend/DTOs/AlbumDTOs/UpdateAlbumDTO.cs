using System.ComponentModel.DataAnnotations;

namespace MusicCollectionAPI.Backend.DTOs.AlbumDTOs
{
    public record class UpdateAlbumDTO
    (
        [Required][StringLength(80)] string Title,
        [Required][StringLength(80)] string Artist,
        int GenreId,
        DateOnly ReleaseDate,
        int FormatId
    );
}
