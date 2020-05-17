using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slot_Machine_01
{
    public partial class Form1 : Form
    {
        //Declaring Constants
        const int MAX_ITEMS = 8;
        const int MAX_SLOTS = 3;

        PictureBox[] pictureBoxs = new PictureBox[MAX_SLOTS];

        public Form1()
        {
            InitializeComponent();

            //Declaring Picture Boxes            
            pictureBoxs[0] = pictureBox1;
            pictureBoxs[1] = pictureBox2;
            pictureBoxs[2] = pictureBox3;
        }

        //Declaring initial values
        public static long credits = 100;
        public static long total = 0;
        public static int bet = 5;
        public static int winValue = 0;

        //Declaring slot values
        public static int[] slots = new int[MAX_SLOTS];

        //Delay function
        async Task UseDelay()
        {
            await Task.Delay(3000); // wait for 1 second
        }

        //Random Number Generation

        // Generate a random number between two numbers  for slots
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        //Generate random values for slots
        public void RandomSlots()
        {
            slots[0] = RandomNumber(1, MAX_ITEMS);
            for (int i = 1; i < MAX_SLOTS; i += 1)
            {
                slots[i] = RandomNumber(1,MAX_ITEMS);
                if (slots[i] == slots[i - 1])
                {
                    slots[i] += 1;
                }
            }
        }

        //Image Link to Value
        public string SlotImage(int image_value)
        {
            switch (image_value)
            {
                case 1:
                    return "apple.jpg";                  

                case 2:
                    return "banana.jpg";

                case 3:
                    return "bar.jpg";

                case 4:
                    return "cherry.jpg";

                case 5:
                    return "grape.jpg";

                case 6:
                    return "lemon.jpg";

                case 7:
                    return "melon.jpg";

                case 8:
                    return "pear.jpg";

                default:
                    return "apple.jpg";
            }
        }

        //Set Images for slots
        public void SetImages()
        {
            for (int i = 0; i < MAX_SLOTS; i = i + 1)
            {
                pictureBoxs[i].Image.Dispose();
                pictureBoxs[i].Image = Image.FromFile(SlotImage(slots[i]));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("1.jpg");
            pictureBox2.Image = Image.FromFile("2.jpg");
            pictureBox3.Image = Image.FromFile("3.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Change to animation          
            for (int i = 0; i < MAX_SLOTS; i += 1)
            {
                pictureBoxs[i].Image.Dispose();
                pictureBoxs[i].Image = Image.FromFile("animation.gif");
            }

            //Randomize Slots
            RandomSlots();
            label5.Text = slots[0] + "," + slots[1] + "," + slots[2];

            //Generate win value
            winValue = RandomNumber(1, 100);

        }

        
    }
}
