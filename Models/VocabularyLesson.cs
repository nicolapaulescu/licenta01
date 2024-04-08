using System;
using System.Collections.Generic;

namespace maibagamofisa.Models;

public partial class VocabularyLesson
{
    public int LessonId { get; set; }

    public string LessonName { get; set; } = null!;

    public string CoverImagePath { get; set; } = null!;

    public string? GermanLessonName { get; set; }

    public virtual ICollection<Color> Colors { get; set; } = new List<Color>();
    public virtual ICollection<Fruit> Fruits { get; set; } = new List<Fruit>();
}
