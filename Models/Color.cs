using System;
using System.Collections.Generic;

namespace maibagamofisa.Models;

public partial class Color
{
    public int ColorId { get; set; }

    public string EnglishName { get; set; } = null!;

    public string GermanName { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public int? LessonId { get; set; }

    public virtual VocabularyLesson? Lesson { get; set; }
}
