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

using Transmitly.Delivery;

namespace Transmitly
{
	/// <summary>
	/// Represents the extend properties for a send grid delivery report.
	/// </summary>
	public interface IDeliveryReportExtendedProperties
	{
		/// <summary>
		/// Adapts the SendGrid delivery report to a <see cref="IDeliveryReportExtendedProperties"/>
		/// </summary>
		/// <param name="report">SendGrid report to adapt.</param>
		/// <returns>Extended proprties bag.</returns>
		IDeliveryReportExtendedProperties Adapt(DeliveryReport report);

		/// <summary>
		/// Extended properties for a SengGrid email deliveryReport.
		/// </summary>
		IEmailExtendedDeliveryReportProperties Email { get; }
	}
}