using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RicercaPratiche.DesktopModules.RegioneMarche2016.RicercaPratiche
{
	/// <summary>
	/// Descrizione di riepilogo per HandlerDeteilsRequest
	/// </summary>
	public class HandlerDeteilsRequest : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			try
			{
				string AdempimentoID			= context.Request.QueryString["aid"];
				context.Response.ContentType	= "text/html";
				context.Response.Write(RenderPartialToString(AdempimentoID));
			}
			catch (Exception ex)
			{
				context.Response.Write(ex.Message);
			}
		}
		// ==============================================
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ModuleId"></param>
		/// <returns></returns>
		private string RenderPartialToString(string AdempimentoID)
		{
			System.IO.StringWriter writer		= new System.IO.StringWriter();
			HttpContext.Current.Server.Execute("Default.aspx?ID=" + AdempimentoID.ToString(), writer, false);
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