﻿using System;
using System.IO;
using OfficeOpenXml;

using Humanizer;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using InvoiceGeneratorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

//using Microsoft.Office.Interop.Excel;
//using System.Runtime.InteropServices;
//using Microsoft.Extensions.Hosting;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Cors;



namespace InvoiceGeneratorAPI.Controllers
{
    //[EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly InvoiceContext _invoiceContext;
        private readonly InvoiceTemplateContext _invoiceTemplateContext;
        private readonly string _invoiceTemplatePath;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public ExcelController(InvoiceContext invoiceContext, InvoiceTemplateContext invoiceTemplateContext, IWebHostEnvironment webHostEnvironment)
        {
            _invoiceContext = invoiceContext;
            _invoiceTemplateContext = invoiceTemplateContext;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetExcelTest()
        {
            if (_invoiceContext.Invoice == null)
            {
                return NotFound();
            }
            return await _invoiceContext.Invoice.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> GenerateInvoicePdf(InvoiceGeneration invoiceGeneration)
        {
            long invoiceId = invoiceGeneration.invoiceId;
            long invoiceTemplateId = invoiceGeneration.invoiceTemplateId;
            
            if (_invoiceContext.Invoice == null || _invoiceTemplateContext.InvoiceTemplates == null)
            {
                return NotFound();
            }
            var invoice = await _invoiceContext.Invoice.FindAsync(invoiceId);
            var invoiceTemplate = await _invoiceTemplateContext.InvoiceTemplates.FindAsync(invoiceTemplateId);
            if (invoice == null || invoiceTemplate == null)
            {
                return NotFound();
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //var src = "C:\\Users\\agmag\\OneDrive\\invoice template creation\\TestInvoiceTemplate.xlsx";
            var src = invoiceTemplate.templatePath;
            var dest = "C:\\Users\\agmag\\Documents\\PDFSavesDoc\\Invoice.pdf";
            GenerateInvoiceByTemplate(src, dest, invoice, invoiceTemplate);
            //SavePDF(src, "C:\\Users\\agmag\\Documents\\PDFSavesDoc",  invoiceId);
            //SavePDF(src, invoiceId);
            return Ok();
        }
       




        private void GenerateInvoiceByTemplate(string excelFilePath, string pdfFilePath, Invoice invoice, InvoiceTemplate invoiceTemplate)
        {
            var package = new ExcelPackage(new FileInfo(excelFilePath));
            var worksheet = package.Workbook.Worksheets[0];
            FillInvoice(worksheet, invoice, invoiceTemplate);

            var tempExcelPath = excelFilePath;
            package.SaveAs(new FileInfo(tempExcelPath));
        }
        private ExcelWorksheet FillInvoice(ExcelWorksheet worksheet, Invoice invoice, InvoiceTemplate invoiceTemplate)
        {
            //Invoice data
            if (invoiceTemplate.invoiceIdCell != "string")
                worksheet.Cells[invoiceTemplate.invoiceIdCell].Value = invoice.id;
            if (invoiceTemplate.invoiceDateCell != "string")
                worksheet.Cells[invoiceTemplate.invoiceDateCell].Value = DateTime.Now.ToString("yyyy-MM-dd");
            //Company Data
            if (invoiceTemplate.companyNameCell != "string")
                worksheet.Cells[invoiceTemplate.companyNameCell].Value = invoice.companyName;
            if (invoiceTemplate.companyPOBoxCell != "string")
                worksheet.Cells[invoiceTemplate.companyPOBoxCell].Value = invoice.companyPOBox;
            if (invoiceTemplate.companyEmailCell != "string")
                worksheet.Cells[invoiceTemplate.companyEmailCell].Value = invoice.companyEmail;
            if (invoiceTemplate.companyPhoneCell != "string")
                worksheet.Cells[invoiceTemplate.companyPhoneCell].Value = invoice.companyPhone;
            //Customer Data
            if (invoiceTemplate.customerAddressCell != "string")
                worksheet.Cells[invoiceTemplate.customerAddressCell].Value = invoice.customerAddress;
            if (invoiceTemplate.customerNameCell != "string")
                worksheet.Cells[invoiceTemplate.customerNameCell].Value = invoice.customerName;
            //Shippee Data
            if (invoiceTemplate.shipeeAddressCell != "string")
                worksheet.Cells[invoiceTemplate.shipeeAddressCell].Value = invoice.shipeeAddress;
            if (invoiceTemplate.shipeeNameCell != "string")
                worksheet.Cells[invoiceTemplate.shipeeNameCell].Value = invoice.shipeeName;
            //Order Data
            if (invoiceTemplate.pONumCell != "string")
                worksheet.Cells[invoiceTemplate.pONumCell].Value = invoice.pONum;
            if (invoiceTemplate.shipDateCell != "string")
                worksheet.Cells[invoiceTemplate.shipDateCell].Value = invoice.shipDate;
            if (invoiceTemplate.productTypeCell != "string")
                worksheet.Cells[invoiceTemplate.productTypeCell].Value = invoice.productType;
            //Item Data
            if (invoiceTemplate.itemIdCell != "string")
                worksheet.Cells[invoiceTemplate.itemIdCell].Value = invoice.itemId;
            if (invoiceTemplate.itemQuantityCell != "string")
                worksheet.Cells[invoiceTemplate.itemQuantityCell].Value = invoice.itemQuantity;
            if (invoiceTemplate.itemSizeCell != "string")
                worksheet.Cells[invoiceTemplate.itemSizeCell].Value = invoice.itemSize;
            if (invoiceTemplate.itemPriceCell != "string")
                worksheet.Cells[invoiceTemplate.itemPriceCell].Value = invoice.itemPrice;

            float itemTotal = invoice.itemPrice * invoice.itemQuantity;
            if (invoiceTemplate.itemPriceTotalCell != "string")
                worksheet.Cells[invoiceTemplate.itemPriceTotalCell].Value = itemTotal;
            //Invoice Total
            //float invoiceTotal = itemTotal + invoice.ItemQuantity; //This is going to be the sum of all item prices in the item prices array
            if (invoiceTemplate.trackingNumberCell != "string")
                worksheet.Cells[invoiceTemplate.trackingNumberCell].Value = invoice.trackingNumber;


            return worksheet;


        }
        private void SavePDF(string excelPath, string pdfPath, long invoiceId)
        {
            pdfPath = Path.Combine(pdfPath, $"{invoiceId}.pdf");

            var startInfo = new ProcessStartInfo
            {
                FileName = @"C:\Program Files\LibreOffice\program\soffice.exe",
                Arguments = $"--convert-to pdf --outdir {Path.GetDirectoryName(pdfPath)} {excelPath}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();
                process.WaitForExit();
            }
        }
        /*private void SavePDF(string worksheet, string pdfFilePath, long invoiceId)
        {

            using (var package = new ExcelPackage())
            {
                package.Workbook.Worksheets.Add(worksheet);

                string newPDF = Path.Combine(pdfFilePath, $"{invoiceId}.pdf");

                using (var pdfFile = new FileStream(newPDF, FileMode.Create, FileAccess.Write))
                {
                    package.SaveAs(pdfFile);
                }
            }
        }*/

        /*private void SavePDF(string excelFilePath, long invoiceId)
            {
            Application excel = new Application();
            Workbook workbook = excel.Workbooks.Open(excelFilePath);
            Worksheet worksheet = (Worksheet)workbook.Sheets[1];
            string pdfDirectory = @"C:\Users\agmag\Documents\PDFSavesDoc";
            string pdfFilePath = Path.Combine(pdfDirectory, "Invoice-" + invoiceId + ".pdf");
            worksheet.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, pdfFilePath);

            workbook.Close(false);
            Marshal.ReleaseComObject(workbook);
            excel.Quit();
            Marshal.ReleaseComObject(excel);
        }*/


        /*public void SaveMyPDF(string excelPath, string pdfPath, long invoiceId)
           {
            pdfPath = Path.Combine(pdfPath, $"{invoiceId}.pdf");

            var startInfo = new ProcessStartInfo
            {
                FileName = "soffice", // The path to the LibreOffice executable
                Arguments = $"--convert-to pdf --outdir {Path.GetDirectoryName(pdfPath)} {excelPath}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();
                process.WaitForExit();
            }
        }*/


    }
}








