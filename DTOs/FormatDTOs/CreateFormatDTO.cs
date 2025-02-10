using System.ComponentModel.DataAnnotations;

namespace MusicCollectionAPI.DTOs.FormatDTOs
{
    public record class CreateFormatDTO
    (
        [Required][StringLength(30)] string Name
    );
}
