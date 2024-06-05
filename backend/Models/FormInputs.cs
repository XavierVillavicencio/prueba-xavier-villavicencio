using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace backend.Models
{
    public class FormInputs
    {
        public int Id { get; set; }
        [Required]
        [NotNull]
        public string foiName { get; set; }
        [Required]
        [NotNull]
        public string foiTitle { get; set; }
        [Required]
        [NotNull]
        public int foiType { get; set; }
        
        public int foiStatus { get; set; }

        // Foreign Key Forms
        public int FormsId { get; set; }
        // Navigation property
        public Forms Forms { get; set; }
    }
}
