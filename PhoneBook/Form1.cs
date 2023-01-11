using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> phoneBook;

        public Form1()
        {
            InitializeComponent();

            this.phoneBook = new Dictionary<string, string>();

            ReadFromFile();


            //this.phoneBook.Add("山田壱郎", "xxx-3456-4343");
            //this.phoneBook.Add("山田弐郎", "xxx-8823-9434");
            //this.phoneBook.Add("山田参郎", "xxx-7793-2117");
            //this.phoneBook.Add("山田師郎", "xxx-1693-7364");

            foreach (KeyValuePair<string, string> data in phoneBook)
            {
                this.nameList.Items.Add(data.Key);
            }

        }

        private void ReadFromFile()
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\data.txt"))
            {
                while (!file.EndOfStream)
                {
                    string line = file.ReadLine();
                    string[] data = line.Split(',');
                    this.phoneBook.Add(data[0], data[1]);
                }
            }
        }

        private void NameSelected(object sender, EventArgs e)
        {
            string name = this.nameList.Text;
            this.phoneNumber.Text = this.phoneBook[name];
        }
    }
}
