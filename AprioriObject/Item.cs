// ***********************************************************************
// Assembly         : AprioriObject
// Author           : MinhTri
// Created          : 30-12-2014
//
// Last Modified By : MinhTri
// Last Modified On : 30-12-2014
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// The AprioriObject namespace.
/// </summary>
namespace AprioriObject
{
    /// <summary>
    /// Class Items.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The items
        /// </summary>
        public List<string> items;
        /// <summary>
        /// The supp
        /// </summary>
        private double supp;

        /// <summary>
        /// Initializes a new instance of the <see cref="Item" /> class.
        /// </summary>
        public Item()
        {
            items = new List<string>();
            supp = 0;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Item" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Item(string value)
        {
            items = new List<string>();
            items.Add(value);
            supp = 0;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Item" /> class.
        /// </summary>
        /// <param name="listValue">The list value.</param>
        public Item(List<string> listValue)
        {
            items = new List<string>(listValue);
            supp = 0;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Item" /> class.
        /// </summary>
        /// <param name="listValue">The list value.</param>
        public Item(string[] listValue)
        {
            items = new List<string>(listValue);
            supp = 0;
        }

        public Item(Item i)
        {
            items = new List<string>(i.items);
            supp = i.supp;
        }

        /// <summary>
        /// Gets or sets the supp.
        /// </summary>
        /// <value>The supp.</value>
        public double Supp
        {
            get { return supp; }
            set { supp = value; }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var item in items)
            {
                // Append each int to the StringBuilder overload.
                builder.Append(item).Append(",");
            }
            builder.Append(supp);
            return builder.ToString();
        }

        /// <summary>
        /// Equalses the specified comp items.
        /// </summary>
        /// <param name="compItems">The comp items.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Equals(Item compItems)
        {
            var tmp1 = new HashSet<string>(this.items);
            var tmp2 = new HashSet<string>(compItems.items);
            return tmp1.IsSubsetOf(tmp2) && tmp2.IsSubsetOf(tmp1);
        }
    }
}
