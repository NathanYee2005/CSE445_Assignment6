//Author: Ahmed Almoshawer
using System;
using System.Web;
using System.Web.SessionState;

namespace A5WebApp
{
    public static class CookieSessionHelper
    {
        public static void SetCookie(HttpResponse response, string name, string value, int days)
        {
            var cookie = new HttpCookie(name, value)
            {
                Expires = DateTime.Now.AddDays(days)
            };
            response.Cookies.Add(cookie);
        }

        public static string GetCookie(HttpRequest request, string name)
        {
            var cookie = request.Cookies[name];
            return cookie == null ? null : cookie.Value;
        }

        public static void SetSession(HttpSessionState session, string name, object value)
        {
            session[name] = value;
        }

        public static object GetSession(HttpSessionState session, string name)
        {
            return session[name];
        }
    }
}