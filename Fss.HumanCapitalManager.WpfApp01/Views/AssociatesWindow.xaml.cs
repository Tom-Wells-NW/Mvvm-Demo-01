using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fss.HumanCapitalManager.WpfApp01.Views
{
    /// <summary>
    /// Interaction logic for AssociatesWindow.xaml
    /// </summary>
    public partial class AssociatesWindow : Window
    {
        public AssociatesWindow()
        {
            InitializeComponent();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            dialog.PrintTicket = GetAssociateCardPrintTicket();
            dialog.PrintVisual(this.associateCard, $"Printing - {this.associateCard_AssociateName.Text}...");
        }

        private PrintTicket GetAssociateCardPrintTicket()
        {
            PrintTicket result = GetPrintTicketFromPrinter();

            const double inch = 96;
            const double pageHeight = 5.0 * inch;
            const double pageWidth = 3.0 * inch;

            result.PageMediaSize = new PageMediaSize(PageMediaSizeName.Unknown, pageWidth, pageHeight);
            result.OutputColor = OutputColor.Monochrome;
            result.PageOrientation = PageOrientation.Landscape;

            return result;
        }

        private PrintTicket GetPrintTicketFromPrinter()
        {
            PrintQueue printQueue = null;

            LocalPrintServer localPrintServer = new LocalPrintServer();

            // Retrieving collection of local printer on user machine
            PrintQueueCollection localPrinterCollection =
                localPrintServer.GetPrintQueues();

            System.Collections.IEnumerator localPrinterEnumerator =
                localPrinterCollection.GetEnumerator();

            if (localPrinterEnumerator.MoveNext())
            {
                // Get PrintQueue from first available printer
                printQueue = (PrintQueue)localPrinterEnumerator.Current;
            }
            else
            {
                // No printer exist, return null PrintTicket
                return null;
            }

            // Get default PrintTicket from printer
            PrintTicket printTicket = printQueue.DefaultPrintTicket;

            PrintCapabilities printCapabilites = printQueue.GetPrintCapabilities();

            // Modify PrintTicket
            if (printCapabilites.CollationCapability.Contains(Collation.Collated))
            {
                printTicket.Collation = Collation.Collated;
            }

            if (printCapabilites.DuplexingCapability.Contains(
                    Duplexing.TwoSidedLongEdge))
            {
                printTicket.Duplexing = Duplexing.TwoSidedLongEdge;
            }

            if (printCapabilites.StaplingCapability.Contains(Stapling.StapleDualLeft))
            {
                printTicket.Stapling = Stapling.StapleDualLeft;
            }

            return printTicket;
        }// end:GetPrintTicketFromPrinter()

    }
}
