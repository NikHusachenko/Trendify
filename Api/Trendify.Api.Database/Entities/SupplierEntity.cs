namespace Trendify.Api.Database.Entities;

public sealed record SupplierEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public Guid CredentialsId { get; set; }
    public CredentialsEntity Credentials { get; set; }

    public List<SupplyEntity> Suppliers { get; set; } = new List<SupplyEntity>();
}