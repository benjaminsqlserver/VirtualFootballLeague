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
    public partial class MatchDaysComponent : ComponentBase
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
        protected RadzenDataGrid<VirtualLeague.Models.ConData.MatchDay> grid0;

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

        IEnumerable<VirtualLeague.Models.ConData.MatchDay> _getMatchDaysResult;
        protected IEnumerable<VirtualLeague.Models.ConData.MatchDay> getMatchDaysResult
        {
            get
            {
                return _getMatchDaysResult;
            }
            set
            {
                if (!object.Equals(_getMatchDaysResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getMatchDaysResult", NewValue = value, OldValue = _getMatchDaysResult };
                    _getMatchDaysResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getMatchDaysCount;
        protected int getMatchDaysCount
        {
            get
            {
                return _getMatchDaysCount;
            }
            set
            {
                if (!object.Equals(_getMatchDaysCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getMatchDaysCount", NewValue = value, OldValue = _getMatchDaysCount };
                    _getMatchDaysCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddMatchDay>("Add Match Day", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportMatchDaysToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "MatchDayID,MatchDayName" }, $"Match Days");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportMatchDaysToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "MatchDayID,MatchDayName" }, $"Match Days");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetMatchDaysResult = await ConData.GetMatchDays(filter:$@"(contains(MatchDayName,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getMatchDaysResult = conDataGetMatchDaysResult.Value.AsODataEnumerable();

                getMatchDaysCount = conDataGetMatchDaysResult.Count;
            }
            catch (System.Exception conDataGetMatchDaysException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load MatchDays" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<VirtualLeague.Models.ConData.MatchDay> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditMatchDay>("Edit Match Day", new Dictionary<string, object>() { {"MatchDayID", args.Data.MatchDayID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteMatchDayResult = await ConData.DeleteMatchDay(matchDayId:data.MatchDayID);
                    if (conDataDeleteMatchDayResult != null && conDataDeleteMatchDayResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (conDataDeleteMatchDayResult != null && conDataDeleteMatchDayResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete MatchDay" });
                    }
                }
            }
            catch (System.Exception conDataDeleteMatchDayException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete MatchDay" });
            }
        }
    }
}
