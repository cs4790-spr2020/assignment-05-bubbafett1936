using System.Collections;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Services {
    public interface IBlabService {
       void AddBlab(string message, string email);
       void AddBlab(Blab blab);
       IEnumerable FindUserBlabs(string email);
       IEnumerable GetAll();
       Blab CreateBlab(string msg, string email);
       Blab CreateBlab(string msg, User user);
    }
}