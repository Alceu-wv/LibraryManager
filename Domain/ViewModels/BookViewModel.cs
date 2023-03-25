using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string ReleaseYear { get; set; }
        public int AuthorId { get; set; }
        public List<AuthorViewModel> Authors { get; set; }
    }
}
