using EasyBillManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EasyBillManager.DataAccess
{
    public class InvoiceRepository
    {
        // Déclaration d'une variable privée de type string qui est en lecture seule après sa construction.
        // Cette variable est destinée à stocker la chaîne de connexion à la base de données.
        private readonly string _connectionString;
        public InvoiceRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EasyBillManagerDB"].ConnectionString; // Sauvegarde la chaîne de connexion passée lors de la création de l'instance du repository.
        }

        #region Methods
        //RÉCUPÈRE UNE FACTURE SPÉCIFIQUE DE LA BASE DE DONNÉES EN UTILISANT SON IDENTIFIANT UNIQUE.
        public Invoice GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // Prépare une requête SQL pour sélectionner une facture par son numero de facture. 
                // La requête utilise un paramètre (@) pour éviter les injections SQL.
                var command = new SqlCommand(@"SELECT Id, customer_id, invoice_number,
                                                      invoice_date, due_date, total_amount_exc_vat,
                                                      total_amount_vat, flag_accounting, communication
                                               FROM invoices 
                                               WHERE Id = @IdInvoice", connection);

                // Associe la valeur du paramètre @Id à la variable 'id' passée à la méthode.
                command.Parameters.AddWithValue("@IdInvoice", id);

                // Ouvre la connexion à la base de données.
                connection.Open();

                // Exécute la requête et récupère les résultats dans un objet SqlDataReader.
                using (var reader = command.ExecuteReader())
                {
                    // Tente de lire la première ligne du résultat (s'il existe).
                    if (reader.Read())
                    {
                        // Crée un nouvel objet Invoice et assigne les valeurs lues 
                        // à partir de la base de données à ses propriétés.
                        return new Invoice
                        {
                            IdInvoice = reader.GetInt32(reader.GetOrdinal("Id")),
                            CustomerId = reader.GetInt32(reader.GetOrdinal("customer_id")),
                            InvoiceNumber = reader.GetString(reader.GetOrdinal("invoice_number")),
                            InvoiceDate = reader.GetDateTime(reader.GetOrdinal("invoice_date")),
                            DueDate = reader.GetDateTime(reader.GetOrdinal("due_date")),
                            TotalAmountExcVat = reader.GetDecimal(reader.GetOrdinal("total_amount_exc_vat")),
                            TotalAmountVat = reader.GetDecimal(reader.GetOrdinal("total_amount_vat")),
                            FlagAccounting = reader.GetBoolean(reader.GetOrdinal("flag_accounting")),
                            Communication = reader.GetString(reader.GetOrdinal("communication"))
                        };
                    }
                }
            }
            return null; // Si aucun client n'a été trouvé avec l'ID fourni, retourne null.
        }

        //public ObservableCollection<Invoice> GetByInvoiceNumber(string invoiceNumber)
        //{
            
        //}

        public ObservableCollection<Invoice> GetByInvoiceDate(string invoiceDate)
        {
            throw new FileNotFoundException("erreur");
        }


        public ObservableCollection<Invoice> GetByCustomerNumber(string customerNumber)
        {
            throw new FileNotFoundException("erreur");
        }

        public ObservableCollection<Invoice> GetAllInvoices()
        {
            ObservableCollection<Invoice> invoices = new ObservableCollection<Invoice>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(@"SELECT *
                                                      FROM invoices", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Invoice invoice = new Invoice 
                        {
                            IdInvoice = reader.GetInt32(reader.GetOrdinal("id")),
                            CustomerId = reader.GetInt32(reader.GetOrdinal("customer_id")),
                            InvoiceNumber = reader.GetString(reader.GetOrdinal("invoice_number")),
                            InvoiceDate = reader.GetDateTime(reader.GetOrdinal("invoice_date")),
                            DueDate = reader.GetDateTime(reader.GetOrdinal("due_date")),
                            TotalAmountExcVat = reader.GetDecimal(reader.GetOrdinal("total_amount_exc_vat")),
                            TotalAmountVat = reader.GetDecimal(reader.GetOrdinal("total_amount_vat")),
                            FlagAccounting = reader.GetBoolean(reader.GetOrdinal("flag_accounting")),
                            Communication = reader.GetString(reader.GetOrdinal("communication"))
                        };
                        invoices.Add(invoice);
                    }
                }
                return invoices;
            }
        }

        public Invoice update(Invoice invoice)
        {
            throw new FileNotFoundException("erreur");
        }
        #endregion
    }
}
