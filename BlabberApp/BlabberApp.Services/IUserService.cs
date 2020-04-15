using BlabberApp.Domain.Entities;
using System.Collections;

namespace BlabberApp.Services {
    public interface IUserService {
       IEnumerable GetAll(); 
       void AddNewUser(string email);
       User CreateUser(string email);
       User FindUser(string email);
    }
}