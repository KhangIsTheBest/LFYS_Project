﻿using System;
using System.Collections.Generic;

namespace LFYS_Project.Models;

public partial class Badge
{
    public int BadgeId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
}
