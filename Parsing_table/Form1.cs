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
            HtmlNode image;
            String srcUrl;
            using (WebClient client = new WebClient())
            {
                //client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/b/d400.jpg", "d400.jpg");
                client.DownloadFile("https://sinoptik.ua/%D0%BF%D0%BE%D0%B3%D0%BE%D0%B4%D0%B0-%D0%B4%D0%BD%D0%B5%D0%BF%D1%80-303007131", "file.html");
                //client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/s/n420.gif", "n420.gif");
                //client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/s/n320.gif", "n320.gif");
                //client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/s/d400.gif", "n400.gif");
                //client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/s/d300.gif", "n300.gif");
                //client.DownloadFile("https://sinst.fwdcdn.com/img/weatherImg/s/n100.gif", "n100.gif");
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
            //tring srcUrl = image.Attributes["src"].XPath.ToString();
            //HtmlNode image = htmlDoc.DocumentNode.SelectSingleNode("//tr[@class='img weatherIcoS']//td[@class='p1  ']//div[@class='weatherIco n300']//img[@class'weatherImg'/@src]");
            //HtmlNode image = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='weatherIco n300']//img[@src]");
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[2]/td[1]/div[1]/img[1]/@src[1]");
            srcUrl = image.Attributes["src"].Value.ToString();
            pictureBox3.Load("https:"+srcUrl);
            
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[2]/td[2]/div[1]/img[1]/@src[1]");
            pictureBox4.Load("https:" + image.Attributes["src"].Value.ToString());
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[2]/td[3]/div[1]/img[1]/@src[1]");
            pictureBox5.Load("https:" + image.Attributes["src"].Value.ToString());
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[2]/td[4]/div[1]/img[1]/@src[1]");
            pictureBox6.Load("https:" + image.Attributes["src"].Value.ToString());
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[2]/td[5]/div[1]/img[1]/@src[1]");
            pictureBox7.Load("https:" + image.Attributes["src"].Value.ToString());
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[2]/td[6]/div[1]/img[1]/@src[1]");
            pictureBox8.Load("https:" + image.Attributes["src"].Value.ToString());
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[2]/td[7]/div[1]/img[1]/@src[1]");
            pictureBox9.Load("https:" + image.Attributes["src"].Value.ToString());
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[2]/td[8]/div[1]/img[1]/@src[1]");
            pictureBox10.Load("https:" + image.Attributes["src"].Value.ToString());

            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='description']");
            label21.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[3]/div[2]/div[1]");
            label22.Text = htmlNode.InnerText;
            //image = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='rSide']//div[@class='description']//h2");
            //srcUrl = image.XPath.ToString();
            //textBox1.Text += srcUrl;
            //foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//p[@class='infoHistory']"))
            //{
            //    label23.Text = link.InnerText;
            //}
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='infoHistory']");
            label23.Text = htmlNode.InnerText;

        }


    }
}
