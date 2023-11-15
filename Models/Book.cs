﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Grosu_Andrada_lab.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Display(Name = "Book Title")]
        public string Title { get; set; }
     
            [Range(0.01, 500)]
        public int? AuthorID {  get; set; }
        public Author? Author { get; set; }
      
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
        public int? BorrowingID { get; set; }
        public Borrowing? Borrowing { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
