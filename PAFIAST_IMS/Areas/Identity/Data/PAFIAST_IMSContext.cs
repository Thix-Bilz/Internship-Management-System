using PAFIAST_IMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAFIAST_IMS.Data;

public class PAFIAST_IMSContext : IdentityDbContext<IdentityUser>
{

    public PAFIAST_IMSContext(DbContextOptions<PAFIAST_IMSContext> options) : base(options) {}
    public DbSet<FormC> FormC_IMS { get; set; }
    public DbSet<stdInfo> stdInfo_IMS { get; set; }
    public DbSet<AssignTask> AssignTask_IMS { get; set; }
    public DbSet<IEForm> IEForm_IMS { get; set; }
    public DbSet<Supervisor> Supervisor_IMS { get; set; }
    public DbSet<FacultyAdvisor> FacultyAdvisor_IMS { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //(localdb)\\mssqllocaldb
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PAFIAST_IMS");

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //one to many
        //builder.Entity<stdInfo>().HasOne<stdInfo>(s => s.Form_C).WithMany(f => f.FormCs).HasForeignKey(s => s.FormCId).OnDelete(DeleteBehavior.Cascade);
        builder.Entity<AssignTask>().HasOne<stdInfo>(s => s.stdinfo).WithMany(at => at.AssignTasks).HasForeignKey(s => s.stdinfoid);
        builder.Entity<FacultyAdvisor>().HasOne<stdInfo>(s => s.stdinfo).WithMany(at => at.FacultyAdvisors).HasForeignKey(s => s.stdinfoid);
        //builder.Entity<stdInfo>().HasOne<stdInfo>().WithMany().HasForeignKey();   
        //builder.Entity<FormC>().HasOne(ad => ad.StdInfo).WithMany(a => a.AttendanceDetails).HasForeignKey(ad => ad.AttendaceId);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);


        builder.Entity<FormC>().HasOne<stdInfo>(c => c.stdinfo).WithOne(std => std.FormCs).HasForeignKey<FormC>(c => c.stdinfoid);
        builder.Entity<Supervisor>().HasOne<stdInfo>(sup => sup.stdinfo).WithOne(s => s.Supervisors).HasForeignKey<Supervisor>(c => c.stdinfoid);
        builder.Entity<IEForm>().HasOne<stdInfo>(sup => sup.stdinfo).WithOne(s => s.IEForms).HasForeignKey<IEForm>(c => c.stdinfoid);
        //builder.Entity<ImageModel>().HasOne(img => img.HosteliteData).WithMany(hd => hd.ImageModels).HasForeignKey(img => img.hosteliteId);
    }
}
