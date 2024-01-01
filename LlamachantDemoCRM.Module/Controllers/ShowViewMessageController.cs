using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using LlamachantDemoCRM.Module.BusinessObjects;
using LlamachantDemoCRM.Module.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamachantDemoCRM.Module.Controllers
{
    public class ShowViewMessageController : ObjectViewController<ListView, IHaveClient>
    {
        public SimpleAction ShowViewMessage { get; }
        public ShowViewMessageController()
        {
            ShowViewMessage = new SimpleAction(this, nameof(ShowViewMessage), DevExpress.Persistent.Base.PredefinedCategory.RecordEdit);
            ShowViewMessage.Execute += ShowViewMessage_Execute;

            //TargetViewType = ViewType.ListView;
            //TargetObjectType = typeof(Contact);
            //TargetViewNesting = Nesting.Nested;
            //TargetViewId = "Contact_ListView;Client_ListView";

            
        }

        private void ShowViewMessage_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Application.ShowViewStrategy.ShowMessage($"View ID {View.Id}");
        }
    }
}
