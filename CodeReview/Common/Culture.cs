using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.Common
{
    /// <summary>
    /// This class is for compatibility with differents Windows DateTime Configuration.
    /// </summary>
    public class Culture
    {
            public static string DateTimeFormat = "MM-dd-yyyy hh:mm:ss";
            public static string DateFormat = "MM-dd-yyyy";
            public static string TimeFormat = "hh:mm:ss";

            public static CultureInfo Info = CultureInfo.InvariantCulture;
    }
}
