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
    public partial class EditVirtualLeagueResultComponent : ComponentBase
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

        [Parameter]
        public dynamic RecordID { get; set; }

        bool _hasChanges;
        protected bool hasChanges
        {
            get
            {
                return _hasChanges;
            }
            set
            {
                if (!object.Equals(_hasChanges, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "hasChanges", NewValue = value, OldValue = _hasChanges };
                    _hasChanges = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _canEdit;
        protected bool canEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                if (!object.Equals(_canEdit, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "canEdit", NewValue = value, OldValue = _canEdit };
                    _canEdit = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        VirtualLeague.Models.ConData.VirtualLeagueResult _virtualleagueresult;
        protected VirtualLeague.Models.ConData.VirtualLeagueResult virtualleagueresult
        {
            get
            {
                return _virtualleagueresult;
            }
            set
            {
                if (!object.Equals(_virtualleagueresult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "virtualleagueresult", NewValue = value, OldValue = _virtualleagueresult };
                    _virtualleagueresult = value;
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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            hasChanges = false;

            canEdit = true;

            var conDataGetVirtualLeagueResultByRecordIdResult = await ConData.GetVirtualLeagueResultByRecordId(recordId:RecordID);
            virtualleagueresult = conDataGetVirtualLeagueResultByRecordIdResult;

            canEdit = conDataGetVirtualLeagueResultByRecordIdResult != null;

            var conDataGetLeagueSeasonsResult = await ConData.GetLeagueSeasons();
            getLeagueSeasonsResult = conDataGetLeagueSeasonsResult.Value.AsODataEnumerable();

            var conDataGetMatchDaysResult = await ConData.GetMatchDays();
            getMatchDaysResult = conDataGetMatchDaysResult.Value.AsODataEnumerable();

            var conDataGetTeamsResult = await ConData.GetTeams();
            getTeamsResult = conDataGetTeamsResult.Value.AsODataEnumerable();
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await this.Load();
        }

        protected async System.Threading.Tasks.Task Form0Submit(VirtualLeague.Models.ConData.VirtualLeagueResult args)
        {
            try
            {
                var conDataUpdateVirtualLeagueResultResult = await ConData.UpdateVirtualLeagueResult(recordId:RecordID, virtualLeagueResult:virtualleagueresult);
                if (conDataUpdateVirtualLeagueResultResult.StatusCode != System.Net.HttpStatusCode.PreconditionFailed) {
                  DialogService.Close(virtualleagueresult);
                }

                hasChanges = conDataUpdateVirtualLeagueResultResult.StatusCode == System.Net.HttpStatusCode.PreconditionFailed;
            }
            catch (System.Exception conDataUpdateVirtualLeagueResultException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update VirtualLeagueResult" });

            hasChanges = conDataUpdateVirtualLeagueResultException.Message.Contains("412");

            if (!conDataUpdateVirtualLeagueResultException.Message.Contains("412")) {
                canEdit = false;
            }
            }
        }

        protected async System.Threading.Tasks.Task Button4Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
