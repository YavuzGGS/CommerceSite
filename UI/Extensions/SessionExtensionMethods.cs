using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Extensions
{
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string objectStr = JsonConvert.SerializeObject(value);
            session.SetString(key, objectStr);
        }
        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string objectStr = session.GetString(key);
            if (string.IsNullOrEmpty(objectStr))
                return null;
            else
            {
                T value = JsonConvert.DeserializeObject<T>(objectStr);
                return value;
            }
        }
    }
}
