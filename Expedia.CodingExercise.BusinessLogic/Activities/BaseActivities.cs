using Expedia.CodingExercise.DataType;
using Expedia.CodingExercise.DataType.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Expedia.CodingExercise.BusinessLogic.Activities
{
    /// <summary>
    /// Base class for any activities in the system.
    /// </summary>
    public abstract class BaseActivities : IDisposable
    {
        /// <summary>
        /// The common returned class for any methon in any activities.
        /// </summary>
        public ActivityResult ActivityResult;
        public BaseActivities()
        {
            ActivityResult = new ActivityResult();
        }
        public virtual void Dispose()
        {
            if (ActivityResult != null)
                ActivityResult.Reset();
        }
    }
}   
