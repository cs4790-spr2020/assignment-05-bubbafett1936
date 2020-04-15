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
            _id = Guid.NewGuid();
            _user = new User();
            _message = "";
        }

        public Blab(string message) {
            _id = Guid.NewGuid();
            _user = new User();
            _message = message;
        }

        public Blab(User user) {
            _id = Guid.NewGuid();
            _user = user;
            _message = "";
        }

        public Blab(User user, string message) {
            _id = Guid.NewGuid();
            _user = user;
            _message = message;
        }

        public bool IsValid() {
            return true;
        }
    }
}