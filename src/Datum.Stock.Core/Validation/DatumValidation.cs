using System;
using System.Collections.Generic;
using System.Text;

namespace Datum.Stock.Core.Validation
{
    public partial class DatumValidation
    {
        public static void CheckNull<T>(T obj)
        {
            if(obj is String && string.IsNullOrWhiteSpace(obj as String))
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
                
        }

        
    }
}
