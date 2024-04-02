using EasyBillManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBillManager.DataAccess
{
    public class CustomerRepository
    {
        // Déclaration d'une variable privée de type string qui est en lecture seule après sa construction.
        // Cette variable est destinée à stocker la chaîne de connexion à la base de données.
        private readonly string _connectionString;
        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString; // Sauvegarde la chaîne de connexion passée lors de la création de l'instance du repository.
        }
        #region Methods

        #region C
        //AJOUTE UN NOUVEAU CLIENT À LA BASE DE DONNÉES.

        public void Add(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))// Utilise using pour s'assurer que la connexion est bien fermée et disposée après l'exécution
            {
                // Prépare la commande SQL pour insérer un nouveau client
                var command = new SqlCommand(@"INSERT INTO customers (
                                                      category_id, payment_term_id, customer_number, 
                                                      customer_name, phone_number, fax_number, mail, 
                                                      vat_number, registered_vat, is_active
                                               ) VALUE (
                                                   @CategoryId, @PaymentTermId, @CustomerNumber,
                                                   @CustomerName, @CustomerPhoneNumber, @CustomerFaxNumber,
                                                   @CustomerMail, @CustomerVatNumber, @RegisteredVat, @IsActive
                                               )", connection);
                // Sécurise la commande en utilisant des paramètres pour prévenir les injections SQL
                command.Parameters.AddWithValue("@CategoryId", customer.CategoryId);
                command.Parameters.AddWithValue("@PaymentTermId", customer.PaymentTermId);
                command.Parameters.AddWithValue("@CustomerNumber", customer.CustomerNumber);
                command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                command.Parameters.AddWithValue("@CustomerPhoneNumber", customer.CustomerPhoneNumber);
                command.Parameters.AddWithValue("@CustomerFaxNumber", customer.CustomerFaxNumber);
                command.Parameters.AddWithValue("@CustomerMail", customer.CustomerMail);
                command.Parameters.AddWithValue("@CustomerVatNumber", customer.CustomerVatNumber);
                command.Parameters.AddWithValue("@RegisteredVat", customer.RegisteredVat);
                command.Parameters.AddWithValue("@IsActive", customer.IsActive);

                connection.Open(); // Ouvre la connexion à la base de données
                command.ExecuteNonQuery(); // Exécute la commande d'insertion

            }
        }
        #endregion

        #region R
        //RÉCUPÈRE UN CLIENT SPÉCIFIQUE DE LA BASE DE DONNÉES EN UTILISANT SON IDENTIFIANT UNIQUE.
        public Customer GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // Prépare une requête SQL pour sélectionner un client par son ID. 
                // La requête utilise un paramètre (@Id) pour éviter les injections SQL.
                var command = new SqlCommand(@"SELECT (
                                                  Id, category_id, payment_term_id
                                                  customer_number, customer_name, phone_number,
                                                  fax_number, mail, vat_number,
                                                  registered_vat, is_active
                                                ) FROM customers 
                                                  WHERE id = @IdCustomer", connection);

                // Associe la valeur du paramètre @IdCustomer à la variable 'id' passée à la méthode.
                command.Parameters.AddWithValue("IdCustomer", id);

                // Ouvre la connexion à la base de données.
                connection.Open();

                // Exécute la requête et récupère les résultats dans un objet SqlDataReader.
                using (var reader = command.ExecuteReader())
                {
                    // Tente de lire la première ligne du résultat (s'il existe).
                    if (reader.Read())
                    {
                        // Crée un nouvel objet Customer et assigne les valeurs lues 
                        // à partir de la base de données à ses propriétés.
                        return new Customer
                        {
                            IdCustomer = reader.GetInt32(0),
                            CategoryId = reader.GetInt32(1),
                            PaymentTermId = reader.GetInt32(2),
                            CustomerNumber = reader.GetString(3),
                            CustomerName = reader.GetString(4),
                            CustomerPhoneNumber = reader.GetString(5),
                            CustomerFaxNumber = reader.GetString(6),
                            CustomerMail = reader.GetString(7),
                            CustomerVatNumber = reader.GetString(8),
                            RegisteredVat = reader.GetBoolean(9),
                            IsActive = reader.GetBoolean(10)
                        };
                    }
                }
            }
            return null; // Si aucun client n'a été trouvé avec l'ID fourni, retourne null.
        }
        #endregion

        #region R

        //RÉCUPÈRE TOUS LES CLIENTS PRÉSENTS DANS LA BASE DE DONNÉES.
        public IEnumerable<Customer> GetAll()
        {
            // Crée une liste vide pour stocker les objets Customer récupérés.
            var customers = new List<Customer>();

            // Utilise un bloc using pour s'assurer que la connexion est correctement fermée après l'utilisation.
            using (var connection = new SqlConnection(_connectionString))
            {
                // Prépare la requête SQL pour sélectionner tous les enregistrements de la table customers.
                var command = new SqlCommand(@"SELECT *
                                               FROM customers", connection);

                // Ouvre la connexion à la base de données.
                connection.Open();

                // Exécute la requête et récupère les résultats dans un SqlDataReader.
                using (var reader = command.ExecuteReader())
                {
                    // Boucle sur les résultats de la requête.
                    while (reader.Read())
                    {
                        // Pour chaque ligne du résultat, crée un nouvel objet Customer et l'initialise avec les données de la ligne.
                        var customer = new Customer
                        {
                            // Assigne chaque propriété de l'objet Customer à partir des données de la colonne correspondante.
                            IdCustomer = reader.GetInt32(reader.GetOrdinal("id")),
                            CategoryId = reader.GetInt32(reader.GetOrdinal("category_id")),
                            PaymentTermId = reader.GetInt32(reader.GetOrdinal("payment_term_id")),
                            CustomerNumber = reader.GetString(reader.GetOrdinal("customer_number")),
                            CustomerName = reader.GetString(reader.GetOrdinal("customer_name")),
                            CustomerPhoneNumber = reader.GetString(reader.GetOrdinal("phone_number")),
                            CustomerFaxNumber = reader.GetString(reader.GetOrdinal("fax_number")),
                            CustomerMail = reader.GetString(reader.GetOrdinal("mail")),
                            CustomerVatNumber = reader.GetString(reader.GetOrdinal("vat_number")),
                            RegisteredVat = reader.GetBoolean(reader.GetOrdinal("registered_vat")),
                            IsActive = reader.GetBoolean(reader.GetOrdinal("is_active"))
                        };
                        // Ajoute l'objet Customer à la liste des clients.
                        customers.Add(customer);
                    }

                }
                // Retourne la liste des clients.
                return customers;
            }
        }
        #endregion

        #region U
        //MET À JOUR LES INFORMATIONS D'UN CLIENT EXISTANT DANS LA BASE DE DONNÉES.
        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region D
        //SUPPRIME UN CLIENT SPÉCIFIQUE DE LA BASE DE DONNÉES.

        public void Delete(Customer customer)
        {
            // Vérifie si l'objet client passé en argument est non null et a un ID valide.
            if (customer == null || customer.IdCustomer <= 0)
            {
                throw new ArgumentException("Le client est null ou son Id n'est pas valide");
            }

            // Utilise using pour s'assurer que la connexion est bien fermée et libérée après l'exécution
            using (var connection = new SqlConnection(_connectionString))
            {
                // Prépare la commande SQL pour supprimer le client spécifié par son ID
                var command = new SqlCommand(@"DELETE
                                               FROM customers
                                               WHERE Id = @IdCustomer", connection);

                // Ajoute le paramètre @IdCustomer à la commande et assigne la valeur de l'ID du client
                command.Parameters.AddWithValue("@IdCustomer", customer.IdCustomer);

                // Ouvre la connexion à la base de données
                connection.Open();

                // Exécute la commande qui supprime le client
                int rowsAffected = command.ExecuteNonQuery(); //La méthode ExecuteNonQuery() renvoie un entier représentant le nombre de lignes qui ont été impactées

                //vérifier si le nombre de lignes affectées est égal à 0 pour savoir si la mise à jour a réussi.
                if (rowsAffected == 0)
                {
                    throw new InvalidOperationException("La suppression du client a échoué.");
                }
            }
        }
        #endregion
    }
    #endregion
}
