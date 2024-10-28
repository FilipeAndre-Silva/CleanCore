namespace CleanCore.Domain.Entities.Base;

public abstract class EntityBase
{
    public int Id { get; private set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public bool IsActive { get; private set; }

    public void SetCreatedDate()
    {
        CreatedDate = DateTime.Now;
    }

    public void SetLastModifiedDate()
    {
        LastModifiedDate = DateTime.Now;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Disable()
    {
        IsActive = true;
    }
}