using TodoApp.Models;

namespace TodoApp.Services;

public class TodoService
{
    private List<TodoItem> _todoItems = new();

    public IEnumerable<TodoItem> GetAllItems() => _todoItems;

    public IEnumerable<TodoItem> GetCompletedItems() => _todoItems.Where(item => item.IsDone);

    public IEnumerable<TodoItem> GetActiveItems() => _todoItems.Where(item => !item.IsDone);

    public void AddItem(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return;

        _todoItems.Add(new TodoItem { Title = title });
    }

    public void ToggleItemStatus(Guid id)
    {
        var item = _todoItems.FirstOrDefault(item => item.Id == id);
        if (item != null)
        {
            item.IsDone = !item.IsDone;
        }
    }

    public void RemoveItem(Guid id)
    {
        var item = _todoItems.FirstOrDefault(item => item.Id == id);
        if (item != null)
        {
            _todoItems.Remove(item);
        }
    }

    public void ClearCompletedItems()
    {
        _todoItems.RemoveAll(item => item.IsDone);
    }
}
