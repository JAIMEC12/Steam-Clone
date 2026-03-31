using System;
using System.Collections.Generic;

namespace Steam.Domain.Database.SqlServer.Entities;

public partial class Publisher
{
    public Guid PublisherId { get; set; }

    public string? PublisherName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
