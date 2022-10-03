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

  [Route("odata/ConData/MatchDays")]
  public partial class MatchDaysController : ODataController
  {
    private VirtualLeague.Data.ConDataContext context;

    public MatchDaysController(VirtualLeague.Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/MatchDays
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.MatchDay> GetMatchDays()
    {
      var items = this.context.MatchDays.AsQueryable<Models.ConData.MatchDay>();
      this.OnMatchDaysRead(ref items);

      return items;
    }

    partial void OnMatchDaysRead(ref IQueryable<Models.ConData.MatchDay> items);

    partial void OnMatchDayGet(ref SingleResult<Models.ConData.MatchDay> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/ConData/MatchDays(MatchDayID={MatchDayID})")]
    public SingleResult<MatchDay> GetMatchDay(int key)
    {
        var items = this.context.MatchDays.Where(i=>i.MatchDayID == key);
        var result = SingleResult.Create(items);

        OnMatchDayGet(ref result);

        return result;
    }
    partial void OnMatchDayDeleted(Models.ConData.MatchDay item);
    partial void OnAfterMatchDayDeleted(Models.ConData.MatchDay item);

    [HttpDelete("/odata/ConData/MatchDays(MatchDayID={MatchDayID})")]
    public IActionResult DeleteMatchDay(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.MatchDays
                .Where(i => i.MatchDayID == key)
                .Include(i => i.VirtualLeagueResults)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.MatchDay>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnMatchDayDeleted(item);
            this.context.MatchDays.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMatchDayDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMatchDayUpdated(Models.ConData.MatchDay item);
    partial void OnAfterMatchDayUpdated(Models.ConData.MatchDay item);

    [HttpPut("/odata/ConData/MatchDays(MatchDayID={MatchDayID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMatchDay(int key, [FromBody]Models.ConData.MatchDay newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.MatchDays
                .Where(i => i.MatchDayID == key)
                .Include(i => i.VirtualLeagueResults)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.MatchDay>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnMatchDayUpdated(newItem);
            this.context.MatchDays.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MatchDays.Where(i => i.MatchDayID == key);
            this.OnAfterMatchDayUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/ConData/MatchDays(MatchDayID={MatchDayID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMatchDay(int key, [FromBody]Delta<Models.ConData.MatchDay> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.MatchDays.Where(i => i.MatchDayID == key);

            items = EntityPatch.ApplyTo<Models.ConData.MatchDay>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnMatchDayUpdated(item);
            this.context.MatchDays.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MatchDays.Where(i => i.MatchDayID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMatchDayCreated(Models.ConData.MatchDay item);
    partial void OnAfterMatchDayCreated(Models.ConData.MatchDay item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.MatchDay item)
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

            this.OnMatchDayCreated(item);
            this.context.MatchDays.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConData/MatchDays/{item.MatchDayID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
