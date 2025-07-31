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

using Moq;
using Transmitly.Channel.Configuration.Email;
using Transmitly.ChannelProvider.SendGrid.Configuration;
using Transmitly.Delivery;

namespace Transmitly.ChannelProvider.SendGrid.ConfigurationTests
{
    [TestClass]
    public sealed class ExtendedPropertiesSetupTests
    {
        [TestInitialize]
        public void Init()
        {
            // since the registration should happen in a single threaded env (Startup/Program.cs)
            // we'll reset and force each test execution to start 'fresh'
            SendGridChannelProviderExtendedPropertiesBuilderExtensions.Reset();
        }

        [TestMethod]
        public void SmsExtensionShouldReturnEmptyBagIfNotConfigured()
        {
            var emailConfig = new Mock<IEmailChannelConfiguration>();
            emailConfig.SetupAllProperties();
            var result = SendGridChannelProviderConfigurationExtensions.SendGrid(emailConfig.Object);
            Assert.IsInstanceOfType<EmptyEmailExtendedChannelProperties>(result);
        }

        [TestMethod]
        public void SmsExtensionShouldReturnConfiguredPropertyBag()
        {
            var emailConfig = new Mock<IEmailChannelConfiguration>();
            var mockBag = new Mock<IEmailExtendedChannelProperties>();
            mockBag.SetupAllProperties();

            SendGridChannelProviderExtendedPropertiesBuilderExtensions.AddEmailExtendedPropertiesAdaptor<MockEmailBag>(null);
            var result = SendGridChannelProviderConfigurationExtensions.SendGrid(emailConfig.Object);

            Assert.IsInstanceOfType<MockEmailBag>(result);
        }

        [TestMethod]
        public void DeliveryReportExtensionShouldReturnEmptyBagIfNotConfigured()
        {
            var report = new DeliveryReport(null, null, null, null, null, null, null, null, null, null);
            var result = SendGridChannelProviderConfigurationExtensions.SendGrid(report);
            Assert.IsInstanceOfType<EmptyDeliveryReportExtendedProprties>(result);
        }

        [TestMethod]
        public void DeliveryExtensionShouldReturnConfiguredPropertyBag()
        {
            var report = new DeliveryReport(null, null, null, null, null, null, null, null, null, null);
            var mockBag = new Mock<IEmailExtendedChannelProperties>();
            mockBag.SetupAllProperties();

            SendGridChannelProviderExtendedPropertiesBuilderExtensions.AddDeliveryReportExtendedProprtiesAdaptor<MockDeliveryReportBag>(null);
            var result = SendGridChannelProviderConfigurationExtensions.SendGrid(report);

            Assert.IsInstanceOfType<MockDeliveryReportBag>(result);
        }
    }
}