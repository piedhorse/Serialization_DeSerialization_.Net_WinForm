using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GorselProgOdev
{
    public class Personel
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Mail_Adres { get; set; }
    }
}
