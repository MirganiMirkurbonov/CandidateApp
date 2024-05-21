using Domain.Context.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntityState = Domain.Enumerators.EntityState;

namespace Domain.Context.Configurations;

public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();
        
        builder.HasIndex(x => x.LinkedinProfileUrl).IsUnique();
        
        builder.HasIndex(x => x.GithubProfileUrl).IsUnique();
        
        builder.Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20);
        
        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.GithubProfileUrl)
            .HasMaxLength(200);

        builder.Property(x => x.LinkedinProfileUrl)
            .HasMaxLength(200);

        builder.Property(x => x.Comment)
            .HasMaxLength(500)
            .IsRequired();

        builder.HasQueryFilter(x => x.State != EntityState.Deleted);
    }
}