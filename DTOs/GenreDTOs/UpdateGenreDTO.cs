using System.ComponentModel.DataAnnotations;

namespace MusicCollectionAPI.DTOs.GenreDTOs
{
    public record class UpdateGenreDTO
    (
        [Required][StringLength(50)] string Name
    );
}
