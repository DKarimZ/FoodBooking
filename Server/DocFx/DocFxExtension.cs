using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocFx
{

	/// <summary>
	/// classe concernat la classe d'extension DOCFX
	/// </summary>
	public static class DocFxExtension
	{
		/// <summary>
		/// Ajouter l'intergiciel Server static files
		/// </summary>
		/// <param name="app"></param>
		/// <param name="settings"></param>
		/// <returns></returns>
		public static IApplicationBuilder UseDocFx(this IApplicationBuilder app, Action<DocFxSettings> configure = null)
		{

			//Options de configuration
			DocFxSettings settings = new DocFxSettings();
			if (configure == null)
			{
				settings.rootPath = "/docFx";
			}
			else
			{
				configure.Invoke(settings);

			}
			//servir les fichiers statics sur l'URI rootPath
			app.UseFileServer(new FileServerOptions
			{
				RequestPath = new PathString(settings.rootPath),
				FileProvider = new EmbeddedFileProvider(typeof(DocFxExtension).GetTypeInfo().Assembly, "DocFx._site")

			});


			return app;

		}
	}
}
