namespace TodoApi.Data
{
    public class DbInitializer
    {
        public void Initialize(TodoContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}