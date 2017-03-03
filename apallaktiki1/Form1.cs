using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace apallaktiki1
{
    public partial class Form1 : Form
    {
        string[] names;
        string[] contents;
        int count = -1;
        string  description;
        string fileToOpen;
        FirstClass obj2 = new FirstClass();
        SecondClass obj1 = new SecondClass();
        public Form1()
        {
            InitializeComponent();
            names = new string[1000];
            contents = new string[1000];
            for (int i = 0; i < 1000; i++)
            {
                contents[i] = ""; //αρχικοποίηση πίνακα περιεχομένων
            }

        }

        Image Zoom(Image img, Size size)
        {
            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp; 
        }
        Image Zoomout(Image img, Size size)
        {
            Bitmap bmp = new Bitmap(img, img.Width - (img.Width * size.Width / 100), img.Height - (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileToOpen = FD.FileName;
            }
            count++;
            names[count] = fileToOpen;//τοποθέτηση path αρχειου στον πίνακα names
            if (FD.FileName != null && FD.FileName != "") pictureBox1.Image = Image.FromFile(FD.FileName);//βάλε στο picturebox την εικόνα από το αρχείο που επιλέχθηκε
            else MessageBox.Show("You didn't pick an image...");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //για να μετονομάσουμε ένα αρχείο, "αντιγράφουμε" το παλιό σε νέο path, και κατόπιν διαγράφουμε το παλιό
            string neo = textBox1.Text; 
             if (fileToOpen.Contains("jpg"))
               {
            
                neo = neo + ".jpg";
                pictureBox1.Image.Save(neo);
                pictureBox1.Image.Dispose();// (παλιού) αρχείου για να μπορεί να τη διαγράψει το πρόγραμμα
                pictureBox1.Image = Image.FromFile(neo); //μετονομασμένο αρχείο στο picturebox
                for (int i = 0; i < 1000; i++)
                {//αναζήτηση του αρχείου που μετονομάσαμε, για να αλλάξουμε το path στον πίνακα
                    if (fileToOpen == names[i])
                    {
                        names[i] = neo;
                        break;
                    }
                }
                
                FileInfo file = new FileInfo(fileToOpen); //αρχείο που έχει ως όνομα το path της εικόνας
                File.Delete(file.ToString()); //διαγραφή της εικόνας πριν την μετονομασία, αφήνουμε μόνο το καινούριο
            }
            else if (fileToOpen.Contains("png"))
            { //ομοίως με jpg, βλέπε if 
                neo = neo + ".png";
                pictureBox1.Image.Save(neo);
                pictureBox1.Image.Dispose();
                pictureBox1.Image = Image.FromFile(neo);
                for (int i = 0; i < names.Length; i++)
                {
                    if (fileToOpen == names[i])
                    {
                        names[i] = neo;
                        break;
                    }
                }
                
                FileInfo file = new FileInfo(fileToOpen);
                File.Delete(file.ToString());
               
            }
            fileToOpen = neo;
            neo = "";
         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int extra2 = 0;
            if (extra2 == 0)
            {//στροφή 90 μοιρών της εικόνας
                pictureBox1.Image.RotateFlip((RotateFlipType.Rotate90FlipY));
                pictureBox1.Refresh();
                extra2++;
            }
            if (extra2 == 1)
            {
                pictureBox1.Image.RotateFlip((RotateFlipType.Rotate180FlipY));
                pictureBox1.Refresh();
                extra2++;
            }
            if (extra2 == 2)
            {
                pictureBox1.Image.RotateFlip((RotateFlipType.Rotate270FlipY));
                pictureBox1.Refresh();
                extra2++;
            }
            if (extra2 == 3)
            {
                extra2 = 0; //βάζω το έξτρα = 0 για να αποφύγω να πάρει πολύ μεγάλο αριθμό μετά απο πολλά 
                //κλικ και να έχουμε υπερχείληση
                pictureBox1.Image.RotateFlip((RotateFlipType.Rotate90FlipY));
                pictureBox1.Refresh();
                extra2++;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Refresh(); //για να αλλάξει απευθείας το ταίριασμα της εικόνας, χωρίς να χρειαστεί να πατήσουμε 
            //κάτι άλλο
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Refresh();
        }

        private void RotateLeft_Click(object sender, EventArgs e)
        { //ομοίως με rotate right
            int extra = 0;
            if (extra == 0){
                pictureBox1.Image.RotateFlip((RotateFlipType.Rotate90FlipX));
                pictureBox1.Refresh();
                extra++;
            }
            if (extra == 1)
            {
                pictureBox1.Image.RotateFlip((RotateFlipType.Rotate270FlipX));
                pictureBox1.Refresh();
                extra++;
            }
            if (extra == 2)
            {
                pictureBox1.Image.RotateFlip((RotateFlipType.Rotate180FlipX));
                pictureBox1.Refresh(); extra++;
            }
            if (extra == 3)
            {
                extra = 0;
                pictureBox1.Image.RotateFlip((RotateFlipType.Rotate90FlipX));
                pictureBox1.Refresh();
                extra++;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap sepiaEffect = (Bitmap)pictureBox1.Image.Clone();
            
            pictureBox1.Image = obj1.make_sepia(sepiaEffect); //δημιουργία νέου αντικειμένου obj1, για να κάνουμε
            //σέπια τη φωτογραφία
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            description = textBox2.Text; //τοποθέτηση περιγραφής στις εικόνες
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == fileToOpen)
                {
                    contents[i] = description; //τοποθέτηση περιγραφής στο κελί που πρέπει
                    description = "";
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                if ( names[i] == fileToOpen) //εύρεση της εικόνας που προβάλλεται στον πίνακα names
                    //προβολή του αντίστοιχου κελιού του πίνακα contents
                {
                    MessageBox.Show(contents[i]);
                }
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (names[0] != null)
            {
                for (int i = 0; i < 1000; i++)
                {//εύρεση και προβολή της προηγούμενης εικόνας που φορτώθηκε απο αυτή που προβάλλεται
                 //βασισμένη σε αναζήτηση στον πίνακα με τα paths των εικόνων
                    if (fileToOpen == names[i])
                    {
                        if (i - 1 == -1)
                        {
                            if (names[0] == null) MessageBox.Show("No picture found");
                            pictureBox1.Image = Image.FromFile(names[count]);
                            fileToOpen = names[count];
                            break;
                        }
                        if (names[i - 1] != null)
                        {
                            if (names[i - 1] != null)
                            {
                                pictureBox1.Image = Image.FromFile(names[i - 1]);
                                fileToOpen = names[i - 1];
                                break;
                            }
                            else
                            {
                                pictureBox1.Image = Image.FromFile(names[0]);
                                fileToOpen = names[0];
                                break;
                            }
                        }


                    }
                }
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {//ομοίως με την previous
            if (names[0] != null)
            {
                for (int i = 0; i < 1000; i++)
                {
                    if (fileToOpen == names[i])
                    {
                        if (names[i + 1] != null)
                        {
                            pictureBox1.Image = Image.FromFile(names[i + 1]);
                            fileToOpen = names[i + 1];
                            break;
                        }
                        else
                        {
                            if (names[0] == null) MessageBox.Show("No picture found");
                            pictureBox1.Image = Image.FromFile(names[0]);
                            fileToOpen = names[0];
                            break;
                        }
                    }

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form f3 = new Form3(names);
            f3.Show();
            //εμφάνιση της φόρμας 3
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2(names, count);
            f2.Show();
            //εμφάνιση της φόρμας 2
        }

        private void seeDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button9_Click(sender,e);
        }

        private void moreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button11_Click(sender, e);
        }

        private void slideshowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button10_Click(sender, e);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Value > 0) //ζουμ +
            {
                pictureBox1.Image = Zoom(Image.FromFile(fileToOpen), new Size(trackBar2.Value, trackBar2.Value));
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value > 0) //ζουμ -
            {
                pictureBox1.Image = Zoomout(Image.FromFile(fileToOpen), new Size(trackBar1.Value, trackBar1.Value));
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Bitmap grayEffect = (Bitmap)pictureBox1.Image.Clone();//κάνει κλώνο της εικόνας που προβάλλεται
            obj2.make_bw(grayEffect);//την κάνει ασπρόμαυρη
            pictureBox1.Image =obj2.make_bw(grayEffect);
            pictureBox1.Refresh(); //αλλάζει τηην εικόνα που προβάλλεται στο picturebox
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Unipi students 2017");
        }
    }
}

public class FirstClass 
{
    public Bitmap make_bw(Bitmap original){
            Bitmap output = new Bitmap(original.Width, original.Height);
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color c = original.GetPixel(i, j);
                    int average = ((c.R + c.B + c.G) / 3); //εύρεση μέσης τιμής των τιμών των χρωμάτων red, green,black
                //στο εκάστοτε πίξελ
                    if (average < 200)
                        output.SetPixel(i, j, Color.Black); // αν ΜΟ<200, κάνε το μαύρο, αλλιώς άσπρο
                    else
                        output.SetPixel(i, j, Color.White);
                }
            }
            return output;
            }
}

public class SecondClass 
{
    public Bitmap make_sepia(Bitmap original2)
    {
       Bitmap sepiaEffect = (Bitmap)original2.Clone();

        for (int yCoordinate = 0; yCoordinate < sepiaEffect.Height; yCoordinate++)
        {
            for (int xCoordinate = 0; xCoordinate < sepiaEffect.Width; xCoordinate++)
            {
                Color color = sepiaEffect.GetPixel(xCoordinate, yCoordinate);
                double grayColor = ((double)(color.R + color.G + color.B)) / 3.0d; //εύρεση μέσου όρου χρωμάτων R,G,B
                Color sepia = Color.FromArgb((byte)grayColor, (byte)(grayColor * 0.95), (byte)(grayColor * 0.82));//δημιουργία sepia
                sepiaEffect.SetPixel(xCoordinate, yCoordinate, sepia); //αλλαγή χρώματος πίξελ-πίξελ
            }
        }
        return sepiaEffect;
    }
}