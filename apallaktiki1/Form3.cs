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
    public partial class Form3 : Form
    {
        int tick=0;
        string[] name;
        public Form3(string[] names)
        {
            InitializeComponent();
            this.name = names;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (name[0] == null) //αν ο πίνακας είναι άδειος, δεν προβάλλεται τίποτα
            {
                timer1.Stop();
                MessageBox.Show("Not enough pictures");
            }
            else //αλλιώς τις φορτώνει όλες μία μία
                //μόλις φτάσει στο τέλος, ξαναξεκινάει από την αρχή
            {
               


                if (name[tick] == null)
                {
                    pictureBox1.Image = Image.FromFile(name[0]);
                    tick = 0;
                }
                pictureBox1.Image = Image.FromFile(name[tick]);
            }
            tick++;


           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                        
        }
    }
}
