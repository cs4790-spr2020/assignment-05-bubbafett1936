using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlabberApp.Services;

namespace BlabberApp.Client.Pages {
    public class RegisterModel : PageModel {
        private readonly IUserService _service;
        private string _email = "";
        public string message_user = "";
        public string message_succ = "";

        public string Email {
            get { return _email; }
            set { _email = value; }
        }

        public RegisterModel(IUserService service) {
            _service = service;
        }

        public void OnGet() {}

        public void OnPost() {
            var email = Request.Form["emailaddress"];
            try {
                _service.AddNewUser(email);
                message_succ = "successfully registered!";
            } catch (System.Data.DuplicateNameException dne) {
                message_succ = dne.Message;
            } catch (Exception e) {
                throw new Exception($"FeedModel::OnPost: {e.ToString() }");
            } finally {
                message_user = "User";
                Email = email.ToString().ToLower();
            }
        }
    }
}