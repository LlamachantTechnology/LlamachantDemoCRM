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
    public class InvoiceLineItem : BaseObject
    {
        public InvoiceLineItem(Session session) : base(session) { }


        private Item _Item;
        public Item Item
        {
            get { return _Item; }
            set { SetPropertyValue<Item>(nameof(Item), ref _Item, value); }
        }


        private decimal _Quantity;
        [ModelDefault("EditMask", "n2")]
        [ModelDefault("DisplayFormat", "{0:n2}")]
        public decimal Quantity
        {
            get { return _Quantity; }
            set { SetPropertyValue<decimal>(nameof(Quantity), ref _Quantity, value); }
        }


        private decimal _Price;
        public decimal Price
        {
            get { return _Price; }
            set { SetPropertyValue<decimal>(nameof(Price), ref _Price, value); }
        }


        [PersistentAlias("[Quantity] * [Price]")]
        public decimal LineItemTotal
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(LineItemTotal))); }
        }


        private Invoice _Invoice;
        [Association]
        public Invoice Invoice
        {
            get { return _Invoice; }
            set { SetPropertyValue<Invoice>(nameof(Invoice), ref _Invoice, value); }
        }


    }
}
