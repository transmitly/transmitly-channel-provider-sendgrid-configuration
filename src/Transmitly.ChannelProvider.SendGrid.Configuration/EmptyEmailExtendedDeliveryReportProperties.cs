// ﻿﻿Copyright (c) Code Impressions, LLC. All Rights Reserved.
//  
//  Licensed under the Apache License, Version 2.0 (the "License")
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using System;
using System.Collections.Generic;
using Transmitly.Channel.Configuration.Email;

namespace Transmitly.ChannelProvider.SendGrid.Configuration
{
    sealed class EmptyEmailExtendedDeliveryReportProperties : IEmailExtendedDeliveryReportProperties
    {
        public int? AsmGroupId { get; set; }
        public string? BounceClassification { get; set; }
        public IReadOnlyCollection<string>? Categories { get; set; }
        public string? Domain { get; set; }
        public string? Email { get; set; }
        public string? Event { get; set; }
        public string? EventId { get; set; }
        public string? From { get; set; }
        public bool? MachineOpen { get; set; }
        public string? MessageId { get; set; }
        public string? Reason { get; set; }
        public string? Response { get; set; }
        public string? SmtpId { get; set; }
        public string? Status { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public string? Type { get; set; }
        public string? Url { get; set; }
        public string? UserAgent { get; set; }
        public int? Attempt { get; set; }
        public string? Ip { get; set; }

        public IEmailExtendedChannelProperties Adapt(IEmailChannelConfiguration email)
        {
            return new EmptyEmailExtendedChannelProperties();
        }
    }
}