﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;
using static Acme.Common.LoggingService;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {

        public Product()
        {
            this.productVendor = new Vendor(); 
            Console.WriteLine("Product instance created");
        }
        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            this.productVendor = new Vendor();
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

        private Vendor productVendor;       
            
        public Vendor ProductVendor
        {
            get { return productVendor; }
            set { productVendor = value; }
        }
        
        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from the supplier");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product", this.productName, "Sales@abc.com");
            var result = LogAction("Hello");

            return "Hello " + ProductName +
                    " (" + ProductId + "): " +
                    Description;
        }

    }
}