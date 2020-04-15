using BlabberApp.DataStore.Adapters;
using BlabberApp.Domain.Entities;
using System;
using System.Collections;

namespace BlabberApp.Services {
    public class BlabService : IBlabService {
        private readonly BlabAdapter _adapter;

        public BlabService(BlabAdapter adapter) {
            _adapter = adapter;
        }

        public void AddBlab(string message, string email) {
            _adapter.Add(CreateBlab(message, email) );
        }

        public void AddBlab(Blab blab) {
            _adapter.Add(blab);
        }

        public IEnumerable GetAll() {
            return _adapter.GetAll();
        }

        public IEnumerable FindUserBlabs(string email) {
            throw new NotImplementedException("FindUserBlabs");
        }

        public Blab CreateBlab(string msg, string email) {
            User usr = new User(email);
            return new Blab(usr, msg);
        }

        public Blab CreateBlab(string msg, User user) {
            return new Blab(user, msg);
        }
    }
}