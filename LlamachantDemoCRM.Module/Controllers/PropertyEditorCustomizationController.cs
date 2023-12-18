using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamachantDemoCRM.Module.Controllers
{
    public class PropertyEditorCustomizationController : ViewController<DetailView>
    {
        private List<PropertyEditor> propertyEditors = null;

        protected override void OnActivated()
        {
            base.OnActivated();

            propertyEditors = View.GetItems<PropertyEditor>().ToList();

            foreach (var editor in propertyEditors)
            {
                editor.ControlCreated += Editor_ControlCreated;
                editor.AllowEditChanged += Editor_AllowEditChanged;
            }
        }

        protected override void OnDeactivated()
        {
            if (propertyEditors != null)
            {
                foreach (var editor in propertyEditors)
                {
                    editor.ControlCreated -= Editor_ControlCreated;
                    editor.AllowEditChanged -= Editor_AllowEditChanged;
                }

                propertyEditors.Clear();
                propertyEditors = null;
            }

            base.OnDeactivated();
        }

        private void Editor_AllowEditChanged(object sender, EventArgs e)
        {
            UpdatePropertyEditor((PropertyEditor)sender);
        }

        private void Editor_ControlCreated(object sender, EventArgs e)
        {
            UpdatePropertyEditor((PropertyEditor)sender);
        }

        protected virtual void UpdatePropertyEditor(PropertyEditor editor)
        {

        }
    }
}
