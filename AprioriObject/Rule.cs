// ***********************************************************************
// Assembly         : AprioriObject
// Author           : Ga9286
// Created          : 30-12-2014
//
// Last Modified By : Ga9286
// Last Modified On : 30-12-2014
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprioriObject
{
    /// <summary>
    /// Class Rule.
    /// </summary>
    public class Rule
    {
        double _conf;

        public double Conf
        {
            get { return _conf; }
            set { _conf = value; }
        }

        Item _leftItem;
        Item _rightItem;
        Item _bothLeftRight;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rule"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <param name="bothLeftRight">The both left right.</param>
        public Rule(Item left, Item right, Item bothLeftRight)
        {
            _leftItem = left;
            _rightItem = right;
            _bothLeftRight = bothLeftRight;
            _conf = _bothLeftRight.Supp / _leftItem.Supp;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return _leftItem.ToString() + " => " + _rightItem.ToString();
        }
    }
}
