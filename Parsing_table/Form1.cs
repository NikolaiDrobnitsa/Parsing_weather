using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.IO;

namespace Parsing_table
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            using (WebClient client = new WebClient())
            {
                client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/b/d400.jpg", "d400.jpg");
                client.DownloadFile("https://sinoptik.ua/%D0%BF%D0%BE%D0%B3%D0%BE%D0%B4%D0%B0-%D0%B4%D0%BD%D0%B5%D0%BF%D1%80-303007131", "file.html");
                client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/s/n420.gif", "n420.gif");
                client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/s/n320.gif", "n320.gif");
                client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/s/d400.gif", "n400.gif");
                client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/s/d300.gif", "n300.gif");
                client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/s/n100.gif", "n100.gif");
            }
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            
            //htmlDoc.Load("file.html");
            htmlDoc.Load("file.html", Encoding.UTF8);
            pictureBox1.BackgroundImage = Image.FromFile("d400.jpg");
            pictureBox2.BackgroundImage = Image.FromFile("termometr.PNG");
            HtmlNode htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='today-time']");
            label1.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='today-temp']");
            label2.Text = htmlNode.InnerText.Replace("deg;", "");
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='infoDaylight']");
            label3.Text = htmlNode.InnerText;
            //htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='p1  ']");
            //label9.Text = htmlNode.InnerText;
            foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//tr[@class='gray time']"))
            {
                label9.Text = link.InnerText.Replace(" ", " ");
            }
            foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//tr[@class='temperature']"))
            {
                label10.Text = link.InnerText.Replace("deg;", "° ");
            }
            foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//tr[@class='temperatureSens']"))
            {
                label11.Text = link.InnerText.Replace("deg;", "°   ");
            }
            foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//tr[contains(@class,'gray')][2]"))
            {
                label12.Text = link.InnerText.Replace(" ", "     ");
            }
            foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//tr[6]"))
            {
                label18.Text = link.InnerText.Replace(" ", "       ");
            }
            foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//tr[@class='gray']"))
            {
                label19.Text = link.InnerText.Replace(" ", "  ");
            }
            foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//tr"))
            {
                label20.Text = link.InnerText.Replace(" ", "          ");
            }
            pictureBox3.BackgroundImage = Image.FromFile("n420.gif");
            pictureBox4.BackgroundImage = Image.FromFile("n420.gif");
            pictureBox5.BackgroundImage = Image.FromFile("n320.gif");
            pictureBox6.BackgroundImage = Image.FromFile("n400.gif");
            pictureBox7.BackgroundImage = Image.FromFile("n300.gif");
            pictureBox8.BackgroundImage = Image.FromFile("n400.gif");
            pictureBox9.BackgroundImage = Image.FromFile("n400.gif");
            pictureBox10.BackgroundImage = Image.FromFile("n100.gif");



        }


    }
}
