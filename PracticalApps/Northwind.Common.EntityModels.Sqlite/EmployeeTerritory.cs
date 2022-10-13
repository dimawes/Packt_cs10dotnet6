using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace West.Shared
{
    [Keyless]
    public partial class EmployeeTerritory
    {
        public int EmployeeId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        public string TerritoryId { get; set; } = null!;
    }
}
