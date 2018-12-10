using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulatedCaffe;
using System.Windows;

namespace CaffeSimulation
{
    public partial class Form1 : Form
    {
        public int l = 0;
        public int i = 10;
        public int count =0;
        public int t;
        public Bitmap bmp; //Здесь рисуем
        public List<Rectangle> R = new List<Rectangle>();
        public List<People> peoplelist = new List<People>();
        public List<CustomerInPlace> peoplelistIT = new List<CustomerInPlace>();
        public CustomerFactory customerFact = new CustomerFactory();
        public List<Rectangle> Ellipse = new List<Rectangle>();
        public Random rng = new Random();
        public List<Table> tableList = new List<Table>();
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            //   textBox1.Text = peoplelist[0].name;
            timer1.Start(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics G = Graphics.FromImage(bmp); pictureBox1.Image = bmp;
    
             G.DrawEllipse(new Pen(Color.Black), Cursor.Position.X-5,Cursor.Position.Y-30, 40, 40);
            tableList.Add(new Table(t,Cursor.Position.X-5, Cursor.Position.Y-30));
            t++;
            for (int i = 0; i < tableList.Count(); i++)
            {
                textBox1.Text = tableList[i].Free.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            Pen pencil = new Pen(Color.Blue, 1f);
            i=i+4;
            Graphics G = Graphics.FromImage(bmp); pictureBox1.Image = bmp;
            for (int p=0;p<peoplelist.Count;p++)
            {
                peoplelistIT.Add((CustomerInPlace)peoplelist[p]);

            }
            for (int p = 0; p < peoplelistIT.Count; p++)
            {

                    peoplelistIT[p].MoveToTarget(peoplelistIT[p].Target.PositionX, peoplelistIT[p].Target.PositionY);
      
                    peoplelistIT[p].MoveToTarget(peoplelistIT[p].Target.PositionX, peoplelistIT[p].Target.PositionY);
                
            }
            for (int j = 0; j < peoplelist.Count; j++)
            {

                G.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                R.Add(new Rectangle(peoplelistIT[j].positionX, peoplelistIT[j].positionY, 20, 20));
                for (int k = 0; k < R.Count; k++)
                {
                    G.DrawRectangle(pencil, R[k]);
                }
            }
            for (int j = 0; j < tableList.Count; j++)
            {
                Ellipse.Add(new Rectangle(tableList[j].PositionX, tableList[j].PositionY,20,20));
                for (int k = 0; k < Ellipse.Count; k++)
                {
                    G.DrawEllipse(pencil, Ellipse[k]);
                }
            }
            R.Clear();
            Ellipse.Clear();
            peoplelistIT.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            l++;
            CustomerInPlace cust = (CustomerInPlace)customerFact.CreatePeople("first", 200, 100 - l);
            cust.budget = rng.Next(100, 1000);
            for (int i = 0; i < tableList.Count(); i++)
            {
                tableList[i] = cust.FindFreeTable(tableList[i]);
            }
            peoplelist.Add(cust);
            textBox1.Text = cust.Target.Number.ToString() + cust.budget.ToString() ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
