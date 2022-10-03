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
    public partial class AddLeagueSeasonComponent : ComponentBase
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

        VirtualLeague.Models.ConData.LeagueSeason _leagueseason;
        protected VirtualLeague.Models.ConData.LeagueSeason leagueseason
        {
            get
            {
                return _leagueseason;
            }
            set
            {
                if (!object.Equals(_leagueseason, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "leagueseason", NewValue = value, OldValue = _leagueseason };
                    _leagueseason = value;
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
            leagueseason = new VirtualLeague.Models.ConData.LeagueSeason(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(VirtualLeague.Models.ConData.LeagueSeason args)
        {
            try
            {
                var conDataCreateLeagueSeasonResult = await ConData.CreateLeagueSeason(leagueSeason:leagueseason);
                DialogService.Close(leagueseason);
            }
            catch (System.Exception conDataCreateLeagueSeasonException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new LeagueSeason!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
