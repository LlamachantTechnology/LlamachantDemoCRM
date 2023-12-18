using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor;
using LlamachantDemoCRM.Blazor.Server.Services;
using Microsoft.JSInterop;
using System.Security.Policy;

namespace LlamachantDemoCRM.Blazor.Server.Controllers
{
    public class JSController : ViewController
    {
        public SimpleAction actionOpenDevExpress { get; set; }

        public JSController()
        {
            actionOpenDevExpress = new SimpleAction(this, nameof(actionOpenDevExpress), DevExpress.Persistent.Base.PredefinedCategory.Edit);
            actionOpenDevExpress.Caption = "Open DevExpress";
            actionOpenDevExpress.Execute += ActionOpenDevExpress_Execute;
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            var browserService = ((BlazorApplication)Application).ServiceProvider.GetRequiredService<BrowserService>();
            browserService.SetWindowCaption("Test");
        }

        private void ActionOpenDevExpress_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var JSRuntime = ((BlazorApplication)Application).ServiceProvider.GetRequiredService<IJSRuntime>();
            JSRuntime.InvokeVoidAsync("open", @"https://www.devexpress.com", "_blank");
        }
    }
}
