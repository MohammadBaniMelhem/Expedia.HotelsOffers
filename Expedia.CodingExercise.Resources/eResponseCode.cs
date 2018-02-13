using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.CodingExercise.Resources
{
    /// <summary>
    /// ResponseCode of the system.
    /// </summary>
    public enum eResponseCode
    {
        Success = 1000,
        General_Error = 1001,
        Missing_Bad_Parameters = 1002,
        Unassigned = 1003
    }
}
