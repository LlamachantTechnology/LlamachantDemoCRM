using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace LlamachantDemoCRM.Module.BusinessObjects
{
    [VisibleInReports(true)]
    [VisibleInDashboards(true)]
    public class Payment : BaseObject
    {
        public Payment(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            PaymentDate = DateTime.Today;
        }


        private DateTime _PaymentDate;
        public DateTime PaymentDate
        {
            get { return _PaymentDate; }
            set { SetPropertyValue<DateTime>(nameof(PaymentDate), ref _PaymentDate, value); }
        }


        private PaymentMethod _PaymentMethod;
        public PaymentMethod PaymentMethod
        {
            get { return _PaymentMethod; }
            set { SetPropertyValue<PaymentMethod>(nameof(PaymentMethod), ref _PaymentMethod, value); }
        }


        private string _TransactionID;
        public string TransactionID
        {
            get { return _TransactionID; }
            set { SetPropertyValue<string>(nameof(TransactionID), ref _TransactionID, value); }
        }




        private decimal _PaymentAmount;
        public decimal PaymentAmount
        {
            get { return _PaymentAmount; }
            set { SetPropertyValue<decimal>(nameof(PaymentAmount), ref _PaymentAmount, value); }
        }


        private Client _Client;
        [Association]
        public Client Client
        {
            get { return _Client; }
            set { SetPropertyValue<Client>(nameof(Client), ref _Client, value); }
        }



    }

}
