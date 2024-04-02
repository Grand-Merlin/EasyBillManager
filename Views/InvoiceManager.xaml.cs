using EasyBillManager.DataAccess;
using EasyBillManager.Models;
using EasyBillManager.ViewModels;
using EasyBillManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyBillManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class InvoiceManager : Window
    {
        private InvoiceManagerViewModels _invoiceManagerViewModels;
        public InvoiceManager()
        {
            InitializeComponent();
            _invoiceManagerViewModels = new InvoiceManagerViewModels();
            this.DataContext = _invoiceManagerViewModels;
        }

        private void AddInvoice_Click(object sender, RoutedEventArgs e)
        {
            _invoiceManagerViewModels.AddInvoice();
        }

        private void EditInvoice_Click(object sender, RoutedEventArgs e)
        {
            _invoiceManagerViewModels.EditInvoice();
        }
    }
}

