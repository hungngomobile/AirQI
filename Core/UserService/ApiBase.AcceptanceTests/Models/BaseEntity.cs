using System.ComponentModel.DataAnnotations;

namespace ApiBase.AcceptanceTests.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

    }
}