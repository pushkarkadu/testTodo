namespace MyApplication.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly MyApplicationDbContext _context;

        public InitialHostDbBuilder(MyApplicationDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new ToDoListDefaultDataCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
