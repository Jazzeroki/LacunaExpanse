using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Fusillade;
using LacunaExpanseAPIWrapper.ResponseModels;
using Refit;
using Akavache;
using Plugin.Connectivity;
using Polly;

namespace LacunaExpanse.Server
{
	public class RefitApiService : ILeApi
	{
		public async Task<Response> Empire(Priority priority, string request)
		{
			var cache = BlobCache.LocalMachine;
			var cached = cache.GetAndFetchLatest("co", () => EmpireAsync(priority, request),
				offset =>
				{
					TimeSpan elapsed = DateTimeOffset.Now - offset;
					return elapsed > new TimeSpan(hours: 1, minutes: 30, seconds: 0);
				});
			var response = await cached.FirstOrDefaultAsync();
			return response;
		}

		private readonly IApiService _apiService;
		public RefitApiService(IApiService apiService)
		{
			_apiService = apiService;
		}


		public async Task<Response> EmpireAsync(Priority priority, string request)
		{
			Response conference = null;

			Task<Response> EmpireTask;
			try
			{
				switch (priority)
				{
					case Priority.Background:
						EmpireTask = _apiService.Background.Empire(request);
						break;
					case Priority.UserInitiated:
						EmpireTask = _apiService.UserInitiated.Empire(request);
						break;
					case Priority.Speculative:
						EmpireTask = _apiService.Speculative.Empire(request);
						break;
					default:
						EmpireTask = _apiService.UserInitiated.Empire(request);
						break;
				}

				if (CrossConnectivity.Current.IsConnected)
				{
					conference = await Policy
						.Handle<Exception>()
						.RetryAsync(retryCount: 5)
						.ExecuteAsync(async () => await EmpireTask);
				}
			}
			catch (Exception ex)
			{
				var t = ex;
				Xamarin.Insights.Report(ex);
			}


			return conference;
		}
		public async Task<Response> InboxAsync(Priority priority, string request)
		{
			Response conference = null;

			Task<Response> InboxTask;
			try
			{
				switch (priority)
				{
					case Priority.Background:
						InboxTask = _apiService.Background.Inbox(request);
						break;
					case Priority.UserInitiated:
						InboxTask = _apiService.UserInitiated.Inbox(request);
						break;
					case Priority.Speculative:
						InboxTask = _apiService.Speculative.Inbox(request);
						break;
					default:
						InboxTask = _apiService.UserInitiated.Inbox(request);
						break;
				}

				if (CrossConnectivity.Current.IsConnected)
				{
					conference = await Policy
						.Handle<Exception>()
						.RetryAsync(retryCount: 5)
						.ExecuteAsync(async () => await InboxTask);
				}
			}
			catch (Exception ex)
			{
				var t = ex;
				Xamarin.Insights.Report(ex);
			}


			return conference;
		}
	}
}
