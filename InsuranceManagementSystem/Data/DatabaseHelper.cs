using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Security.Policy;

namespace InsuranceManagementSystem.Data
{
    public static class DatabaseHelper
    {
        private static string DatabasePath => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "InsuranceManagementSystem", "InsuranceManagementSystem.accdb");

        private static string ConnectionString =>
            "Provider=Microsoft.ACE.OLEDB.12.0;" +
            $"Data Source = {DatabasePath};";
        public static OleDbConnection GetConnection()
        {
            if (!File.Exists(DatabasePath))
            {
                throw new FileNotFoundException(
                    "Database file not found: " + DatabasePath);
            }
            return new OleDbConnection(ConnectionString);
        }
        public static DataTable GetClients()
        {
            using OleDbConnection connection = GetConnection();
            using OleDbDataAdapter adapter =
                new OleDbDataAdapter(
                    "SELECT Id, FirstName, LastName, Email, Phone, " +
                    "RegistrationDate FROM Clients ORDER BY Id DESC",
                    connection);

            DataTable clientsTable = new DataTable();
            adapter.Fill(clientsTable);

            return clientsTable;
        }

        public static void AddClient(
            string firstName,
            string lastName,
            string email,
            string phone)
        {
            using OleDbConnection connection = GetConnection();
            connection.Open();

            string sql = "INSERT INTO CLIENTS " +
                "(FirstName, LastName, Email, Phone, RegistrationDate)" +
                "VALUES (?, ?, ?, ?, ?)";
            using OleDbCommand command = new OleDbCommand(sql, connection);
            command.Parameters.Add(
                "FirstName", OleDbType.VarWChar).Value = firstName;
            command.Parameters.Add(
                "LastName", OleDbType.VarWChar).Value = lastName;
            command.Parameters.Add(
                "Email", OleDbType.VarWChar).Value = email;
            command.Parameters.Add(
                "Phone", OleDbType.VarWChar).Value = phone;
            command.Parameters.Add(
                "RegistrationDate", OleDbType.Date).Value = DateTime.Now;
            command.ExecuteNonQuery();
        }

        public static void UpdateClient(
            int id,
            string firstName,
            string lastName,
            string email,
            string phone)
        {
            using OleDbConnection connection = GetConnection();
            connection.Open();
            MessageBox.Show("Database: " + DatabasePath);
            string sql =
                "UPDATE Clients SET FirstName = ?, " +
                " LastName = ?, Email = ?, Phone = ? WHERE Id = ?";
            using OleDbCommand command = new OleDbCommand(sql, connection);
            command.Parameters.Add(
                "FirstName", OleDbType.VarWChar).Value = firstName;
            command.Parameters.Add(
                "LastName", OleDbType.VarWChar).Value = lastName;
            command.Parameters.Add(
                "Email", OleDbType.VarWChar).Value = email;
            command.Parameters.Add(
                "Phone", OleDbType.VarWChar).Value = phone;
            command.Parameters.Add(
                "Id", OleDbType.Integer).Value = id;
            command.ExecuteNonQuery();
        }

        public static void DeleteClient(int id)
        {
            using OleDbConnection connection = GetConnection();
            connection.Open();

            using OleDbCommand command = new OleDbCommand("DELETE FROM Clients WHERE Id = ?", connection);
            command.Parameters.Add(
                "Id", OleDbType.Integer).Value = id;
            command.ExecuteNonQuery();
        }
        public static void CreatePoliciesTable()
        {
            using OleDbConnection connection = GetConnection();
            connection.Open();
            DataTable schema = connection.GetSchema("Tables");
            foreach (DataRow row in schema.Rows)
            {
                if (string.Equals(
                    row["TABLE_NAME"]?.ToString(),
                    "Policies",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }
            string sql = @"
       CREATE TABLE Policies (
           Id COUNTER PRIMARY KEY,
           ClientId LONG NOT NULL,
           PolicyNumber TEXT(50),
           InsuranceType TEXT(50),
           StartDate DATETIME,
           EndDate DATETIME,
           Premium CURRENCY,
           Status TEXT(30)
       )";
            using OleDbCommand command = new OleDbCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static DataTable GetPolicies()
        {
            using OleDbConnection connection = GetConnection();
            using OleDbDataAdapter adapter = new OleDbDataAdapter(
                "SELECT Id, ClientId, PolicyNumber, InsuranceType, StartDate, EndDate, Premium, Status " +
                "FROM Policies ORDER BY Id DESC",
                connection);
            DataTable policiesTable = new DataTable();
            adapter.Fill(policiesTable);
            return policiesTable;

        }

        public static int GetTotalClients()
        {
            using OleDbConnection connection = GetConnection();
            using OleDbCommand command = new OleDbCommand(
                "SELECT COUNT(*) FROM Clients",
                connection);

            connection.Open();
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public static int GetTotalPolicies()
        {
            using OleDbConnection connection = GetConnection();
            using OleDbCommand command = new OleDbCommand(
                "SELECT COUNT(*) FROM Policies",
                connection);

            connection.Open();
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public static int GetActivePolicies()
        {
            using OleDbConnection connection = GetConnection();
            using OleDbCommand command = new OleDbCommand(
                "SELECT COUNT(*) FROM Policies WHERE Status = 'Active'",
                connection);

            connection.Open();
            return Convert.ToInt32(command.ExecuteScalar());
        }


        public static int GetPoliciesByType(string insuranceType)
        {
            using OleDbConnection connection = GetConnection();

            using OleDbCommand command = new OleDbCommand(
                "SELECT COUNT(*) FROM Policies WHERE InsuranceType = ?",
                connection);

            command.Parameters.AddWithValue("@InsuranceType", insuranceType);

            connection.Open();

            return Convert.ToInt32(command.ExecuteScalar());
        }



        public static decimal GetTotalPremium()
        {
            using OleDbConnection connection = GetConnection();
            using OleDbCommand command = new OleDbCommand(
                "SELECT SUM(Premium) FROM Policies",
                connection);

            connection.Open();

            object result = command.ExecuteScalar();

            if (result == DBNull.Value || result == null)
                return 0;

            return Convert.ToDecimal(result);
        }

        public static void AddPolicy(
            int clientId,
           string policyNumber,
           string insuranceType,
           DateTime startDate,
           DateTime endDate,
           decimal premium,
           string status)
        {
            using OleDbConnection connection = GetConnection();
            connection.Open();
            string sql =
                "INSERT INTO Policies " +
                "(ClientId, PolicyNumber, InsuranceType, " +
                "StartDate, EndDate, Premium, Status) " +
                "VALUES (?, ?, ?, ?, ?, ?, ?)";
            using OleDbCommand command = new OleDbCommand(sql, connection);
            command.Parameters.Add("ClientId", OleDbType.Integer).Value = clientId;
            command.Parameters.Add("PolicyNumber", OleDbType.VarWChar).Value = policyNumber;
            command.Parameters.Add("InsuranceType", OleDbType.VarWChar).Value = insuranceType;
            command.Parameters.Add("StartDate", OleDbType.Date).Value = startDate;
            command.Parameters.Add("EndDate", OleDbType.Date).Value = endDate;
            command.Parameters.Add("Premium", OleDbType.Currency).Value = premium;
            command.Parameters.Add("Status", OleDbType.VarWChar).Value = status;
            command.ExecuteNonQuery();
        }

        public static void UpdatePolicy(
           int id,
           int clientId,
           string policyNumber,
           string insuranceType,
           DateTime startDate,
           DateTime endDate,
           decimal premium,
           string status)
        {
            using OleDbConnection connection = GetConnection();
            connection.Open();
            string sql =
                "UPDATE Policies SET " +
                "ClientId = ?, PolicyNumber = ?, InsuranceType = ?, " +
                "StartDate = ?, EndDate = ?, Premium = ?, Status = ? " +
                "WHERE Id = ?";
            using OleDbCommand command = new OleDbCommand(sql, connection);
            command.Parameters.Add("ClientId", OleDbType.Integer).Value = clientId;
            command.Parameters.Add("PolicyNumber", OleDbType.VarWChar).Value = policyNumber;
            command.Parameters.Add("InsuranceType", OleDbType.VarWChar).Value = insuranceType;
            command.Parameters.Add("StartDate", OleDbType.Date).Value = startDate;
            command.Parameters.Add("EndDate", OleDbType.Date).Value = endDate;
            command.Parameters.Add("Premium", OleDbType.Currency).Value = premium;
            command.Parameters.Add("Status", OleDbType.VarWChar).Value = status;
            command.Parameters.Add("Id", OleDbType.Integer).Value = id;
            command.ExecuteNonQuery();
        }

        public static void DeletePolicy(int id)
        {
            using OleDbConnection connection = GetConnection();
            connection.Open();
            string sql = "DELETE FROM Policies WHERE Id = ?";
            using OleDbCommand command = new OleDbCommand(sql, connection);
            command.Parameters.Add("Id", OleDbType.Integer).Value = id;
            command.ExecuteNonQuery();
        }

    
        public static bool PolicyNumberExists(string policyNumber, int? excludedPolicyId = null)
        {
            using OleDbConnection connection = GetConnection();

            string sql = "SELECT COUNT(*) FROM Policies WHERE UCASE(PolicyNumber) = ?";

            if (excludedPolicyId.HasValue)
                sql += " AND Id <> ?";

            using OleDbCommand command = new OleDbCommand(sql, connection);

            command.Parameters.Add("PolicyNumber", OleDbType.VarWChar).Value =
                policyNumber.Trim().ToUpperInvariant();

            if (excludedPolicyId.HasValue)
            {
                command.Parameters.Add("Id", OleDbType.Integer).Value =
                    excludedPolicyId.Value;
            }

            connection.Open();

            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }




        public static DataTable GetDashboardStatistics()
        {
            using OleDbConnection connection = GetConnection();
            connection.Open();

            DataTable result = new DataTable();
            result.Columns.Add("TotalClients", typeof(int));
            result.Columns.Add("LifePolicies", typeof(int));
            result.Columns.Add("PropertyPolicies", typeof(int));
            result.Columns.Add("TotalPolicies", typeof(int));
            result.Columns.Add("ActivePolicies", typeof(int));
            result.Columns.Add("TotalPremium", typeof(decimal));

            int totalClients;
            int lifePolicies;
            int propertyPolicies;
            int totalPolicies;
            int activePolicies;
            decimal totalPremium;

            using (OleDbCommand command = new OleDbCommand(
                "SELECT COUNT(*) FROM Clients", connection))
            {
                totalClients = Convert.ToInt32(command.ExecuteScalar());
            }

            using (OleDbCommand command = new OleDbCommand(
                "SELECT COUNT(*) FROM Policies WHERE InsuranceType = ?", connection))
            {
                command.Parameters.Add("type", OleDbType.VarWChar).Value = "Life";
                lifePolicies = Convert.ToInt32(command.ExecuteScalar());
            }

            using (OleDbCommand command = new OleDbCommand(
                "SELECT COUNT(*) FROM Policies WHERE InsuranceType = ?", connection))
            {
                command.Parameters.Add("type", OleDbType.VarWChar).Value = "Property";
                propertyPolicies = Convert.ToInt32(command.ExecuteScalar());
            }

            using (OleDbCommand command = new OleDbCommand(
                "SELECT COUNT(*) FROM Policies", connection))
            {
                totalPolicies = Convert.ToInt32(command.ExecuteScalar());
            }

            using (OleDbCommand command = new OleDbCommand(
                "SELECT COUNT(*) FROM Policies WHERE Status = ?", connection))
            {
                command.Parameters.Add("status", OleDbType.VarWChar).Value = "Active";
                activePolicies = Convert.ToInt32(command.ExecuteScalar());
            }

            using (OleDbCommand command = new OleDbCommand(
                "SELECT SUM(Premium) FROM Policies", connection))
            {
                object value = command.ExecuteScalar();
                totalPremium = value == DBNull.Value
                    ? 0m
                    : Convert.ToDecimal(value);
            }

            result.Rows.Add(
                totalClients,
                lifePolicies,
                propertyPolicies,
                totalPolicies,
                activePolicies,
                totalPremium);

            return result;
        }




    }
}
