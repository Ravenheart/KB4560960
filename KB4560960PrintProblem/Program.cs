using System.Drawing;
using System.Drawing.Printing;

namespace KB4560960PrintProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var printDocument = new PrintDocument())
            {
                printDocument.PrinterSettings = new PrinterSettings { PrinterName = "Microsoft Print to PDF" };
                printDocument.PrintPage += PrintDocument_PrintPage;
                printDocument.Print();
            }
        }

        private static void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            using (var bmp = Image.FromFile(@"broken.png"))
            {
                e.Graphics.DrawImage(bmp, new PointF());
            }
        }
    }
}
