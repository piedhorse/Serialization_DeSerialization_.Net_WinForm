using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net;

namespace GorselProgOdev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string strPersonelData;           
        public const string motif = @"/^0[.\(\/]5[0-9][0-9][.\)\/][.\ \/][1-9]([0-9]){2}[.\-\/]([0-9]){4}$/";

        public static class PhoneNumber
        {

            public static bool IsPhoneNbr(string number)
            {
                if (number != null) return Regex.IsMatch(number, motif);
                else return false;
            }
        }

        EmailAddressAttribute foo = new EmailAddressAttribute();
        bool bar;
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox2.Text == "")
            {

                MessageBox.Show("Boş Alan Hatası");


            }
           else if (bar = foo.IsValid(textBox2.Text.ToString()) == false || Regex.Match(textBox4.Text.ToString(), motif).Success==true)
            {
                MessageBox.Show("Telefon numarani ve E posta adresini dogru giriniz!!!");
            }
            else
            {
            Personel yeni_Personel = new Personel()
            {
                Adi = textBox1.Text,
                Soyadi = textBox5.Text,
                Telefon = textBox4.Text,
                Mail_Adres = textBox2.Text
            };
              strPersonelData = SerializeObject(yeni_Personel);
              txt_xml_cikti.Text = strPersonelData;

                MessageBox.Show("Serialization islemi gerceklesti !!!!");
            }

            
            
           
            
        
        
        
        }

        private string SerializeObject(Personel PersObject)
        {
            XmlSerializer MySerializer = new XmlSerializer(typeof(Personel));
            TextWriter TW = new StringWriter();
            MySerializer.Serialize(TW, PersObject);
            Temizle();
            return TW.ToString();
        }
        void Temizle()
        {
            textBox1.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeserializeXml(strPersonelData);
        }
        private void DeserializeXml(string XmlData)
        {
            XmlSerializer MyDeserializer = new XmlSerializer(typeof(Personel));
            StringReader SR = new StringReader(XmlData);
            XmlReader XR = new XmlTextReader(SR);
            if (MyDeserializer.CanDeserialize(XR))
            {
                Personel GelenBilgiler = (Personel)MyDeserializer.Deserialize(XR);
               // ShowEmployeeData(GelenBilgiler);
                txt_xml_cikti.Text = "";
            }
        }
        private void PersonelGoster(Personel PersonelObject)
        {
            textBox1.Text = PersonelObject.Adi;
            textBox5.Text = PersonelObject.Soyadi;
            textBox4.Text = PersonelObject.Telefon;
            textBox2.Text = PersonelObject.Mail_Adres;
        }

     
    }
}
