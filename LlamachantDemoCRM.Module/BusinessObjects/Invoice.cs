using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace LlamachantDemoCRM.Module.BusinessObjects
{
    [VisibleInReports(true)]
    [VisibleInDashboards(true)]
    [DefaultProperty(nameof(Description))]
    public class Invoice : BaseObject
    {
        public Invoice(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            InvoiceDate = DateTime.Today;
        }

        public string Description => ObjectFormatter.Format("{Client.Name} - {InvoiceDate:d} - {Total:c2}", this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);

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


        [PersistentAlias("[SubTotal] * iif(ISNULL(Client.TaxRate), 1, 1 + Client.TaxRate.Rate)")]
        public decimal Total
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(Total))); }
        }

        //public decimal Total => SubTotal * (Client?.TaxRate == null ? 1 : 1 + Client.TaxRate.Rate);


        [DevExpress.Xpo.Aggregated, Association]
        public XPCollection<InvoiceLineItem> InvoiceLineItems
        {
            get { return GetCollection<InvoiceLineItem>(nameof(InvoiceLineItems)); }
        }


        [Association]
        [DataSourceCriteria("Client = '@This.Client' AND ISNULL(Invoice)")]
        public XPCollection<BillableHours> BillableHours
        {
            get { return GetCollection<BillableHours>(nameof(BillableHours)); }
        }

    }
}
