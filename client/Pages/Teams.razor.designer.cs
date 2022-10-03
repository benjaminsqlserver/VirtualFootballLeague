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
    public partial class TeamsComponent : ComponentBase
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
        protected RadzenDataGrid<VirtualLeague.Models.ConData.Team> grid0;

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

        IEnumerable<VirtualLeague.Models.ConData.Team> _getTeamsResult;
        protected IEnumerable<VirtualLeague.Models.ConData.Team> getTeamsResult
        {
            get
            {
                return _getTeamsResult;
            }
            set
            {
                if (!object.Equals(_getTeamsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTeamsResult", NewValue = value, OldValue = _getTeamsResult };
                    _getTeamsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getTeamsCount;
        protected int getTeamsCount
        {
            get
            {
                return _getTeamsCount;
            }
            set
            {
                if (!object.Equals(_getTeamsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTeamsCount", NewValue = value, OldValue = _getTeamsCount };
                    _getTeamsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddTeam>("Add Team", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportTeamsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TeamID,TeamName" }, $"Teams");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportTeamsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TeamID,TeamName" }, $"Teams");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetTeamsResult = await ConData.GetTeams(filter:$@"(contains(TeamName,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getTeamsResult = conDataGetTeamsResult.Value.AsODataEnumerable();

                getTeamsCount = conDataGetTeamsResult.Count;
            }
            catch (System.Exception conDataGetTeamsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load Teams" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<VirtualLeague.Models.ConData.Team> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditTeam>("Edit Team", new Dictionary<string, object>() { {"TeamID", args.Data.TeamID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteTeamResult = await ConData.DeleteTeam(teamId:data.TeamID);
                    if (conDataDeleteTeamResult != null && conDataDeleteTeamResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (conDataDeleteTeamResult != null && conDataDeleteTeamResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Team" });
                    }
                }
            }
            catch (System.Exception conDataDeleteTeamException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Team" });
            }
        }
    }
}
