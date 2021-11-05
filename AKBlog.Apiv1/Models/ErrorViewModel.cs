using System;

namespace AKBlog.Apiv1.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public static class UserToken
    {
        public static string Token = "";
    }
}
