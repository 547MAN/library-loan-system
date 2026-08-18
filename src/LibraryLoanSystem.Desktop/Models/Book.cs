using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLoanSystem.Desktop.Models
{
    public class Book
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
