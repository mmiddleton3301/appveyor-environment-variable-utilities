// ----------------------------------------------------------------------------
// <copyright file="EvuSession.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Logic
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Meridian.AppVeyorEvu.Logic.Definitions;

    /// <summary>
    /// Implements <see cref="IEvuSession" />.
    /// </summary> 
    public class EvuSession : IEvuSession
    {
        /// <summary>
        /// The base URI for the AppVeyor API.
        /// </summary>
        private const string AppVeyorApiBaseUri = 
            "https://ci.appveyor.com/api/";

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
        /// <param name="environments">
        /// A list of environment names, as they appear in AppVeyor.
        /// </param>
        /// <returns>
        /// Returns true if the process completed with success, otherwise
        /// false.
        /// </returns>
        public bool CompareEnvironmentVariables(
            string apiToken,
            string[] environments)
        {
            bool toReturn = default(bool);

            this.loggingProvider.Debug(
                "Attempting to pull back all environments...");

            Models.Environment[] allEnvironments =
                this.ExecuteAppVeyorApi<Models.Environment[]>(
                    apiToken,
                    new Uri("./environments", UriKind.Relative));

            this.loggingProvider.Info(
                $"{allEnvironments.Length} environment(s) returned.");

            this.loggingProvider.Debug("Environments returned:");

            foreach (Models.Environment environment in allEnvironments)
            {
                this.loggingProvider.Debug($"-> {environment}");
            }

            string environmentsPassedIn = string.Join(
                ", ",
                environments.Select(x => $"\"{x}\""));

            this.loggingProvider.Debug(
                $"Selecting environment names passed in " +
                $"({environmentsPassedIn}) from the ones pulled back from " +
                $"the API...");

            Models.Environment[] matchingEnvs = allEnvironments
                .Where(x => environments.Contains(x.Name))
                .ToArray();

            if (environments.Length != matchingEnvs.Length)
            {
                string[] notMatched = environments
                    .Except(matchingEnvs.Select(y => y.Name))
                    .ToArray();

                string notMatchedDesc = string.Join(
                    ", ",
                    notMatched.Select(x => $"\"{x}\""));

                this.loggingProvider.Warn(
                    $"Warning! Could not find more than one environment " +
                    $"passed in! Environments not found: {notMatchedDesc}. " +
                    $"Execution will continue with found environments.");
            }
                
            return toReturn;
        }

        /// <summary>
        /// Executes a <paramref name="methodEndpoint" /> against the AppVeyor
        /// API.
        /// </summary>
        /// <typeparam name="ResultType">
        /// A model type representing the returned JSON.
        /// </typeparam>
        /// <param name="apiToken">
        /// The AppVeyor API token to be used.
        /// </param>
        /// <param name="methodEndpoint">
        /// The method endpoint to invoke.
        /// </param>
        /// <returns>
        /// The result as a <typeparamref name="ResultType" /> instance.
        /// </returns>
        private ResultType ExecuteAppVeyorApi<ResultType>(
            string apiToken,
            Uri methodEndpoint)
            where ResultType : class
        {
            ResultType toReturn = null;

            using (HttpClient httpClient = new HttpClient())
            {
                // Setup headers.
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", apiToken);

                Uri apiPath = new Uri(
                    new Uri(AppVeyorApiBaseUri),
                    methodEndpoint);

                this.loggingProvider.Debug($"Invoking {apiPath}...");

                // Get the list of roles
                Task<HttpResponseMessage> getTask =
                    httpClient.GetAsync(apiPath);

                using (HttpResponseMessage response = getTask.Result)
                {
                    this.loggingProvider.Debug(
                        $"HTTP response code returned: " +
                        $"{response.StatusCode}.");

                    response.EnsureSuccessStatusCode();

                    this.loggingProvider.Debug(
                        $"Reading results as {typeof(ResultType).Name}...");

                    Task<ResultType> readAsTask =
                        response.Content.ReadAsAsync<ResultType>();

                    this.loggingProvider.Debug("Results parsed with success.");

                    toReturn = readAsTask.Result;
                }
            }

            return toReturn;
        }
    }
}