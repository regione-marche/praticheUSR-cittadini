using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework;
using RicercaPratiche.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RicercaPratiche.DesktopModules.RegioneMarche2016.RicercaPratiche
{
	/// <summary>
	/// 
	/// </summary>
	public partial class View : PortalModuleBase
	{
		/// <summary>
		/// 
		/// </summary>
		wsSisma16DBEntities db = new wsSisma16DBEntities();

		public wsSisma16DBEntities Db
		{
			get
			{
				return db;
			}

			set
			{
				db = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_search_ServerClick(object sender, EventArgs e)
		{
			/* */
			var pratiche = (from tba in Db.tmpvB02DettaglioPratica
							join tbb in db.tmpVB01StatoFasiPratica on tba.IdRichiesta equals tbb.IdRichiesta
							where tba.ImpresaAppaltatricePartitaIva == this.txt_Piva.Text
							orderby tba.DataProtocollo ascending
							select new JoinedClass()
							{
								StatoPraticheDettaglioEsteso = tba,
								VB01StatoFasiPratica = tbb
							}).Take(50);

			/* */
			this.pnl_NoResults.Visible = false;

			/* */
			this.rpt_elenco.DataSource = pratiche.ToList();
			this.rpt_elenco.DataBind();

			/* */
			this.pnl_NoResults.Visible = pratiche.Count() == 0;
		}
		/// <summary>
		/// 
		/// </summary>
		public override void Dispose()
		{
			this.Db.Dispose();
			base.Dispose();
		}
		/// <summary>
		/// 
		/// </summary>
		public class JoinedClass
		{
			public tmpvB02DettaglioPratica StatoPraticheDettaglioEsteso { get; set; }
			public tmpVB01StatoFasiPratica VB01StatoFasiPratica { get; set; }
		}
	}
}