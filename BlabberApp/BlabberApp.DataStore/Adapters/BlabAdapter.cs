using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using System;
using System.Collections;

namespace BlabberApp.DataStore.Adapters {
    public class BlabAdapter {
        private readonly IBlabPlugin _plugin;

        public BlabAdapter(IBlabPlugin plugin) {
            _plugin = plugin;
        }

        public void Add(Blab blab) {
            _plugin.Create(blab);
        }

        public void Remove(Blab blab) {
            _plugin.Delete(blab);
        }

        public void Update(Blab blab) {
            _plugin.Update(blab);
        }

        public IEnumerable GetAll() {
            return _plugin.ReadAll();
        }

        public Blab GetById(Guid id) {
            return (Blab) _plugin.ReadById(id);
        }

        public IEnumerable GetByUserId(string id) {
            return _plugin.ReadByUserId(id);
        }
    }    
}