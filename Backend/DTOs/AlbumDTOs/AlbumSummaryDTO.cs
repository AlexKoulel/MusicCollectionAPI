namespace MusicCollectionAPI.Backend.DTOs.AlbumDTOs
{
    public record class AlbumSummaryDTO(
        int Id,
        string Title,
        string Artist,
        string Genre,
        DateOnly ReleaseDate,
        string Format);
}
