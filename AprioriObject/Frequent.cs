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
    /// Class Frequent.
    /// </summary>
    public class Frequent
    {
        private HashSet<Item> _database;

        private List<Item> _itemSets;

        private List<Item> _beforeItemSet;

        private int _k;

        private double _minSupp;

        bool _endPoint = false;

        public bool EndPoint
        {
            get { return _endPoint; }
        }


        List<Rule> _rules;

        public List<Item> ItemSets
        {
            get { return _itemSets; }
        }

        public int K
        {
            get { return _k; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Frequent" /> class.
        /// </summary>
        /// <param name="k">The k.</param>
        /// <param name="minSupp">The minimum supp.</param>
        /// <param name="database">The database.</param>
        /// <param name="beforeItemSets">The before item sets.</param>
        public Frequent(int k, double minSupp, List<Item> database, List<Item> beforeItemSets)
        {
            _k = k;
            _minSupp = minSupp;
            _database = new HashSet<Item>(database);
            _itemSets = new List<Item>();
            _beforeItemSet = beforeItemSets;
        }


        /// <summary>
        /// Creates the candidates.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CreateCandidates()
        {
            if (_k == 1)
            {
                //Đổ các phần tử vào danh sách và lấy không trùng để có được danh sách các itemset có 1 phần tử.
                var basicItemNames = new List<string>();
                _beforeItemSet.ForEach(p => basicItemNames.AddRange(p.items.ToList()));
                basicItemNames = basicItemNames.Distinct().ToList();

                //Tạo danh sách các dòng item từ list string trên 
                basicItemNames.ForEach(p => _itemSets.Add(new Item(p)));
            }
            else
            {
                var length = _beforeItemSet.Count;
                for (int i = 0; i < length - 1; i++)
                {
                    for (int j = i + 1; j < length; j++)
                    {
                        var listNames = new List<string>();
                        listNames.AddRange(_beforeItemSet[i].items);
                        listNames.AddRange(_beforeItemSet[j].items);
                        listNames.Distinct().ToList();

                        if (_itemSets.FirstOrDefault(p =>
                        {
                            var tmp1 = new HashSet<string>(p.items);
                            var tmp2 = new HashSet<string>(listNames);
                            //Check if two sets are equal then add to itemset
                            if (tmp1.IsSubsetOf(tmp2) && tmp2.IsSubsetOf(tmp1))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }) == null)
                        {
                            _itemSets.Add(new Item(listNames));
                        }
                    }
                }

                _itemSets.RemoveAll(p => p.items.Count != _k);
            }

            if (_itemSets.Count == 0)
            {
                _endPoint = true;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Calculates the supp and check minimum supp.
        /// </summary>
        /// <param name="minSupp">The minimum supp.</param>
        public void CalcSuppAndCheckMinSupp(double minSupp)
        {
            //Tinh supp
            foreach (var item in _itemSets)
            {
                var item_tmp = new HashSet<string>(item.items);
                item.Supp = (double)_database.Count(p => item_tmp.IsProperSubsetOf(new HashSet<string>(p.items))) / _database.Count;
            }

            //Xoa cai khong thoa minSupp
            do
            {
                var item = _itemSets.FirstOrDefault(p => p.Supp < minSupp || p.Supp == 0);
                _itemSets.Remove(item);

            } while (_itemSets.FirstOrDefault(p => p.Supp < minSupp) != null);
        }

        /// <summary>
        /// Calculates the conf and check minimum conf.
        /// </summary>
        /// <param name="minConf">The minimum conf.</param>
        /// <param name="frequents">The frequents.</param>
        public void CreateRules(double minConf, List<Frequent> frequents)
        {
            foreach (var item in _itemSets)
            {
                var leftItems = new List<Item>();
                var rightItems = new List<Item>();
                var tmpItemHashSet = new HashSet<string>(item.items);

                //Chọn các tập con tổ hợp từ các phần tử của item = cách chọn trong frequents đã tính trước đó.
                for (int i = 1; i < _k; i++)
                {
                    leftItems.AddRange(frequents[i]._itemSets.Where(p => { return new HashSet<string>(p.items).IsProperSubsetOf(tmpItemHashSet); }));
                }

                foreach (var it in leftItems)
                {
                    var tmp = new Item(item);
                    tmp.items = tmp.items.Except(it.items).ToList();
                    rightItems.Add(tmp);
                }

                var rules = new List<Rule>();
                for (int i = 0; i < leftItems.Count; i++)
                {
                    var rule = new Rule(leftItems[i], rightItems[i], item);
                    if (rule.Conf >= minConf)
                    {
                        rules.Add(rule);
                    }
                }

                //Loại bỏ item không tạo đc rule nào
                if (rules.Count == 0)
                {
                    _itemSets.Remove(item);
                }

            }
        }
    }
}
