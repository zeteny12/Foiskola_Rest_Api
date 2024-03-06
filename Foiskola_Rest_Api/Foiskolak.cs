﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Foiskola_Rest_Api;
//
//    var foiskolak = Foiskolak.FromJson(jsonString);

namespace Foiskola_Rest_Api
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Foiskolak
    {
        [JsonProperty("alpha_two_code")]
        public AlphaTwoCode AlphaTwoCode { get; set; }

        [JsonProperty("web_pages")]
        public Uri[] WebPages { get; set; }

        [JsonProperty("state-province")]
        public string StateProvince { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("domains")]
        public string[] Domains { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }
    }

    public enum AlphaTwoCode { Hu };

    public enum Country { Hungary };

    public partial class Foiskolak
    {
        public static Foiskolak[] FromJson(string json) => JsonConvert.DeserializeObject<Foiskolak[]>(json, Foiskola_Rest_Api.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Foiskolak[] self) => JsonConvert.SerializeObject(self, Foiskola_Rest_Api.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                AlphaTwoCodeConverter.Singleton,
                CountryConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class AlphaTwoCodeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AlphaTwoCode) || t == typeof(AlphaTwoCode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "HU")
            {
                return AlphaTwoCode.Hu;
            }
            throw new Exception("Cannot unmarshal type AlphaTwoCode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AlphaTwoCode)untypedValue;
            if (value == AlphaTwoCode.Hu)
            {
                serializer.Serialize(writer, "HU");
                return;
            }
            throw new Exception("Cannot marshal type AlphaTwoCode");
        }

        public static readonly AlphaTwoCodeConverter Singleton = new AlphaTwoCodeConverter();
    }

    internal class CountryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Country) || t == typeof(Country?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Hungary")
            {
                return Country.Hungary;
            }
            throw new Exception("Cannot unmarshal type Country");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Country)untypedValue;
            if (value == Country.Hungary)
            {
                serializer.Serialize(writer, "Hungary");
                return;
            }
            throw new Exception("Cannot marshal type Country");
        }

        public static readonly CountryConverter Singleton = new CountryConverter();
    }
}