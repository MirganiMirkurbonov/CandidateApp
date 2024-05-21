using Domain.Context.Tables;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context;

public partial class EntityContext
{
    public virtual DbSet<Candidate> Candidates { get; set; }
}