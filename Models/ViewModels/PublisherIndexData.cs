using Grosu_Andrada_lab.Models;

namespace Grosu_Andrada_lab.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
