using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportHtmlPdf_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Logic.Brain.imagenCulminator();
            Logic.Brain.HeadFun();
            Logic.Brain.MergeItemsNoLast();
            Logic.Brain.PdfSexo();
            
        }
    }
}
