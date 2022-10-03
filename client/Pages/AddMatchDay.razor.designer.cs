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
    public partial class AddMatchDayComponent : ComponentBase
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

        VirtualLeague.Models.ConData.MatchDay _matchday;
        protected VirtualLeague.Models.ConData.MatchDay matchday
        {
            get
            {
                return _matchday;
            }
            set
            {
                if (!object.Equals(_matchday, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "matchday", NewValue = value, OldValue = _matchday };
                    _matchday = value;
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
            matchday = new VirtualLeague.Models.ConData.MatchDay(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(VirtualLeague.Models.ConData.MatchDay args)
        {
            try
            {
                var conDataCreateMatchDayResult = await ConData.CreateMatchDay(matchDay:matchday);
                DialogService.Close(matchday);
            }
            catch (System.Exception conDataCreateMatchDayException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new MatchDay!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
