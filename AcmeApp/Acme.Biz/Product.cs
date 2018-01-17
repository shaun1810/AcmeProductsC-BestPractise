using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {

        public Product()
        {
            Console.WriteLine("Product instance created");
        }
        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;

            Console.WriteLine("Product instance has a name: " +
                                ProductName);
        }
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }


        public string SayHello()
        {
            var vendor = new Vendor();
            var emailService = new EmailService();
            vendor.SendWelcomeEmail("Message from the supplier");
            emailService.SendMessage("Vendor", "New vendor", "Vendor@Argos.com");
            return "Hello " + ProductName +
                    " (" + ProductId + "): " +
                    Description;
        }

    }
}