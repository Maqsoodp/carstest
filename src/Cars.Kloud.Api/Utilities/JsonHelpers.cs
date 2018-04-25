using System;
using System.IO;
using Newtonsoft.Json;

namespace Cars.Kloud.Api.Utilities
{
    public static class JsonHelpers
    {
        public static T CreateFromJsonStream<T>(this Stream stream)
        {
            var serializer = new JsonSerializer();
            T data;
            //disposes the stream as using streamreader 
            using (var streamReader = new StreamReader(stream))
            {
                data = (T)serializer.Deserialize(streamReader, typeof(T));
            }
            return data;
        }
    }
}