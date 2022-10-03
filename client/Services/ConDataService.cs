
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using VirtualLeague.Models.ConData;

namespace VirtualLeague
{
    public partial class ConDataService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;
        public ConDataService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/ConData/");
        }

        public async System.Threading.Tasks.Task ExportFixtureTemplatesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/fixturetemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/fixturetemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportFixtureTemplatesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/fixturetemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/fixturetemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetFixtureTemplates(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.FixtureTemplate>> GetFixtureTemplates(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"FixtureTemplates");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFixtureTemplates(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.FixtureTemplate>>(response);
        }
        partial void OnCreateFixtureTemplate(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.FixtureTemplate> CreateFixtureTemplate(VirtualLeague.Models.ConData.FixtureTemplate fixtureTemplate = default(VirtualLeague.Models.ConData.FixtureTemplate))
        {
            var uri = new Uri(baseUri, $"FixtureTemplates");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(fixtureTemplate), Encoding.UTF8, "application/json");

            OnCreateFixtureTemplate(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.FixtureTemplate>(response);
        }

        public async System.Threading.Tasks.Task ExportLeagueSeasonsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/leagueseasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/leagueseasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportLeagueSeasonsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/leagueseasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/leagueseasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetLeagueSeasons(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.LeagueSeason>> GetLeagueSeasons(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"LeagueSeasons");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLeagueSeasons(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.LeagueSeason>>(response);
        }
        partial void OnCreateLeagueSeason(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.LeagueSeason> CreateLeagueSeason(VirtualLeague.Models.ConData.LeagueSeason leagueSeason = default(VirtualLeague.Models.ConData.LeagueSeason))
        {
            var uri = new Uri(baseUri, $"LeagueSeasons");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(leagueSeason), Encoding.UTF8, "application/json");

            OnCreateLeagueSeason(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.LeagueSeason>(response);
        }

        public async System.Threading.Tasks.Task ExportMatchDaysToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/matchdays/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/matchdays/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMatchDaysToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/matchdays/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/matchdays/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMatchDays(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.MatchDay>> GetMatchDays(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MatchDays");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMatchDays(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.MatchDay>>(response);
        }
        partial void OnCreateMatchDay(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.MatchDay> CreateMatchDay(VirtualLeague.Models.ConData.MatchDay matchDay = default(VirtualLeague.Models.ConData.MatchDay))
        {
            var uri = new Uri(baseUri, $"MatchDays");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(matchDay), Encoding.UTF8, "application/json");

            OnCreateMatchDay(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.MatchDay>(response);
        }

        public async System.Threading.Tasks.Task ExportTeamsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/teams/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/teams/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTeamsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/teams/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/teams/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetTeams(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.Team>> GetTeams(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Teams");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTeams(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.Team>>(response);
        }
        partial void OnCreateTeam(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.Team> CreateTeam(VirtualLeague.Models.ConData.Team team = default(VirtualLeague.Models.ConData.Team))
        {
            var uri = new Uri(baseUri, $"Teams");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(team), Encoding.UTF8, "application/json");

            OnCreateTeam(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.Team>(response);
        }

        public async System.Threading.Tasks.Task ExportVirtualLeagueResultsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/virtualleagueresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/virtualleagueresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVirtualLeagueResultsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/virtualleagueresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/virtualleagueresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVirtualLeagueResults(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.VirtualLeagueResult>> GetVirtualLeagueResults(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VirtualLeagueResults");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVirtualLeagueResults(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.VirtualLeagueResult>>(response);
        }
        partial void OnCreateVirtualLeagueResult(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.VirtualLeagueResult> CreateVirtualLeagueResult(VirtualLeague.Models.ConData.VirtualLeagueResult virtualLeagueResult = default(VirtualLeague.Models.ConData.VirtualLeagueResult))
        {
            var uri = new Uri(baseUri, $"VirtualLeagueResults");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(virtualLeagueResult), Encoding.UTF8, "application/json");

            OnCreateVirtualLeagueResult(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.VirtualLeagueResult>(response);
        }
        partial void OnDeleteFixtureTemplate(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteFixtureTemplate(int? templateId = default(int?))
        {
            var uri = new Uri(baseUri, $"FixtureTemplates({templateId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteFixtureTemplate(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetFixtureTemplateByTemplateId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.FixtureTemplate> GetFixtureTemplateByTemplateId(string expand = default(string), int? templateId = default(int?))
        {
            var uri = new Uri(baseUri, $"FixtureTemplates({templateId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFixtureTemplateByTemplateId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.FixtureTemplate>(response);
        }
        partial void OnUpdateFixtureTemplate(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateFixtureTemplate(int? templateId = default(int?), VirtualLeague.Models.ConData.FixtureTemplate fixtureTemplate = default(VirtualLeague.Models.ConData.FixtureTemplate))
        {
            var uri = new Uri(baseUri, $"FixtureTemplates({templateId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", fixtureTemplate.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(fixtureTemplate), Encoding.UTF8, "application/json");

            OnUpdateFixtureTemplate(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteLeagueSeason(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteLeagueSeason(int? seasonId = default(int?))
        {
            var uri = new Uri(baseUri, $"LeagueSeasons({seasonId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteLeagueSeason(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetLeagueSeasonBySeasonId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.LeagueSeason> GetLeagueSeasonBySeasonId(string expand = default(string), int? seasonId = default(int?))
        {
            var uri = new Uri(baseUri, $"LeagueSeasons({seasonId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLeagueSeasonBySeasonId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.LeagueSeason>(response);
        }
        partial void OnUpdateLeagueSeason(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateLeagueSeason(int? seasonId = default(int?), VirtualLeague.Models.ConData.LeagueSeason leagueSeason = default(VirtualLeague.Models.ConData.LeagueSeason))
        {
            var uri = new Uri(baseUri, $"LeagueSeasons({seasonId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", leagueSeason.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(leagueSeason), Encoding.UTF8, "application/json");

            OnUpdateLeagueSeason(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMatchDay(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMatchDay(int? matchDayId = default(int?))
        {
            var uri = new Uri(baseUri, $"MatchDays({matchDayId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMatchDay(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMatchDayByMatchDayId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.MatchDay> GetMatchDayByMatchDayId(string expand = default(string), int? matchDayId = default(int?))
        {
            var uri = new Uri(baseUri, $"MatchDays({matchDayId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMatchDayByMatchDayId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.MatchDay>(response);
        }
        partial void OnUpdateMatchDay(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMatchDay(int? matchDayId = default(int?), VirtualLeague.Models.ConData.MatchDay matchDay = default(VirtualLeague.Models.ConData.MatchDay))
        {
            var uri = new Uri(baseUri, $"MatchDays({matchDayId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", matchDay.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(matchDay), Encoding.UTF8, "application/json");

            OnUpdateMatchDay(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteTeam(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteTeam(int? teamId = default(int?))
        {
            var uri = new Uri(baseUri, $"Teams({teamId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTeam(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetTeamByTeamId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.Team> GetTeamByTeamId(string expand = default(string), int? teamId = default(int?))
        {
            var uri = new Uri(baseUri, $"Teams({teamId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTeamByTeamId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.Team>(response);
        }
        partial void OnUpdateTeam(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateTeam(int? teamId = default(int?), VirtualLeague.Models.ConData.Team team = default(VirtualLeague.Models.ConData.Team))
        {
            var uri = new Uri(baseUri, $"Teams({teamId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", team.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(team), Encoding.UTF8, "application/json");

            OnUpdateTeam(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteVirtualLeagueResult(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteVirtualLeagueResult(Int64? recordId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"VirtualLeagueResults({recordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteVirtualLeagueResult(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetVirtualLeagueResultByRecordId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.VirtualLeagueResult> GetVirtualLeagueResultByRecordId(string expand = default(string), Int64? recordId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"VirtualLeagueResults({recordId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVirtualLeagueResultByRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.VirtualLeagueResult>(response);
        }
        partial void OnUpdateVirtualLeagueResult(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateVirtualLeagueResult(Int64? recordId = default(Int64?), VirtualLeague.Models.ConData.VirtualLeagueResult virtualLeagueResult = default(VirtualLeague.Models.ConData.VirtualLeagueResult))
        {
            var uri = new Uri(baseUri, $"VirtualLeagueResults({recordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", virtualLeagueResult.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(virtualLeagueResult), Encoding.UTF8, "application/json");

            OnUpdateVirtualLeagueResult(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
