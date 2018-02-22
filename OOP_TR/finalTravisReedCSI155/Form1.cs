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
using System.Media;


namespace finalTravisReedCSI155
{
    public partial class Form1 : Form
    {
        Random rand = new Random();

        

        //In Form1, create a SortedDictionary collection to hold Person objects.
//In Form1_Load, using phone as a unique identifier, Add 12 Person objects to the sortedDictionary
//2.	Providen a ListView and a button to display all the Person objects in the sortedDictionary

    
        SortedDictionary<string, Person> personSortedDictionary = new SortedDictionary<string, Person>();

        ListView LVI = new ListView();
        //--------------------------------------------------------

        //4.	Define a delegate type that returns an  int and take a parameter of type Person

        public delegate int MyPersonAge(int x);

        MyPersonAge pa1;
        

        private int Age(int x)
        {
            return x;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("mike and quinn");
            Console.ReadLine();

           
        }

        //------------------------------------------------------------------

        string[] firstNames = { "Rick", "Jake", "Crissy", "Jen", "Amy", "Jarrod", "Jamie", "Dee", "Scott", "Mel", "Tasha", "Dihante", "Niailla" };
        string[] lastNames = { "Jones", "Claud", "Myers", "Willan", "Hoit", "Wilkins", "Reed", "Akins", "Romero", "Beth", "Massey", "Oshan", "Coe"};
        string[] phoneNumber = { "4253660882", "4254960882", "4253660082", "4253940882", "4253660012", "4253643882", "4253660884", "4253660800", 
                                   "4253660886", "4253660822", "4253660833", "4253660844" };

        string[] animals = { "Canari", "Elephant", "Lion", "Tiger", "Vulcture", "Whale", "Zebra" };
        
        public Form1()
        {
            InitializeComponent();
            MyLVI();
            PopComboBox();
            pa1 = new MyPersonAge(Age);
            
        }
        
      
        private void MyLVI()
        {
            LVI.Bounds = new Rectangle(new Point(10, 10), new Size(580, 300));
            LVI.View = View.Details;
            LVI.AllowColumnReorder = true;
            LVI.FullRowSelect = true;
            LVI.GridLines = true;
            LVI.Columns.Add("Phone Number", 100, HorizontalAlignment.Left);
            LVI.Columns.Add("First Name", 120, HorizontalAlignment.Left);
            LVI.Columns.Add("Last Name", 120, HorizontalAlignment.Left);
            LVI.Columns.Add("Date Of Birth", 240, HorizontalAlignment.Left);
            LVI.BackColor = SystemColors.Info;
            this.Controls.Add(LVI);
        }
        private void Display(Person ps)
        {
            ListViewItem lvi = new ListViewItem(ps.Phone);
            lvi.SubItems.Add(ps.Firstname);
            lvi.SubItems.Add(ps.Lastname);
            lvi.SubItems.Add(ps.DateOfBirth.ToLongDateString());
            lvi.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            LVI.Items.Add(lvi);

        }
        private Person GetRandomPerson()
        {
            string pNumber = phoneNumber[rand.Next(0, 12)]; 
            string fname = firstNames[rand.Next(0, 12)];
            string lname = lastNames[rand.Next(0, 12)];
            int year = rand.Next(1955,1994);
            int month = rand.Next(1, 13);
            int day = rand.Next(1, 29);
            DateTime dateOfBirth = new DateTime(year, month, day);


            return new Person(pNumber, fname, lname, dateOfBirth);

        }
        private void DisplayPersons()
        {
            LVI.Items.Clear();
            foreach (KeyValuePair<string, Person> kvp in personSortedDictionary)
            {
                string key = kvp.Key;
                Person em = kvp.Value;
                Display(em);
            }


        }

       // 3.	Provide a textbox to enter the phone number of a person, then get the person with the given phone number. 
        //Display the person if found in a messagebox, otherwise display no such person with the given phone number.
        private void button1_Click(object sender, EventArgs e)
        {
            string emplyeeID = textBox1.Text;

           Person em;
            if (personSortedDictionary.TryGetValue(emplyeeID, out em))
            {
                MessageBox.Show(String.Format("{0} {1,-20} {2,-15}", em.Firstname, em.Lastname, em.Phone));
            }
            else
                MessageBox.Show("Person number not found");
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
             for (int i = 1; i <= 100; i++)
            {
                try
                { 
                    Person ps = GetRandomPerson();


                    personSortedDictionary.Add(ps.Phone, ps);
                }
                catch (ArgumentException ae) { }  
            }
            
            
        }
        private void PopComboBox()
        {
            foreach (string ani in animals)
            {
                comboBox2.Items.Add(ani);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetRandomPerson();
            DisplayPersons();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (comboBox2.SelectedIndex == 0)
            {
                CanariSound();
                pictureBox1.ImageLocation = "Canari.jpg";
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                ElephantSound();
                pictureBox1.ImageLocation = "Elephant.jpg";
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                LionSound();
                pictureBox1.ImageLocation = "Lion.jpg";
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                TigerSound();
                pictureBox1.ImageLocation = "Tiger.jpg";
            }
            else if (comboBox2.SelectedIndex == 4)
            {
                VulctureSound();
                pictureBox1.ImageLocation = "Vulture.jpg";
            }
            else if (comboBox2.SelectedIndex == 5)
            {
                WhaleSound();
                pictureBox1.ImageLocation = "Whale.jpg";
            }
            else if (comboBox2.SelectedIndex == 6)
            {
                ZebraSound();
                pictureBox1.ImageLocation = "Zebra.jpg";
            }

        }

        private void CanariSound()
        {
            SoundPlayer sp = new SoundPlayer("canary.wav");
            sp.PlaySync();
        }
        private void ElephantSound()
        {
            SoundPlayer sp = new SoundPlayer("elephant.wav");
            sp.PlaySync();
        }
        private void LionSound()
        {
            //used tiger sound because i couldnt get the lion one to work...
            SoundPlayer sp = new SoundPlayer("tiger.wav");
            sp.PlaySync();
            //-------------------------------------------------------------
        }
        private void TigerSound()
        {
            SoundPlayer sp = new SoundPlayer("tiger.wav");
            sp.PlaySync();
        }
        private void VulctureSound()
        {
            SoundPlayer sp = new SoundPlayer("vulture.wav");
            sp.PlaySync();
        }
        private void WhaleSound()
        {
            SoundPlayer sp = new SoundPlayer("whale.wav");
            sp.PlaySync();
        }
        private void ZebraSound()
        {
            SoundPlayer sp = new SoundPlayer("zebra5.wav");
            sp.PlaySync();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
