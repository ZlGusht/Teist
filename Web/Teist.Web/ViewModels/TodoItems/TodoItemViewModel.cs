namespace Teist.Web.ViewModels.TodoItems
{
    using Teist.Common.Mapping;
    using Teist.Data.Models;

    public class TodoItemViewModel : IMapFrom<TodoItem>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }
    }
}
