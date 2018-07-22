using System.Net.Http;

namespace Shelter
{
	internal class FilesGateway : IFilesGateway
	{
		private readonly HttpClient client;

		public FilesGateway(HttpClient client)
		{
			this.client = client;
		}
	}
}