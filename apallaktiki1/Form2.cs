using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apallaktiki1
{
    public partial class Form2 : Form
    {
        int counter;
        string[] name;
        int next = 7;
        bool flag = false;
        public Form2(string[] names, int count)
        {
            InitializeComponent();
            this.counter = count;
            this.name = names;
            //αντιγραφή του μετρητή και του πίνακα με τα paths από την φόρμα 1
            
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        { //φόρτωση εικόνων στα pictureboxes
            //μόνο αριστερή ή μόνο δεξιά προβολή (στα βελάκια -> και <- δηλαδή )
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            if (counter>=0 && counter <= 6)
            {
                if (counter == 6)
                {
                    pictureBox1.Image = Image.FromFile(name[0]);
                    pictureBox2.Image= Image.FromFile(name[1]);
                    pictureBox3.Image= Image.FromFile(name[2]);
                    pictureBox4.Image= Image.FromFile(name[3]);
                    pictureBox5.Image= Image.FromFile(name[4]);
                    pictureBox6.Image= Image.FromFile(name[5]);
                    pictureBox7.Image= Image.FromFile(name[6]);
                }
                else if (counter == 5)
                {
                    pictureBox1.Image = Image.FromFile(name[0]);
                    pictureBox2.Image = Image.FromFile(name[1]);
                    pictureBox3.Image = Image.FromFile(name[2]);
                    pictureBox4.Image = Image.FromFile(name[3]);
                    pictureBox5.Image = Image.FromFile(name[4]);
                    pictureBox6.Image = Image.FromFile(name[5]);
                }
                else if (counter == 4)
                {
                    pictureBox1.Image = Image.FromFile(name[0]);
                    pictureBox2.Image = Image.FromFile(name[1]);
                    pictureBox3.Image = Image.FromFile(name[2]);
                    pictureBox4.Image = Image.FromFile(name[3]);
                    pictureBox5.Image = Image.FromFile(name[4]);
                }
                else if (counter == 3)
                {
                    pictureBox1.Image = Image.FromFile(name[0]);
                    pictureBox2.Image = Image.FromFile(name[1]);
                    pictureBox3.Image = Image.FromFile(name[2]);
                    pictureBox4.Image = Image.FromFile(name[3]);
                }
                else if (counter == 2)
                {
                    pictureBox1.Image = Image.FromFile(name[0]);
                    pictureBox2.Image = Image.FromFile(name[1]);
                    pictureBox3.Image = Image.FromFile(name[2]);

                }
                else if (counter == 1)
                {
                    pictureBox1.Image = Image.FromFile(name[0]);
                    pictureBox2.Image = Image.FromFile(name[1]);
                }
                else if (counter == 0){
                    pictureBox1.Image = Image.FromFile(name[0]);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //εδώ ξεκινά η μαύρη μαγεία
            //αν ο χρήστης έχει δώσει 7 ακριβώς εικόνες, τις κάνει swap αν πατήσουμε το <- ή το ->
            if (counter < 6)
            {
                if (counter == 0) MessageBox.Show("No pictures found...");
                if (counter == 1) { pictureBox1.Image = Image.FromFile(name[1]); pictureBox2.Image = null;counter--; }
                else if (counter == 2) {
                    pictureBox1.Image = Image.FromFile(name[1]);
                    pictureBox2.Image = Image.FromFile(name[2]);
                    name[1] = name[2]; pictureBox3.Image = null; counter--; }
                else if (counter == 3) {
                    pictureBox1.Image = Image.FromFile(name[1]);
                    pictureBox2.Image = Image.FromFile(name[2]);
                    pictureBox3.Image = Image.FromFile(name[3]);
                    name[1] = name[2]; name[2] = name[3];
                    pictureBox4.Image = null; counter--;
                }
                else if (counter == 4) {
                    pictureBox1.Image = Image.FromFile(name[1]);
                    pictureBox2.Image = Image.FromFile(name[2]);
                    pictureBox3.Image = Image.FromFile(name[3]);
                    pictureBox4.Image = Image.FromFile(name[4]);
                    name[1] = name[2]; name[2] = name[3]; name[3] = name[4]; pictureBox5.Image = null; counter--;
                }
                else if (counter == 5) {
                    pictureBox1.Image = Image.FromFile(name[1]);
                    pictureBox2.Image = Image.FromFile(name[2]);
                    pictureBox3.Image = Image.FromFile(name[3]);
                    pictureBox4.Image = Image.FromFile(name[4]);
                    pictureBox5.Image = Image.FromFile(name[5]);
                    name[1] = name[2]; name[2] = name[3]; name[3] = name[4]; name[4] = name[5]; pictureBox6.Image = null; counter--;
                }

            }
            else if (counter == 6)
            {
                string temp = name[6];
                name[6] = name[5];
                name[5] = name[4];
                name[4] = name[3];
                name[3] = name[2];
                name[2] = name[1];
                name[1] = name[0];
                name[0] = temp;
                pictureBox1.Image = Image.FromFile(name[0]);
                pictureBox2.Image = Image.FromFile(name[1]);
                pictureBox3.Image = Image.FromFile(name[2]);
                pictureBox4.Image = Image.FromFile(name[3]);
                pictureBox5.Image = Image.FromFile(name[4]);
                pictureBox6.Image = Image.FromFile(name[5]);
                pictureBox7.Image = Image.FromFile(name[6]);
            }
            else if (counter > 6)
            { 
                next++;
                if (name[next - 6] != null && name[next] != null)
                {
                 pictureBox1.Image = Image.FromFile(name[next - 6]);
                 pictureBox2.Image = Image.FromFile(name[next - 5]);
                 pictureBox3.Image = Image.FromFile(name[next - 4]);
                 pictureBox4.Image = Image.FromFile(name[next - 3]);
                 pictureBox5.Image = Image.FromFile(name[next - 2]);
                 pictureBox6.Image = Image.FromFile(name[next - 1]);
                 pictureBox7.Image = Image.FromFile(name[next]);
                }
                else if (name[next-6] == null)
                {

                    pictureBox1.Image = null;
                    pictureBox2.Image = Image.FromFile(name[next - 6]);
                    pictureBox3.Image = Image.FromFile(name[next - 5]);
                    pictureBox4.Image = Image.FromFile(name[next - 4]);
                    pictureBox5.Image = Image.FromFile(name[next - 3]);
                    pictureBox6.Image = Image.FromFile(name[next - 2]);
                    pictureBox7.Image = Image.FromFile(name[next-1]);
                    counter = 5;
                }
                else if (name[next] == null)
                {
                    MessageBox.Show("No pictures found...");
                }
             }
                }

        private void button1_Click(object sender, EventArgs e)
        {
            if (counter < 6)
            {
                MessageBox.Show("No pictures found...");
                
            }
            if (counter == 6)
            {
                if (flag == true)
                {
                pictureBox1.Image = Image.FromFile(name[0]); 
                pictureBox2.Image = Image.FromFile(name[1]); 
                pictureBox3.Image = Image.FromFile(name[2]); 
                pictureBox4.Image = Image.FromFile(name[3]); 
                pictureBox5.Image = Image.FromFile(name[4]); 
                pictureBox6.Image = Image.FromFile(name[5]); 
                pictureBox7.Image = Image.FromFile(name[6]);
                    counter = 5;
                }
                string temp = name[0];
                name[0] = name[1];
                name[1] = name[2];
                name[2] = name[3];
                name[3] = name[4];
                name[4] = name[5];
                name[5] = name[6];
                name[6] = temp;
                pictureBox1.Image = Image.FromFile(name[0]); 
                pictureBox2.Image = Image.FromFile(name[1]); 
                pictureBox3.Image = Image.FromFile(name[2]); 
                pictureBox4.Image = Image.FromFile(name[3]); 
                pictureBox5.Image = Image.FromFile(name[4]); 
                pictureBox6.Image = Image.FromFile(name[5]); 
                pictureBox7.Image = Image.FromFile(name[6]); 

            }
            else if (counter > 6)
            {
                next--;
                flag = true;
                if (name[next - 6] != null && name[next] != null)
                {
                    
                    pictureBox1.Image = Image.FromFile(name[next - 6]);
                    pictureBox2.Image = Image.FromFile(name[next - 5]);
                    pictureBox3.Image = Image.FromFile(name[next - 4]);
                    pictureBox4.Image = Image.FromFile(name[next - 3]);
                    pictureBox5.Image = Image.FromFile(name[next - 2]);
                    pictureBox6.Image = Image.FromFile(name[next - 1]);
                    pictureBox7.Image = Image.FromFile(name[next]);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
