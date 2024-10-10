namespace MyLibraryApp.Models
{
    public class Borrow
    {
        public required int Id { get; set; }
        public required int BookId { get; set; }
        public required Book Book { get; set; }

        public required int UserId { get; set; }
        public required User User { get; set; }

        public required DateTime DateBorrow { get; set; }
        public required DateTime DateReturn { get; set; }
    }
}
