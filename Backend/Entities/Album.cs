namespace MusicCollectionAPI.Backend.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Artist { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int FormatId { get; set; }
        public Format? Format { get; set; }
    }
}
