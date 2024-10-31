using Blazor.Share.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoCodeMauBlazor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
