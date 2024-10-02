﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObj.Models;

[PrimaryKey("BlogId", "FeedbackId", "UserId")]
[Table("RefBogsFeedback")]
public partial class RefBogsFeedback
{
    [Key]
    [Column("BlogID")]
    [StringLength(20)]
    public string BlogId { get; set; }

    [Key]
    [Column("FeedbackID")]
    [StringLength(20)]
    public string FeedbackId { get; set; }

    [Key]
    [Column("UserID")]
    [StringLength(20)]
    public string UserId { get; set; }

    [StringLength(10)]
    public string Status { get; set; }

    [ForeignKey("BlogId")]
    [InverseProperty("RefBogsFeedbacks")]
    public virtual Blog Blog { get; set; }

    [ForeignKey("FeedbackId")]
    [InverseProperty("RefBogsFeedbacks")]
    public virtual Feedback Feedback { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("RefBogsFeedbacks")]
    public virtual User User { get; set; }
}