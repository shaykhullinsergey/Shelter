using System.Net.Http;

namespace Shelter
{
	internal class MangasGate : IMangasGate
	{
		private readonly HttpClient client;

		public MangasGate(HttpClient client)
		{
			this.client = client;
		}
	}
}