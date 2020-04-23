using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;
using System;
using System.Collections;

namespace BlabberApp.DataStore.Plugins
{
    public class InMemory : IBlabPlugin, IUserPlugin {
        private ArrayList _buffer;

        public InMemory() {
            _buffer = new ArrayList();
        }

        public void Create(IEntity obj) {
            _buffer.Add(obj);
        }

        public IEnumerable ReadAll() {
            return _buffer;
        }

        public IEntity ReadById(Guid id) {
            foreach (IEntity obj in _buffer) {
                if (obj.Id.Equals(id) ) return obj;
            }
            
            return null;
        }

        public IEnumerable ReadByUserId(string id) {
            ArrayList al_blabs = new ArrayList();
            foreach (Blab blab in _buffer) {
                if (blab.User.Email.Equals(id) ) {
                    al_blabs.Add(blab);
                }
            }
            
            return al_blabs.Count > 0 ? al_blabs : null;
        }

        public IEntity ReadByUserEmail(string email) {
            foreach (User user in _buffer) {
                if (user.Email.Equals(email) ) {
                    return user;
                }
            }
            
            return null;
        }

        public void Update(IEntity obj) {
            Delete(obj);
            Create(obj);
        }

        public void Delete(IEntity obj) {
            _buffer.Remove(obj);
        }
    }
}
