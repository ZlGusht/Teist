namespace Teist.Web.ViewModels.TodoItems
{
    using System.ComponentModel.DataAnnotations;

    using Teist.Common.Mapping;
    using Teist.Data.Models;

    public class TodoItemBindingModel : IMapTo<TodoItem>
    {
        [Required]
        public string Title { get; set; }
    }
}
