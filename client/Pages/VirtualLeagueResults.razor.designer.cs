using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using VirtualLeague.Models.ConData;
using VirtualLeague.Client.Pages;

namespace VirtualLeague.Pages
{
    public partial class VirtualLeagueResultsComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected ConDataService ConData { get; set; }
        protected RadzenDataGrid<VirtualLeague.Models.ConData.VirtualLeagueResult> grid0;

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<VirtualLeague.Models.ConData.VirtualLeagueResult> _getVirtualLeagueResultsResult;
        protected IEnumerable<VirtualLeague.Models.ConData.VirtualLeagueResult> getVirtualLeagueResultsResult
        {
            get
            {
                return _getVirtualLeagueResultsResult;
            }
            set
            {
                if (!object.Equals(_getVirtualLeagueResultsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getVirtualLeagueResultsResult", NewValue = value, OldValue = _getVirtualLeagueResultsResult };
                    _getVirtualLeagueResultsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getVirtualLeagueResultsCount;
        protected int getVirtualLeagueResultsCount
        {
            get
            {
                return _getVirtualLeagueResultsCount;
            }
            set
            {
                if (!object.Equals(_getVirtualLeagueResultsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getVirtualLeagueResultsCount", NewValue = value, OldValue = _getVirtualLeagueResultsCount };
                    _getVirtualLeagueResultsCount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddVirtualLeagueResult>("Add Virtual League Result", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportVirtualLeagueResultsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "LeagueSeason,MatchDay,Team,Team1", Select = "RecordID,LeagueSeason.SeasonName as LeagueSeasonSeasonName,MatchDay.MatchDayName as MatchDayMatchDayName,Team.TeamName as TeamTeamName,HomeScore,Team1.TeamName as Team1TeamName,AwayScore" }, $"Virtual League Results");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportVirtualLeagueResultsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "LeagueSeason,MatchDay,Team,Team1", Select = "RecordID,LeagueSeason.SeasonName as LeagueSeasonSeasonName,MatchDay.MatchDayName as MatchDayMatchDayName,Team.TeamName as TeamTeamName,HomeScore,Team1.TeamName as Team1TeamName,AwayScore" }, $"Virtual League Results");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetVirtualLeagueResultsResult = await ConData.GetVirtualLeagueResults(filter:$@"{(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", expand:$"LeagueSeason,MatchDay,Team,Team1", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getVirtualLeagueResultsResult = conDataGetVirtualLeagueResultsResult.Value.AsODataEnumerable();

                getVirtualLeagueResultsCount = conDataGetVirtualLeagueResultsResult.Count;
            }
            catch (System.Exception conDataGetVirtualLeagueResultsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load VirtualLeagueResults" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<VirtualLeague.Models.ConData.VirtualLeagueResult> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditVirtualLeagueResult>("Edit Virtual League Result", new Dictionary<string, object>() { {"RecordID", args.Data.RecordID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteVirtualLeagueResultResult = await ConData.DeleteVirtualLeagueResult(recordId:data.RecordID);
                    if (conDataDeleteVirtualLeagueResultResult != null && conDataDeleteVirtualLeagueResultResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (conDataDeleteVirtualLeagueResultResult != null && conDataDeleteVirtualLeagueResultResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete VirtualLeagueResult" });
                    }
                }
            }
            catch (System.Exception conDataDeleteVirtualLeagueResultException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete VirtualLeagueResult" });
            }
        }
    }
}
