﻿using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor 
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public enum IncludeAddress {yes,no};
        public enum SendCopy {yes,no};
                                
       /// <summary>
       /// Sends a product order to the vendor
       /// </summary>
       /// <param name="product"></param>
       /// <param name="quantity"></param>
       /// <returns></returns>
     /*  public OperationResult PlaceOrder(Product product, int quantity)
        {
            return PlaceOrder(product, quantity, null, null);
        } */

        /// <summary>
        /// Sends a product order to the vendor Overload for delievery date
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <param name="deliverBy"></param>
        /// <returns></returns>
        /*public OperationResult PlaceOrder(Product product, int quantity, DateTimeOffset? deliverBy)
        {
            return PlaceOrder(product, quantity, deliverBy, null);
        }*/

        /// <summary>
        /// Sends a product order to the vendor Overload for delievery date
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <param name="deliverBy"></param>
        /// <param name="instructions"></param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity, DateTimeOffset? deliverBy= null, string instructions = "Standard Delivery")
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliverBy <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException(nameof(deliverBy));
           
            var success = false;

            var orderText = "Order from Acme Inc" + System.Environment.NewLine + "Product: "
                         + product.ProductCode + System.Environment.NewLine + "Quantity: " + quantity;

            if (deliverBy.HasValue)
            {
                orderText += System.Environment.NewLine +
                             "Deliver By: " + deliverBy.Value.ToString("d");
            }

            if (instructions != null)
            {
                orderText += System.Environment.NewLine +
                                "Instructions:" + instructions;
            }

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;

            }

            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }

       public OperationResult PlaceOrder(Product product, int quantity, IncludeAddress includeAddress, SendCopy sendCopy)
        {
            var orderText = "Test";
            if (includeAddress == IncludeAddress.yes) orderText += " With Address";
            if (sendCopy == SendCopy.yes) orderText += " With Copy";

            var operationResult = new OperationResult(true, orderText);
            return operationResult;
        } 
        
        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = "Hello " + this.CompanyName;
            var confirmation = emailService.SendMessage(subject,
                                                        message, 
                                                        this.Email);
            return confirmation;
        }
    }
}