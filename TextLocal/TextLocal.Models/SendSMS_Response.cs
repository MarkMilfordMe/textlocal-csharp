using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextLocal.Models
{
    public class SendSMS_Response : TextLocal_Base
    {
        public double balance { get; set; }
        public int batch_id { get; set; }
        public double cost { get; set; }
        public int num_messages { get; set; }

        /*
	"message":{
		"num_parts":1,
		"sender":"Jims Autos",
		"content":"This is your message"
	},
	"messages":[{
		"id":"1151346216",
		"recipient":447123456789
    }

	{
		"id":"1151347780",
		"recipient":447987654321
	}],*/
	
    }
}
