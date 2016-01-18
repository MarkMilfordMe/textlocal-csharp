using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLocal.Models
{
    public class SendSMS_Parameters 
    {
        
        /// <summary>
        /// Use this field to specify the sender name for your message. This must be at least 3 characters in length but no longer than 11 alphanumeric characters or 13 numeric characters.
        /// </summary>
        public string sender { get; set; }

        /// <summary>
        /// The message content. This parameter should be no longer than 766 characters. 
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// list of mobile numbers in international format (i.e. 447123456789).
        /// </summary>
        public List<string> numbers { get; set; }

        /// <summary>
        /// Use this field to specify an alternative URL to which the delivery receipt(s) will be sent.
        /// </summary>
        public string receipt_url { get; set; }

        /// <summary>
        /// Set this field to true to enable test mode, no messages will be sent and your credit balance will be unaffected. If not provided defaults to false
        /// </summary>
        public bool test { get; set; }

        /// <summary>
        /// This value will be set against the message batch and will passed back in the delivery receipts. This allows you to match delivery receipts to their corresponding messages.
        /// </summary>
        public string custom { get; set; }
    }
}
