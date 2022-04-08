using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using CSharp_20_Dapper.Model;
using System.Linq;
using System;


namespace CSharp_20_Dapper
{
    class Program
    {

        /* Previamente crear esta tabla en la base de datos con esta sentencia:

            CREATE TABLE [dbo].[Customers] (
                [CustomerID] INT            IDENTITY (1, 1) NOT NULL,
                [FirstName]  NVARCHAR (MAX) NULL,
                [LastName]   NVARCHAR (MAX) NULL,
                [Email]      NVARCHAR (MAX) NULL,
                CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
                );
        */

        static void Main(string[] args)
        {
            using IDbConnection connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = DapperDemo; Trusted_Connection = True;");

            //CRUD -> Create, Read, Update and Delete
            // Read
            ShowDatabase(connection);

            // Create
            var dataCreate = AddData(connection);

            // Update
            Update(connection, dataCreate);

            // Delete
            Delete(connection);
           
            //Cerrar la conexión 
            connection.Close();
        }

        private static void Delete(IDbConnection connection)
        {
            var customer = connection.Query<Customer>("Select * From Customers").FirstOrDefault();

            string sqlQueryDelete = "Delete From Customers WHERE CustomerID = " + customer.CustomerID;

            int rowsAffectedDelete = connection.Execute(sqlQueryDelete);
            Console.WriteLine("({0} row(s) afectadas)", rowsAffectedDelete);


            // Visualizar los cambios
            var customers = connection.Query<Customer>("Select * From Customers").ToList();
            Console.WriteLine("Tabla total:");
            customers.ForEach(z => Console.WriteLine("{0} - {1} {2} {3}", z.CustomerID, z.FirstName, z.LastName, z.Email));
        }

        private static void Update(IDbConnection connection, int dataCreate)
        {
            string sqlQuery2 = "UPDATE Customers set FirstName='" + "Nino" +
                                           "',LastName='" + "Perez" +
                                           "',Email='" + "nuevo@correo.es" +
                                           "' WHERE CustomerID=" + dataCreate;

            int rowsAffected2 = connection.Execute(sqlQuery2);
            Console.WriteLine("({0} row(s) afectadas)", rowsAffected2);
        }

        private static int AddData(IDbConnection connection)
        {           
            string insertUserSql = @"INSERT INTO dbo.[Customers](FirstName, LastName, Email)
                                    OUTPUT INSERTED.*
                                    VALUES(@FirstName, @LastName, @Email);";

            Customer newCustomer = connection.QuerySingle<Customer>(insertUserSql,
                                            new
                                            {
                                                FirstName = "lorem ipsum",
                                                LastName = "555-123",
                                                Email = "lorem ipsum"
                                            });

            // Visualizar el dato añadido
            Console.WriteLine("{0} - {1} {2} {3}", newCustomer.CustomerID, newCustomer.FirstName, newCustomer.LastName, newCustomer.Email);
            return newCustomer.CustomerID;
        }

        private static void ShowDatabase(IDbConnection connection)
        {
            List<Customer> customers = new List<Customer>();

            customers = connection.Query<Customer>("Select * From Customers").ToList();
            var id = customers.FirstOrDefault().CustomerID;

            Console.WriteLine("Tabla total:");
            customers.ForEach(z => Console.WriteLine("{0} - {1} {2} {3}", z.CustomerID, z.FirstName, z.LastName, z.Email));
        }
    }


}
