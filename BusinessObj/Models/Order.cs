﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObj.Models;

[Table("Order")]
public partial class Order
{
    [Key]
    [Column("OrderID")]
    [StringLength(20)]
    public string OrderId { get; set; }

    [Required]
    [Column("UserID")]
    [StringLength(20)]
    public string UserId { get; set; }

    [Column("PromotionID")]
    [StringLength(20)]
    public string PromotionId { get; set; }

    public double Total { get; set; }

    public int PaymentType { get; set; }

    [Required]
    [StringLength(100)]
    public string Address { get; set; }

    [Required]
    [MaxLength(11)]
    public byte[] Phonenumber { get; set; }

    [Required]
    [StringLength(30)]
    public string FullName { get; set; }

    [Column("LocationID")]
    public int LocationId { get; set; }

    public bool IsPayed { get; set; }

    [Column("Create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("Create_by")]
    [StringLength(20)]
    public string CreateBy { get; set; }

    [Column("Update_at", TypeName = "datetime")]
    public DateTime? UpdateAt { get; set; }

    [Column("Update_by")]
    [StringLength(20)]
    public string UpdateBy { get; set; }

    [Column("Delete_at", TypeName = "datetime")]
    public DateTime? DeleteAt { get; set; }

    [Column("Delete_by")]
    [StringLength(20)]
    public string DeleteBy { get; set; }

    public int? Status { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("Orders")]
    public virtual ShippingPrice Location { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("PromotionId")]
    [InverseProperty("Orders")]
    public virtual Promotion Promotion { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User User { get; set; }
}