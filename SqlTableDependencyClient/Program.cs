using System;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace SqlTableDependencyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = @"Data Source=PF1GGK43\SQLEXPRESS02;Initial Catalog=SqlTableDependency;MultipleActiveResultSets=true; Integrated Security=true;";

            using (var tableDependency=new SqlTableDependency<Customer>(cs,"Customer"))
            {
                tableDependency.OnChanged += TableDependency_OnChanged;
                tableDependency.OnError += TableDependency_OnError;

                tableDependency.Start();
                Console.WriteLine("Waiting for receiving notifications...");
                Console.WriteLine("Press a key to stop.");
                Console.ReadLine();
                tableDependency.Stop();
            } 
        }

        private static void TableDependency_OnChanged(object sender, RecordChangedEventArgs<Customer> e)
        {
            Console.WriteLine(Environment.NewLine);
            if (e.ChangeType != ChangeType.None)
            {
               
                var changedEntity = e.Entity;
                Console.WriteLine("DML operatios: " + e.ChangeType);
                Console.WriteLine("ID: " + changedEntity.Id);
                Console.WriteLine("Name: " + changedEntity.Name);
                Console.WriteLine("SurName: " + changedEntity.Surname);
                Console.WriteLine(Environment.NewLine);

            }     
        }

        private static void TableDependency_OnError(object sender, ErrorEventArgs e)
        {
            Exception ex = e.Error;
            throw ex;
        }
    }
}
