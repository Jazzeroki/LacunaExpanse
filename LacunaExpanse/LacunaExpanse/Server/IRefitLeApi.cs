using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LacunaExpanseAPIWrapper.ResponseModels;

namespace LacunaExpanse.Server
{
	public interface IRefitLeApi
	{
		[Post("/empire")]
		Task<Response> Empire([Body] string Request);
		[Post("/inbox")]
		Task<Response> Inbox([Body] string Request);
	}
}
