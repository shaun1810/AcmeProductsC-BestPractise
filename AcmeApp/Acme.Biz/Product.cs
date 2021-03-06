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

        public const double inchesInMetre = 39.37;
        public readonly decimal MinimumPrice;

        public Product()
        {
            this.productVendor = new Vendor();
            this.MinimumPrice = .96m;
            Console.WriteLine("Product instance created");
        }
        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            if (ProductName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.99m;
            }
            //this.productVendor = new Vendor();
            Console.WriteLine("Product instance has a name: " +
                                ProductName);
        }

        private decimal productCost;

        public decimal ProductCost
        {
            get { return productCost; }
            set { productCost = value; }
        }

        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get
            {
                return availabilityDate;
            }
            set { availabilityDate = value; }
        }

        private string productName;

        public string ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }

            set {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name must be more than 20 characters";
                }
                else {
                    productName = value?.Trim();
                }
            }
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
            get {
                if (productVendor != null)
                {
                    this.productVendor = new Vendor();
                }
                 return productVendor;
                }
            set { productVendor = value; }
        }

        public string ProductCategory { get; set; } = "Tools";

        public int SequnceNumber { get; set; } = 1;

        public string ProductCode => $"{this.SequnceNumber:0000}-{this.ProductCategory}"; 

        public string ValidationMessage { get; private set; }

        public decimal CalculatedSuggestedPrice(decimal markupPercent) =>
             this.ProductCost + (this.ProductCost * markupPercent / 100);
   
        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from the supplier");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product", this.productName, "Sales@abc.com");
            var result = LogAction("Hello");

            return "Hello " + ProductName +
                    " (" + ProductId + "): " +
                    Description + " Available on: " + AvailabilityDate?.ToShortDateString();
        }

        public override string ToString() =>
             this.ProductName + " (" + this.productId + ")";      
    }
}