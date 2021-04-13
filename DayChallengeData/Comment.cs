﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DayChallengeData
{
    public class Comment //Jeff
    {
        [Key]
        public int CommentID { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid AuthorID { get; set; }
        //public virtual List<Reply> Replies { get; set; }
        [ForeignKey(nameof(Post))]
        public int Id { get; set; } //Needs to be FK after first migration
        
        public virtual Post Post { get; set; }
    }
}