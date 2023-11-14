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
    public class Contact : BaseObject
    {
        public Contact(Session session) : base(session) { }


        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { SetPropertyValue<string>(nameof(FirstName), ref _FirstName, value); }
        }


        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { SetPropertyValue<string>(nameof(LastName), ref _LastName, value); }
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


        private Client _Client;
        [Association]
        public Client Client
        {
            get { return _Client; }
            set { SetPropertyValue<Client>(nameof(Client), ref _Client, value); }
        }


    }
}
