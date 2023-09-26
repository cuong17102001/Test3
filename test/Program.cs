using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("input product name:");
                var productName = Console.ReadLine();


                string store1ConnectionString = ConfigurationManager.ConnectionStrings["StoreA"].ConnectionString;
                string store2ConnectionString = ConfigurationManager.ConnectionStrings["StoreB"].ConnectionString;

                ProductQuery queryStore1 = new ProductQuery(store1ConnectionString);
                ProductQuery queryStore2 = new ProductQuery(store2ConnectionString);

                DataSet dataSetStore1 = queryStore1.FindProduct(productName);
                DataSet dataSetStore2 = queryStore2.FindProduct(productName);

                bool productAvailableInBothStores = (dataSetStore1.Tables[0].Rows.Count > 0) && (dataSetStore2.Tables[0].Rows.Count > 0);

                if (productAvailableInBothStores)
                {
                    Console.WriteLine("The product is available in both stores.");
                }
                else
                {
                    Console.WriteLine("The product is not available in both stores.");
                }

                Console.WriteLine("do you want to continue? (yes/no)");
                var isContinue = Console.ReadLine();
                if (isContinue != "yes")
                {
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
