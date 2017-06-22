using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Excavator.Models
{
    public class LinkIn
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
    }

    public class JobHistory
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public int? Duration { get; set; }
        public string Status { get; set; }
    }

    public class appContext : DbContext
    {
        public DbSet<LinkIn> linkIns { get; set; }
        public DbSet<JobHistory> JobHistorys { get; set; }

        public appContext(DbContextOptions<appContext> options) : base(options) {}
    }

    public class appContextFactory : IDbContextFactory<appContext>
    {
        appContext IDbContextFactory<appContext>.Create(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
