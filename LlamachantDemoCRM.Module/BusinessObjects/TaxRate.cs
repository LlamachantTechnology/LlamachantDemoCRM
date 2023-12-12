using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamachantDemoCRM.Module.BusinessObjects
{

    [NavigationItem("Setup")]
    public class TaxRate : BaseObject
    {
        public TaxRate(Session session) : base(session) { }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>(nameof(Name), ref _Name, value); }
        }


        private decimal _Rate;
        [ModelDefault("EditMask", "P")]
        [ModelDefault("DisplayFormat", "{0:P}")]
        public decimal Rate
        {
            get { return _Rate; }
            set { SetPropertyValue<decimal>(nameof(Rate), ref _Rate, value); }
        }


    }


}
