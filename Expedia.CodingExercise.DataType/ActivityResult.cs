using Expedia.CodingExercise.DataType.Models;
using Expedia.CodingExercise.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Expedia.CodingExercise.DataType.Models.JSONResult;

namespace Expedia.CodingExercise.DataType
{
    /// <summary>
    /// The main and common class for all the activities calls and methods
    /// </summary>
    public class ActivityResult
    {
        private bool isPassed;
        public bool IsPassed
        {
            get { return isPassed; }
            set
            {
                isPassed = value;
                if (isPassed)
                    Code = eResponseCode.Success;
                else if (Code == eResponseCode.Success || Code == eResponseCode.Unassigned)
                {
                    Code = eResponseCode.General_Error;
                }
            }
        }
        public eResponseCode Code { get; set; }
        public object ReturnedObject { get; set; }

        public ActivityResult()
        {
            Reset();
        }
        public void Reset()
        {
            Code = eResponseCode.Unassigned;
            ReturnedObject = null;
            IsPassed = false;
        }

        public  JSONResult ToJSONResult()
        {
            JSONResult JSONResult = new JSONResult();
            JSONResult.IsPassed = this.IsPassed;
            JSONResult.ReturnedObject = this.ReturnedObject;
            JSONResult.Message.Text = this.Code.Message();
            JSONResult.Message.Type = JSONResult.IsPassed ? ResultMessageType.Success.ToString() : ResultMessageType.Warning.ToString();

            return JSONResult;
        }
    }
}
