using System;
using System.Collections.Generic;

namespace DigimonApi.Models
{
    public partial class DigiInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Ability { get; set; }
        public string Stage { get; set; }
        public string Attribute { get; set; }
        public int? Memory { get; set; }
        public int? EquipSlots { get; set; }
        public int? Hp { get; set; }
        public int? Sp { get; set; }
        public int? Atk { get; set; }
        public int? Def { get; set; }
        public int? Spd { get; set; }
        public int? DigiId { get; set; }

        public virtual DigiDex Digi { get; set; }
    }
}
