using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MongoDB.Bson;
//public abstract class JsonConverter<T> : System.Text.Json.Serialization.JsonConverter

namespace Net6ApiExmple.Application.utils
{
    /// <summary>
    /// come from:https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-converters-how-to?pivots=dotnet-5-0
    /// </summary>
    public class JsonObjectIdConverterBySystemTextJson : JsonConverter<ObjectId>
    {

        public override ObjectId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => new ObjectId(JsonSerializer.Deserialize<string>(ref reader, options));


        // public override void Write(Utf8JsonWriter writer, ObjectId value, JsonSerializerOptions options) => writer.WriteNumberValue(value.Id);


        public override void Write(Utf8JsonWriter writer, ObjectId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}

