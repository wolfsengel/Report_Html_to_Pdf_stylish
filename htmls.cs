namespace ReportHtmlPdf_Final.Logic
{

    internal class htmls
    {
        public static string page = $@"<div class=""page"">
        <header>
            --logo--
            <!--foto de proba-->
            <div class=""header"">
                <p>Spett. le</p>
                <p>--wrasoc--</p>
                <p>--wraso1--</p>
                <p>--windir--</p>
                <p>--wlocal--</p>
            </div>
        </header>
        <main>
            <table>
                <tr>
                    <th style=""width: 30%;"" class=""first"">
                        <!--quedei aqui-->
                        <p>Tipo Documento</p>
                    </th>
                    <th style=""width:10%"">
                        <p>Data</p>
                    </th>
                    <th style=""width: 10%;"" colspan=""2"">
                        <p class=""center"">Numero</p>
                    </th>
                    <th style=""width: 10%;"">
                        <p>Cod. Cliente</p>
                    </th>
                    <th style=""width:10%;"">
                        <p>Dest.</p>
                    </th>
                    <th>
                        <p>P.Iva / C.F.</p>
                    </th>
                    <th>
                        <p>Mag.</p>
                    </th>
                    <th>
                        <p>Operatore</p>
                    </th>
                </tr>
                <tr>
                    <td class=""first"">
                        <p>--wtidoc--</p>
                    </td>
                    <td>
                        <p>--wdafat--</p>
                    </td>
                    <td>
                        <p class=""right"">--wnufat--</p>
                    </td>
                    <td>
                        <p>--wsgfat--</p>
                    </td>
                    <td>
                        <p>--wcoana--</p>
                    </td>
                    <td>
                        <p>--wcodes--</p>
                    </td>
                    <td>
                        <p>--wcofis--</p>
                    </td>
                    <td>
                        <p>--wcomag--</p>
                    </td>
                    <td>
                        <p>--wopera--</p>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <th class=""first"" style=""width: 30;"">
                        <p>Modalità di pagamento</p>
                    </th>
                    <th>
                        <p>IBAN</p>
                    </th>
                    <th>
                        <p>SWIFT</p>
                    </th>
                    <th>
                        <p>Banca</p>
                    </th>
                    <th>
                        <p>Abi</p>
                    </th>
                    <th>
                        <p>Cab</p>
                    </th>
                </tr>
                <tr>
                    <td class=""first"">
                        <p>--wdepag--</p>
                    </td>
                    <td>
                        <p>--wiban--</p>
                    </td>
                    <td>
                        <p>--wswift--</p>
                    </td>
                    <td>
                        <p>--wbanca--</p>
                    </td>
                    <td>
                        <p>--wabi--</p>
                    </td>
                    <td>
                        <p>--wcab--</p>
                    </td>
                </tr>
            </table>
            <table class=""ojete"">
                <tr>
                    <th class=""first"" style=""width: 13%;"">
                        <p>Codice</p>
                    </th>
                    <th style=""width: 33%;"">
                        <p>Descrizione</p>
                    </th>
                    <th style=""width: 3%;"">
                        <p>Um</p>
                    </th>
                    <th style=""width: 3%;"">
                        <p>Colli</p>
                    </th>
                    <th style=""width: 9%;"">
                        <p>Quantità</p>
                    </th>
                    <th style=""width: 11%;"">
                        <p>Prezzo unit.</p>
                    </th>
                    <th style=""width: 5%;"">
                        <p>Sconti</p>
                    </th>
                    <th style=""width: 5%;"">
                        <p>Importo</p>
                    </th>
                    <th style=""width: 10%;"">
                        <p>Codice iva</p>
                    </th>
                </tr>";
        public static string footer_last = $@"</table>
        </main>
        <footer>
            <table style=""width: 100%; "">
                <tr>
                    <th style=""width: 20%; "">
                        <p>Totale merce</p>
                    </th>
                    <th>
                        <p>Tot. spese</p>
                    </th>
                    <th>
                        <p>Omaggi</p>
                    </th>
                    <th>
                        <p>Sc. Merce</p>
                    </th>
                    <th>
                        <p>Totale imponibile</p>
                    </th>
                    <th>
                        <p>Totale imposta</p>
                    </th>
                    <th>
                        <p>Totale documento</p>
                    </th>
                </tr>
                <tr>
                    <td>
                        <p>--%query_wtotme--</p>
                    </td> <td>
                        <p>--%query_wtotsp--</p>
                    </td>  <td>
                        <p>--%query_wtotom--</p>
                    </td> <td>
                        <p>--%query_wtotco--</p>
                    </td> <td>
                        <p>--%query_wimpon--</p>
                    </td> <td>
                        <p>--%query_wimpos--</p>
                    </td> 
                    <td>
                        <p style=""font-weight: bold; "" class=""right ""></p>
                    </td>
                </tr>
                <tr>
                    <th>
                        <p>Cod. iva</p>
                    </th>
                    <th style=""width: 30%; "">
                        <p>Descrizioneiva</p>
                    </th>
                    <th>
                        <p>Imponibile</p>
                    </th>
                    <th>
                        <p>Aliquota</p>
                    </th>
                    <th>
                        <p>Imposta</p>
                    </th>
                    <th>
                        <p>Scontrino</p>
                    </th>
                    <th>
                        <p>Abbuono</p>
                    </th>
                </tr>
                <tr>
                    <td>
                        <p>--%query_Wcoi01--</p>
                    </td> <td>
                        <p>--%query_Wiva01--</p>
                    </td> <td>
                        <p>--%query_Wimp01--</p>
                    </td> <td>
                        <p>--%query_Wali01--</p>
                    </td> <td>
                        <p>--%query_Wips01--</p>
                    </td>
                    <td rowspan=""4 "">
                        <table style=""border: 0; height: 100%; "">
                            <tr>
                                <td>
                                    <p>Numero</p>
                                    </th>
                                <td>
                                    <p>--%query_wNusco--</p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>Data</p>
                                    </th>
                                <td>
                                    <p>--%query_wdtsc--</p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>Matricola</p>
                                <td>
                                    <p>--%query_wmatricola--</p>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <p class=""right "">--%query_wabbuo--</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>--%query_Wcoi02--</p>
                    </td>
                    <td>
                        <p>--%query_Wiva02--</p>
                    </td>
                    <td>
                        <p>--%query_Wimp02--</p>
                    </td>
                    <td>
                        <p>--%query_Wali02--</p>
                    </td>
                    <td>
                        <p>--%query_Wips02--</p>
                    </td>
                    <th>
                        <p>Acconto</p>
                    </th>
                </tr>
                <tr>
                    <td>
                        <p>--%query_Wcoi03--</p>
                    </td>
                    <td>
                        <p>--%query_Wiva03--</p>
                    </td>
                    <td>
                        <p>--%query_Wimp03--</p>
                    </td>
                    <td>
                        <p>--%query_Wali03--</p>
                    </td>
                    <td>
                        <p>--%query_Wips03--</p>
                    </td>
                    <td>
                        <p class=""right "">--%query_waccon--</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>--%query_Wcoi04--</p>
                    </td>
                    <td>
                        <p>--%query_Wiva04--</p>
                    </td>
                    <td>
                        <p>--%query_Wimp04--</p>
                    </td>
                    <td>
                        <p>--%query_Wali04--</p>
                    </td>
                    <td>
                        <p>--%query_Wips04--</p>
                    </td>
                    <th>
                        <p>Netto a pagare</p>
                    </th>
                </tr>
                <tr>
           <td></td>                      
            <td></td>                      
            <td></td>                      
            <td></td>                      
            <td></td>                      
            <td></td>-
                    <td>
                        <p class=""right "">--%query_wnetto--</p>
                        </th>
                </tr>
            </table>
            <table style=""width: 100%; "">
                <tr>
                    <th class=""first "">
                        <p>Trasporto a cura</p>
                    </th>
                    <th>
                        <p>Destinazione</p>
                    </th>
                    <th>
                        <p>Causale trasporto</p>
                    </th>
                </tr>
                <tr>
                    <td class=""first "">
                        <p>--%query_wdetra--</p>
                    </td>
                    <td>
                        <p>--%query_wdesti--</p>
                    </td>
                    <td>
                        <p>--%query_wdecau--</p>
                    </td>
                </tr>
            </table>
            <table style=""width: 100%; "">
                <tr>
                    <th style=""width: 50%; "" class=""first "">
                        <p>Descrizione beni</p>
                    </th>
                    <th>
                        <p>Porto</p>
                    </th>
                    <th>
                        <p>Colli</p>
                    </th>
                    <th>
                        <p>Firma conducente</p>
                    </th>
                </tr>
                <tr>
                    <td class=""first "">
                        <p>--%query_wdeben--</p>
                    </td>
                    <td>
                        <p>--%query_wdepor--</p>
                    </td>
                    <td>
                        <p>--%query_wtotco--</p>
                    </td>
                </tr>
            </table>
            <table style=""width: 100%; "">
                <tr>
                    <th class=""first "">
                        <p>Annotazioni</p>
                    </th>
                    <th>
                        <p>Data e ora partenza</p>
                    </th>
                    <th>
                        <p>Firma destinatario</p>
                    </th>
                </tr>
                <tr>
                    <td class=""first "">
                        <p>--%query_wdecassa--</p>
                    </td>
                    <td>
                        <p>--%query_wdatpa--</p>
                    </td>
                    <td>
                        <p>--%query_worapa--</p>
                    </td>
                </tr>
            </table>
            <p class=""center "" style=""font-weight: bold; "">--%query_Ppiede1--</p>
        </footer>
    </div>";
        public static string footer_nolast = $@"</table>
        </main>
        <footer>
            <table style=""width: 100%; "">
                <tr>
                    <th style=""width: 20%; "">
                        <p>Totale merce</p>
                    </th>
                    <th>
                        <p>Tot. spese</p>
                    </th>
                    <th>
                        <p>Omaggi</p>
                    </th>
                    <th>
                        <p>Sc. Merce</p>
                    </th>
                    <th>
                        <p>Totale imponibile</p>
                    </th>
                    <th>
                        <p>Totale imposta</p>
                    </th>
                    <th>
                        <p>Totale documento</p>
                    </th>
                </tr>
                <tr>
                    <td>
                        <p>‎ </p>
                    </td> <td>
                        <p>‎ </p>
                    </td>  <td>
                        <p>‎ </p>
                    </td> <td>
                        <p>‎ </p>
                    </td> <td>
                        <p>‎ </p>
                    </td> <td>
                        <p>‎ </p>
                    </td> 
                    <td>
                        <p style=""font-weight: bold; "" class=""right ""></p>
                    </td>
                </tr>
                <tr>
                    <th>
                        <p>Cod. iva</p>
                    </th>
                    <th style=""width: 30%; "">
                        <p>Descrizioneiva</p>
                    </th>
                    <th>
                        <p>Imponibile</p>
                    </th>
                    <th>
                        <p>Aliquota</p>
                    </th>
                    <th>
                        <p>Imposta</p>
                    </th>
                    <th>
                        <p>Scontrino</p>
                    </th>
                    <th>
                        <p>Abbuono</p>
                    </th>
                </tr>
                <tr>
                    <td>
                        <p>‎ </p>
                    </td> <td>
                        <p>‎ </p>
                    </td> <td>
                        <p>‎ </p>
                    </td> <td>
                        <p>‎ </p>
                    </td> <td>
                        <p>‎ </p>
                    </td>
                    <td rowspan=""4 "">
                        <table style=""border: 0; height: 100%; "">
                            <tr>
                                <td>
                                    <p>Numero</p>
                                    </th>
                                <td>
                                    <p>‎ </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>Data</p>
                                    </th>
                                <td>
                                    <p>‎ </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>Matricola</p>
                                <td>
                                    <p>‎ </p>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <p class=""right "">‎ </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <th>
                        <p>Acconto</p>
                    </th>
                </tr>
                <tr>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p class=""right "">‎ </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <th>
                        <p>Netto a pagare</p>
                    </th>
                </tr>
                <tr>
           <td></td>                      
            <td></td>                      
            <td></td>                      
            <td></td>                      
            <td></td>                      
            <td></td>-
                    <td>
                        <p class=""right "">‎ </p>
                        </th>
                </tr>
            </table>
            <table style=""width: 100%; "">
                <tr>
                    <th class=""first "">
                        <p>Trasporto a cura</p>
                    </th>
                    <th>
                        <p>Destinazione</p>
                    </th>
                    <th>
                        <p>Causale trasporto</p>
                    </th>
                </tr>
                <tr>
                    <td class=""first "">
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                </tr>
            </table>
            <table style=""width: 100%; "">
                <tr>
                    <th style=""width: 50%; "" class=""first "">
                        <p>Descrizione beni</p>
                    </th>
                    <th>
                        <p>Porto</p>
                    </th>
                    <th>
                        <p>Colli</p>
                    </th>
                    <th>
                        <p>Firma conducente</p>
                    </th>
                </tr>
                <tr>
                    <td class=""first "">
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                </tr>
            </table>
            <table style=""width: 100%; "">
                <tr>
                    <th class=""first "">
                        <p>Annotazioni</p>
                    </th>
                    <th>
                        <p>Data e ora partenza</p>
                    </th>
                    <th>
                        <p>Firma destinatario</p>
                    </th>
                </tr>
                <tr>
                    <td class=""first "">
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                    <td>
                        <p>‎ </p>
                    </td>
                </tr>
            </table>
            <p class=""center "" style=""font-weight: bold; "">‎ </p>
        </footer>
    </div>";
    }

}
