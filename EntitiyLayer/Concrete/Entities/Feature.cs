using System.ComponentModel.DataAnnotations;

namespace EntitiyLayer.Concrete;

public class Feature
{
    [Key]
    public int FeatureId { get; set; }
    public string Header { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
}   