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

namespace StudentsDiary
{
    public partial class Main : Form
    {
        public Main()//konstruktor
        {
            InitializeComponent();

            var path = $@"{ Path.GetDirectoryName(Application.ExecutablePath)}\..\NowyPlik2.txt";

            //if (!File.Exists(path))
            //{
            //    //System.IO.File.Create("C:\\Users\BONDEX1\\source\\repos\\StudentsDiary\\StudentsDiary"); // dwa slesze albo @ przed slashem
            //    File.Create(path);
            //}
            //File.Delete(path);

            //File.WriteAllText(path, "Zostań Programistą . NET");
            File.AppendAllText(path, "Zostań Programistą . NET");


            var text = File.ReadAllText(path);

            MessageBox.Show(text);

            MessageBox.Show("Test", "TYTUŁ", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Error);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
