using EasyBillManager.DataAccess;
using EasyBillManager.Models;
using EasyBillManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.ViewModels
{
    public class InvoiceManagerViewModels : INotifyPropertyChanged
    {
        #region Fields
        // Une collection observable des factures, qui sera liée à la DataGrid de la vue.
        // Quand elle est mise à jour, l'interface utilisateur est notifiée du changement.
        private ObservableCollection<Invoice> _invoices;
        private string _selectedSearchCriteria;
        private string _searchQuery;
        private readonly InvoiceRepository _invoiceRepository;
        private Invoice _selectedInvoice;
        #endregion

        #region Constructors
        public InvoiceManagerViewModels()
        {
            Invoices = new ObservableCollection<Invoice>();
            SelectedSearchCriteria = SearchCriteriaOptions.FirstOrDefault(); // Sélectionne par défaut le premier critère de recherche
            _invoiceRepository = new InvoiceRepository();
            LoadInvoicesFromDb();
        }
        #endregion

        #region Properties
        public Invoice SelectedInvoice
        {
            get { return _selectedInvoice; }
            set
            {
                _selectedInvoice = value;
                OnPropertyChanged(nameof(SelectedInvoice));
            }
        }

        public ObservableCollection<Invoice> Invoices
        {
            get { return _invoices; }
            set
            {
                _invoices = value;
                OnPropertyChanged(nameof(Invoices)); // Notifie la vue du changement.
            }
        }

        // Critère de recherche sélectionné par l'utilisateur via une ComboBox dans la vue.
        public string SelectedSearchCriteria
        {
            get { return _selectedSearchCriteria; }
            set
            {

                _selectedSearchCriteria = value;
                OnPropertyChanged(nameof(SelectedSearchCriteria));

            }
        }

        // Texte de recherche entré par l'utilisateur, lié à une TextBox dans la vue.
        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                FilterInvoices();
            }
        }


        public List<string> SearchCriteriaOptions { get; set; } = new List<string>
        {
            "n° de facture", "date", "nom de client", "n° de client"
        };
        #endregion

        #region Methods
        // Méthode pour invoquer l'événement PropertyChanged, utilisée pour notifier les changements de propriétés.
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Méthode qui exécute la logique de recherche quand la commande est invoquée.
        public void FilterInvoices()
        {
            Invoices.Clear();
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            if (SelectedSearchCriteria == "n° de facture")
            {
               // Invoices = invoiceRepository.GetByInvoiceNumber(SearchQuery);
            }
            else if (SelectedSearchCriteria == "date")
            {
                Invoices = invoiceRepository.GetByInvoiceDate(SearchQuery);
            }
            else if (SelectedSearchCriteria == "nom de client")
            {
               // Invoices = invoiceRepository.GetByCustomerName(SearchQuery);
            }
            else if (SelectedSearchCriteria == "n° de client")
            {
                Invoices = invoiceRepository.GetByCustomerNumber(SearchQuery);
            }


        }
        public void LoadInvoicesFromDb()
        {
            Invoices.Clear();
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            Invoices = invoiceRepository.GetAllInvoices();
        }

        public void AddInvoice()
        {
            InvoiceDetails invoiceDetails = new InvoiceDetails();
            invoiceDetails.Show();
        }
        public void EditInvoice()
        {
            InvoiceDetailsViewModels invoiceDetailsViewModels = new InvoiceDetailsViewModels
            {
                Invoice = SelectedInvoice
            };
            InvoiceDetails invoiceDetails = new InvoiceDetails();
            invoiceDetails.DataContext = invoiceDetailsViewModels;//Ce code lie l'interface utilisateur invoiceDetails aux données de invoiceDetailsViewModels
            invoiceDetails.Show();
        }
        #endregion
    }

}
