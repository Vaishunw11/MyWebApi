using MyWebApi.Core.entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyWebApi.Entity
{
    [Table("Departments")]
    public class Departments
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        public string? DepartmentName { get; set; }

        public bool IsActive { get; set; } = false;

        //        [JsonIgnore]
        //        public Users? user { get; set; }
    }
}
