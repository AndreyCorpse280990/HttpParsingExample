using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpParsingExample
{
    // BestFilmItem - класс, описывающий фильм из списка лучших фильмов
    internal class BestFilmItem
    {
        public int Position { get; set; }       // позиция фильма в рейтинге
        public string Name { get; set; }        // название фильма
        public int Year { get; set; }           // год выхода
        public string FilmMaker { get; set; }   // режиссер
        public string[] Genres { get; set; }    // жанры фильма

        public BestFilmItem() { }

        public override string ToString()
        {
            return $"{Position} - {Name} - {Year} - {FilmMaker} - {string.Join(", ", Genres)}";
        }
    }
}
