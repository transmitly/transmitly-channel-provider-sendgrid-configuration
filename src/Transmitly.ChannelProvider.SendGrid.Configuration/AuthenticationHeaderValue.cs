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
using Transmitly.Util;

namespace Transmitly.ChannelProvider.SendGrid.Configuration
{
	/// <summary>
	/// Represents an authentication header value used in HTTP requests.
	/// </summary>
	/// <param name="scheme">Authentication scheme. Example: Bearer</param>
	/// <param name="parameter">The parameter value associated with the authentication scheme (e.g., API key).</param>
	public sealed class AuthenticationHeaderValue(string scheme, string parameter) : ICloneable
	{
		private AuthenticationHeaderValue(AuthenticationHeaderValue cloneObj) : this(cloneObj.Scheme, cloneObj.Parameter)
		{
			Guard.AgainstNull(cloneObj);
		}

		/// <summary>
		/// The authentication scheme (e.g., "Bearer").
		/// </summary>
		public string Scheme { get; set; } = scheme;
		/// <summary>
		/// The parameter value associated with the authentication scheme (e.g., API key).
		/// </summary>
		public string Parameter { get; set; } = parameter;

		object ICloneable.Clone()
		{
			return new AuthenticationHeaderValue(this);
		}
	}
}