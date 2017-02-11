using Xunit;

namespace TodoApi.Models
{
    public class TodoRepositoryTests
    {

        private ITodoRepository _repository;

        public TodoRepositoryTests()
        {
            _repository = new TodoRepository();
        }

        [Fact]
        public void CanFindANewlyAddedTodoItem()
        {
            //Given
            _repository.Add(new TodoItem {TodoItemID="abc", Name = "Some Random Todo", IsComplete = false });
            //When
            TodoItem foundItem = _repository.Find("abc");
            //Then
            Assert.NotNull(foundItem);
        }
    }
}