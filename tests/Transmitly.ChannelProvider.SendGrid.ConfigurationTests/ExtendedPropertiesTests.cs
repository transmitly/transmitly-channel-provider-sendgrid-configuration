// Copyright (c) Code Impressions, LLC. All Rights Reserved.
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

using Moq;
using Transmitly.Channel.Configuration.Email;
using Transmitly.ChannelProvider.SendGrid.Configuration;
using Transmitly.Delivery;

namespace Transmitly.ChannelProvider.SendGrid.ConfigurationTests
{
	/// <summary>
	/// SendGrid values live on the channel or report itself, so nothing has to be registered for them to be kept.
	/// </summary>
	[TestClass]
	public sealed class ExtendedPropertiesTests
	{
		[TestMethod]
		public void TemplateId_IsKeptOnTheChannel_WithoutRegistration()
		{
			IExtendedProperties bag = new ExtendedProperties();
			var channel = Mock.Of<IEmailChannelConfiguration>(c => c.ExtendedProperties == bag);

			channel.SendGrid().TemplateId = "d-123";

			Assert.AreEqual("d-123", channel.SendGrid().TemplateId);
			Assert.AreEqual("d-123", bag.GetValue<string>(SendGridConstant.EmailPropertiesKey, "TemplateId"));
		}

		[TestMethod]
		public void TemplateId_SetOnTheChannel_IsReadFromTheDispatchedEmail()
		{
			// Core hands the channel's extended properties to the email it builds for dispatch.
			IExtendedProperties bag = new ExtendedProperties();
			Mock.Of<IEmailChannelConfiguration>(c => c.ExtendedProperties == bag).SendGrid().TemplateId = "d-123";

			var email = Mock.Of<IEmail>(e => e.ExtendedProperties == bag);

			Assert.AreEqual("d-123", email.SendGrid().TemplateId);
		}

		[TestMethod]
		public void DeliveryReportValues_RoundTrip_WithoutRegistration()
		{
			var report = new DeliveryReport(DeliveryReport.Event.StatusChanged(), "Email", "SendGrid", null, null, "msg-1", CommunicationsStatus.Info("SendGrid", "bounce"), null, null, null);

			var written = report.SendGrid().Email;
			written.Event = "bounce";
			written.Reason = "550 no such user";
			written.Timestamp = DateTimeOffset.FromUnixTimeSeconds(1762300000);
			written.Attempt = 3;
			written.AsmGroupId = 7;
			written.Categories = new[] { "statements", "monthly" };

			var read = report.SendGrid().Email;
			Assert.AreEqual("bounce", read.Event);
			Assert.AreEqual("550 no such user", read.Reason);
			Assert.AreEqual(DateTimeOffset.FromUnixTimeSeconds(1762300000), read.Timestamp);
			Assert.AreEqual(3, read.Attempt);
			Assert.AreEqual(7, read.AsmGroupId);
			CollectionAssert.AreEqual(new[] { "statements", "monthly" }, read.Categories!.ToArray());
		}
	}
}
