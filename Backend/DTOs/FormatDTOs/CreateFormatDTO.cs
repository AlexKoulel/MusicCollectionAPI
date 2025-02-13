using System.ComponentModel.DataAnnotations;

namespace MusicCollectionAPI.Backend.DTOs.FormatDTOs
{
    public record class CreateFormatDTO
    (
        [Required][StringLength(30)] string Name
    );
}
