using System.ComponentModel.DataAnnotations;

namespace PIPlatform.UserManager.DomainModel
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
