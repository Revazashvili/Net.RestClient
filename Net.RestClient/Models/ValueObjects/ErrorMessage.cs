﻿using Net.RestClient.Models.Primitives;

namespace Net.RestClient.Models.ValueObjects
{
    public class ErrorMessage : IErrorMessage
    {
        public ErrorMessage() { }
        
        public ErrorMessage(string value)
        {
            Key = "unknown";
            Value = value;
        }

        public ErrorMessage(string key,string value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}