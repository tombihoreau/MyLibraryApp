namespace MyLibraryApp.Models
{
    public class BorrowingHistory
    {
        public required int Id { get; set; }
        public required int BookId { get; set; }
        public required Book Book { get; set; }
        public required DateTime DateBorrow { get; set; }
        public required Borrow Borrow { get; set; }
    }
}
