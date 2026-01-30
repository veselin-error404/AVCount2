using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AVCount
{
    public static class PdfGenerator
    {
        public static void CreateInvoicePdf(Invoice invoice, string filePath, decimal ddsPercent)
        {

            if (invoice == null)
                throw new ArgumentNullException(nameof(invoice));

            if (invoice.Items == null || invoice.Items.Count == 0)
                throw new ArgumentException("Фактурата трябва да съдържа поне един артикул.");

            // EUR formatting
            NumberFormatInfo eur = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            eur.CurrencySymbol = "€";
            eur.CurrencyDecimalSeparator = ".";
            eur.CurrencyGroupSeparator = " ";

            string fontPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
                "arial.ttf");

            if (!File.Exists(fontPath))
                throw new FileNotFoundException("Arial font not found.");

            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);


            var fontBigTitle = new Font(bf, 24, Font.BOLD);
            var fontTitle = new Font(bf, 18, Font.BOLD);
            var fontBold = new Font(bf, 11, Font.BOLD);
            var fontNormal = new Font(bf, 10, Font.NORMAL);

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (Document doc = new Document(PageSize.A4, 36, 36, 36, 36))
            {
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // ---------- TITLE ----------
                doc.Add(new Paragraph("ФАКТУРА", fontBigTitle)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20
                });

                // ---------- HEADER ----------
                PdfPTable header = new PdfPTable(2)
                {
                    WidthPercentage = 100,
                    SpacingAfter = 20
                };
                header.SetWidths(new float[] { 1f, 2f });

                PdfPCell logoCell;
                if (File.Exists("logo.png"))
                {
                    Image logo = Image.GetInstance("logo.png");
                    logo.ScaleToFit(120, 120);
                    logoCell = new PdfPCell(logo)
                    {
                        Border = Rectangle.NO_BORDER
                    };
                }
                else
                {
                    logoCell = new PdfPCell(new Phrase(""))
                    {
                        Border = Rectangle.NO_BORDER
                    };
                }

                PdfPCell numberCell = new PdfPCell(
                    new Phrase($"ФАКТУРА № {invoice.InvoiceNumber}", fontTitle))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };

                header.AddCell(logoCell);
                header.AddCell(numberCell);
                doc.Add(header);

                // ---------- SELLER / BUYER ----------
                PdfPTable info = new PdfPTable(2)
                {
                    WidthPercentage = 100,
                    SpacingAfter = 20
                };
                info.SetWidths(new float[] { 1f, 1f });

                info.AddCell(CreatePartyCell("Продавач:", invoice, true, fontBold, fontNormal));
                info.AddCell(CreatePartyCell("Клиент:", invoice, false, fontBold, fontNormal));

                doc.Add(info);

                // ---------- ITEMS TABLE ----------
                PdfPTable table = new PdfPTable(4)
                {
                    WidthPercentage = 100
                };
                table.SetWidths(new float[] { 3f, 1f, 1.5f, 1.5f });

                string[] headers = { "Описание", "Количество", "Ед. цена (€)", "Сума (€)" };

                foreach (string h in headers)
                {
                    table.AddCell(new PdfPCell(new Phrase(h, fontBold))
                    {
                        BackgroundColor = new BaseColor(220, 220, 220),
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 6
                    });
                }

                foreach (var item in invoice.Items)
                {
                    table.AddCell(new PdfPCell(new Phrase(item.Description, fontNormal)) { Padding = 4 });
                    table.AddCell(new PdfPCell(new Phrase(item.Quantity.ToString(), fontNormal))
                    {
                        Padding = 4,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    });
                    table.AddCell(new PdfPCell(new Phrase(item.UnitPriceEUR.ToString("C2", eur), fontNormal))
                    {
                        Padding = 4,
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    });
                    table.AddCell(new PdfPCell(new Phrase(item.TotalEUR.ToString("C2", eur), fontNormal))
                    {
                        Padding = 4,
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    });
                }

                doc.Add(table);

                // ---------- TOTALS ----------
                decimal subtotal = 0m;
                foreach (var i in invoice.Items)
                    subtotal += i.TotalEUR;

                decimal vat = subtotal * ddsPercent;

                decimal total = subtotal + vat;

                PdfPTable totals = new PdfPTable(1)
                {
                    WidthPercentage = 40,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    SpacingBefore = 20
                };
                string totalInWords = AmountToWordsAccountingEUR(total);
                totals.AddCell(new PdfPCell(new Phrase($"Стойност без ДДС: {subtotal.ToString("C2", eur)}", fontNormal)) { Padding = 6 });
                totals.AddCell(
                    new PdfPCell(
                        new Phrase($"ДДС ({ddsPercent:P0}): {vat.ToString("C2", eur)}", fontNormal)
                    )
                    { Padding = 6 }
                );
                totals.AddCell(
                    new PdfPCell(
                        new Phrase(
                            $"Обща сума: {total.ToString("C2", eur)} " +
                            $"(словом: {char.ToUpper(totalInWords[0]) + totalInWords.Substring(1)})",
                            fontBold))
                    {
                        Padding = 8
                    });
                
        



                doc.Add(totals);

                // ---------- PAYMENT ----------
                string paymentText = invoice.PaymentMethod == PaymentMethod.Bank
                    ? $"Начин на плащане: Банков превод\nБанка: {invoice.BankName}\nIBAN: {invoice.IBAN}\nBIC: {invoice.BIC}"
                    : "Начин на плащане: В брой";

                doc.Add(new Paragraph(paymentText, fontNormal) { SpacingBefore = 20 });

                // ---------- SIGNATURES ----------
                PdfPTable signs = new PdfPTable(2)
                {
                    WidthPercentage = 80,
                    SpacingBefore = 30
                };
                signs.SetWidths(new float[] { 1f, 1f });

                signs.AddCell(new PdfPCell(new Phrase("Подпис (Продавач):\n\n_________________________", fontNormal))
                { Border = Rectangle.NO_BORDER });

                signs.AddCell(new PdfPCell(new Phrase("Подпис (Клиент):\n\n_________________________", fontNormal))
                { Border = Rectangle.NO_BORDER });

                doc.Add(signs);

                // ---------- DATE ----------
                doc.Add(new Paragraph(
                    $"Дата на издаване: {invoice.Date:dd.MM.yyyy}",
                    fontNormal)
                {
                    Alignment = Element.ALIGN_RIGHT,
                    SpacingBefore = 20
                });
            }
        }
        private static readonly string[] Units =
        {
    "нула", "едно", "две", "три", "четири", "пет", "шест", "седем", "осем", "девет",
    "десет", "единадесет", "дванадесет", "тринадесет", "четиринадесет",
    "петнадесет", "шестнадесет", "седемнадесет", "осемнадесет", "деветнадесет"
};

        private static readonly string[] Tens =
        {
    "", "", "двадесет", "тридесет", "четиридесет",
    "петдесет", "шестдесет", "седемдесет", "осемдесет", "деветдесет"
};

        private static readonly string[] Hundreds =
        {
    "", "сто", "двеста", "триста", "четиристотин",
    "петстотин", "шестстотин", "седемстотин", "осемстотин", "деветстотин"
};

        private static string NumberToWordsBG(long number)
        {
            if (number == 0)
                return Units[0];

            string words = "";

            if (number >= 1_000_000)
            {
                words += NumberToWordsBG(number / 1_000_000) + " милиона ";
                number %= 1_000_000;
            }

            if (number >= 1000)
            {
                if (number / 1000 == 1)
                    words += "хиляда ";
                else
                    words += NumberToWordsBG(number / 1000) + " хиляди ";

                number %= 1000;
            }

            if (number >= 100)
            {
                words += Hundreds[number / 100] + " ";
                number %= 100;
            }

            if (number >= 20)
            {
                words += Tens[number / 10] + " ";
                number %= 10;
            }

            if (number > 0)
                words += Units[number] + " ";

            return words.Trim();
        }


        private static string AmountToWordsAccountingEUR(decimal amount)
        {
            long euros = (long)Math.Floor(amount);
            int cents = (int)Math.Round((amount - euros) * 100);

            string euroWords = NumberToWordsBG(euros) + " евро";
            string centsText = cents > 0
                ? $" и {cents:D2} цента"
                : " и 00 цента";

            return euroWords + centsText;
        }

        private static PdfPCell CreatePartyCell(
            string title,
            Invoice invoice,
            bool seller,
            Font bold,
            Font normal)
        {
            PdfPCell cell = new PdfPCell { Border = Rectangle.NO_BORDER };

            cell.AddElement(new Paragraph(title, bold));

            if (seller)
            {
                cell.AddElement(new Paragraph(invoice.SellerName, normal));
                cell.AddElement(new Paragraph($"ЕИК: {invoice.SellerEIK}", normal));
                cell.AddElement(new Paragraph($"ДДС №: {invoice.SellerVAT}", normal));
                cell.AddElement(new Paragraph($"Град: {invoice.SellerCity}", normal));
                cell.AddElement(new Paragraph($"МОЛ: {invoice.SellerMOL}", normal));
                cell.AddElement(new Paragraph($"Телефон: {invoice.SellerPhone}", normal));
                cell.AddElement(new Paragraph($"Адрес: {invoice.SellerAddress}", normal));
            }
            else
            {
                cell.AddElement(new Paragraph(invoice.BuyerName, normal));
                cell.AddElement(new Paragraph($"ЕИК: {invoice.BuyerEIK}", normal));
                cell.AddElement(new Paragraph($"ДДС №: {invoice.BuyerVAT}", normal));
                cell.AddElement(new Paragraph($"Град: {invoice.BuyerCity}", normal));
                cell.AddElement(new Paragraph($"МОЛ: {invoice.BuyerMOL}", normal));
                cell.AddElement(new Paragraph($"Телефон: {invoice.BuyerPhone}", normal));
                cell.AddElement(new Paragraph($"Адрес: {invoice.BuyerAddress}", normal));
            }

            return cell;
        }
    }
}
