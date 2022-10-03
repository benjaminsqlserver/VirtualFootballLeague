using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualLeague.Data;

namespace VirtualLeague
{
    public partial class ExportConDataController : ExportController
    {
        private readonly ConDataContext context;
        public ExportConDataController(ConDataContext context)
        {
            this.context = context;
        }

        [HttpGet("/export/ConData/fixturetemplates/csv")]
        [HttpGet("/export/ConData/fixturetemplates/csv(fileName='{fileName}')")]
        public FileStreamResult ExportFixtureTemplatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.FixtureTemplates, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/fixturetemplates/excel")]
        [HttpGet("/export/ConData/fixturetemplates/excel(fileName='{fileName}')")]
        public FileStreamResult ExportFixtureTemplatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.FixtureTemplates, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/leagueseasons/csv")]
        [HttpGet("/export/ConData/leagueseasons/csv(fileName='{fileName}')")]
        public FileStreamResult ExportLeagueSeasonsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.LeagueSeasons, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/leagueseasons/excel")]
        [HttpGet("/export/ConData/leagueseasons/excel(fileName='{fileName}')")]
        public FileStreamResult ExportLeagueSeasonsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.LeagueSeasons, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/matchdays/csv")]
        [HttpGet("/export/ConData/matchdays/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMatchDaysToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MatchDays, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/matchdays/excel")]
        [HttpGet("/export/ConData/matchdays/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMatchDaysToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MatchDays, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/teams/csv")]
        [HttpGet("/export/ConData/teams/csv(fileName='{fileName}')")]
        public FileStreamResult ExportTeamsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Teams, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/teams/excel")]
        [HttpGet("/export/ConData/teams/excel(fileName='{fileName}')")]
        public FileStreamResult ExportTeamsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Teams, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/virtualleagueresults/csv")]
        [HttpGet("/export/ConData/virtualleagueresults/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVirtualLeagueResultsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VirtualLeagueResults, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/virtualleagueresults/excel")]
        [HttpGet("/export/ConData/virtualleagueresults/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVirtualLeagueResultsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VirtualLeagueResults, Request.Query), fileName);
        }
    }
}
