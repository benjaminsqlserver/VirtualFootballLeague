using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLeague.Models.ConData
{
  [Table("Teams", Schema = "dbo")]
  public partial class Team
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
    public int TeamID
    {
      get;
      set;
    }

    public IEnumerable<VirtualLeagueResult> VirtualLeagueResults { get; set; }
    public IEnumerable<VirtualLeagueResult> VirtualLeagueResults1 { get; set; }
    [ConcurrencyCheck]
    public string TeamName
    {
      get;
      set;
    }
  }
}
