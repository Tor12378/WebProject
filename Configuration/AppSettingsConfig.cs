using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WebProject.Configuration
{
    public class AppSettingsConfig
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("port")]
        public uint Port { get; set; }

        [JsonProperty("staticFilesPath")]
        public string StaticPathFiles { get; set; }

        [JsonProperty("emailSender")]
        public string EmailSender { get; set; }

        [JsonProperty("passwordSender")]
        public string PasswordSender { get; set; }

        [JsonProperty("fromName")]
        public string FromName { get; set; }

        [JsonProperty("smtpServerHost")]
        public string SmtpServerHost { get; set; }

        [JsonProperty("smtpServerPort")]
        public int SmtpServerPort { get; set; }
    }
}
