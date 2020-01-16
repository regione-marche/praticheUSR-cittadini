using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RicercaPratiche.DesktopModules.RegioneMarche2016.RicercaPratiche
{
	/// <summary>
	/// Descrizione di riepilogo per HandlerDetails
	/// </summary>
	public class HandlerDetails : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			try
			{
				string AdempimentoID = context.Request.QueryString["aid"];
				string Position = context.Request.QueryString["position"];
				context.Response.ContentType = "text/html";
				context.Response.Write(RenderPartialToString(AdempimentoID, Position));
			}
			catch (Exception ex)
			{
				context.Response.Write(ex.ToString());
			}
		}
		// ==============================================
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ModuleId"></param>
		/// <returns></returns>
		private string RenderPartialToString(string AdempimentoID, string position)
		{
			System.IO.StringWriter writer = new System.IO.StringWriter();
			HttpContext.Current.Server.Execute("Dettagli/" + position + ".aspx?aid=" + AdempimentoID, writer, false);
			return writer.ToString();
		}
		// ==============================================
		/// <summary>
		/// 
		/// </summary>
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}