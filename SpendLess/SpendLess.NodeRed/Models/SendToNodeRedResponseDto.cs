﻿using Newtonsoft.Json;
using SpendLess.Domain.Constants;

namespace SpendLess.NodeRed.Models
{
    public class SendToNodeRedResponseDto
    {
        public required SendToNodeRedResponseDtoTransaction Transaction { get; set; }
    }

    public class SendToNodeRedResponseDtoTransaction
    {
        [JsonRequired]
        public required decimal Amount { get; set; }
        public HashSet<string> Tags { get; set; } = [];
        public string Category { get; set; } = SpendLessConstants.DefaultCategory;
        public SendToNodeRedResponseDtoAccountData Source { get; set; } = new();
        public SendToNodeRedResponseDtoAccountData Destination { get; set; } = new();
        public string Description { get; set; } = "";
    }

    public class SendToNodeRedResponseDtoAccountData
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}