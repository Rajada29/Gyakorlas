using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;

namespace Csibészkutyák
{
    public partial class Form1 : Form
    {
        string[] paths;
        static List<kutyanevek> adatok = new List<kutyanevek>();
        static List<kutyafajtak> adatok1 = new List<kutyafajtak>();
        static List<kutyak> adatok2 = new List<kutyak>();
        public Form1()
        {

            InitializeComponent();
            
            
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. Feladat
            richTextBox1.Text += "Kutyanevek száma: " + adatok.Count().ToString() + "\n";

            

           

   

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //2. Feladat
            double eletkorossz = 0;
            double eletkoratlag = 0;

            foreach (var item in adatok2)
            {
                eletkorossz += item.age;
            }
            eletkoratlag = Math.Round(eletkorossz / adatok2.Count(), 2);
            richTextBox1.Text += "Az átlag életkor : " + eletkoratlag.ToString() + "\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //3.Feladat
            int kor = 0;
            int legidosebbid = 0;
            foreach (var item in adatok2)
            {
                if (item.age > kor)
                {
                    kor = item.age;
                    legidosebbid = item.id;
                }
            }
            richTextBox1.Text += "A legidősebb kutya neve, és fajtája : ";
            foreach (var item in adatok)
            {
                if (legidosebbid == item.id)
                {
                    richTextBox1.Text += item.name + ", ";
                }
            }
            foreach (var item in adatok1)
            {
                if (legidosebbid == item.id)
                {
                    richTextBox1.Text += item.name + "\n";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //4.Feladat
            List<int> kutyaid = new List<int>();
            Dictionary<string, int> mydictionary = new Dictionary<string, int>();

            foreach (var item in adatok2)
            {
                if (item.ellenorzes == "2018.01.10")
                {
                    kutyaid.Add(item.id);
                }
            }
            foreach (var item in kutyaid)
            {
                foreach (var item1 in adatok1)
                {
                    if (item == item1.id)
                    {
                        if (mydictionary.ContainsKey(item1.name))
                        {
                            mydictionary[item1.name]++;
                        }
                        else
                        {
                            mydictionary.Add(item1.name, 1);
                        }
                    }
                }
            }
            foreach (var item in mydictionary)
            {
                richTextBox1.Text += item.Key + " : " + item.Value + "\n";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //5.feladat
            Dictionary<string, int> mydictionary2 = new Dictionary<string, int>();
            foreach (var item in adatok2)
            {
                if (mydictionary2.ContainsKey(item.ellenorzes))
                {
                    mydictionary2[item.ellenorzes]++;
                }
                else
                {
                    mydictionary2.Add(item.ellenorzes, 1);
                }

            }
            int legtobb = 0;
            string legtobbnap = string.Empty;
            foreach (var item in mydictionary2)
            {
                if (item.Value > legtobb)
                {
                    legtobb = item.Value;
                    legtobbnap = item.Key + ", " + item.Value.ToString();
                }


            }
            richTextBox1.Text += legtobbnap;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> nevek = new Dictionary<string, int>();
            foreach (var item in adatok2)
            {
                foreach (var item1 in adatok)
                {
                    if (item.nev_id == item1.id)
                    {
                        if (nevek.ContainsKey(item1.name))
                        {
                            nevek[item1.name]++;
                        }
                        else
                        {
                            nevek.Add(item1.name, 1);
                        }
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter("névstatisztika.txt"))
            {
                int szam = 6;
                for (int i = 0; i < 7; i++)
                {

                
                foreach (var item in nevek)
                {
                    if (item.Value == szam)
                    {
                        sw.WriteLine(item.Key + ": " + item.Value);
                    }

                }
                    szam--;
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            paths = openFileDialog1.FileNames;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            foreach (var item in paths)
            {
                if (item.Contains("KutyaNevek"))
                {
                    var arr = File.ReadAllLines(item);
                    foreach (var item1 in arr.Skip(1))
                    {
                        adatok.Add(new kutyanevek(item1));
                    }
                }
                else if (item.Contains("KutyaFajtak"))
                {
                    var arr1 = File.ReadAllLines(item);
                    foreach (var item1 in arr1.Skip(1))
                    {
                        adatok1.Add(new kutyafajtak(item1));
                    }
                }
                else
                {
                    var arr2 = File.ReadAllLines(item);
                    foreach (var item1 in arr2.Skip(1))
                    {
                        adatok2.Add(new kutyak(item1));
                    }
                }
            }
        }
    }
}
