namespace MyLibraryApp.Models
{
    public class User
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required List<Borrow> Borrows { get; set; }
        public required List<Reservation> Reservations { get; set; }
    }

}
