using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextLocal.Models;
using System.Net;
using System.Collections.Specialized;

namespace TextLocal
{
    public class TextLocalConnector
    {
        private TextLocal_Authentication _auth;

        #region Constructors
        public TextLocalConnector(TextLocal_Authentication auth)
        {
            _auth = auth;
        }

        public TextLocalConnector(string apiKey)
        {
            _auth = new TextLocal_Authentication(apiKey);
        }

        public TextLocalConnector(string username, string hash)
        {
            _auth = new TextLocal_Authentication(username, hash);
        }
        #endregion

        private NameValueCollection CreateCollectionWithAuthentication()
        {
            NameValueCollection Parameters = new NameValueCollection();
            if (string.IsNullOrEmpty(_auth.apiKey))
            {
                Parameters.Add("username", _auth.username);
                Parameters.Add("hash", _auth.hash);
            }
            else
                Parameters.Add("apiKey", _auth.apiKey);
            return Parameters;
        }

        private T DecodeResponse<T>(string response) where T:TextLocal_Base {
            TextLocal_Base baseResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TextLocal_Base>(response);
            if(!baseResponse.IsSuccess)
            {
               
                TextLocal_ErrorCollection er = Newtonsoft.Json.JsonConvert.DeserializeObject<TextLocal_ErrorCollection>(response);
                throw new TextLocalException(er.errors);
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
        }

        #region SendSMS
        public SendSMS_Response SendSMS(SendSMS_Parameters opts)
        {
            using (WebClient wb = new WebClient())
            {
                wb.Encoding = System.Text.Encoding.UTF8;

                NameValueCollection Parameters = CreateCollectionWithAuthentication();

                Parameters.Add("numbers", string.Join(",",opts.numbers.ToArray()));
                Parameters.Add("message", opts.message);
                Parameters.Add("sender", opts.sender);
                if (!string.IsNullOrEmpty(opts.receipt_url))
                    Parameters.Add("receipt_url", opts.receipt_url);
                Parameters.Add("unicode", "true");
                if (opts.test)
                    Parameters.Add("test", "true");

                byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", Parameters);
                string result = System.Text.Encoding.UTF8.GetString(response);
               
                return DecodeResponse<SendSMS_Response>(result);
            }
        }
        public SendSMS_Response SendSMS_Response(string sender, string message, List<string> numbers, string receipt_url, bool test=false)
        {
            return SendSMS(new SendSMS_Parameters() { message = message, sender = sender, numbers = numbers, receipt_url = receipt_url, test = test });
        }
        #endregion
    }
}
