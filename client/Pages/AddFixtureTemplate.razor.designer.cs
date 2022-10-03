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
    public partial class AddFixtureTemplateComponent : ComponentBase
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

        VirtualLeague.Models.ConData.FixtureTemplate _fixturetemplate;
        protected VirtualLeague.Models.ConData.FixtureTemplate fixturetemplate
        {
            get
            {
                return _fixturetemplate;
            }
            set
            {
                if (!object.Equals(_fixturetemplate, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "fixturetemplate", NewValue = value, OldValue = _fixturetemplate };
                    _fixturetemplate = value;
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
            fixturetemplate = new VirtualLeague.Models.ConData.FixtureTemplate(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(VirtualLeague.Models.ConData.FixtureTemplate args)
        {
            try
            {
                var conDataCreateFixtureTemplateResult = await ConData.CreateFixtureTemplate(fixtureTemplate:fixturetemplate);
                DialogService.Close(fixturetemplate);
            }
            catch (System.Exception conDataCreateFixtureTemplateException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new FixtureTemplate!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
