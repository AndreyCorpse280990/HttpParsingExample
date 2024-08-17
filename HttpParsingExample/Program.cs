using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpParsingExample
{
    internal class Program
    {
        // ParseBestFilms - процедура парсинга данных с html-страницы
        static List<BestFilmItem> ParseBestFilms(string htmlBody)
        {
            // 1. попробовать вырезать часть самой таблицы (тег <tbody>)
            int tBodyStartIndex = htmlBody.IndexOf("<td>1</td>");
            int tBodyEndIndex = htmlBody.IndexOf("</tbody");
            htmlBody = htmlBody.Substring(tBodyStartIndex, tBodyEndIndex - tBodyStartIndex);
            // 2. удалить лишние промежуточные строки
            htmlBody = htmlBody
                .Replace("\r", "")
                .Replace("</td></tr>\n<tr>\n", "")
                .Replace("\n</td></tr>", "");
            // на данном этапе строка состоит из пятерок строк
            // каждая из которых должна быть преобразована в объект
            Console.WriteLine(htmlBody);
            return new List<BestFilmItem>();
        }

        static async Task Main(string[] args)
        {
            try
            {
                // 1. создать http-client
                HttpClient client = new HttpClient();
                // 2. выполнить запрос на получение html-страницы
                const string URI = @"https://ru.wikipedia.org/wiki/250_%D0%BB%D1%83%D1%87%D1%88%D0%B8%D1%85_%D1%84%D0%B8%D0%BB%D1%8C%D0%BC%D0%BE%D0%B2_%D0%BF%D0%BE_%D0%B2%D0%B5%D1%80%D1%81%D0%B8%D0%B8_IMDb";
                HttpResponseMessage response = await client.GetAsync(URI);
                // 3. прочитать тело запроса
                string htmlBody = await response.Content.ReadAsStringAsync();
                // 4. выполнить парсинг
                List<BestFilmItem> bestFilms = ParseBestFilms(htmlBody);
                // 5. вывести результат
                foreach (BestFilmItem bestFilm in bestFilms)
                {
                    Console.WriteLine(bestFilm);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
