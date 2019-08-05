﻿namespace Teist.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Teist.Common.Mapping;
    using Teist.Data.Common.Repositories;
    using Teist.Data.Models;
    using Teist.Web.Infrastructure.Extensions;
    using Teist.Web.ViewModels.TodoItems;

    using AutoMapper;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Mvc;

    public class TodoItemsController : BaseController
    {
        private readonly IDeletableEntityRepository<TodoItem> repository;

        public TodoItemsController(IDeletableEntityRepository<TodoItem> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult All()
        {
            var userId = this.User.GetId();
            var todoItems = this.repository.All().Where(t => t.AuthorId == userId).To<TodoItemViewModel>().ToList();

            return this.Ok(todoItems);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TodoItemBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetFirstError());
            }

            var todoItem = Mapper.Map<TodoItem>(model);
            todoItem.AuthorId = this.User.GetId();

            this.repository.Add(todoItem);
            await this.repository.SaveChangesAsync();

            return this.Ok(Mapper.Map<TodoItemViewModel>(todoItem));
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsDone(int id)
        {
            var todoItem = await this.repository.GetByIdAsync(id);

            if (todoItem == null)
            {
                return this.NotFound();
            }

            if (todoItem.AuthorId != this.User.GetId())
            {
                return this.Forbid(JwtBearerDefaults.AuthenticationScheme);
            }

            if (!todoItem.IsDone)
            {
                todoItem.IsDone = true;

                this.repository.Update(todoItem);
                await this.repository.SaveChangesAsync();
            }

            return this.Ok();
        }
    }
}
