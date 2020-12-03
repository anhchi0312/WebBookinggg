namespace WebBooking.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBconect : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DatGoi> DatGois { get; set; }
        public DbSet<Goi> Gois { get; set; }
        public DbSet<New> News { get; set; }
        public DBconect()
            : base("name=DBconect")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
