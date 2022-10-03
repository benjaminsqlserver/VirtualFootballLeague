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
    public partial class EditFixtureTemplateComponent : ComponentBase
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
        public dynamic TemplateID { get; set; }

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
            hasChanges = false;

            canEdit = true;

            var conDataGetFixtureTemplateByTemplateIdResult = await ConData.GetFixtureTemplateByTemplateId(templateId:TemplateID);
            fixturetemplate = conDataGetFixtureTemplateByTemplateIdResult;

            canEdit = conDataGetFixtureTemplateByTemplateIdResult != null;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await this.Load();
        }

        protected async System.Threading.Tasks.Task Form0Submit(VirtualLeague.Models.ConData.FixtureTemplate args)
        {
            try
            {
                var conDataUpdateFixtureTemplateResult = await ConData.UpdateFixtureTemplate(templateId:TemplateID, fixtureTemplate:fixturetemplate);
                if (conDataUpdateFixtureTemplateResult.StatusCode != System.Net.HttpStatusCode.PreconditionFailed) {
                  DialogService.Close(fixturetemplate);
                }

                hasChanges = conDataUpdateFixtureTemplateResult.StatusCode == System.Net.HttpStatusCode.PreconditionFailed;
            }
            catch (System.Exception conDataUpdateFixtureTemplateException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update FixtureTemplate" });

            hasChanges = conDataUpdateFixtureTemplateException.Message.Contains("412");

            if (!conDataUpdateFixtureTemplateException.Message.Contains("412")) {
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
