using System;
using System.Collections.Generic;

namespace Models
{
    public class AchievementsView : IKey
    {
        public Guid Id { get; set; }
        public List<Achievement> Achievements { get; set; }
    }
}