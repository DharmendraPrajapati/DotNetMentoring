using System;
using System.Collections;
using System.Collections.Generic;
using ServiceModels;

namespace UnitTestProject1
{
    internal class ReportViewModelComparer : IComparer, IComparer<ReportViewModel>
    {
        public int Compare(object x, object y)
        {
            var lhs = x as ReportViewModel;
            var rhs = y as ReportViewModel;

            if ((lhs == null) || (rhs == null))
            {
                throw new InvalidOperationException();
            }

            return Compare(lhs, rhs);
        }

        /// <summary>
        ///     Returns 0 if equals, otherwise 1
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(ReportViewModel x, ReportViewModel y)
        {
            if ((y != null) && (x != null) && (x.Id == y.Id) && (x.Customer.Id == y.Customer.Id) &&
                x.ReportData.Equals(y.ReportData, StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            return 1;
        }
    }
}