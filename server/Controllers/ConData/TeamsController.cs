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

  [Route("odata/ConData/Teams")]
  public partial class TeamsController : ODataController
  {
    private VirtualLeague.Data.ConDataContext context;

    public TeamsController(VirtualLeague.Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/Teams
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.Team> GetTeams()
    {
      var items = this.context.Teams.AsQueryable<Models.ConData.Team>();
      this.OnTeamsRead(ref items);

      return items;
    }

    partial void OnTeamsRead(ref IQueryable<Models.ConData.Team> items);

    partial void OnTeamGet(ref SingleResult<Models.ConData.Team> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/ConData/Teams(TeamID={TeamID})")]
    public SingleResult<Team> GetTeam(int key)
    {
        var items = this.context.Teams.Where(i=>i.TeamID == key);
        var result = SingleResult.Create(items);

        OnTeamGet(ref result);

        return result;
    }
    partial void OnTeamDeleted(Models.ConData.Team item);
    partial void OnAfterTeamDeleted(Models.ConData.Team item);

    [HttpDelete("/odata/ConData/Teams(TeamID={TeamID})")]
    public IActionResult DeleteTeam(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.Teams
                .Where(i => i.TeamID == key)
                .Include(i => i.VirtualLeagueResults)
                .Include(i => i.VirtualLeagueResults1)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.Team>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnTeamDeleted(item);
            this.context.Teams.Remove(item);
            this.context.SaveChanges();
            this.OnAfterTeamDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnTeamUpdated(Models.ConData.Team item);
    partial void OnAfterTeamUpdated(Models.ConData.Team item);

    [HttpPut("/odata/ConData/Teams(TeamID={TeamID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutTeam(int key, [FromBody]Models.ConData.Team newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Teams
                .Where(i => i.TeamID == key)
                .Include(i => i.VirtualLeagueResults)
                .Include(i => i.VirtualLeagueResults1)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.Team>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnTeamUpdated(newItem);
            this.context.Teams.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Teams.Where(i => i.TeamID == key);
            this.OnAfterTeamUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/ConData/Teams(TeamID={TeamID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchTeam(int key, [FromBody]Delta<Models.ConData.Team> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Teams.Where(i => i.TeamID == key);

            items = EntityPatch.ApplyTo<Models.ConData.Team>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnTeamUpdated(item);
            this.context.Teams.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Teams.Where(i => i.TeamID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnTeamCreated(Models.ConData.Team item);
    partial void OnAfterTeamCreated(Models.ConData.Team item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.Team item)
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

            this.OnTeamCreated(item);
            this.context.Teams.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConData/Teams/{item.TeamID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
