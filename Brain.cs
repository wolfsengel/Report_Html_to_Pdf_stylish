using System;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using System.Collections.Generic;
using System.Drawing;

namespace ReportHtmlPdf_Final.Logic
{
    internal class Brain
    {

        static int me, co, sc, om, on, sp, sco;
        //STAMPA TEMPLATE
        static string templatePath = "C:/Users/angel/source/repos/ReportHtmlPdf_Final/ReportHtmlPdf_Final/FilesHtmlPdfData/NoLast.html";
        //DATABASE
        static string connectionString = "Server=localhost;Database=ac00prtf;Uid=root;Pwd=12345;";
        static int maxItemsPorPagina = 15;

        static string templateContent = File.ReadAllText(templatePath);
        static StringBuilder builder = new StringBuilder(templateContent);

        //-------------------------------------------------------------------------------head_fun

        public static void HeadFun()
        {
            //-----------------Header----------------------------------------------------------------------
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                //conexion y extraccion de datos
                connection.Open();
                string query = "SELECt * FROM cassadoc limit 1";
                MySqlCommand command = new MySqlCommand(query, connection);


                //client box info
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        var replacements = new Dictionary<string, string>
                        {
                            {"wrasoc", reader.GetString("wrasoc")},
                            {"wraso1", reader.GetString("wraso1")},
                            {"windir", reader.GetString("windir")},
                            {"wlocal", reader.GetString("wlocal")}
                        };
                        //Replace

                        foreach (var replacement in replacements)
                        {
                            builder.Replace("--" + replacement.Key + "--", replacement.Value);
                        }
                    }
                }

                //header general info----------------------------------------------------------------------------------

                //conexion y extraccion de datos
                string query2 = "SELECT * FROM cassadoc";
                MySqlCommand command2 = new MySqlCommand(query2, connection);

                using (MySqlDataReader reader = command2.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        var replacements = new Dictionary<string, string>
                            {
                                {"wtidoc", reader.GetString("wtidoc")},
                                {"wdafat", reader.GetString("wdafat")},
                                {"wnufat", reader.GetString("wnufat")},
                                {"wsgfat", reader.GetString("wsgfat")},
                                {"wcoana", reader.GetString("wcoana")},
                                {"wcodes", reader.GetString("wcodes")},
                                {"wcofis", reader.GetString("wcofis")},
                                {"wcomag", reader.GetString("wcomag")},
                                {"wopera", reader.GetString("wopera")},
                                {"wdepag", reader.GetString("wdepag")},
                                {"wiban", reader.GetString("wiban")},
                                {"wswift", reader.GetString("wswift")},
                                {"wbanca", reader.GetString("wbanca")},
                                {"wabi", reader.GetString("wabi")},
                                {"wcab", reader.GetString("wcab")}
                            };

                        foreach (var replacement in replacements)
                        {
                            builder.Replace("--" + replacement.Key + "--", replacement.Value);
                        }

                    }
                }
            }
            //-----------------End Header-------------------------------------------------------------------------------------------
        }

        //----------------------------------------------------------------------------------



        //-------------------------------------------------------------------------------Image Generator
        public static void imagenCulminator()
        {
            // Supongamos que tienes un objeto Blob llamado "blobData" que contiene los datos de la imagen

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Open the connection to the database
                connection.Open();

                // Define the query to retrieve data from the database
                string query = "SELECT * FROM cassadoclogo";
                MySqlCommand command = new MySqlCommand(query, connection);

                // Execute the query and retrieve the data
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Check if there is any data to read
                    if (reader.Read())
                    {
                        // Get the data from the reader
                        var blobData = reader["wlogo"]; 

                        // Convert the Blob to a byte array
                        byte[] blobBytes = (byte[])blobData;

                        using (MemoryStream ms = new MemoryStream(blobBytes))
                        {
                            // Load the image from the MemoryStream
                            Image image = Image.FromStream(ms);

                            // Save the image to a file
                            string filePath = "C:/Users/angel/source/repos/ReportHtmlPdf_Final/ReportHtmlPdf_Final/FilesHtmlPdfData/logoloco.jpeg";
                            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                            string base64Image = ConvertImageToBase64(filePath);
                            string dataUrl = "data:image/png;base64," + base64Image;
                            builder.Replace("--logo--", "<img src=\""+dataUrl+"\" alt=\"Imagen en Base64\">");
                        }
                    }
                }
            }
        }
        static string ConvertImageToBase64(string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            string base64Image = Convert.ToBase64String(imageBytes);
            return base64Image;
        }
        //-------------------------------------------------------------------------------Image end Gentr

        //-------------------------------------------------------------------------------head_fun_end

        public static void intercambiadorItems(MySqlDataReader reader, int count_me, int count_co, int count_sc, int count_om,int count_on, int count_sp, int count_sco)
        {
            int i = 0;
            //----------------cosa
            while (reader.Read() && i < maxItemsPorPagina)
            {

                string etiqueta_me = "<tr>\r\n                    <td class=\"first\">\r\n                        <p>--wcoart_me--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wdeart_me--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wunmis_me--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wcolli_me--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wquant_me--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wprezz_me--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wscon1_me--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wimpor_me--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wcoiva_me--</p>\r\n                    </td>\r\n                </tr>";
                string etiqueta_co = "<tr>\r\n                    <td></td>\r\n                    <td>\r\n                        <p>--wdeart_co--</p>\r\n                    </td>\r\n                </tr>";
                string etiqueta_sc = " <tr>\r\n                    <td class=\"first\">\r\n                        <p>--wcoart_sc--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wdeart_sc--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wunmis_sc--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wcolli_sc--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wquant_sc--</p>\r\n                    </td>\r\n                </tr>";
                string etiqueta_om = "<tr>\r\n                    <td class=\"first\">\r\n                        <p>--wcoart_om--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wdeart_om--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wunmis_om--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wcolli_om--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wquant_om--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wprezz_om--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wscon1_om--</p>\r\n                    </td>\r\n                    <td></td>\r\n                    <td>\r\n                        <p>--wcoiva_om--</p>\r\n                    </td>\r\n                </tr>";
                string etiqueta_on = "<tr>\r\n                    <td class=\"first\">\r\n                        <p>--wcoart_on--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wdeart_on--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wunmis_on--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wcolli_on--</p>\r\n                    </td>\r\n                    <td>\r\n                        <p>--wquant_on--</p>\r\n                    </td>\r\n                </tr>";
                string etiqueta_sp = "<tr>\r\n                    <td></td>\r\n                    <td>\r\n                        <p>--wdeart_sp--</p>\r\n                    </td>\r\n                    <td></td>\r\n                    <td></td>\r\n                    <td></td>\r\n                    <td></td>\r\n                    <td></td>\r\n                    <td></td>\r\n                    <td>\r\n                        <p>--wcoiva_sp--</p>\r\n                    </td>\r\n                </tr>";
                string etiqueta_sco = "<tr>\r\n                    <td></td>\r\n                    <td>\r\n                        <p>--wdeart_sco--</p>\r\n                    </td>\r\n                </tr>";

                if (me < count_me)
                {
                    builder.Append(etiqueta_me);
                    me++;
                }
                if (co < count_co)
                {
                    builder.Append(etiqueta_co);
                    co++;
                }
                if (sc < count_sc)
                {
                    builder.Append(etiqueta_sc);
                    sc++;
                }
                if (om < count_om)
                {
                    builder.Append(etiqueta_om);
                    om++;
                }
                if (on < count_on)
                {
                    builder.Append(etiqueta_on);
                    on++;
                }
                if (sp < count_sp)
                {
                    builder.Append(etiqueta_sp);
                    sp++;
                }
                if (sco < count_sco)
                {
                    builder.Append(etiqueta_sco);
                    sco++;
                }

                var replacements = new Dictionary<string, string>
                            {
                                {"wcoart_me", reader.GetString("wcoart_me")},
                                {"wdeart_me", reader.GetString("wdeart_me")},
                                {"wunmis_me", reader.GetString("wunmis_me")},
                                {"wcolli_me", reader.GetString("wcolli_me")},
                                {"wquant_me", reader.GetString("wquant_me")},
                                {"wprezz_me", reader.GetString("wprezz_me")},
                                {"wscon1_me", reader.GetString("wscon1_me")},
                                {"wimpor_me", reader.GetString("wimpor_me")},
                                {"wcoiva_me", reader.GetString("wcoiva_me")},
                                {"wdeart_co", reader.GetString("wdeart_co")},
                                {"wcoart_sc", reader.GetString("wcoart_sc")},
                                {"wdeart_sc", reader.GetString("wdeart_sc")},
                                {"wunmis_sc", reader.GetString("wunmis_sc")},
                                {"wcolli_sc", reader.GetString("wcolli_sc")},
                                {"wquant_sc", reader.GetString("wquant_sc")},
                                {"wcoart_om", reader.GetString("wcoart_om")},
                                {"wdeart_om", reader.GetString("wdeart_om")},
                                {"wunmis_om", reader.GetString("wunmis_om")},
                                {"wcolli_om", reader.GetString("wcolli_om")},
                                {"wquant_om", reader.GetString("wquant_om")},
                                {"wprezz_om", reader.GetString("wprezz_om")},
                                {"wscon1_om", reader.GetString("wscon1_om")},
                                {"wcoiva_om", reader.GetString("wcoiva_om")},
                                {"wcoart_on", reader.GetString("wcoart_on")},
                                {"wdeart_on", reader.GetString("wdeart_on")},
                                {"wunmis_on", reader.GetString("wunmis_on")},
                                {"wcolli_on", reader.GetString("wcolli_on")},
                                {"wquant_on", reader.GetString("wquant_on")},
                                {"wdeart_sp", reader.GetString("wdeart_sp")},
                                {"wcoiva_sp", reader.GetString("wcoiva_sp")},
                                {"wdeart_sco", reader.GetString("wdeart_sco")}
                            };

                foreach (var replacement in replacements)
                {
                    builder.Replace("--" + replacement.Key + "--", replacement.Value);
                }

                i++;

            }
        }


        public static void MergeItemsNoLast()
        {
            //-----------------Items Loop-------------------------------------------------------------------------------------------
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                connection.Open();
                string query = "SELECT * FROM (SELECT * FROM cassadoc LIMIT 1,999999) as CONSULTA";
                MySqlCommand command = new MySqlCommand(query, connection);

                //count number items
                var cmd = new MySqlCommand("SELECT COUNT(wcoart_me) FROM cassadoc WHERE wcoart_me <> 0 AND TRIM(wcoart_me) <> ''", connection);
                int count_me = Convert.ToInt32(cmd.ExecuteScalar());
                //count number items
                var cmd2 = new MySqlCommand("SELECT COUNT(wdeart_co) FROM cassadoc WHERE wdeart_co <> 0 AND TRIM(wdeart_co) <> ''", connection);
                int count_co = Convert.ToInt32(cmd2.ExecuteScalar());
                //count number items
                var cmd3 = new MySqlCommand("SELECT COUNT(wcoart_sc) FROM cassadoc WHERE wcoart_sc <> 0 AND TRIM(wcoart_sc) <> ''", connection);
                int count_sc = Convert.ToInt32(cmd3.ExecuteScalar());
                //count number items
                var cmd4 = new MySqlCommand("SELECT COUNT(wcoart_om) FROM cassadoc WHERE wcoart_om <> 0 AND TRIM(wcoart_om) <> ''", connection);
                int count_om = Convert.ToInt32(cmd4.ExecuteScalar());
                //count number items
                var cmd5 = new MySqlCommand("SELECT COUNT(wcoart_on) FROM cassadoc WHERE wcoart_on <> 0 AND TRIM(wcoart_on) <> ''", connection);
                int count_on = Convert.ToInt32(cmd5.ExecuteScalar());
                //count number items
                var cmd6 = new MySqlCommand("SELECT COUNT(wdeart_sp) FROM cassadoc WHERE wdeart_sp <> 0 AND TRIM(wdeart_sp) <> ''", connection);
                int count_sp = Convert.ToInt32(cmd6.ExecuteScalar());
                //count number items
                var cmd7 = new MySqlCommand("SELECT COUNT(wdeart_sco) FROM cassadoc WHERE wdeart_sco <> 0 AND TRIM(wdeart_sco) <> ''", connection);
                int count_sco = Convert.ToInt32(cmd7.ExecuteScalar());

                using (MySqlDataReader reader = command.ExecuteReader())
                {

                    me = 0;
                    co = 0;
                    sc = 0;
                    om = 0;
                    on = 0;
                    sp = 0;
                    sco = 0;
                                      
         
                    if (reader.HasRows)
                    {intercambiadorItems(reader,count_me,count_co,count_sc,count_om,count_on,count_sp,count_sco);

                        reader.Read();
                        //while read
                        //---------------------------------------------------------footers tags
                        string footer_nolast = htmls.footer_nolast;
                        string footer_last = htmls.footer_last;
                        string footer;

                        //after the products, adds the footer
                        //es ultima pagina?
                        int sumtot = count_co + count_me + count_om + count_on + count_sc + count_sco;
                        int numItemsUltimaPagina = sumtot % maxItemsPorPagina;
                        int EspaciosEnBlanco = maxItemsPorPagina - numItemsUltimaPagina;

                        for (int y = 0; y < EspaciosEnBlanco; y++)
                        {
                            builder.AppendLine("<tr>\r\n                    <td>\r\n                        <p>‎ </p>\r\n                    </td>\r\n                </tr>");
                        }
                        if (sumtot < maxItemsPorPagina)
                        {
                            numItemsUltimaPagina = sumtot % maxItemsPorPagina;
                            EspaciosEnBlanco = maxItemsPorPagina - numItemsUltimaPagina;

                            for (int y = 0; y < EspaciosEnBlanco; y++)
                            {
                                builder.AppendLine("<tr>\r\n                    <td>\r\n                        <p>‎ </p>\r\n                    </td>\r\n                </tr>");
                            }
                            footer = footer_last;
                            builder.AppendLine(footer);
                            footerFun();
                            return;
                        }
                        else
                        {
                            
                            int paginas = sumtot / maxItemsPorPagina;
                            for (int j=0;j<paginas-1;j++)
                            {
                                footer = footer_nolast;
                                builder.AppendLine(footer);
                                builder.AppendLine("<p>‎ </p>");
                                builder.AppendLine(htmls.page);
                                intercambiadorItems(reader, count_me, count_co, count_sc, count_om, count_on, count_sp, count_sco);
                                numItemsUltimaPagina = sumtot % maxItemsPorPagina;
                                EspaciosEnBlanco = maxItemsPorPagina - numItemsUltimaPagina;
                            //-------------------------aaaaaa
                                for (int y = 0; y < EspaciosEnBlanco; y++)
                                {
                                    builder.AppendLine("<tr>\r\n                    <td>\r\n                        <p>‎ </p>\r\n                    </td>\r\n                </tr>");
                                }
                                HeadFun();  
                                imagenCulminator();
                            }
                            
                            footer = footer_last;
                            builder.AppendLine(footer);
                            footerFun();
                        }

                        //añade etiquetas de fin como body o tal
                        //aqui
                        builder.AppendLine("</body>\r\n\r\n</html>");


                       //---------------------------------------------------------cosa

                    }//if has rows
                }
            }

            //-----------------Items Loop End---------------------------------------------------------------------------------------
        }//mergetest

        //------------------------------------------------------------------------------------------------------------------------FOOTER
        public static void footerFun()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                //conexion y extraccion de datos
                connection.Open();
                string query = "SELECT * FROM cassadoc order by 1 desc";
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string wtotme = reader.GetString("wtotme_cftp");
                        if (!string.IsNullOrEmpty(wtotme) && wtotme != "0,00")
                            builder.Replace("--%query_wtotme--", wtotme);
                        else
                            builder.Replace("--%query_wtotme--", "‎ ‎");

                        string wnusco = reader.GetString("wnusco_cftp");
                        if (!string.IsNullOrEmpty(wnusco) && wnusco != "0")
                            builder.Replace("--%query_wNusco--", wnusco);
                        else
                            builder.Replace("--%query_wNusco--", "‎ ‎");

                        string wali01 = reader.GetString("wali01_cftp");
                        if (!string.IsNullOrEmpty(wali01) && wali01 != "0")
                            builder.Replace("--%query_Wali01--", wali01);
                        else
                            builder.Replace("--%query_Wali01--", "‎ ‎");

                        string wtotsp = reader.GetString("wtotsp_cftp");
                        if (!string.IsNullOrEmpty(wtotsp) && wtotsp != "0,00")
                            builder.Replace("--%query_wtotsp--", wtotsp);
                        else
                            builder.Replace("--%query_wtotsp--", "‎ ‎");

                        string wtotom = reader.GetString("wtotom_cftp");
                        if (!string.IsNullOrEmpty(wtotom) && wtotom != "0,00")
                            builder.Replace("--%query_wtotom--", wtotom);
                        else
                            builder.Replace("--%query_wtotom--", "‎ ‎");

                        string wimpon = reader.GetString("wimpon_cftp");
                        if (!string.IsNullOrEmpty(wimpon) && wimpon != "0,00")
                            builder.Replace("--%query_wimpon--", wimpon);
                        else
                            builder.Replace("--%query_wimpon--", "‎ ‎");

                        string wimpos = reader.GetString("wimpos_cftp");
                        if (!string.IsNullOrEmpty(wimpos) && wimpos != "0")
                            builder.Replace("--%query_wimpos--", wimpos);
                        else
                            builder.Replace("--%query_wimpos--", "‎ ‎");

                        string wTotFa = reader.GetString("wTotFa_cftp");
                        if (!string.IsNullOrEmpty(wTotFa) && wTotFa != "0")
                            builder.Replace("--%query_wTotFa--", wTotFa);
                        else
                            builder.Replace("--%query_wTotFa--", "‎ ‎");

                        string Wcoi01 = reader.GetString("Wcoi01_cftp");
                        if (!string.IsNullOrEmpty(Wcoi01) && Wcoi01 != "0")
                            builder.Replace("--%query_Wcoi01--", Wcoi01);
                        else
                            builder.Replace("--%query_Wcoi01--", "‎ ‎");

                        string Wiva01 = reader.GetString("Wiva01_cftp");
                        if (!string.IsNullOrEmpty(Wiva01) && Wiva01 != "0")
                            builder.Replace("--%query_Wiva01--", Wiva01);
                        else
                            builder.Replace("--%query_Wiva01--", "‎ ‎");

                        string Wimp01 = reader.GetString("Wimp01_cftp");
                        if (!string.IsNullOrEmpty(Wcoi01))
                            builder.Replace("--%query_Wimp01--", Wimp01);
                        else
                            builder.Replace("--%query_Wimp01--", "‎ ‎");

                        string Wips01 = reader.GetString("Wips01_cftp");
                        if (!string.IsNullOrEmpty(Wcoi01))
                            builder.Replace("--%query_Wips01--", Wips01);
                        else
                            builder.Replace("--%query_Wips01--", "‎ ‎");

                        string wdtsc = reader.GetString("wdtsc$_cftp");
                        if (!string.IsNullOrEmpty(wdtsc) && wdtsc != "0")
                            builder.Replace("--%query_wdtsc--", wdtsc);
                        else
                            builder.Replace("--%query_wdtsc--", "‎ ‎");

                        string wmatricola = reader.GetString("wmatricola_cftp");
                        if (!string.IsNullOrEmpty(wmatricola) && wmatricola != "0")
                            builder.Replace("--%query_wmatricola--", wmatricola);
                        else
                            builder.Replace("--%query_wmatricola--", "‎ ‎");

                        string wabbuo = reader.GetString("wabbuo_cftp");
                        if (!string.IsNullOrEmpty(wabbuo) && wabbuo != "0,00")
                            builder.Replace("--%query_wabbuo--", wabbuo);
                        else
                            builder.Replace("--%query_wabbuo--", "‎ ‎");

                        string Wcoi02 = reader.GetString("Wcoi02_cftp");
                        if (!string.IsNullOrEmpty(Wcoi02) && Wcoi02 != "0")
                            builder.Replace("--%query_Wcoi02--", Wcoi02);
                        else
                            builder.Replace("--%query_Wcoi02--", "‎ ‎");

                        string Wiva02 = reader.GetString("Wiva02_cftp");
                        if (!string.IsNullOrEmpty(Wcoi01))
                            builder.Replace("--%query_Wiva02--", Wiva02);
                        else
                            builder.Replace("--%query_Wiva02--", "‎ ‎");

                        string Wimp02 = reader.GetString("Wimp02_cftp");
                        if (!string.IsNullOrEmpty(Wcoi01))
                            builder.Replace("--%query_Wimp02--", Wimp02);
                        else
                            builder.Replace("--%query_Wimp02--", "‎ ‎");

                        string Wali02 = reader.GetString("Wali02_cftp");
                        if (!string.IsNullOrEmpty(Wcoi01))
                            builder.Replace("--%query_Wali02--", Wali02);
                        else
                            builder.Replace("--%query_Wali02--", "‎ ‎");

                        string Wips02 = reader.GetString("Wips02_cftp");
                        if (!string.IsNullOrEmpty(Wcoi01))
                            builder.Replace("--%query_Wips02--", Wips02);
                        else
                            builder.Replace("--%query_Wips02--", "‎ ‎");

                        string Wcoi03 = reader.GetString("Wcoi03_cftp");
                        if (!string.IsNullOrEmpty(Wcoi03) && Wcoi03 != "0")
                            builder.Replace("--%query_Wcoi03--", Wcoi03);
                        else
                            builder.Replace("--%query_Wcoi03--", "‎ ‎");

                        string Wiva03 = reader.GetString("Wiva03_cftp");
                        if (!string.IsNullOrEmpty(Wcoi03))
                            builder.Replace("--%query_Wiva03--", Wiva03);
                        else
                            builder.Replace("--%query_Wiva03--", "‎ ‎");

                        string Wimp03 = reader.GetString("Wimp03_cftp");
                        if (!string.IsNullOrEmpty(Wcoi03))
                            builder.Replace("--%query_Wimp03--", Wimp03);
                        else
                            builder.Replace("--%query_Wimp03--", "‎ ‎");

                        string Wali03 = reader.GetString("Wali03_cftp");
                        if (!string.IsNullOrEmpty(Wcoi03))
                            builder.Replace("--%query_Wali03--", Wali03);
                        else
                            builder.Replace("--%query_Wali03--", "‎ ‎");

                        string Wimps03 = reader.GetString("Wips03_cftp");
                        if (!string.IsNullOrEmpty(Wcoi03))
                            builder.Replace("--%query_Wips03--", Wimps03);
                        else
                            builder.Replace("--%query_Wips03--", "‎ ‎");

                        string waccon = reader.GetString("waccon_cftp");
                        if (!string.IsNullOrEmpty(waccon) && waccon != "0,00")
                            builder.Replace("--%query_waccon--", waccon);
                        else
                            builder.Replace("--%query_waccon--", "‎ ‎");

                        string Wcoi04 = reader.GetString("Wcoi04_cftp");
                        if (!string.IsNullOrEmpty(Wcoi04) && Wcoi04 != "0")
                            builder.Replace("--%query_Wcoi04--", Wcoi04);
                        else
                            builder.Replace("--%query_Wcoi04--", "‎ ‎");

                        string Wiva04 = reader.GetString("Wiva04_cftp");
                        if (!string.IsNullOrEmpty(Wcoi04))
                            builder.Replace("--%query_Wiva04--", Wiva04);
                        else
                            builder.Replace("--%query_Wiva04--", "‎ ‎");

                        string Wimp04 = reader.GetString("Wimp04_cftp");
                        if (!string.IsNullOrEmpty(Wcoi04))
                            builder.Replace("--%query_Wimp04--", Wimp04);
                        else
                            builder.Replace("--%query_Wimp04--", "‎ ‎");

                        string Wali04 = reader.GetString("Wali04_cftp");
                        if (!string.IsNullOrEmpty(Wcoi04))
                            builder.Replace("--%query_Wali04--", Wali04);
                        else
                            builder.Replace("--%query_Wali04--", "‎ ‎");

                        string Wimps04 = reader.GetString("Wips04_cftp");
                        if (!string.IsNullOrEmpty(Wcoi04))
                            builder.Replace("--%query_Wips04--", Wimps04);
                        else
                            builder.Replace("--%query_Wips04--", "‎ ‎");

                        string wnetto = reader.GetString("wnetto_cftp");
                        if (!string.IsNullOrEmpty(wnetto) && wnetto != "0")
                            builder.Replace("--%query_wnetto--", wnetto);
                        else
                            builder.Replace("--%query_wnetto--", "‎ ‎");

                        string wdetra = reader.GetString("wdetra_cftp");
                        if (!string.IsNullOrEmpty(wdetra) && wdetra != "0")
                            builder.Replace("--%query_wdetra--", wdetra);
                        else
                            builder.Replace("--%query_wdetra--", "‎ ‎");

                        string wdesti = reader.GetString("wdesti_cftp");
                        if (!string.IsNullOrEmpty(wdesti) && wdesti != "0")
                            builder.Replace("--%query_wdesti--", wdesti);
                        else
                            builder.Replace("--%query_wdesti--", "‎ ‎");

                        string wdecau = reader.GetString("wdecau_cftp");
                        if (!string.IsNullOrEmpty(wdecau) && wdecau != "0")
                            builder.Replace("--%query_wdecau--", wdecau);
                        else
                            builder.Replace("--%query_wdecau--", "‎ ‎");

                        string wdeben = reader.GetString("wdeben_cftp");
                        if (!string.IsNullOrEmpty(wdeben) && wdeben != "0")
                            builder.Replace("--%query_wdeben--", wdeben);
                        else
                            builder.Replace("--%query_wdeben--", "‎ ‎");

                        string wdepor = reader.GetString("wdepor_cftp");
                        if (!string.IsNullOrEmpty(wdepor) && wdepor != "0")
                            builder.Replace("--%query_wdepor--", wdepor);
                        else
                            builder.Replace("--%query_wdepor--", "‎ ‎");

                        string wtotco = reader.GetString("wtotco_cftp");
                        if (!string.IsNullOrEmpty(wtotco) && wtotco != "0")
                            builder.Replace("--%query_wtotco--", wtotco);
                        else
                            builder.Replace("--%query_wtotco--", "‎ ‎");

                        string wdecassa = reader.GetString("wdecassa_cftp");
                        if (!string.IsNullOrEmpty(wdecassa) && wdecassa != "0")
                            builder.Replace("--%query_wdecassa--", wdecassa);
                        else
                            builder.Replace("--%query_wdecassa--", "‎ ‎");

                        string wdatpa = reader.GetString("wdatpa_cftp");
                        if (!string.IsNullOrEmpty(wdatpa) && wdatpa != "0")
                            builder.Replace("--%query_wdatpa--", wdatpa);
                        else
                            builder.Replace("--%query_wdatpa--", "‎ ‎");

                        string worapa = reader.GetString("worapa_cftp");
                        if (!string.IsNullOrEmpty(worapa) && worapa != "0,00")
                            builder.Replace("--%query_worapa--", worapa);
                        else
                            builder.Replace("--%query_worapa--", "‎ ‎");

                        string Ppiede = reader.GetString("Ppiede1_cftp");
                        if (!string.IsNullOrEmpty(Ppiede) && Ppiede != "0")
                            builder.Replace("--%query_Ppiede1--", Ppiede);
                        else
                            builder.Replace("--%query_Ppiede1--", "‎ ‎");

                    }
                }
            }
            //--------------------------bad footer end
        }//footer
        //------------------------------------------------------------------------------------------------------------------------FOOTER END
        public static void PdfSexo()
        {
            imagenCulminator();
            // Provide the path to your local HTML file
            string htmlFilePath = "C:/Users/angel/source/repos/ReportHtmlPdf_Final/ReportHtmlPdf_Final/FilesHtmlPdfData/RESULTADO.html";

            // Provide the path where you want to save the generated PDF
            string pdfFilePath = "C:/Users/angel/source/repos/ReportHtmlPdf_Final/ReportHtmlPdf_Final/FilesHtmlPdfData/testOut.pdf";

            string processedContent = builder.ToString();
            File.WriteAllText(htmlFilePath, processedContent);

            var browserFetcher = new BrowserFetcher();
            browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision).GetAwaiter().GetResult();
            var chromiumRevision = browserFetcher.RevisionInfo(BrowserFetcher.DefaultChromiumRevision).ExecutablePath;

            var browser = Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                ExecutablePath = chromiumRevision
            }).GetAwaiter().GetResult();

            using (var page = browser.NewPageAsync().GetAwaiter().GetResult())
            {
                //style
                page.EvaluateExpressionAsync(@"
                var style = document.createElement('style');
                style.innerHTML = `
                    @page {
                        size: A4; 
                        margin: 0;
                    }

                    body {
                        margin-top: 10px;  
                        font-family: Arial, Helvetica, sans-serif;  
                    }

                    header {
                        display: flex;  
                        flex-direction: row;  
                        justify-content: space-around;  
                        align-items: center;  
                    }

                    .header {
                        background-color: gray;  
                        border-radius: 30px;  
                        padding-left: 20px;  
                        width: 300px;  
                        height: 150px;  
                        padding-right: 10px;  
                        padding-bottom: 15px;  
                        display: flex;  
                        flex-direction: column;  
                        justify-content: space-between;  
                    }

                    h1 {
                        font-size: 20px;  
                        font-weight: normal;  
                    }

                    h1:first-of-type {
                        font-style: italic;  
                    }

                    main {
                        display: flex;  
                        flex-direction: column;  
                        justify-content: center;  
                        padding-top: 15px;  
                    }

                    th {
                        background-color: gray;  
                    }

                    table {
                        /*para que non quede a cor en anacos nas filas */
                        border-collapse: collapse;  
                        border: 1px solid gray;  
                        margin-bottom: 20px;  
                    }

                    footer {
                        display: flex;  
                        flex-direction: column;  
                        padding-top: 10px;  
                        justify-content: center;  
                    }

                    p {
                        font-size: 10px; 
                        text-align: left;  
                        margin-top: 10px;  
                        margin-bottom: 5px;   
                    }

                    .center {
                        text-align: center;   
                    }

                    .first {
                        padding-left: 15px;   
                    }

                    .right {
                        text-align: right;   
                    }

                    .last {
                        padding-right: 11px;  
                    }
                `;

                document.head.appendChild(style);
            ").GetAwaiter().GetResult();

                
                var options = new PdfOptions
                {
                    PrintBackground = true,
                    DisplayHeaderFooter = true,
                    Format = PaperFormat.A4,
                    PreferCSSPageSize = true // Incluir estilo de letra
                };
                // Set the page content to the local HTML file content
                string htmlContent = File.ReadAllText(htmlFilePath);
                page.SetContentAsync(htmlContent).GetAwaiter().GetResult();

                // Generate PDF from the page
                page.PdfAsync(pdfFilePath, options).GetAwaiter().GetResult();
            }

            browser.CloseAsync().GetAwaiter().GetResult();
        }



        //------------------------------------------------------------------------------------------------------------------------
    }

}

