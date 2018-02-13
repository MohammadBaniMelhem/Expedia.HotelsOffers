using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.CodingExercise.Resources
{
    public static class ResourcesManager
    {
        static ResourceManager messagesManager = Messages.ResourceManager;
        /// <summary>
        /// Get message form the resource file
        /// </summary>
        public static string GetMessage(string code)
        {
            return ((string)(messagesManager.GetString("_" + code)));
        }
    }
}
