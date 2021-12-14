using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoListFoTheDay.Models
{
    public class TodoList
    { 

    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "День недели", Order = 5)]
    public string Weekday { get; set; }
  
    [Display(Name = "Время", Order = 10)]
    public DateTime Time { get; set; }

    [Required]
    [Display(Name = "Жесткие дела", Order = 20)]
    public string Hard { get; set; }

    [Required]
    [Display(Name = "Гипкие дела", Order = 30)]
    public string Flex { get; set; }

    [ScaffoldColumn(false)]
    public DateTime CreateAt { get; set; }

    }
}