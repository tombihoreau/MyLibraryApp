using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MyLibraryApp.Models; 
using MyLibraryApp.Data;

namespace MyLibraryApp.Services
{
    private readonly LibraryContext _context;

    public class GoogleBookService
    {
    _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task FetchAndSaveBooksAsync(string searchQuery)
        {
            var client = new HttpClient();
            var apiKey = "AIzaSyDHKWcQUF9lgWQbD-F7rsp8rXpqvyMDNuQ";
            var requestUrl = $"https://www.googleapis.com/books/v1/volumes?q={searchQuery}&key={apiKey}";

            var response = await client.GetStringAsync(requestUrl);
            var bookResponse = JsonConvert.DeserializeObject<BookResponse>(response);

            using (var context = new LibraryContext())
            {
                foreach (var item in bookResponse.Items)
                {
                    var volumeInfo = item.VolumeInfo;
                    var book = new Book
                    {
                        Titre = volumeInfo.Title,
                        Autor = string.Join(", ", volumeInfo.Authors),
                        IsAvailable = true 
                    };

                    context.Books.Add(book);
                }
                await context.SaveChangesAsync();
            }
        }

    }
}