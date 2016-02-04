using Fusillade;
using ModernHttpClient;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanse.Server
{
	public class ApiService : IApiService
	{
		private readonly Lazy<IRefitLeApi> _background;
		private readonly Lazy<IRefitLeApi> _userInitiated;
		private readonly Lazy<IRefitLeApi> _speculative;

		public IRefitLeApi Background
		{
			get
			{
				return _background.Value;
			}
		}

		public IRefitLeApi Speculative
		{
			get
			{
				return _speculative.Value;
			}
		}

		public IRefitLeApi UserInitiated
		{
			get
			{
				return _userInitiated.Value;
			}
		}

		public const string ApiBaseAddress = "https://us1.lacunaexpanse.com/";
		public ApiService(string apiBaseAddress = null)
		{
			System.Diagnostics.Debug.WriteLine(apiBaseAddress);
			Func<HttpMessageHandler, IRefitLeApi> createClient = messageHandler =>
			{
				var client = new HttpClient(messageHandler)
				{
					BaseAddress = new Uri(apiBaseAddress ?? ApiBaseAddress)
				};
				var r = RestService.For<IRefitLeApi>(client);
				System.Diagnostics.Debug.WriteLine(client.BaseAddress);
				return r;
			};

			_background = new Lazy<IRefitLeApi>(() => createClient(
				new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Background)));

			_userInitiated = new Lazy<IRefitLeApi>(() => createClient(
				new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.UserInitiated)));

			_speculative = new Lazy<IRefitLeApi>(() => createClient(
				new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Speculative)));
		}
	}
}
