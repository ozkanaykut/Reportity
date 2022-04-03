using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Reportity.Helper
{
    internal class PageEventHelper : PdfPageEventHelper
    {
        PdfContentByte cb;
        PdfTemplate template;
        BaseFont baseFont = BaseFont.CreateFont(
                                                        BaseFont.HELVETICA,
                                                        "CP1254",
                                                        BaseFont.NOT_EMBEDDED,
                                                        false);

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            cb = writer.DirectContent;
            template = cb.CreateTemplate(50, 50);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);

            int pageN = writer.PageNumber;
            String text = "Page " + pageN.ToString() + " of ";
            float len = baseFont.GetWidthPoint(text, 11);

            iTextSharp.text.Rectangle pageSize = document.PageSize;

            cb.SetRgbColorFill(100, 100, 100);

            cb.BeginText();
            cb.SetFontAndSize(baseFont, 11);
            cb.SetTextMatrix(document.LeftMargin, pageSize.GetBottom(document.BottomMargin));
            cb.ShowText(text);

            cb.EndText();

            cb.AddTemplate(template, document.LeftMargin + len, pageSize.GetBottom(document.BottomMargin));
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            template.BeginText();
            template.SetFontAndSize(baseFont, 11);
            template.SetTextMatrix(0, 0);
            template.ShowText("" + (writer.PageNumber - 1));
            template.EndText();
        }
    }
}
