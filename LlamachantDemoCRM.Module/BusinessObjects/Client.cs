using DevExpress.ExpressApp.ConditionalAppearance;
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

    [DefaultClassOptions]
    [Appearance("Client-UseCustomRate", "[UseCustomRate] = False", TargetItems = "CustomRate", Enabled = false, Context = "DetailView")]
    public class Client : BaseObject
    {
        public Client(Session session) : base(session) { }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>(nameof(Name), ref _Name, value); }
        }


        private string _Address;
        [Size(250)]
        public string Address
        {
            get { return _Address; }
            set { SetPropertyValue<string>(nameof(Address), ref _Address, value); }
        }



        [PersistentAlias($"ISNULL([Invoices][].Sum({nameof(Invoice.Total)}), 0) - ISNULL([Payments][].Sum({nameof(Payment.PaymentAmount)}), 0)")]     
        public decimal Balance
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(Balance))); }
        }


        private string _EmailAddress;
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { SetPropertyValue<string>(nameof(EmailAddress), ref _EmailAddress, value); }
        }


        private string _PhoneNumber;
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { SetPropertyValue<string>(nameof(PhoneNumber), ref _PhoneNumber, value); }
        }


        private string _Website;
        public string Website
        {
            get { return _Website; }
            set { SetPropertyValue<string>(nameof(Website), ref _Website, value); }
        }


        private TaxRate _TaxRate;
        public TaxRate TaxRate
        {
            get { return _TaxRate; }
            set { SetPropertyValue<TaxRate>(nameof(TaxRate), ref _TaxRate, value); }
        }


        private bool _UseCustomRate;
        [ImmediatePostData]
        public bool UseCustomRate
        {
            get { return _UseCustomRate; }
            set { SetPropertyValue<bool>(nameof(UseCustomRate), ref _UseCustomRate, value); }
        }

        private decimal _CustomRate;
        public decimal CustomRate
        {
            get { return _CustomRate; }
            set { SetPropertyValue<decimal>(nameof(CustomRate), ref _CustomRate, value); }
        }




        [DevExpress.Xpo.Aggregated, Association]
        public XPCollection<Contact> Contacts
        {
            get { return GetCollection<Contact>(nameof(Contacts)); }
        }


        [DevExpress.Xpo.Aggregated, Association]
        public XPCollection<BillableHours> BillableHours
        {
            get { return GetCollection<BillableHours>(nameof(BillableHours)); }
        }



        [DevExpress.Xpo.Aggregated, Association]
        public XPCollection<Invoice> Invoices
        {
            get { return GetCollection<Invoice>(nameof(Invoices)); }
        }


        [DevExpress.Xpo.Aggregated, Association]
        public XPCollection<Payment> Payments
        {
            get { return GetCollection<Payment>(nameof(Payments)); }
        }


    }


}
