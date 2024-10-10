namespace MyLibraryApp.Models
{
    public class Reservation
    {
        public required int Id { get; set; }
        public required int BookId { get; set; }
        public required Book Book { get; set; }

        public required int UserId { get; set; }
        public required User User { get; set; }

        public required DateTime DateReservation { get; set; }
    }
}
