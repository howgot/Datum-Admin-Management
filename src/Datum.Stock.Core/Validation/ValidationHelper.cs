using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Core
{
    public static class ValidationHelper
    {
        public static bool CheckNull<T>(T obj)
        {
            bool result = false;
            if (obj is String && string.IsNullOrWhiteSpace(obj as String))
            {
                result = true;
            }
            else if (obj == null)
            {
                result = true;
            }
            return result;
        }

        public static void ArgumentNullCheck(this object obj)
        {
            if (CheckNull(obj)) throw new ArgumentNullException(nameof(obj));
        }

    }
}
