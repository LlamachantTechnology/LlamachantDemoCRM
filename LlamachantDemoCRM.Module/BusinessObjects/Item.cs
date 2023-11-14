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
    public class Item : BaseObject
    {
        public Item(Session session) : base(session) { }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>(nameof(Name), ref _Name, value); }
        }


        private string _Description;
        [Size(250)]
        public string Description
        {
            get { return _Description; }
            set { SetPropertyValue<string>(nameof(Description), ref _Description, value); }
        }


        private decimal _DefaultPrice;
        public decimal DefaultPrice
        {
            get { return _DefaultPrice; }
            set { SetPropertyValue<decimal>(nameof(DefaultPrice), ref _DefaultPrice, value); }
        }


        private string _SKU;
        public string SKU
        {
            get { return _SKU; }
            set { SetPropertyValue<string>(nameof(SKU), ref _SKU, value); }
        }


        private bool _BasedOnHours;
        public bool BasedOnHours
        {
            get { return _BasedOnHours; }
            set { SetPropertyValue<bool>(nameof(BasedOnHours), ref _BasedOnHours, value); }
        }
    }
}
