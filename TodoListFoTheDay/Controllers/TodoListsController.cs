using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoListFoTheDay.Models;

namespace TodoListFoTheDay.Controllers
{
    public class TodoListsController : Controller
    {
        
        public ActionResult Index()
        {
            WeekContext db = new WeekContext();
            var todoLists = db.TodoLists.ToList();
            return View(todoLists);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var todoList = new TodoList();
            return View(todoList);
        }

        [HttpPost]
        public ActionResult Create(TodoList model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var db = new WeekContext();
            db.TodoLists.Add(model);
            model.CreateAt = DateTime.Now;

            db.SaveChanges();
            return RedirectPermanent("/TodoLists/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new WeekContext();
            var todoList = db.TodoLists.FirstOrDefault(x => x.Id == id);
            if (todoList == null)
                return RedirectPermanent("/TodoLists/Index");

            db.TodoLists.Remove(todoList);
            db.SaveChanges();

            return RedirectPermanent("/TodoLists/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new WeekContext();
            var todoList = db.TodoLists.FirstOrDefault(x => x.Id == id);
            if (todoList == null)
                return RedirectPermanent("TodoLists/Index");

            return View(todoList);
        }

        [HttpPost]
        public ActionResult Edit(TodoList model)
        {
            var db = new WeekContext();
            var todoList = db.TodoLists.FirstOrDefault(x => x.Id == model.Id);
            if (todoList == null)
                ModelState.AddModelError("Id", "Список не найдена");

            if (!ModelState.IsValid)
                return View(model);

            MappingTodoList(model, todoList);

            db.Entry(todoList).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/TodoLists/Index");
        }

        private void MappingTodoList(TodoList sourse, TodoList destination)
        {
            destination.Weekday = sourse.Weekday;
            destination.Time = sourse.Time;
            destination.Hard = sourse.Hard;
            destination.Flex = sourse.Flex;
        }
    }
}