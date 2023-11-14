using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace LlamachantDemoCRM.Module.BusinessObjects
{
    [VisibleInReports(true)]
    [VisibleInDashboards(true)]
    public class Invoice : BaseObject
    {
        public Invoice(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            InvoiceDate = DateTime.Today;
        }

        private Client _Client;
        [Association]
        public Client Client
        {
            get { return _Client; }
            set { SetPropertyValue<Client>(nameof(Client), ref _Client, value); }
        }

        private DateTime _InvoiceDate;
        public DateTime InvoiceDate
        {
            get { return _InvoiceDate; }
            set { SetPropertyValue<DateTime>(nameof(InvoiceDate), ref _InvoiceDate, value); }
        }


        private string _InvoiceNotes;
        [Size(SizeAttribute.Unlimited)]
        public string InvoiceNotes
        {
            get { return _InvoiceNotes; }
            set { SetPropertyValue<string>(nameof(InvoiceNotes), ref _InvoiceNotes, value); }
        }


        [PersistentAlias($"[InvoiceLineItems][].Sum([{nameof(InvoiceLineItem.LineItemTotal)}])")]
        public decimal SubTotal
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(SubTotal))); }
        }


        [PersistentAlias("[SubTotal] * 1.13")]
        public decimal Total
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(Total))); }
        }



        [DevExpress.Xpo.Aggregated, Association]
        public XPCollection<InvoiceLineItem> InvoiceLineItems
        {
            get { return GetCollection<InvoiceLineItem>(nameof(InvoiceLineItems)); }
        }

    }
}
