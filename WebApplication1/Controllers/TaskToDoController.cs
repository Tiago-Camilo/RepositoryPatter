using Application.Interfaces.Services.Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Services.Domain;

namespace WebApplication1.Controllers
{
    public class TaskToDoController : Controller
    {
        private readonly ITaskToDoService _taskToDoService;

        public TaskToDoController(ITaskToDoService taskToDoService)
        {
            _taskToDoService = taskToDoService;
        }

        // GET: TaskToDo/Create/{userId}
        public IActionResult Create(int? userId)
        {
            ViewData["UserId"] = userId;
            return View();
        }

        // POST: TaskToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Start,DeadLine,UserId")] TaskToDo taskToDo)
        {
            if (!ModelState.IsValid)
            {
                await _taskToDoService.AddAsync(taskToDo);
                return RedirectToAction("Index",
                      new RouteValueDictionary(
                          new { controller = "User", action = "Index", Id = taskToDo.UserId }));
            }
            ViewData["UserId"] = taskToDo.UserId;
            return View(taskToDo);
        }

        // GET: TaskToDo/Edit/{taskId}
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var taskToDo = await _taskToDoService.GetByIdIncludingUserAsync(id.Value);
            if (taskToDo == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = taskToDo.UserId;
            return View(taskToDo);
        }

        // POST: TaskToDo/Edit/{taskId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Start,DeadLine,UserId")] TaskToDo taskToDo)
        {
            if (id != taskToDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                ViewData["UserId"] = taskToDo.UserId;
                return View(taskToDo);
            }

            try
            {
                var existingTask = await _taskToDoService.GetByIdAsync(id);
                if (existingTask == null)
                {
                    return NotFound();
                }

                existingTask.Title = taskToDo.Title;
                existingTask.Start = taskToDo.Start;
                existingTask.DeadLine = taskToDo.DeadLine;

                await _taskToDoService.UpdateAsync(existingTask);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _taskToDoService.Exists(id))
                {
                    return NotFound();
                }else
                {
                    throw;
                }
            }

            return RedirectToAction("Index", "User", new {Id = taskToDo.UserId});
        }

        // GET: TaskToDo/Delete/{taskId}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskToDo = await _taskToDoService.GetByIdAsync(id);

            if (taskToDo == null)
            {
                return NotFound();
            }

            return View(taskToDo);
        }

        // POST: TaskToDo/Delete/{taskId}/{userId}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int userId)
        {
            var taskToDo = await _taskToDoService.RemoveAsync(id);
            return RedirectToAction("Index",
                      new RouteValueDictionary(
                          new { controller = "User", action = "Index", Id = userId }));
        }

        // POST: TaskToDo/Complete/{taskId}/{userId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Complete(int id, int userId)
        {
            await _taskToDoService.UpdateStatusAsync(id, true);
            return RedirectToAction("Index",
                      new RouteValueDictionary(
                          new { controller = "User", action = "Index", Id = userId }));
        }
    }
}
