using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodoListFoTheDay.Models
{
    public class WeekContext : DbContext
    {
        public DbSet<TodoList> TodoLists { get; set; }
        public WeekContext() : base("TodoListFoTheDayEntity")
        { }
    }
}