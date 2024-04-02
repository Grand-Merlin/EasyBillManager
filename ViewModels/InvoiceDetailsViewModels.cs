using EasyBillManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.ViewModels
{
    public class InvoiceDetailsViewModels : INotifyPropertyChanged
    {
        private Invoice _invoice;
        private string _selectedCustomerCriteria;
        public InvoiceDetailsViewModels()
        {
            SelectedCustomerCriteria = CustomerCriteriaOptions.FirstOrDefault();//Selectionne le 1er string dans la liste
        }
        public string SelectedCustomerCriteria
        {
            get { return _selectedCustomerCriteria; }
            set
            {
                _selectedCustomerCriteria = value;
                OnPropertyChanged(nameof(SelectedCustomerCriteria));
            }
        }


        public List<string> CustomerCriteriaOptions { get; set; } = new List<string>
        {
            "N° de client", "Nom de client", "N° de TVA"
        };

        public Invoice Invoice
        {
            get { return _invoice; }
            set
            {
                _invoice = value;
                OnPropertyChanged(nameof(Invoice));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

