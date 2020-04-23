using System;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.Domain.Entities
{
    public class Blab : IEntity {
        private Guid _id;
        private DateTime _dttm;
        private string _message;
        private User _user;
        public Guid Id {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime DTTM {
            get { return _dttm; }
            set { _dttm = value; }
        }
        public string Message {
            get { return _message; }
            set { _message = value; }
        }
        public User User {
            get { return _user; }
            set { _user = value; }
        }
        public Blab() {
            Id = Guid.NewGuid();
            User = new User();
            Message = "";
        }

        public Blab(string message) {
            Id = Guid.NewGuid();
            User = new User();
            Message = message;
        }

        public Blab(User user) {
            Id = Guid.NewGuid();
            User = user;
            Message = "";
        }

        public Blab(User user, string message) {
            Id = Guid.NewGuid();
            User = user;
            Message = message;
        }

        public bool IsValid() {
            if (Id == null) throw new ArgumentNullException();
            if (User.IsValid() == false) throw new ArgumentNullException();
            if (DTTM == null) throw new ArgumentNullException();
            if (Message == null) throw new ArgumentNullException();
            return true;
        }
    }
}