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
    public partial class FixtureTemplatesComponent : ComponentBase
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
        protected RadzenDataGrid<VirtualLeague.Models.ConData.FixtureTemplate> grid0;

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

        IEnumerable<VirtualLeague.Models.ConData.FixtureTemplate> _getFixtureTemplatesResult;
        protected IEnumerable<VirtualLeague.Models.ConData.FixtureTemplate> getFixtureTemplatesResult
        {
            get
            {
                return _getFixtureTemplatesResult;
            }
            set
            {
                if (!object.Equals(_getFixtureTemplatesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFixtureTemplatesResult", NewValue = value, OldValue = _getFixtureTemplatesResult };
                    _getFixtureTemplatesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getFixtureTemplatesCount;
        protected int getFixtureTemplatesCount
        {
            get
            {
                return _getFixtureTemplatesCount;
            }
            set
            {
                if (!object.Equals(_getFixtureTemplatesCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFixtureTemplatesCount", NewValue = value, OldValue = _getFixtureTemplatesCount };
                    _getFixtureTemplatesCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddFixtureTemplate>("Add Fixture Template", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportFixtureTemplatesToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TemplateID,HomeTeam,AwayTeam" }, $"Fixture Templates");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportFixtureTemplatesToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TemplateID,HomeTeam,AwayTeam" }, $"Fixture Templates");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetFixtureTemplatesResult = await ConData.GetFixtureTemplates(filter:$@"(contains(HomeTeam,""{search}"") or contains(AwayTeam,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getFixtureTemplatesResult = conDataGetFixtureTemplatesResult.Value.AsODataEnumerable();

                getFixtureTemplatesCount = conDataGetFixtureTemplatesResult.Count;
            }
            catch (System.Exception conDataGetFixtureTemplatesException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load FixtureTemplates" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<VirtualLeague.Models.ConData.FixtureTemplate> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditFixtureTemplate>("Edit Fixture Template", new Dictionary<string, object>() { {"TemplateID", args.Data.TemplateID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteFixtureTemplateResult = await ConData.DeleteFixtureTemplate(templateId:data.TemplateID);
                    if (conDataDeleteFixtureTemplateResult != null && conDataDeleteFixtureTemplateResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (conDataDeleteFixtureTemplateResult != null && conDataDeleteFixtureTemplateResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete FixtureTemplate" });
                    }
                }
            }
            catch (System.Exception conDataDeleteFixtureTemplateException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete FixtureTemplate" });
            }
        }
    }
}
