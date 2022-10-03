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

  [Route("odata/ConData/VirtualLeagueResults")]
  public partial class VirtualLeagueResultsController : ODataController
  {
    private VirtualLeague.Data.ConDataContext context;

    public VirtualLeagueResultsController(VirtualLeague.Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/VirtualLeagueResults
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.VirtualLeagueResult> GetVirtualLeagueResults()
    {
      var items = this.context.VirtualLeagueResults.AsQueryable<Models.ConData.VirtualLeagueResult>();
      this.OnVirtualLeagueResultsRead(ref items);

      return items;
    }

    partial void OnVirtualLeagueResultsRead(ref IQueryable<Models.ConData.VirtualLeagueResult> items);

    partial void OnVirtualLeagueResultGet(ref SingleResult<Models.ConData.VirtualLeagueResult> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/ConData/VirtualLeagueResults(RecordID={RecordID})")]
    public SingleResult<VirtualLeagueResult> GetVirtualLeagueResult(Int64 key)
    {
        var items = this.context.VirtualLeagueResults.Where(i=>i.RecordID == key);
        var result = SingleResult.Create(items);

        OnVirtualLeagueResultGet(ref result);

        return result;
    }
    partial void OnVirtualLeagueResultDeleted(Models.ConData.VirtualLeagueResult item);
    partial void OnAfterVirtualLeagueResultDeleted(Models.ConData.VirtualLeagueResult item);

    [HttpDelete("/odata/ConData/VirtualLeagueResults(RecordID={RecordID})")]
    public IActionResult DeleteVirtualLeagueResult(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.VirtualLeagueResults
                .Where(i => i.RecordID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.VirtualLeagueResult>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnVirtualLeagueResultDeleted(item);
            this.context.VirtualLeagueResults.Remove(item);
            this.context.SaveChanges();
            this.OnAfterVirtualLeagueResultDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnVirtualLeagueResultUpdated(Models.ConData.VirtualLeagueResult item);
    partial void OnAfterVirtualLeagueResultUpdated(Models.ConData.VirtualLeagueResult item);

    [HttpPut("/odata/ConData/VirtualLeagueResults(RecordID={RecordID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutVirtualLeagueResult(Int64 key, [FromBody]Models.ConData.VirtualLeagueResult newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.VirtualLeagueResults
                .Where(i => i.RecordID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.VirtualLeagueResult>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnVirtualLeagueResultUpdated(newItem);
            this.context.VirtualLeagueResults.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.VirtualLeagueResults.Where(i => i.RecordID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "LeagueSeason,MatchDay,Team,Team1");
            this.OnAfterVirtualLeagueResultUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/ConData/VirtualLeagueResults(RecordID={RecordID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchVirtualLeagueResult(Int64 key, [FromBody]Delta<Models.ConData.VirtualLeagueResult> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.VirtualLeagueResults.Where(i => i.RecordID == key);

            items = EntityPatch.ApplyTo<Models.ConData.VirtualLeagueResult>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnVirtualLeagueResultUpdated(item);
            this.context.VirtualLeagueResults.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.VirtualLeagueResults.Where(i => i.RecordID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "LeagueSeason,MatchDay,Team,Team1");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnVirtualLeagueResultCreated(Models.ConData.VirtualLeagueResult item);
    partial void OnAfterVirtualLeagueResultCreated(Models.ConData.VirtualLeagueResult item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.VirtualLeagueResult item)
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

            this.OnVirtualLeagueResultCreated(item);
            this.context.VirtualLeagueResults.Add(item);
            this.context.SaveChanges();

            var key = item.RecordID;

            var itemToReturn = this.context.VirtualLeagueResults.Where(i => i.RecordID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "LeagueSeason,MatchDay,Team,Team1");

            this.OnAfterVirtualLeagueResultCreated(item);

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
