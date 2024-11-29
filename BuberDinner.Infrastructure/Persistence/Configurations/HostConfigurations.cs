using BuberDinner.Domain.HostAggregate;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;
public class HostConfigurations : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        ConfigureHostsTable(builder);
        ConfigureHostDinnerIdsTable(builder);
        ConfigureHostMenuIdsTable(builder);
    }

    private static void ConfigureHostsTable(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");
        builder.HasKey(host => host.Id);
        builder.Property(host => host.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));
        builder.Property(h => h.FirstName)
            .HasMaxLength(50);
        builder.Property(h => h.LastName)
            .HasMaxLength(50);
        builder.Property(h => h.ProfileImage)
            .HasMaxLength(255);
        builder.OwnsOne(host => host.AverageRating);
        builder.Property(h => h.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
    }

    private static void ConfigureHostMenuIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(h => h.MenuIds, mib =>
        {
            mib.WithOwner().HasForeignKey("HostId");
            mib.ToTable("HostMenuIds");
            mib.HasKey("Id");
            mib.Property(mi => mi.Value)
                .HasColumnName("HostMenuId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Host.MenuIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureHostDinnerIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(h => h.DinnerIds, mib =>
        {
            mib.WithOwner().HasForeignKey("DinnerId");
            mib.ToTable("HostDinnerIds");
            mib.HasKey("Id");
            mib.Property(mi => mi.Value)
                .HasColumnName("HostDinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Host.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
