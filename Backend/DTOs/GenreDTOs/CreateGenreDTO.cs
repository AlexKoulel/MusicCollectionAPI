using System.ComponentModel.DataAnnotations;

namespace MusicCollectionAPI.Backend.DTOs.GenreDTOs
{
    public record class CreateGenreDTO
    (
        [Required][StringLength(50)] string Name
    );
}
