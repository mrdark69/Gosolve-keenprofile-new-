using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net.Mail;
using HiQPdf;

/// <summary>
/// Summary description for pdfgen
/// </summary>
/// 

namespace Utility
{
    public class pdfgen
    {
        public pdfgen()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static byte[] pdfGenerate(string HtmlInput)
        {
            // read parameters from the webpage
            string htmlString = HtmlInput;

            // create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();
            // htmlToPdfConverter.SerialNumber = "jMTl3dzo-6sDl7v7t-/vW1orys-vay9rLi0-ur+sv72i-vb6itbW1-tQ==";


            // set browser width
            htmlToPdfConverter.BrowserWidth = 794;
            //htmlToPdfConverter.BrowserHeight = 3365;
            //htmlToPdfConverter.BrowserHeight = int.Parse(textBoxBrowserHeight.Text);

            // set browser height if specified, otherwise use the default




            // set HTML Load timeout
            htmlToPdfConverter.HtmlLoadedTimeout = 120;

            //htmlToPdfConverter.Document.FitPageWidth = true;
            //htmlToPdfConverter.Document.ForceFitPageWidth = true;

            // set PDF page size and orientation
            //htmlToPdfConverter.Document.PageSize = PdfPageSize.A4;
            //htmlToPdfConverter.Document.PageOrientation = PdfPageOrientation.Portrait;

            // set the PDF standard used by the document
            //htmlToPdfConverter.Document.PdfStandard = checkBoxPdfA.Checked ? PdfStandard.PdfA : PdfStandard.Pdf;

            //htmlToPdfConverter.Document.P
            // set PDF page margins

            // htmlToPdfConverter.Document.Margins = new PdfMargins(5);



            // set header and footer
            //SetHeader(htmlToPdfConverter.Document);
            //SetFooter(htmlToPdfConverter.Document);

            // convert HTML to PDF
            byte[] pdfBuffer = null;

            // convert HTML code
            string htmlCode = htmlString;
            string baseUrl = "";

            // convert HTML code to a PDF memory buffer
            pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlCode, baseUrl);

            return pdfBuffer;
        }


        public static void ToClientSave(byte[] pdfBuffer, string FileName)
        {


            //File.WriteAllBytes(FileName, pdfBuffer);


            //Attachment att = new Attachment(new MemoryStream(pdfBuffer), "HtmlToPdf.pdf");

            // inform the browser about the binary data format
            HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

            // let the browser know how to open the PDF document, attachment or inline, and the file name
            //HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("{0}; filename=HtmlToPdf.pdf; size={1}",
            //    checkBoxOpenInline.Checked ? "inline" : "attachment", pdfBuffer.Length.ToString()));

            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("{0}; filename=" + FileName + ".pdf; size={1}", "attachment", pdfBuffer.Length.ToString()));

            // write the PDF buffer to HTTP response
            HttpContext.Current.Response.BinaryWrite(pdfBuffer);

            // call End() method of HTTP response to stop ASP.NET page processing
            HttpContext.Current.Response.End();
        }

    }
}

