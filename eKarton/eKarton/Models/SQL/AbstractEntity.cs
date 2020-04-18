using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKarton.Models
{
    public abstract class AbstractEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
