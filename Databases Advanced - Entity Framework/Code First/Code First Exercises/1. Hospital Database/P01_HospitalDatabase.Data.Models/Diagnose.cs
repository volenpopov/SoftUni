
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    [Table("Diagnoses")]
    public class Diagnose
    {
        public int DiagnoseId { get; set; }

        //[MaxLength(50)]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }

        //[MaxLength(250)]
        [Column(TypeName = "NVARCHAR(250)")]
        public string Comments { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
