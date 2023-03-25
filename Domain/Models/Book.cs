using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string ReleaseYear { get; set; }
        public long AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public Book(long id, string title, string iSBN, string releaseYear, long authorId)
        {
            Id = id;
            Title = title;
            ISBN = iSBN;
            ReleaseYear = releaseYear;
            AuthorId = authorId;
        }
    }
}
