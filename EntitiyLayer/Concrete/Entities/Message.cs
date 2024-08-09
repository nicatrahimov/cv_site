﻿using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete.Entities;

public class Message
{
    [Key]
    public int MessageId { get; set; }
    public string? Name { get; set; }
    public string? Mail { get; set; }
    public string? Content { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}