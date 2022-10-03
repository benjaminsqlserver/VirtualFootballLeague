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

  [Route("odata/ConData/FixtureTemplates")]
  public partial class FixtureTemplatesController : ODataController
  {
    private VirtualLeague.Data.ConDataContext context;

    public FixtureTemplatesController(VirtualLeague.Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/FixtureTemplates
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.FixtureTemplate> GetFixtureTemplates()
    {
      var items = this.context.FixtureTemplates.AsQueryable<Models.ConData.FixtureTemplate>();
      this.OnFixtureTemplatesRead(ref items);

      return items;
    }

    partial void OnFixtureTemplatesRead(ref IQueryable<Models.ConData.FixtureTemplate> items);

    partial void OnFixtureTemplateGet(ref SingleResult<Models.ConData.FixtureTemplate> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/ConData/FixtureTemplates(TemplateID={TemplateID})")]
    public SingleResult<FixtureTemplate> GetFixtureTemplate(int key)
    {
        var items = this.context.FixtureTemplates.Where(i=>i.TemplateID == key);
        var result = SingleResult.Create(items);

        OnFixtureTemplateGet(ref result);

        return result;
    }
    partial void OnFixtureTemplateDeleted(Models.ConData.FixtureTemplate item);
    partial void OnAfterFixtureTemplateDeleted(Models.ConData.FixtureTemplate item);

    [HttpDelete("/odata/ConData/FixtureTemplates(TemplateID={TemplateID})")]
    public IActionResult DeleteFixtureTemplate(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.FixtureTemplates
                .Where(i => i.TemplateID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.FixtureTemplate>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnFixtureTemplateDeleted(item);
            this.context.FixtureTemplates.Remove(item);
            this.context.SaveChanges();
            this.OnAfterFixtureTemplateDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnFixtureTemplateUpdated(Models.ConData.FixtureTemplate item);
    partial void OnAfterFixtureTemplateUpdated(Models.ConData.FixtureTemplate item);

    [HttpPut("/odata/ConData/FixtureTemplates(TemplateID={TemplateID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutFixtureTemplate(int key, [FromBody]Models.ConData.FixtureTemplate newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.FixtureTemplates
                .Where(i => i.TemplateID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.FixtureTemplate>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnFixtureTemplateUpdated(newItem);
            this.context.FixtureTemplates.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.FixtureTemplates.Where(i => i.TemplateID == key);
            this.OnAfterFixtureTemplateUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/ConData/FixtureTemplates(TemplateID={TemplateID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchFixtureTemplate(int key, [FromBody]Delta<Models.ConData.FixtureTemplate> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.FixtureTemplates.Where(i => i.TemplateID == key);

            items = EntityPatch.ApplyTo<Models.ConData.FixtureTemplate>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnFixtureTemplateUpdated(item);
            this.context.FixtureTemplates.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.FixtureTemplates.Where(i => i.TemplateID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnFixtureTemplateCreated(Models.ConData.FixtureTemplate item);
    partial void OnAfterFixtureTemplateCreated(Models.ConData.FixtureTemplate item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.FixtureTemplate item)
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

            this.OnFixtureTemplateCreated(item);
            this.context.FixtureTemplates.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConData/FixtureTemplates/{item.TemplateID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
