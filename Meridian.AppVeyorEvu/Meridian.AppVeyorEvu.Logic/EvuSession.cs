// ----------------------------------------------------------------------------
// <copyright file="EvuSession.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Logic
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Meridian.AppVeyorEvu.Logic.Definitions;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Implements <see cref="IEvuSession" />.
    /// </summary> 
    public class EvuSession : IEvuSession
    {
        /// <summary>
        /// An instance of <see cref="ILoggingProvider" />.
        /// </summary>
        private readonly ILoggingProvider loggingProvider;

        /// <summary>
        /// Initialises a new instance of the <see cref="EvuSession" /> class.
        /// </summary>
        /// <param name="loggingProvider">
        /// An instance of <see cref="ILoggingProvider" />.
        /// </param>
        public EvuSession(ILoggingProvider loggingProvider)
        {
            this.loggingProvider = loggingProvider;
        }

        /// <summary>
        /// Implements <see cref="IEvuSession.Run()" />.
        /// </summary> 
        /// <param name="apiToken">
        /// The AppVeyor API token to be used.
        /// </param>
        /// <returns>
        /// Returns true if the process completed with success, otherwise
        /// false.
        /// </returns>
        public bool Run(string apiToken)
        {
            bool toReturn = default(bool);

            using (HttpClient httpClient = new HttpClient())
            {
                // Setup headers.
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", apiToken);

                // Get the list of roles
                Task<HttpResponseMessage> getTask =
                    httpClient.GetAsync("https://ci.appveyor.com/api/roles");

                using (HttpResponseMessage response = getTask.Result)
                {
                    response.EnsureSuccessStatusCode();

                    Task<JToken[]> readAsTask =
                        response.Content.ReadAsAsync<JToken[]>();

                    JToken[] roles = readAsTask.Result;

                    foreach (JToken role in roles)
                    {
                        this.loggingProvider.Warn(role.Value<string>("name"));
                    }
                }
            }

            return toReturn;
        }
    }
}