using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Inva.LawMax.Domain.Entities;

namespace Inva.LawMax.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class LawMaxDbContext :
    AbpDbContext<LawMaxDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    public DbSet<Lawyer> Lawyers { get; set; }
    public DbSet<Case> Cases { get; set; }
    public DbSet<Hearing> Hearings { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext 
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext .
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public LawMaxDbContext(DbContextOptions<LawMaxDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();
        
   

        builder.Entity<Lawyer>(b =>
        {
            b.ToTable("Lawyers");
            b.HasKey(l => l.Id);
            b.Property(l => l.Name).IsRequired().HasMaxLength(100);
            b.Property(l => l.Position).HasMaxLength(50);
            b.Property(l => l.Mobile).HasMaxLength(15);
            b.Property(l => l.Address).HasMaxLength(250);
        });

        builder.Entity<Case>(b =>
        {
            b.ToTable("Cases");
            b.HasKey(c => c.Id);
            b.Property(c => c.Number).IsRequired().HasMaxLength(50);
            b.Property(c => c.Year).IsRequired();
            b.Property(c => c.LitigationDegree).HasMaxLength(100);
            b.Property(c => c.FinalVerdict).HasMaxLength(500);
            b.HasOne(c => c.Lawyer)
             .WithMany()
             .HasForeignKey(c => c.LaywerId);
        });

        builder.Entity<Hearing>(b =>
        {
            b.ToTable("Hearings");
            b.HasKey(h => h.Id);
            b.Property(h => h.Date).IsRequired();
            b.Property(h => h.Decision).HasMaxLength(500);
            b.HasOne(h => h.Case)
             .WithMany(c => c.Hearings)
             .HasForeignKey(h => h.CaseId);
        });
        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(LawMaxConsts.DbTablePrefix + "YourEntities", LawMaxConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
