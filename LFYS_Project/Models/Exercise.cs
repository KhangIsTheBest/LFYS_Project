using System;
using System.Collections.Generic;

namespace LFYS_Project.Models;

public partial class Exercise
{
    public int ExerciseId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UserId { get; set; }

    public int? Ac { get; set; }

    public virtual ICollection<CategoryExercise> CategoryExercises { get; set; } = new List<CategoryExercise>();

    public virtual User? User { get; set; }
}
