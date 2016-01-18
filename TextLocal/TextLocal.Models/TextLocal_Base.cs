using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLocal.Models
{
    public class TextLocal_Base
    {
        public const string SUCCESS = "success";
        public const string FAILURE = "failure";

        public string status { get; set; }

        public bool IsSuccess {  get
            {
                return status == SUCCESS;
            } }
    }
}
