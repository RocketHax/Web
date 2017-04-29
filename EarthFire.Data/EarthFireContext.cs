using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EarthFire.Model.Entities;

namespace EarthFire.Data
{
  public class EarthFireContext : DbContext
  {
    public System.Data.Entity.DbSet<GeoLocation> GeoLocations { get; set; }

    public EarthFireContext(string nameOrConnectionString) : base(nameOrConnectionString)
    {
      Database.SetInitializer<EarthFireContext>(new CreateDatabaseIfNotExists<EarthFireContext>());
      Database.SetInitializer<EarthFireContext>(new DropCreateDatabaseIfModelChanges<EarthFireContext>());

      //Database.SetInitializer<EarthFireContext>(new DropCreateDatabaseAlways<EarthFireContext>());
      //Database.SetInitializer<EarthFireContext>(new SchoolDBInitializer());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
      //{
      //  relationship.DeleteBehavior = DeleteBehavior.Restrict;
      //}

      //modelBuilder.Entity<GeoLocation>().ToTable("GeoLocation");
      //modelBuilder.Entity<GeoLocation>().Property(s => s.Latitude).IsRequired();
      //modelBuilder.Entity<GeoLocation>().Property(s => s.Latitude).IsRequired();
      //modelBuilder.Entity<Schedule>().Property(s => s.DateCreated).HasDefaultValue(DateTime.Now);
      //modelBuilder.Entity<Schedule>().Property(s => s.DateUpdated).HasDefaultValue(DateTime.Now);
      //modelBuilder.Entity<Schedule>().Property(s => s.Type).HasDefaultValue(ScheduleType.Work);
      //modelBuilder.Entity<Schedule>().Property(s => s.Status).HasDefaultValue(ScheduleStatus.Valid);
      //modelBuilder.Entity<Schedule>().HasOne(s => s.Creator).WithMany(c => c.SchedulesCreated);

      //modelBuilder.Entity<User>().ToTable("User");
      //modelBuilder.Entity<User>().Property(u => u.Name).HasMaxLength(100).IsRequired();

      //modelBuilder.Entity<Attendee>()
      //    .ToTable("Attendee");

      //modelBuilder.Entity<Attendee>()
      //    .HasOne(a => a.User)
      //    .WithMany(u => u.SchedulesAttended)
      //    .HasForeignKey(a => a.UserId);

      //modelBuilder.Entity<Attendee>()
      //    .HasOne(a => a.Schedule)
      //    .WithMany(s => s.Attendees)
      //    .HasForeignKey(a => a.ScheduleId);

    }
  }
}
