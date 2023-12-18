using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Editors;
using LlamachantDemoCRM.Module.Controllers;

namespace LlamachantDemoCRM.Blazor.Server.Controllers
{
    public class BlazorPropertyEditorCustomizationController : PropertyEditorCustomizationController
    {
        protected override void UpdatePropertyEditor(PropertyEditor editor)
        {
            base.UpdatePropertyEditor(editor);

            if (editor is NumericPropertyEditor numeric && numeric.ComponentModel != null)
                numeric.ComponentModel.ShowSpinButtons = editor.AllowEdit;
        }
    }
}
