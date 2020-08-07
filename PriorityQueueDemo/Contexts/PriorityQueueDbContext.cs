using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Marques.EFCore.SnakeCase;
using Microsoft.EntityFrameworkCore;
using PriorityQueueDemo.Models;

namespace PriorityQueueDemo.Contexts
{
    [ExcludeFromCodeCoverage]
    public class PriorityQueueDbContext : DbContext
    {
        public PriorityQueueDbContext()
        {
            
        }

        public PriorityQueueDbContext(DbContextOptions<PriorityQueueDbContext> options) : base(options)
        {
        }
        
        public virtual DbSet<QueueType> QueueType { get; set; }
        public virtual DbSet<PriorityQueue> PriorityQueue { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ToSnakeCase();
        }
    }
}