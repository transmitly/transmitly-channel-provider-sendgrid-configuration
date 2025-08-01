﻿// ﻿﻿Copyright (c) Code Impressions, LLC. All Rights Reserved.
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
using Transmitly.Channel.Configuration.Email;
using Transmitly.ChannelProvider.SendGrid.Configuration;
using Transmitly.Delivery;
using Transmitly.Util;

namespace Transmitly
{
	/// <summary>
	///  Extensions for SendGrid specific channel provider configuration.
	/// </summary>
	public static class SendGridChannelProviderConfigurationExtensions
	{
		/// <summary>
		/// Returns the SendGrid channel provider identifier.
		/// </summary>
		/// <param name="channelProviders">Channel providers.</param>
		/// <param name="providerId">Optional provider identifier.</param>
		/// <returns>SendGrid channel identifier.</returns>
		public static string SendGrid(this ChannelProviders channelProviders, string? providerId = null)
		{
			Guard.AgainstNull(channelProviders);
			return channelProviders.GetId(SendGridConstant.Id, providerId);
		}

		/// <summary>
		/// SendGrid specific settings for Email channels.
		/// </summary>
		/// <param name="email">Email Channel.</param>
		/// <returns>SendGrid Email properties.</returns>
		public static IEmailExtendedChannelProperties SendGrid(this IEmailChannelConfiguration email)
		{
			Guard.AgainstNull(email);
			return SendGridChannelProviderExtendedPropertiesBuilderExtensions.Email.Adapt(email);
		}

		/// <summary>
		/// Infobip specific settings for sms delivery reports.
		/// </summary>
		/// <param name="deliveryReport">Delivery Report.</param>
		/// <returns>Infobip SMS delivery report properties.</returns>
		public static IDeliveryReportExtendedProperties SendGrid(this DeliveryReport deliveryReport)
		{
			return SendGridChannelProviderExtendedPropertiesBuilderExtensions.DeliveryReport.Adapt(deliveryReport);
		}
	}
}