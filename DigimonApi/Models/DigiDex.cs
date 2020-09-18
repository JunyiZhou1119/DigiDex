using System;
using System.Collections.Generic;

namespace DigimonApi.Models
{
    public partial class DigiDex
    {
        public DigiDex()
        {
            DigiInfo = new HashSet<DigiInfo>();
        }

        public int DigiId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DigiInfo> DigiInfo { get; set; }
    }
}
