using BlabberApp.Domain.Entities;
using BlabberApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace BlabberApp.Client.Pages {
    public class FeedModel : PageModel {
        private readonly IBlabService _blab_service;
        private readonly IUserService _user_service;
        public string ErrorMessage = "";

        public FeedModel(IBlabService blab_service, IUserService user_service) {
            _blab_service = blab_service;
            _user_service = user_service;
        }

        public void OnGet() {

        }

        public void OnPost() {
            var email = Request.Form["emailaddress"];
            var message = Request.Form["message"];

            try {
                User user = _user_service.FindUser(email);
                Blab blab = _blab_service.CreateBlab(message, user);
                _blab_service.AddBlab(blab);
            } catch (System.Data.DataException de) {
                ErrorMessage = de.Message;
            } catch (Exception e) {
                throw new Exception($"FeedModel::OnPost: {e.ToString() }");
            }
        }
    }
}