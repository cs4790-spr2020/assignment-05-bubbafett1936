using BlabberApp.DataStore.Adapters;
using BlabberApp.Domain.Entities;
using System;
using System.Collections;

namespace BlabberApp.Services {
    public class UserService : IUserService {
        private readonly UserAdapter _adapter;

        public UserService(UserAdapter adapter) {
            _adapter = adapter;
        }

        public IEnumerable GetAll() {
            return _adapter.GetAll();
        }

        public void AddNewUser(string email) {
            try {
                _adapter.Add(CreateUser(email) );
            } catch (System.Data.DuplicateNameException dne) {
                throw new System.Data.DuplicateNameException(dne.Message);
            } catch (Exception e) {
                throw new Exception(e.ToString() );
            }
        }

        public User CreateUser(string email) {
            return new User(email);
        }

        public User FindUser(string email) {
            try {
                return _adapter.GetByEmail(email);
            } catch (System.Data.DataException de) {
                throw new System.Data.DataException(de.Message);
            }
        }
    }
}