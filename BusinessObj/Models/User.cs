﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObj.Models;

[Table("User")]
public partial class User
{
    [Key]
    [Column("UserID")]
    [StringLength(20)]
    public string UserId { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    [StringLength(50)]
    public string Passwork { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; }

    [Required]
    [StringLength(50)]
    public string Fullname { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string Phonenumber { get; set; }

    [StringLength(100)]
    public string Address { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    public string ImgUrl { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    public bool Status { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("User")]
    public virtual ICollection<RefFeedback> RefFeedbacks { get; set; } = new List<RefFeedback>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; }
}