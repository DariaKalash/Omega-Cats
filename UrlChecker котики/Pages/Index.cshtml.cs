using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTP_Cat.Pages
{
    public class IndexModel : PageModel
    {
        public string CatUrl { get; set; }

        public async Task OnPostAsync(string url)
        {
            // Отправить GET-запрос на указанный URL
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                // Получить код состояния ответа
                var statusCode = (int)response.StatusCode;

                // Получить изображение кота с сервиса https://http.cat/
                CatUrl = $"https://http.cat/{statusCode}";
            }
        }
    }
}
