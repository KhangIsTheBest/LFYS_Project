using System;
using System.Collections.Generic;

namespace LFYS_Project.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string? Message { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
