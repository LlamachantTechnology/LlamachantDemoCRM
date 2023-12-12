using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LlamachantDemoCRM.Module.BusinessObjects
{

    [DefaultProperty(nameof(BillableHoursDescription))]
    public class BillableHours : Event
    {
        public BillableHours(Session session) : base(session) { }

        [ModelDefault("EditMask", "n2")]
        [ModelDefault("DisplayFormat", "{0:n2}")]
        public double Duration => EndOn == DateTime.MinValue ? DateTime.Now.Subtract(StartOn).TotalHours : EndOn.Subtract(StartOn).TotalHours;


        private string _BillableHoursDescription;
        [Size(250)]
        public string BillableHoursDescription
        {
            get { return _BillableHoursDescription; }
            set 
            { 
                SetPropertyValue<string>(nameof(BillableHoursDescription), ref _BillableHoursDescription, value); 

                if (!IsSaving && !IsLoading)
                {
                    Subject = value;
                    OnChanged(nameof(Subject));
                }
                    
            }
        }


        private Client _Client;
        [Association]
        public Client Client
        {
            get { return _Client; }
            set { SetPropertyValue<Client>(nameof(Client), ref _Client, value); }
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
