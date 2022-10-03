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
    public partial class LeagueSeasonsComponent : ComponentBase
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
        protected RadzenDataGrid<VirtualLeague.Models.ConData.LeagueSeason> grid0;

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

        IEnumerable<VirtualLeague.Models.ConData.LeagueSeason> _getLeagueSeasonsResult;
        protected IEnumerable<VirtualLeague.Models.ConData.LeagueSeason> getLeagueSeasonsResult
        {
            get
            {
                return _getLeagueSeasonsResult;
            }
            set
            {
                if (!object.Equals(_getLeagueSeasonsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLeagueSeasonsResult", NewValue = value, OldValue = _getLeagueSeasonsResult };
                    _getLeagueSeasonsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getLeagueSeasonsCount;
        protected int getLeagueSeasonsCount
        {
            get
            {
                return _getLeagueSeasonsCount;
            }
            set
            {
                if (!object.Equals(_getLeagueSeasonsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLeagueSeasonsCount", NewValue = value, OldValue = _getLeagueSeasonsCount };
                    _getLeagueSeasonsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddLeagueSeason>("Add League Season", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportLeagueSeasonsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SeasonID,SeasonName" }, $"League Seasons");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportLeagueSeasonsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SeasonID,SeasonName" }, $"League Seasons");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetLeagueSeasonsResult = await ConData.GetLeagueSeasons(filter:$@"(contains(SeasonName,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getLeagueSeasonsResult = conDataGetLeagueSeasonsResult.Value.AsODataEnumerable();

                getLeagueSeasonsCount = conDataGetLeagueSeasonsResult.Count;
            }
            catch (System.Exception conDataGetLeagueSeasonsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load LeagueSeasons" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<VirtualLeague.Models.ConData.LeagueSeason> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditLeagueSeason>("Edit League Season", new Dictionary<string, object>() { {"SeasonID", args.Data.SeasonID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteLeagueSeasonResult = await ConData.DeleteLeagueSeason(seasonId:data.SeasonID);
                    if (conDataDeleteLeagueSeasonResult != null && conDataDeleteLeagueSeasonResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (conDataDeleteLeagueSeasonResult != null && conDataDeleteLeagueSeasonResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete LeagueSeason" });
                    }
                }
            }
            catch (System.Exception conDataDeleteLeagueSeasonException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete LeagueSeason" });
            }
        }
    }
}
