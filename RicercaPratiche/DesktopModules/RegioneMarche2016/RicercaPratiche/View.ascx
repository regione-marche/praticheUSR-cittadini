<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="RicercaPratiche.DesktopModules.RegioneMarche2016.RicercaPratiche.View" %>

<%--<%@ Import Namespace="wsPoint.DesktopModules.RegioneMarche2016.wsPoint.Model" %>--%>

<div class="col-sm-12">
	<div class="row">

		<div class="form-inline">

			<div class="form-group">
				<label for="email">Partita Iva: </label>
				<br />
				<asp:TextBox ID="txt_Piva" runat="server" CssClass="form-control" placeholder="inserisca la P.Iva da ricercare">
				</asp:TextBox>
			</div>

			<div class="form-group">
				<label for="pwd"></label>
				<br />
				<button type="submit" id="btn_search" class="btn btn-success" runat="server" onserverclick="btn_search_ServerClick">Effettua la ricerca</button>
			</div>

		</div>
	</div>


	<div class="row">
		<div class="col-sm-12">
			&nbsp;
		</div>
	</div>

	<div class="row">

		<div class="col-sm-12">

			<div class="table-responsive">
				<table class="table" id="tbl_List">
					<thead>
						<tr>
							<th>Fascicolo pratica</th>
							<th>Progettista</th>
							<th>Presentazione Progetto</th>

							<%--
                                <th>Stato pratica</th>
							--%>

							<th></th>
						</tr>
					</thead>
					<tbody>

						<asp:Repeater ID="rpt_elenco" runat="server">
							<ItemTemplate>
								<tr>
									<td><%# ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.CodiceFascicolo%> </td>
									<td><%# ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.Progettista%></td>
									<td><%# ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.DataProtocollo.Value.ToShortDateString()%></td>
									<td>
										<!--
                                        <button class="btn btn-success btnDetails" data-key=""><i class="fa fa-calendar"></i></button>
                                        -->
										<button class="btn btn-success btnWorkFlowPI" data-value="<%# ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.IdRichiesta%>"><i class="fa fa-gears"></i></button>

										<div id="mdl_workFlow" class="modal fade" role="dialog">
											<div class="modal-dialog modal-lg">

												<!-- Modal content-->
												<div class="modal-content">
													<div class="modal-header">
														<button type="button" class="close" data-dismiss="modal">&times;</button>
														<h3>Intervento n° <%# ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.NumeroIntervento.ToString() %>
															<br />
															Pratica protocollo n° <%# ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.NumProtocollo.ToString() %> del  <%# ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.DataProtocollo.Value.ToShortDateString() %>- Ordinanza <%# ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.Ordinanza.ToString() %>
															<br />
															Istruttore USR <%# ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.IstruttoreUSR.ToString() %>
														</h3>
														<h4>La tua pratica è nella fase '<b style="color: #ff6a00; text-transform: uppercase;"><%# GetFase(((JoinedClass)Container.DataItem ), ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.IdRichiesta) %></b>' </h4>
														<h4>Per ulteriori informazioni contattare <%# ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.IstruttoreUSR.ToString() %>, <%# GetContatti(((JoinedClass)Container.DataItem ), ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.IdRichiesta) %> o il tuo progettista <%# ((JoinedClass)Container.DataItem ).StatoPraticheDettaglioEsteso.Progettista %> </h4>
													</div>
													<div class="modal-body workFlowContent">
													</div>
												</div>
											</div>
										</div>

										<script runat="server">
											/// <summary>
											/// 
											/// </summary>
											/// <param name="dati"></param>
											/// <param name="IdRichiesta"></param>
											/// <returns></returns>
											string GetContatti(JoinedClass dati, int IdRichiesta)
											{
												string res = "";

												/* */
												if (dati.StatoPraticheDettaglioEsteso.Provincia.ToLower().Contains("mc") || dati.StatoPraticheDettaglioEsteso.Provincia.ToLower().Contains("an"))
												{
													res = "Edilizia privata : tel. 0733 904711 - Attività produttive : tel. 0733 289603";
												}
												else if (dati.StatoPraticheDettaglioEsteso.Provincia.ToLower().Contains("ap") || dati.StatoPraticheDettaglioEsteso.Provincia.ToLower().Contains("fm"))
												{
													res = "tel. 0736 30751";
												}

												/* */
												res = String.Format("email : <a href='mailto:{0}'>{0}</a> - ", dati.StatoPraticheDettaglioEsteso.EmailIstruttoreUSR) + res;

												/* */
												return res;
											}
											/// <summary>
											/// 
											/// </summary>
											/// <param name="dati"></param>
											/// <param name="IdRichiesta"></param>
											/// <returns></returns>
											string GetFase(JoinedClass dati, int IdRichiesta)
											{
												string res = IdRichiesta.ToString();
												if (dati.VB01StatoFasiPratica.VerificaAmmissibilitaUSR == "A")
													res = "USR : Verifica ammissibilità da parte dell'USR";
												else
													if (dati.VB01StatoFasiPratica.VerificaAmmissibilitaCM == "A")
													res = "Comune : Verifica ammissibilità da parte del Comune";
												else
													if (dati.VB01StatoFasiPratica.PreavvisoRigetto1 == "A")
													res = "Professionista : Preavviso di rigetto in fase di ammissibilità";
												else
													if (dati.VB01StatoFasiPratica.IstruttoriaCM == "A")
													res = "Comune : Istruttoria da parte del Comune";
												else
													if (dati.VB01StatoFasiPratica.RichiestaIntegrazioniCM == "A")
													res = "Professionista : Integrazione del Professionista per il Comune";
												else
													if (dati.VB01StatoFasiPratica.SanatoriaCM == "A")
													res = "Professionista : Sanatoria";
												else
													if (dati.VB01StatoFasiPratica.ConferenzaRegionale == "A")
													res = "Conferenza : Conferenza permanente Regionale";
												else
													if (dati.VB01StatoFasiPratica.IstruttoriaUSR == "A")
													res = "USR : Istruttoria da parte dell' USR";
												else
													if (dati.VB01StatoFasiPratica.RichiestaIntegrazioniUSR == "A")
													res = "Professionista : Integrazione del Professionista per l' USR";
												else
													if (dati.VB01StatoFasiPratica.PreavvisoRigetto2 == "A")
													res = "Professionista : Preavviso di rigetto a seguito di istruttoria";
												else
													if (dati.VB01StatoFasiPratica.ConcessioneContributoUSR == "A")
													res = "USR : Concessione Contributo";
												else
													if (dati.VB01StatoFasiPratica.IstruttoriaSAL == "A")
													res = "USR : Istruttoria SAL (Stato Avanzamento dei Lavori)";
												else
													if (dati.VB01StatoFasiPratica.RichiestaIntegrazioniSAL == "A")
													res = "Professionista : Integrazione del Professionista in SAL";
												else
													if (dati.VB01StatoFasiPratica.EsecuzioneLavori == "A")
													res = "Professionista : Esecuzione Lavori";
												else
													if (dati.VB01StatoFasiPratica.AutorizzazionePagamento == "A")
													res = "USR : Autorizzazione al Pagamento in SAL";
												else
													if (dati.VB01StatoFasiPratica.Rinuncia == 1)
													res = "Professionista : Rinuncia";
												else
													if (dati.VB01StatoFasiPratica.PraticaConclusa == 1)
													res = "USR : Pratica conclusa positivamente";
												else
													if (dati.VB01StatoFasiPratica.PraticaRigettata1 == 1)
													res = "USR : Pratica rigettata per inammissibilità";
												else
													if (dati.VB01StatoFasiPratica.PraticaRigettata2 == 1)
													res = "USR : Pratica rigettata a seguito di istruttoria";

												return res;
											}
										</script>

									</td>
								</tr>
							</ItemTemplate>
						</asp:Repeater>

					</tbody>
				</table>
				<asp:Panel ID="pnl_NoResults" runat="server" Visible="false">

					<p>
						<strong>Non risultano pratiche aperte presso l’USR.</strong><br />
						Attenzione: le istanze depositate su Mude vengono visualizzate
                        <br />
						solo dopo la protocollazione da parte dell’USR<br />
					</p>
				</asp:Panel>
			</div>
		</div>
	</div>
</div>

<script runat="server">
	//// ===========================================
	///// <summary>
	///// 
	///// </summary>
	///// <param name="ID_Richiesta"></param>
	///// <returns></returns>
	//string GetDetailsProtocollo(int ID_Richiesta)
	//{
	//    /* */
	//    string res = "N° Protocollo {0} del {1}";

	//    /* */
	//    try
	//    {

	//        /* */
	//        var rich = this.Db.DocumentiIstruttoriaUSR.FirstOrDefault(w => w.ID_Richiesta == ID_Richiesta);

	//        /* */
	//        if (rich != null)
	//            res = string.Format(res, rich.Numero_Protocollo, rich.Data_Protocollo);
	//        else
	//            res = "---";

	//    }
	//    catch (Exception ex)
	//    {

	//    }

	//    /* */
	//    return res;
	//}
	// ===========================================
</script>

<style>
	.tableMoreInfo {
		width: 100%;
	}

		.tableMoreInfo tr td {
			padding: .4em;
		}
</style>
<script>
	/* */
	$(document).ready(function () {
		/* */
		$('.btnDetails').click(function () {
			$(this).parent().find("#myModal").modal();
			return false;
		});

		/* */
		$('.btnWorkFlowPI').click(function () {
			var mdl = $(this).parent().find("#mdl_workFlow");
			mdl.modal();
			var aid = $(this).attr("data-value");
			$.get("/DesktopModules/RegioneMarche2016/RicercaPratichePI/HandlerDeteilsRequest.ashx?aid=" + aid, function (data, status) {
				$(mdl).find(".workFlowContent").html(data);
			});

			return false;
		});
	});
</script>
