namespace Deloitte.Task.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Deloitte.Task.DomainModel;
    using Deloitte.Task.DomainModel.Abstractions;
    using Deloitte.Task.Web.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Initializes a new instance of the <see cref="ToDoItemController"/> class.
    /// </summary>
    public class ToDoItemController : Controller
    {
        private readonly ITaskDetailsProvider _taskdetails;

        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoItemController"/> class.
        /// </summary>
        /// <param name="itaskdetails">Task Details Provider interface.</param>
        /// <param name="mapper">IMapper object.</param>
        public ToDoItemController(ITaskDetailsProvider itaskdetails, IMapper mapper)
        {
            this._taskdetails = itaskdetails;
            this._mapper = mapper;
        }

        private string GetSessionString()
        {
            string strUserName = this.HttpContext.Session.GetString("userName");
            return strUserName;
        }

        // GET: ToDoItems
        public async Task<ActionResult<IEnumerable<ToDoItemViewModel>>> Index()
        {
            if (this.GetSessionString() == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var taskDetails = this._taskdetails.GetTaskDetails().ToList();

            if (taskDetails.Any())
            {
                var model = this._mapper.Map<List<ToDoItemViewModel>>(taskDetails);
                return this.View(model);
            }

            return this.View();
        }

        // GET: ToDoItems/Create
        public IActionResult Create()
        {
            if (this.GetSessionString() == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        // POST: ToDoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// New task creation (Task Name, Description).
        /// </summary>
        /// <param name="todoitems">Web model view object.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskName,TaskDescription,IsTaskChecked")] ToDoItemViewModel todoitems)
        {
            if (this.GetSessionString() == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            if (this.ModelState.IsValid)
            {
                var model = this._mapper.Map<ToDoItemViewModel, TaskDetailsDomain>(todoitems);
                model.LastUpdatedDate = DateTime.Now;
                this._taskdetails.CreateTask(model);
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(todoitems);
        }

        // GET: ToDoItems/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (this.GetSessionString() == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return this.NotFound();
            }

            var model = this._mapper.Map<TaskDetailsDomain, ToDoItemViewModel>(this._taskdetails.GetTaskDetailsById(id));
            if (model == null)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(model);
        }

        // POST: ToDoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskName,TaskDescription,IsTaskChecked")] ToDoItemViewModel todoitems)
        {
            if (this.GetSessionString() == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var model = this._mapper.Map<ToDoItemViewModel, TaskDetailsDomain>(todoitems);
                model.Id = id;
                model.LastUpdatedDate = DateTime.Now;
                this._taskdetails.UpdateTaskDetails(model);
                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                return this.View(todoitems);
            }
        }

        // GET: ToDoItems/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (this.GetSessionString() == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return this.NotFound();
            }

            var model = this._mapper.Map<TaskDetailsDomain, ToDoItemViewModel>(this._taskdetails.GetTaskDetailsById(id));
            if (model == null)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(model);
        }

        /// <summary>
        /// Performing delete action.
        /// </summary>
        /// <param name="id">Sending task id as parameter.</param>
        /// <returns>Page return to Task List grid.</returns>
        // POST: ToDoItems/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (this.GetSessionString() == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return this.NotFound();
            }

            this._taskdetails.DeleteTaskdetails(id);

            var taskDetails = this._taskdetails.GetTaskDetails().ToList();
            var model = this._mapper.Map<List<ToDoItemViewModel>>(taskDetails);
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
