using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Buttons
    {
        public int Id { get; set; }
        [Required]
        public string bot_name { get; set; }
        public string bot_description { get; set; }
        public int bot_status { get; set; }

    }
}
