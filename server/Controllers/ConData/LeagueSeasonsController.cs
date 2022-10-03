using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;




namespace VirtualLeague.Controllers.ConData
{
  using Models;
  using Data;
  using Models.ConData;

  [Route("odata/ConData/LeagueSeasons")]
  public partial class LeagueSeasonsController : ODataController
  {
    private VirtualLeague.Data.ConDataContext context;

    public LeagueSeasonsController(VirtualLeague.Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/LeagueSeasons
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.LeagueSeason> GetLeagueSeasons()
    {
      var items = this.context.LeagueSeasons.AsQueryable<Models.ConData.LeagueSeason>();
      this.OnLeagueSeasonsRead(ref items);

      return items;
    }

    partial void OnLeagueSeasonsRead(ref IQueryable<Models.ConData.LeagueSeason> items);

    partial void OnLeagueSeasonGet(ref SingleResult<Models.ConData.LeagueSeason> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/ConData/LeagueSeasons(SeasonID={SeasonID})")]
    public SingleResult<LeagueSeason> GetLeagueSeason(int key)
    {
        var items = this.context.LeagueSeasons.Where(i=>i.SeasonID == key);
        var result = SingleResult.Create(items);

        OnLeagueSeasonGet(ref result);

        return result;
    }
    partial void OnLeagueSeasonDeleted(Models.ConData.LeagueSeason item);
    partial void OnAfterLeagueSeasonDeleted(Models.ConData.LeagueSeason item);

    [HttpDelete("/odata/ConData/LeagueSeasons(SeasonID={SeasonID})")]
    public IActionResult DeleteLeagueSeason(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.LeagueSeasons
                .Where(i => i.SeasonID == key)
                .Include(i => i.VirtualLeagueResults)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.LeagueSeason>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnLeagueSeasonDeleted(item);
            this.context.LeagueSeasons.Remove(item);
            this.context.SaveChanges();
            this.OnAfterLeagueSeasonDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnLeagueSeasonUpdated(Models.ConData.LeagueSeason item);
    partial void OnAfterLeagueSeasonUpdated(Models.ConData.LeagueSeason item);

    [HttpPut("/odata/ConData/LeagueSeasons(SeasonID={SeasonID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutLeagueSeason(int key, [FromBody]Models.ConData.LeagueSeason newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.LeagueSeasons
                .Where(i => i.SeasonID == key)
                .Include(i => i.VirtualLeagueResults)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.LeagueSeason>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnLeagueSeasonUpdated(newItem);
            this.context.LeagueSeasons.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.LeagueSeasons.Where(i => i.SeasonID == key);
            this.OnAfterLeagueSeasonUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/ConData/LeagueSeasons(SeasonID={SeasonID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchLeagueSeason(int key, [FromBody]Delta<Models.ConData.LeagueSeason> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.LeagueSeasons.Where(i => i.SeasonID == key);

            items = EntityPatch.ApplyTo<Models.ConData.LeagueSeason>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnLeagueSeasonUpdated(item);
            this.context.LeagueSeasons.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.LeagueSeasons.Where(i => i.SeasonID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnLeagueSeasonCreated(Models.ConData.LeagueSeason item);
    partial void OnAfterLeagueSeasonCreated(Models.ConData.LeagueSeason item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.LeagueSeason item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnLeagueSeasonCreated(item);
            this.context.LeagueSeasons.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConData/LeagueSeasons/{item.SeasonID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
