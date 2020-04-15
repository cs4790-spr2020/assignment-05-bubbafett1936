using BlabberApp.Domain.Interfaces;
using System;
using System.Collections;

namespace BlabberApp.DataStore.Interfaces {
    public interface IPlugin {
        void Create(IEntity obj);
        IEnumerable ReadAll();
        IEntity ReadById(Guid id);
        void Update(IEntity obj);
        void Delete(IEntity obj);
    }
}