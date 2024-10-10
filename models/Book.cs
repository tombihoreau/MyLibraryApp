namespace MyLibraryApp.Models
{
    public class Book
    {        public required int Id { get; set; }
        public required string Titre { get; set; }
        public required string Autor { get; set; }
        public required bool IsAvailable { get; set; }
        public ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
