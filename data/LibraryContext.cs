using Microsoft.EntityFrameworkCore;
using MyLibraryApp.Models;

namespace MyLibraryApp.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Borrow>()
                .HasOne(b => b.Book)
                .WithMany(book => book.Borrows)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Borrow>()
                .HasOne(b => b.User)
                .WithMany(user => user.Borrows)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Book)
                .WithMany(book => book.Reservations)
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(user => user.Reservations)
                .HasForeignKey(r => r.UserId);
        }
    }
}
