using DevExpress.ExpressApp.Editors;
using DevExpress.Mvvm.Native;
using DevExpress.XtraEditors;
using LlamachantDemoCRM.Module.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamachantDemoCRM.Win.Controllers
{
    public class WinPropertyEditorCustomizationController : PropertyEditorCustomizationController
    {
        protected override void UpdatePropertyEditor(PropertyEditor editor)
        {
            base.UpdatePropertyEditor(editor);

            if (editor.Control is SpinEdit spin)
                spin.Properties.Buttons.ForEach(x => x.Visible = editor.AllowEdit);
        }
    }
}
