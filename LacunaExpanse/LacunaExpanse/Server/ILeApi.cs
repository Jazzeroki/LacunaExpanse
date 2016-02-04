using LacunaExpanseAPIWrapper.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fusillade;

namespace LacunaExpanse.Server
{
	public interface ILeApi
	{
		Task<Response> Empire(Priority priority, string request);
	}
}
