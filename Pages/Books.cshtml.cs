using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibraryApp.Models;

namespace MyLibraryApp.Pages {
    public class BooksModel : PageModel
    {
        public List<Book> Books { get; set; } = new List<Book>();

        // public async Task OnGetAsync()
        // {
        //     using (var httpClient = new HttpClient())
        //     {
        //         var response = await httpClient.GetAsync("https://localhost:5043/books");
        //         if (response.IsSuccessStatusCode)
        //         {
        //             Books = await response.Content.ReadAsAsync<List<Book>>();
        //         }
        //     }
        // }
    }
}
