using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLeague.Models.ConData
{
  [Table("VirtualLeagueResults", Schema = "dbo")]
  public partial class VirtualLeagueResult
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
    public Int64 RecordID
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int SeasonID
    {
      get;
      set;
    }
    public LeagueSeason LeagueSeason { get; set; }
    [ConcurrencyCheck]
    public int MatchDayID
    {
      get;
      set;
    }
    public MatchDay MatchDay { get; set; }
    [ConcurrencyCheck]
    public int HomeTeamID
    {
      get;
      set;
    }
    public Team Team { get; set; }
    [ConcurrencyCheck]
    public int HomeScore
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int AwayTeamID
    {
      get;
      set;
    }
    public Team Team1 { get; set; }
    [ConcurrencyCheck]
    public int AwayScore
    {
      get;
      set;
    }
  }
}
