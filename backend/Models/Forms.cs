using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Forms
    {
        public int Id { get; set; }
        [Required]
        public string for_name { get; set; }
        public string for_description { get; set; }
        public int for_status { get; set; }
    }
}