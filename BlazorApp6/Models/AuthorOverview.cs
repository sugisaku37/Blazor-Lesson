using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp6.Models
{
    public class AuthorOverview
    {
        public string AuthorId { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string State { get; set; } = null!;
    }
}