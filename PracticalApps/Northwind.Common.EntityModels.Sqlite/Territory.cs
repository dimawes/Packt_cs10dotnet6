﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace West.Shared
{
    [Keyless]
    public partial class Territory
    {
        [Required]
        [Column(TypeName = "nvarchar")]
        public string TerritoryId { get; set; } = null!;
        [Required]
        [Column(TypeName = "nchar")]
        public string TerritoryDescription { get; set; } = null!;
        [Column(TypeName = "int")]
        public int RegionId { get; set; }
    }
}
