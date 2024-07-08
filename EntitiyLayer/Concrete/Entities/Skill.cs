﻿using System.ComponentModel.DataAnnotations;

namespace EntitiyLayer.Concrete;

public class Skill
{
    [Key]
    public int SkillId { get; set; }
    public string Title { get; set; }
    public string Value { get; set; }
}