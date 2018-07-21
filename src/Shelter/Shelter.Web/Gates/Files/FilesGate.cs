using System.Net.Http;

namespace Shelter
{
	internal class FilesGate : IFilesGate
	{
		private readonly HttpClient client;

		public FilesGate(HttpClient client)
		{
			this.client = client;
		}
	}
}