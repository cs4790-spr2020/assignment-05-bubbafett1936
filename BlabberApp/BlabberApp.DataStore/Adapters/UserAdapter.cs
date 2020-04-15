using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using System;
using System.Collections;

namespace BlabberApp.DataStore.Adapters {
    public class UserAdapter {
        private readonly IUserPlugin _plugin;

        public UserAdapter(IUserPlugin plugin) {
            _plugin = plugin;
        }

        public void Add(User user) {
            try {
                _plugin.Create(user);
            } catch (System.Data.DuplicateNameException dne) {
                throw new System.Data.DuplicateNameException(dne.Message);
            }
            
        }

        public void Remove(User user) {
            _plugin.Delete(user);
        }

        public void Update(User user) {
            _plugin.Update(user);
        }

        public IEnumerable GetAll() {
            return _plugin.ReadAll();
        }

        public User GetById(Guid id) {
            return (User) _plugin.ReadById(id);
        }

        public User GetByEmail(string email) {
            try {
                return (User) _plugin.ReadByUserEmail(email);
            } catch (System.Data.DataException de) {
                throw new System.Data.DataException(de.Message);
            }
            
        }
    }    
}