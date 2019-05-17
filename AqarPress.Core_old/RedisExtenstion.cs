using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Serilog;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace AqarPress.Core
{
    /// <summary>
    /// Source https://msdn.microsoft.com/library/dn690521.aspx#Objects
    /// </summary>
    public static class RedisExtensions
    {
        private static DistributedCacheEntryOptions SlidingExpiration(TimeSpan expiration) => new DistributedCacheEntryOptions
        {
            SlidingExpiration = expiration
        };

        private static DistributedCacheEntryOptions Sliding30Minutes => SlidingExpiration(TimeSpan.FromMinutes(30));

        public static T Get<T>(this IDistributedCache cache, string key)
        {
            var v = cache.GetString(key);

            if (v == null)
            {
                Log.Error("Session with the key " + key + " is not found");
                return default(T);
            }

            var deserialized = JsonConvert.DeserializeObject<T>(v);
            return deserialized;
        }

        public static async Task<object> Get(this IDistributedCache cache, string key)
        {
            var v = await cache.GetStringAsync(key);
            var deserialized = Jil.JSON.Deserialize<object>(v);
            return deserialized;
        }

        public static async Task SetSession(this IDistributedCache cache, string key, object value, TimeSpan? slidingExpiration)
        {
            // var serialized = Jil.JSON.Serialize(value, JilOptions.Server);

            var serialized = JsonConvert.SerializeObject(value);
            if (slidingExpiration.HasValue)
            {
                await cache.SetStringAsync(key, serialized);
            }
            else
                await cache.SetStringAsync(key, serialized, Sliding30Minutes);
        }

        private static byte[] Serialize(object o)
        {
            if (o == null)
            {
                return null;
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, o);
                byte[] objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        private static T Deserialize<T>(byte[] stream)
        {
            if (stream == null)
            {
                return default(T);
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream(stream))
            {
                T result = (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }
    }
}