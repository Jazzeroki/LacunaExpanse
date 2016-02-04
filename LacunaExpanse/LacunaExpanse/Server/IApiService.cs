using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanse.Server
{
	public interface IApiService
	{
		IRefitLeApi Speculative { get; }
		IRefitLeApi UserInitiated { get; }
		IRefitLeApi Background { get; }
	}
}
