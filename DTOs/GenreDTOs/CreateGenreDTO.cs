using System.ComponentModel.DataAnnotations;

namespace MusicCollectionAPI.DTOs.GenreDTOs
{
    public record class CreateGenreDTO
    (
        [Required][StringLength(50)] string Name
    );
}
