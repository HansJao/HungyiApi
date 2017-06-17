using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.DataClass.Customer
{
    public class CustomerEntity
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int CustomerID { get; set; }
        /// <summary>
        /// Gets or sets the customer address.
        /// </summary>
        /// <value>
        /// The customer address.
        /// </value>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets the customer cellphone.
        /// </summary>
        /// <value>
        /// The customer cellphone.
        /// </value>
        public string CustomerCellphone { get; set; }
        /// <summary>
        /// Gets or sets the customer telephone.
        /// </summary>
        /// <value>
        /// The customer telephone.
        /// </value>
        public string CustomerTelephone { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>
        /// The create date.
        /// </value>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Gets or sets the modify date.
        /// </summary>
        /// <value>
        /// The modify date.
        /// </value>
        public DateTime ModifyDate { get; set; }
    }
}
