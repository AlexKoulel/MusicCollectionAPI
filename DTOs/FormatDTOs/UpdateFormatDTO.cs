using System.ComponentModel.DataAnnotations;

namespace MusicCollectionAPI.DTOs.FormatDTOs
{
    public record class UpdateFormatDTO
    (
        [Required][StringLength(30)] string Name
    );
}
