using Microsoft.JSInterop;

namespace LlamachantDemoCRM.Blazor.Server.Services
{
    public class BrowserService
    {
        public IJSRuntime JS { get; private set; }
        public BrowserService(IJSRuntime js)
        {
            JS = js;
        }

        public void SetWindowCaption(string caption)
        {
            JS.InvokeVoidAsync("setTitle", caption);
        }
    }
}
