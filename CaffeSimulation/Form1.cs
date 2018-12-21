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
        public int peopleCounter;
        public int staffCounter;
        public int Timer;
        public int targetX = 1;
        public int targetY = 1;
        public int starttargetX = 0;
        public int starttargetY = 0;
        public Bitmap bmp; //Здесь рисуем
        public List<Rectangle> R = new List<Rectangle>();
        public List<People> peoplelist = new List<People>();
        public List<Waiter> staffList = new List<Waiter>();
        public List<CustomerInPlace> peoplelistIT = new List<CustomerInPlace>();
        public CustomerFactory customerFact = new CustomerFactory();
        public StaffFactory staffFactory = new StaffFactory();
        public List<Rectangle> Ellipse = new List<Rectangle>();
        public Random rng = new Random();
        public List<Rectangle> staff = new List<Rectangle>();
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
            
            staffCounter++;
            Graphics G = Graphics.FromImage(bmp); pictureBox1.Image = bmp;
             G.DrawEllipse(new Pen(Color.Black), Cursor.Position.X-5,Cursor.Position.Y-30, 40, 40);
            Table table = new Table(t, Cursor.Position.X - 5, Cursor.Position.Y - 30);
            tableList.Add(table);
            Waiter staff = (Waiter)staffFactory.CreatePeople(staffCounter.ToString(), table.PositionX-10, table.PositionY-10,new StateWaiter());
            staff.state = new WaiterPending();
            staff.workSpace = table;
            staffList.Add(staff);
            G.DrawEllipse(new Pen(Color.Red), table.PositionX, table.PositionY, 50, 50);
            t++;
            for (int i = 0; i < tableList.Count(); i++)
            {
                textBox1.Text = tableList[i].Free.ToString();
            }
        }
        bool first = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
            richTextBox2.Text = " ";
            richTextBox3.Text = " ";
            textBox1.Text = " ";
            Pen pencil = new Pen(Color.Blue, 1f);
            i=i+4;
            Graphics G = Graphics.FromImage(bmp); pictureBox1.Image = bmp;
            for (int p=0;p<peoplelist.Count;p++)
            {
                peoplelistIT.Add((CustomerInPlace)peoplelist[p]);
                richTextBox1.Text+= peoplelist[p].name + peoplelistIT[p].state+"\n";

            }
            for (int p = 0; p < tableList.Count; p++)
            {
                richTextBox2.Text += "Table №" + tableList[p].Number.ToString() + "\n";

            }
            for (int p = 0; p < tableList.Count; p++)
            {
                if (staffList[p].positionX <= 5 && staffList[p].positionY <= 150)
                {
                    staffList[p].targetPosX  = staffList[p].workSpace.PositionX;
                    staffList[p].targetPosY = staffList[p].workSpace.PositionY;
                }
                else if (staffList[p].positionX == staffList[p].workSpace.PositionX && staffList[p].positionY == staffList[p].workSpace.PositionY)
                {
                    staffList[p].state = new WaiterPending();
                    staffList[p].targetPosX = 5;
                    staffList[p].targetPosY = 150;
                }
                richTextBox3.Text += "Waiter on Table №" + staffList[p].name.ToString() + staffList[p].state.ToString()+ "\n";
                richTextBox3.Text += staffList[p].positionX + " " + staffList[p].positionY + " " + starttargetX +" " + starttargetY + " " + targetX + " " + targetY + " " + staffList[p].state.ToString() ;

                if (staffList[p].state.ToString() == "SimulatedCaffe.TransferOrder" )
                {
                    G.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    staffList[p].MoveToTarget(staffList[p].targetPosX, staffList[p].targetPosY);

                   
                }

            }
            for (int p = 0; p < peoplelistIT.Count; p++)
            {
                People people = null;
                Waiter waiter = null;
                if (p < peoplelist.Count())
                {
                    people = peoplelist[p];
                    waiter = staffList[p];
                }
                if (people!=null)
                {
                    
                    
                        if (peoplelistIT[p].state.ToString() != "SimulatedCaffe.Leaving")
                        {

                            peoplelistIT[p].MoveToTarget(peoplelistIT[p].Target.PositionX, peoplelistIT[p].Target.PositionY);
                        }
                        textBox1.Text = peoplelistIT[p].name.ToString() + " " + peoplelistIT[p].state.ToString();
                        if (peoplelistIT[p].Target.PositionX == peoplelistIT[p].positionX && peoplelistIT[p].Target.PositionY == peoplelistIT[p].positionY && people.state.ToString() == "SimulatedCaffe.NewComer")
                        {
                            
                            peoplelistIT[p].state = new Ordering();
                            textBox1.Text = peoplelistIT[p].name.ToString() + " " + peoplelistIT[p].state.ToString();

                        };



                        if (people.state.ToString() == "SimulatedCaffe.Ordering" && people.state.ToString() != "SimulatedCaffe.Pending" && people.state.ToString() != "SimulatedCaffe.Eating")
                        {
                            Timer++;
                            if (Timer > 70)
                            {

                                Dialogue dialogue = new Dialogue();

                                dialogue.GetOrder(ref waiter, ref people);
                                peoplelistIT[p].Target.customer = peoplelistIT[p];
                                peoplelist[p] = people;
                                staffList[p] = waiter ;
                                textBox1.Text = peoplelistIT[p].name + " " + peoplelistIT[p].state.ToString();
                            }

                        }
                    if (people.state.ToString() == "SimulatedCaffe.Pending")
                    {

                        if (waiter.positionX == waiter.workSpace.PositionX)
                        {
                       
                                Dialogue dialogue = new Dialogue();
                                dialogue.PickUpOrder(ref waiter, ref people);
                                peoplelist[p] = people;
                                staffList[p] = waiter;
                                textBox1.Text = peoplelistIT[p].name + " " + peoplelistIT[p].state.ToString();
                             Timer = 0 ;

                        }
                    }
                        if (people.state.ToString() == "SimulatedCaffe.Eating")
                        {
                           Timer+=1;
                        textBox2.Text = " ";
                        textBox2.Text = peoplelistIT[p].name + " " + peoplelistIT[p].state.ToString() + " " + Timer;
                        if (Timer > peoplelistIT[p].EatTime)
                            {
                                Dialogue dialogue = new Dialogue();
                            dialogue.LeaveOrder(ref waiter, ref people);
                            peoplelist[p] = people;
                            staffList[p] = waiter;
                            //  peoplelist.RemoveAt(p);
                            peoplelistIT[p].Target.Free = true;
                                G.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                                textBox2.Text = peoplelistIT[p].name + " " + peoplelistIT[p].state.ToString() +" " + peoplelistIT[p].Timer;
                            }

                        }
                        if (people.state.ToString() == "SimulatedCaffe.Leaving")
                        {
                            Timer++;

                            Dialogue dialogue = new Dialogue();
                            people.MoveToTarget(10, 10);
                            if (peoplelist[p].positionX == 10 && peoplelist[p].positionY == 10)
                            {
                                peoplelist.RemoveAt(p);

                            }
                            G.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                            textBox1.Text = peoplelistIT[p].name + " " + peoplelistIT[p].state.ToString();




                        }
                    }

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
                    G.DrawRectangle(new Pen(Color.Green), new Rectangle(0, 0, 20, 50));
                    G.DrawRectangle(new Pen(Color.Brown), new Rectangle(5, 150, 20, 50));
                }
            }
            for (int j = 0; j < staffList.Count; j++)
            {
                staff.Add(new Rectangle(staffList[j].positionX, staffList[j].positionY, 40, 40));
                for (int k = 0; k < staff.Count; k++)
                {
                    G.DrawRectangle(new Pen(Color.Red), staff[k]);
                }
            }
            R.Clear();
            Ellipse.Clear();
            staff.Clear();
            peoplelistIT.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            l++;
            peopleCounter++;
            CustomerInPlace cust = (CustomerInPlace)customerFact.CreatePeople(peopleCounter.ToString(), 0, 0,new StateCustInPlace());
            cust.budget = rng.Next(100, 1000);
            cust.MakeOrdering();
            for (int i = 0; i < tableList.Count(); i++)
            {
                tableList[i] = cust.FindFreeTable(tableList[i]);
            }
            if (peoplelist.Count+1 <= tableList.Count())
            {
                peoplelist.Add(cust);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
