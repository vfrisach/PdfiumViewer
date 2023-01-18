using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pdfViewer1.Paint += PdfViewer1_Paint;

        }

        private void PdfViewer1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("************--****************", new Font(FontFamily.GenericSansSerif, 25, FontStyle.Regular), new SolidBrush(Color.Black), new Point(0, 0));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //no muestra nada

        }
    }
}
