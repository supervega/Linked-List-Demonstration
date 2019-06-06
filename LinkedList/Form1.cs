using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LinkedList
{
    public partial class Form1 : Form
    {

        public list li;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            li = new list();
        }

        private void appendPre_Click(object sender, EventArgs e)
        {
            li.append(new element(Convert.ToInt32((ValuetxtBox.Text)), NametxtBox.Text));
            label4.Text = Write();
        }

        public string Write()
        {
            string s = "List Element(s):\n";
            for (element p = li.head; p != null; p = p.Next)
                s += string.Format("Element Value: {0},String: {1}\n", p.num, p.name);
            return s;
        }

        private void Prependbtn_Click(object sender, EventArgs e)
        {
            li.prepend(new element(Convert.ToInt32((ValuetxtBox.Text)), NametxtBox.Text));
            label4.Text = Write();
        }

        private void Insertbtn_Click(object sender, EventArgs e)
        {
            li.InsertOrder(new element(Convert.ToInt32((ValuetxtBox.Text)), NametxtBox.Text));
            label4.Text = Write();
        }

        private void FindIndexbtn_Click(object sender, EventArgs e)
        {
            element p = li.FindAtIndex((int)numericUpDown1.Value);
            if (p == null)
            {
                MessageBox.Show("no element was found in this location !", "missing element");
                return;
            }
            MessageBox.Show((string.Format("Element at index{0}\nhas the value {1}& string {2}", (int)numericUpDown1.Value, p.num, p.name)));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s = li.FindAtElement(new element((int)numericUpDown2.Value, FindtxtBox.Text));
            if (s == -1)
            {
                MessageBox.Show("no element was found  !", "missing element");
                return;
            }
            MessageBox.Show("element was found in {0}location of the List", s.ToString());
        }

        private void DeleteAllbtn_Click(object sender, EventArgs e)
        {
            if (li.DeleteAll(int.Parse(DeletetxtBox.Text)))
            {
                MessageBox.Show("One or more Elements was deleted");
                label4.Text = Write();
            }
            else
                MessageBox.Show("No Element was deleted!!");
        }

        private void Reverse_Click(object sender, EventArgs e)
        {
            li.Reverse();
            label4.Text = Write();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (li.DeleteElement(new element((int)numericUpDown3.Value, Deleteindex.Text)))
            {
                MessageBox.Show("no element was found  !", "missing element");
                label4.Text = Write();
                return;
            }
            MessageBox.Show("No Corresponding Element to delete !!");
        }
    }
}