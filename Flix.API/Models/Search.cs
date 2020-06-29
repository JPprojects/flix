using System;
using System.Collections.Generic;

namespace Flix.API.Models
{
    public class Search
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<Result> results { get; set; }
    }
}
