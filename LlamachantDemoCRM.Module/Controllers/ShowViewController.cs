using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using LlamachantDemoCRM.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamachantDemoCRM.Module.Controllers
{
    public class ShowViewController : ViewController<ListView>
    {
        public SimpleAction ShowView { get; }
        public PopupWindowShowAction ShowViewInPopup { get; }

        private ListViewProcessCurrentObjectController lvController;

        public ShowViewController()
        {
            ShowView = new SimpleAction(this, nameof(ShowView), DevExpress.Persistent.Base.PredefinedCategory.RecordEdit);
            ShowView.Execute += ShowView_Execute;


            ShowViewInPopup = new PopupWindowShowAction(this, nameof(ShowViewInPopup), DevExpress.Persistent.Base.PredefinedCategory.RecordEdit);
            ShowViewInPopup.CustomizePopupWindowParams += ShowViewInPopup_CustomizePopupWindowParams;
            ShowViewInPopup.Execute += ShowViewInPopup_Execute;
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            lvController = Frame.GetController<ListViewProcessCurrentObjectController>();
            if (lvController != null )
            {
                lvController.CustomizeShowViewParameters += LvController_CustomizeShowViewParameters;
            }
        }

        protected override void OnDeactivated()
        {
            if (lvController != null)
            {
                lvController.CustomizeShowViewParameters -= LvController_CustomizeShowViewParameters;
                lvController = null;
            }

            base.OnDeactivated();
        }

        private void LvController_CustomizeShowViewParameters(object sender, CustomizeShowViewParametersEventArgs e)
        {
            e.ShowViewParameters.Context = TemplateContext.View;
            e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
            e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Separate;
        }

        private void ShowViewInPopup_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace space = Application.CreateObjectSpace(typeof(Client));
            Client c = space.CreateObject<Client>();
            c.Name = "My new client";

            DetailView view = Application.CreateDetailView(space, c);

            e.View = view;
        }

        private void ShowViewInPopup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            Client c = (Client)e.PopupWindowViewCurrentObject;
        }

        private void ShowView_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace space = Application.CreateObjectSpace(typeof(Client));
            Client c = space.CreateObject<Client>();
            c.Name = "My new client";

            DetailView view = Application.CreateDetailView(space, c);

            //e.ShowViewParameters.CreatedView = view;
            //e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
            //e.ShowViewParameters.Context = TemplateContext.View;

            Application.ShowViewStrategy.ShowViewInPopupWindow(view, 
                () => { Application.ShowViewStrategy.ShowMessage("OK Clicked"); }, 
                () => { Application.ShowViewStrategy.ShowMessage("Cancel Clicked", InformationType.Warning); });
        }
    }
}
