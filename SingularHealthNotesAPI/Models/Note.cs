﻿using System.ComponentModel.DataAnnotations;

namespace SingularHealthNotesAPI.Models
{
    public class Note
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
