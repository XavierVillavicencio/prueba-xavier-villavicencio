using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace backend.Models
{
    public class FormAnswers
    {
        
        public int Id { get; set; }
        [Required]
        public string foaValue { get; set; }
        [NotNull]
        [Required]

        public int foaStatus { get; set; }

        // Foreign Key Forms
        public int FormsId { get; set; }
        // Navigation property
        public Forms Forms { get; set; }


        // Foreign Key Forms Inputs
        public int FormsInputsId { get; set; }
        // Navigation property
        public FormInputs FormInputs { get; set; }
    }
}
