using Microsoft.EntityFrameworkCore;
using Persistence.Context.Tables;

namespace Persistence.Context;

public partial class EntityContext
{
    public virtual DbSet<Candidate> Candidates { get; set; }
}