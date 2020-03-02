using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyApplication.EntityFrameworkCore
{
    public static class MyApplicationDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyApplicationDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyApplicationDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
