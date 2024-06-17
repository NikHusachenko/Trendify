namespace Trendify.Api.Domain.Handler.Workshop.GetSelectedList;

public sealed class WorkshopSelectedList
{
    public List<WorkshopSelectedItem> Items { get; set; } = new List<WorkshopSelectedItem>();
}

public sealed class WorkshopSelectedItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}