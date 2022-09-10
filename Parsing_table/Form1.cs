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
                client.DownloadFile("https://sinoptik.ua/%D0%BF%D0%BE%D0%B3%D0%BE%D0%B4%D0%B0-%D0%B4%D0%BD%D0%B5%D0%BF%D1%80-303007131", "file.html");
            }
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            var pos = this.PointToScreen(label2.Location);
            pos = pictureBox1.PointToClient(pos);
            label2.Parent = pictureBox1;
            label2.Location = pos;
            label2.BackColor = Color.Transparent;
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


            ////find XPATH
            //image = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][2]//div[@class='weatherIco d200']");
            //srcUrl = image.XPath.ToString();
            //textBox1.Text += srcUrl;

            //foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//p[@class='infoHistory']"))
            //{
            //    label23.Text = link.InnerText;
            //}
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='infoHistory']");
            label23.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='infoHistoryval']");
            label25.Text = htmlNode.InnerText.Replace("deg;", "° ");
            pictureBox11.BackgroundImage = Image.FromFile("termometr.PNG");
            //label2.Parent = pictureBox1;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='main loaded']//p[@class='day-link']");
            label24.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='main loaded']//p[@class='date dateFree']");
            label26.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='main loaded']//p[@class='month']");
            label27.Text = htmlNode.InnerText;
            image = htmlDoc.DocumentNode.SelectSingleNode("html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/img[1]/@src[1]");
            pictureBox12.Load("https:" + image.Attributes["src"].Value.ToString());
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='main loaded']//div[@class='temperature']//div[@class='min']");
            label28.Text = htmlNode.InnerText.Replace("deg;", "° ");
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='main loaded']//div[@class='temperature']//div[@class='max']");
            label29.Text = htmlNode.InnerText.Replace("deg;", "° ");

            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='cityName cityNameShort']//h1");
            label30.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='cityName cityNameShort']//div[@class='currentRegion']");
            label31.Text = htmlNode.InnerText;

            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main ']//p//a[@class='day-link']");
            label34.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main ']//p[@class='date dateFree']");
            label35.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main ']//p[@class='month']");
            label36.Text = htmlNode.InnerText;
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/img[1]/@src[1]");
            pictureBox13.Load("https:" + image.Attributes["src"].Value.ToString());
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main ']//div[@class='temperature']//div[@class='min']");
            label32.Text = htmlNode.InnerText.Replace("deg;", "° "); ;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main ']//div[@class='temperature']//div[@class='max']");
            label33.Text = htmlNode.InnerText.Replace("deg;", "° "); ;

            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][2]//p//a[@class='day-link']");
            label39.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][2]//p[@class='date ']");
            label40.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][2]//p[@class='month']");
            label41.Text = htmlNode.InnerText;
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/img[1]/@src[1]");
            pictureBox14.Load("https:" + image.Attributes["src"].Value.ToString());
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][2]//div[@class='temperature']//div[@class='min']");
            label37.Text = htmlNode.InnerText.Replace("deg;", "° "); ;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][2]//div[@class='temperature']//div[@class='max']");
            label38.Text = htmlNode.InnerText.Replace("deg;", "° "); ;

            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][3]//p//a[@class='day-link']");
            label44.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][3]//p[@class='date ']");
            label45.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][3]//p[@class='month']");
            label46.Text = htmlNode.InnerText;
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/div[8]/div[1]/img[1]/@src[1]");
            pictureBox15.Load("https:" + image.Attributes["src"].Value.ToString());
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][3]//div[@class='temperature']//div[@class='min']");
            label42.Text = htmlNode.InnerText.Replace("deg;", "° "); ;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][3]//div[@class='temperature']//div[@class='max']");
            label43.Text = htmlNode.InnerText.Replace("deg;", "° "); ;

            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][4]//p//a[@class='day-link']");
            label49.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][4]//p[@class='date ']");
            label50.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][4]//p[@class='month']");
            label51.Text = htmlNode.InnerText;
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/div[10]/div[1]/img[1]/@src[1]");
            pictureBox16.Load("https:" + image.Attributes["src"].Value.ToString());
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][4]//div[@class='temperature']//div[@class='min']");
            label47.Text = htmlNode.InnerText.Replace("deg;", "° "); ;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][4]//div[@class='temperature']//div[@class='max']");
            label48.Text = htmlNode.InnerText.Replace("deg;", "° "); ;

            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][5]//p//a[@class='day-link']");
            label54.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][5]//p[@class='date ']");
            label55.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][5]//p[@class='month']");
            label56.Text = htmlNode.InnerText;
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/div[12]/div[1]/img[1]/@src[1]");
            pictureBox17.Load("https:" + image.Attributes["src"].Value.ToString());
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][5]//div[@class='temperature']//div[@class='min']");
            label52.Text = htmlNode.InnerText.Replace("deg;", "° "); ;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][5]//div[@class='temperature']//div[@class='max']");
            label53.Text = htmlNode.InnerText.Replace("deg;", "° "); ;

            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][6]//p//a[@class='day-link']");
            label59.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][6]//p[@class='date ']");
            label60.Text = htmlNode.InnerText;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][6]//p[@class='month']");
            label61.Text = htmlNode.InnerText;
            image = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/div[14]/div[1]/img[1]/@src[1]");
            pictureBox18.Load("https:" + image.Attributes["src"].Value.ToString());
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][6]//div[@class='temperature']//div[@class='min']");
            label57.Text = htmlNode.InnerText.Replace("deg;", "° "); ;
            htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='tabs']//div[@class='main '][6]//div[@class='temperature']//div[@class='max']");
            label58.Text = htmlNode.InnerText.Replace("deg;", "° "); ;





        }


    }
}
