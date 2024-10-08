﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObj.Models;

[Table("Product")]
public partial class Product
{
    [Key]
    [Column("ProductID")]
    [StringLength(20)]
    public string ProductId { get; set; }

    [Required]
    [StringLength(50)]
    public string ProductName { get; set; }

    [Required]
    [StringLength(200)]
    public string ProdutDesription { get; set; }

    public int ProductQuantity { get; set; }

    public double Price { get; set; }

    [Column("Custom_by")]
    [StringLength(20)]
    public string CustomBy { get; set; }

    [Column("Custom_at", TypeName = "datetime")]
    public DateTime? CustomAt { get; set; }

    [Column("Create_by")]
    [StringLength(20)]
    public string CreateBy { get; set; }

    [Column("Create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("Update_by")]
    [StringLength(20)]
    public string UpdateBy { get; set; }

    [Column("Update_at", TypeName = "datetime")]
    public DateTime? UpdateAt { get; set; }

    [Column("Delete_by")]
    [StringLength(20)]
    public string DeleteBy { get; set; }

    [Column("Delete_at", TypeName = "datetime")]
    public DateTime? DeleteAt { get; set; }

    public bool? Status { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<RefFeedback> RefFeedbacks { get; set; } = new List<RefFeedback>();

    [InverseProperty("Product")]
    public virtual ICollection<RefProductAttribute> RefProductAttributes { get; set; } = new List<RefProductAttribute>();

    [InverseProperty("Product")]
    public virtual ICollection<RefProductImg> RefProductImgs { get; set; } = new List<RefProductImg>();
}