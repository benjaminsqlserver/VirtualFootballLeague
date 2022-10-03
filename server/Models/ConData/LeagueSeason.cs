using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLeague.Models.ConData
{
  [Table("LeagueSeasons", Schema = "dbo")]
  public partial class LeagueSeason
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
    public int SeasonID
    {
      get;
      set;
    }

    public IEnumerable<VirtualLeagueResult> VirtualLeagueResults { get; set; }
    [ConcurrencyCheck]
    public string SeasonName
    {
      get;
      set;
    }
  }
}
