using System;

namespace Models
{
    public class Achievement : IKey
    {
        public Guid Id { get; set; }
        public string Headline { get; set; }
        public string UserName { get; set; }
        public string Count { get; set; }
        public string Type { get; set; }
    }
}