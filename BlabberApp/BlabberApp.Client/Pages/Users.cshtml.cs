using Microsoft.AspNetCore.Mvc.RazorPages;
using BlabberApp.Services;

namespace BlabberApp.Client.Pages {
    public class UsersModel : PageModel {
        private readonly IUserService _service;
        
        public UsersModel(IUserService service) {
            _service = service;
        }

        public void OnGet() {}
    }
}