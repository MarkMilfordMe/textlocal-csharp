using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLocal.Models
{
    public enum TextLocalErrorCodes
    {
        NoRecipientsSpecified=4,
        NoMessageContent = 5,
        MessageToLong = 6,
        InsufficientCredits = 7,
        InvalidScheduleDate = 8,
        ScheduleDateIsInThePast = 9,
        InvalidGroupID = 10,
        SelectedGroupIsEmpty = 11,
        InvalidNumberFormat = 32,
        YouHaveSuppliedTooManyNumbers = 33,
        InvalidSenderName = 43,
        NoSenderNameSpecified = 44,
        NoValidNumbersSpecified = 51
    }
    public class TextLocalException : Exception
    {
     
        public TextLocalException(List<TextLocal_Error> errs)
        {
            Errors = errs;
        }
        public List<TextLocal_Error> Errors { get; set; }
        public override string Message
        {
            get
            {
                return string.Join("\n", Errors.Select(f => f.message).ToArray());
            }
        }
    }

    public class TextLocal_ErrorCollection : TextLocal_Base
    {
        public List<TextLocal_Error> errors { get; set; }
    }

    public class TextLocal_Error
    {
        public int code { get; set; }
        public string message { get; set; }
        
    }
}
