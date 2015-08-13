﻿using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Net.Http.Headers;

namespace ModernDirectory.Services
{
		public class AuthenticatedHttpClientHandler : HttpClientHandler
		{
			private readonly Func<Task<string>> getToken;

			public AuthenticatedHttpClientHandler(Func<Task<string>> getToken)
			{
				if (getToken == null) throw new ArgumentNullException("getToken");
				this.getToken = getToken;
			}

			protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
			{
				// See if the request has an authorize header
				var auth = request.Headers.Authorization;
				if (auth != null)
				{
					var token = await getToken().ConfigureAwait(false);
					request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, token);
				}

				return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
			}
	}
}

