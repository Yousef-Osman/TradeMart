using System.ComponentModel.DataAnnotations;

namespace TradeMart.Domian;
internal class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
        Created = DateTime.Now;
        LastModified = DateTime.Now;
    }

    [Key, StringLength(50)]
    public string Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
    public DateTime? Deleted { get; set; }
    public bool IsDeleted { get; set; } = false;
}
