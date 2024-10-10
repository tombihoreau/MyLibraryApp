using MyLibraryApp.Data;
using MyLibraryApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryApp.Services
{
    public class UserService
    {
        private readonly LibraryContext _context;

        public UserService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public bool CanBorrowBook(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("Utilisateur introuvable");
            }

            return user.BorrowedBooks.Count() < 5;
        }

        // Ajoute un nouvel utilisateur
        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        // Met à jour les informations d'un utilisateur
        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                throw new Exception("Utilisateur introuvable");
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("Utilisateur introuvable");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public IQueryable<Borrow> GetUserBorrows(int userId)
        {
            return _context.Borrow.Where(l => l.UserId == userId);
        }
    }
}
