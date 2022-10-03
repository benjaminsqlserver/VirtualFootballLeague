using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLeague.Models.ConData
{
  [Table("FixtureTemplates", Schema = "dbo")]
  public partial class FixtureTemplate
  {
    [NotMapped]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("@odata.etag")]
    public string ETag
    {
        get;
        set;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TemplateID
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string HomeTeam
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string AwayTeam
    {
      get;
      set;
    }
  }
}
