namespace MusicCollectionAPI.Backend.DTOs.AlbumDTOs
{
    public record class AlbumDetailsDTO(
        int Id,
        string Title,
        string Artist,
        int GenreId,
        DateOnly ReleaseDate,
        int FormatId);
}
