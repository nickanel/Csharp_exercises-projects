using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book
    {

        public Book()
        {
            Tags = new List<Tag>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public ICollection<Tag> Tags { get; set; }

    }
}
