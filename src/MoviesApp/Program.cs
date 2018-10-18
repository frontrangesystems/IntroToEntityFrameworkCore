using System;
using MoviesApp.Helpers;

namespace MoviesApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SimpleSelectHelper.RunAll();
//            PagingHelper.RunAll();
//            InsertHelper.RunAll();
//            UpdateHelper.RunAll();
//            DeleteHelper.RunAll();
//            OneToOneSelectHelper.RunAll();
//            OneToManySelectHelper.RunAll();
//            ManyToManySelectHelper.RunAll();
//            PerformanceHelper.RunAll();
//            RawSqlHelper.RunAll();
//            StoredProcedureHelper.RunAll();
//            TransactionHelper.RunAll();

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}