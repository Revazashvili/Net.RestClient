﻿using System;
using Newtonsoft.Json;

namespace Net.RestClient.Models.ValueObjects
{
    public class ConcreteTypeConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer,value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<T>(reader);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}