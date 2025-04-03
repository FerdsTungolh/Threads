using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Threads
{
    public partial class Form1 : Form
    {
        public Random rand = new Random();
        int speed1 = 0;
        int speed2 = 10;
        int interval = 100;
        public int MapLenght = 900;
        bool isRunning = true;
        public Form1()
        {

            InitializeComponent();
            LoadPLayers();
            Background();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public List<Runners> Player = new List<Runners>
       {
           new Runners("Runner 1", 2,42 ,0),
           new Runners("Runner 2", 2,42 ,0),
           new Runners("Runner 3", 2,42 ,0)
       };

        private void Runner1()
        {
            while (isRunning == true)
            {
                int randspeed = rand.Next(speed1, speed2);
                Player[0].Update(interval, MapLenght);
                Thread.Sleep(randspeed);
            }
           
        }
        private void Runner2()
        {
            while (isRunning == true)
            {
                int randspeed = rand.Next(speed1, speed2);
                Player[1].Update(interval, MapLenght);
                Thread.Sleep(randspeed);
            }
        
        }
        private void Runner3()
        {
            while (isRunning == true)
            {
                int randspeed = rand.Next(speed1, speed2);
                Player[2].Update(interval, MapLenght);
                Thread.Sleep(randspeed);
            }
            
        }
        public void UpdateUI()
        {
            pictureBox1.Left = Player[0].Position;
            label1.Left = Player[0].NamePosition;
            pictureBox2.Left = Player[1].Position;
            label2.Left = Player[1].NamePosition;
            pictureBox3.Left = Player[2].Position;
            label3.Left = Player[2].NamePosition;
            Winner();
        }
        public void LoadPLayers()
        {
            label1.Text = Player[0].Name;
            label2.Text = Player[1].Name;
            label3.Text = Player[2].Name;
            this.pictureBox1.Image = Image.FromFile("Assets\\Lambo.png");
            this.pictureBox2.Image = Image.FromFile("Assets\\GTR.png");
            this.pictureBox3.Image = Image.FromFile("Assets\\Supra.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.DoubleBuffered = true;
        }
        public void Background()
        {
            this.BackgroundImage = Image.FromFile("Assets\\Racing Map.jpg");
            this.DoubleBuffered = true;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        public void Winner()
        {
            foreach (Runners rn in Player)
            {
                if (rn.Position >= MapLenght)
                {
                    MessageBox.Show(rn.Name + " is the winner");
                    isRunning = false;
                    System.Environment.Exit(1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread r1 = new Thread(new ThreadStart(Runner1));
            r1.Start();
            Thread r2 = new Thread(new ThreadStart(Runner2));
            r2.Start();
            Thread r3 = new Thread(new ThreadStart(Runner3));
            r3.Start();
            while (true)
            {
                UpdateUI();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);

        }
    }
}
