﻿using System;
using iqoptionapi.models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iqoptionapi.ws.request {
    public class GetCandleItemRequestMessage : WsMessageBase<GetCandlesRequestModel> {

        public GetCandleItemRequestMessage(ActivePair pair, int size, int count, DateTimeOffset to) {
            base.Message = new GetCandlesRequestModel() {
               RequestBody = new GetCandlesRequestModel.GetCandlesRequestBody() {
                   ActivePair = pair,
                   Size = size,
                   Count = count,
                   To = to.ToUniversalTime() // servertime should set here
               }
            };
        }
        public override string Name => "sendMessage";
    }


    public class GetCandlesRequestModel
    {

        [JsonProperty("name")]
        public string Name => "get-candles";

        [JsonProperty("version")]
        public string Version => "2.0";

        [JsonProperty("body")]
        public GetCandlesRequestBody RequestBody { get; set; }

        public class GetCandlesRequestBody
        {

            [JsonProperty("active_id")]
            public ActivePair ActivePair { get; set; }

            [JsonProperty("size")]
            public int Size { get; set; }

            [JsonProperty("to")]
            [JsonConverter(typeof(UnixDateTimeConverter))]
            public DateTimeOffset To { get; set; }

            [JsonProperty("count")]
            public int Count { get; set; }
        }
    }
}