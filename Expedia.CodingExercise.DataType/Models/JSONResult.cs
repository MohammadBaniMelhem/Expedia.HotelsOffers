using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.CodingExercise.DataType.Models
{
    /// <summary>
    /// The common class for any Ajax call needed in the system.
    /// </summary>
    public class JSONResult
    {
        private bool isPassed;
        public bool IsPassed
        {
            get
            {
                return isPassed;
            }
            set
            {
                isPassed = value;
                if (isPassed)
                {
                    this.Message.Type = ResultMessageType.Success.ToString();
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(this.Message.Text))
                    {
                        this.Message.Text = "Something went wrong!";
                        this.Message.Type = ResultMessageType.Error.ToString();
                    }
                }
            }
        }

        public ResultMessage Message { get; set; }
        public object ReturnedObject { get; set; }
        public string RedirectUrl { get; set; }
        public string CallFunction { get; set; }
        public JSONResult()
        {
            this.Message = new ResultMessage();
        }
        public class ResultMessage
        {
            public string Type { get; set; }
            public string Text { get; set; }
        }

        /// <summary>
        /// This type used to show the message if needed.
        /// </summary>
        public enum ResultMessageType
        {
            None = 0,
            Success = 1,
            Info = 2,
            Warning = 3,
            Error = 4
        }
    }
}
