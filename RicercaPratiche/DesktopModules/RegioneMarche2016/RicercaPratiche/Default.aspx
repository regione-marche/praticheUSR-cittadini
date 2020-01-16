<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RicercaPratiche.DesktopModules.RegioneMarche2016.RicercaPratiche.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%;" border="0">
            <tr>
                <td style="width: 2%;">&nbsp;</td>
                <td colspan="4">
                    <h3>
                        <asp:Label ID="ltl_CodiceFascicolo" runat="server" Width="99%"></asp:Label>
                    </h3>

                </td>
            </tr>
            <tr>
                <th style="width: 2%;">&nbsp;</th>
                <th style="width: 25%; background-color: #ffe7e7">
                    <br />
                    USR<br />
                    &nbsp;<br />
                </th>
                <th style="width: 25%; background-color: #c4ffa5">COMUNE</th>
                <th style="width: 25%; background-color: #bbfffb">PROFESSIONISTA</th>
                <th style="width: 25%; background-color: #ffdfad">CONFERENZA</th>
            </tr>
			
            <tr>
                <td>12</td>
                <td>
                    <asp:Label CssClass="lightGray" ID="ltl_Concessione_contributo_USR" Text="Concessione contributo USR" runat="server" data-toggle="popover" data-position="ConcessioneContributo"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>13</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label CssClass="lightGray" ID="ltl_Esecuzione_Lavori" Text="Esecuzione lavori" runat="server" data-toggle="popover" data-position="EsecuzioneLavori"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>14</td>
                <td>
                    <asp:Label CssClass="lightGray" ID="ltl_Istruttoria_SAL_USR" Text="Istruttoria SAL USR" runat="server" data-toggle="popover" data-position="IstruttoriaSALUSR"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>15</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label CssClass="lightGray" ID="ltl_Integrazione_ProfessionistaSAL" Text="Integrazione professionista SAL" runat="server" data-toggle="popover" data-position="IntegrazioneProfessionistaSAL"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>16</td>
                <td>
                    <asp:Label CssClass="lightGray" ID="ltl_Autorizzazione_Pagamento" Text="Autorizzazione pagamento" runat="server" data-toggle="popover" data-position="AutorizzazionePagamentoSAL"></asp:Label></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>17</td>
                <td>
                    <asp:Label CssClass="lightGray" ID="ltl_Pratica_Conclusa" Text="Pratica conclusa positivamente" runat="server"></asp:Label></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>18</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label CssClass="lightGray" ID="ltl_Rinuncia" Text="Rinuncia" runat="server"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
    <script>
        $(document).ready(function () {



            var pos = 0;
            $('.green, .yellow').popover({
                html: true,
                placement: "top",
                trigger: 'manual',
                content: function () {
                    return $.ajax({
                        url: '/DesktopModules/RegioneMarche2016/RicercaPratichePI/HandlerDetails.ashx?position=' + pos + '&aid=<%=this.Request.QueryString["ID"] ?? "1"%>',
                        dataType: 'html',
                        async: false
                    }).responseText;
                }
            }).click(function (e) {
                pos = $(this).attr("data-position");
                $(this).popover('toggle');
            });
        });
    </script>
</body>
</html>

