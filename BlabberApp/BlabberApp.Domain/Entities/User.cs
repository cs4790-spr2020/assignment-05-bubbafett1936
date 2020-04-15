using BlabberApp.Domain.Interfaces;
using System;
using System.Net.Mail;

namespace BlabberApp.Domain.Entities {
    public class User : IEntity {
        private Guid _id;
        private DateTime _regdttm;
        private DateTime _lldttm;
        private string _email;
        public Guid Id {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime RegisterDTTM {
            get { return _regdttm; }
            set { _regdttm = value; }
        }
        public DateTime LastLoginDTTM {
            get { return _lldttm; }
            set { _lldttm = value; }
        }
        public string Email {
            get { return _email; }

            set {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 50)
                    throw new FormatException("Email is invalid");

                try {
                    MailAddress m = new MailAddress(value); 
                } catch (FormatException) {
                    throw new FormatException("Email is invalid");
                }
                _email = value;
            }
        }

        public User() {
            _id = Guid.NewGuid();
        }

        public User(string email) {
            _id = Guid.NewGuid();
            Email = email;
        }

        public bool IsValid() {
            if (_id == null) throw new ArgumentNullException();
            if (_email == null) throw new ArgumentNullException();
            if (_email.ToString().Equals("") ) throw new FormatException();
            if (LastLoginDTTM == null) throw new ArgumentNullException();
            if (RegisterDTTM == null) throw new ArgumentNullException();
            return true;
        }
    }
}