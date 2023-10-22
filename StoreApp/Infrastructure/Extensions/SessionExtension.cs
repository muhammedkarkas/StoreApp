using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace StoreApp.Infrastructure.Extensions
{
    public static class SessionExtension
    {
        //Serialize işlemleri (Object e bağlı olarak çalışır
        public static void SetJson(this ISession session, string key, object value)
        {
            //ilk parametre bir ifadeyi genişletirken kullanılır. İlk parametre işlem esnasında dikkate alınmaz. Hangi parametre hangi nesnesinin genişletildiğine karşılık gelmektedir.
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        //Generic yapı
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data is null 
                ? default(T) 
                : JsonSerializer.Deserialize<T>(data);
        }
    }
}
