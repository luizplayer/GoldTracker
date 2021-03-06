﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace GoldTracker
{
    public partial class Items
    {
        [JsonProperty("bags")]
        public Bag[] Bags { get; set; }
    }

    public partial class Bag
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("inventory")]
        public Inventory[] Inventory { get; set; }
    }

    public partial class Inventory
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("binding")]
        public string Binding { get; set; }

        [JsonProperty("skin", NullValueHandling = NullValueHandling.Ignore)]
        public long? Skin { get; set; }

        [JsonProperty("upgrades", NullValueHandling = NullValueHandling.Ignore)]
        public long[] Upgrades { get; set; }

        [JsonProperty("dyes", NullValueHandling = NullValueHandling.Ignore)]
        public long[] Dyes { get; set; }

        [JsonProperty("bound_to", NullValueHandling = NullValueHandling.Ignore)]
        public string BoundTo { get; set; }
    }

    public partial class Items
    {
        public static Items FromJson(string json) => JsonConvert.DeserializeObject<Items>(json, GoldTracker.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Items self) => JsonConvert.SerializeObject(self, GoldTracker.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}