using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PlanetarySystem.Planetary;

namespace PlanetarySystem.UserInterface
{
    public partial class UserInterface : Form
    {
        private const int SLEEP_BETWEEN_TICKS = 50;
        private const String LBL_TITLE_INFO_PANEL = "Time";
        private const String LBL_SINGLE_TICK = "Tick";
        private const String LBL_STOP_AUTO_TICK = "Stop auto Tick";
        private const String LBL_START_AUTO_TICK = "Start auto Tick";
        private static bool _tick = true;
        private static bool _auto;
        private readonly PSController _controller = new PSController();

        private double _cx;
        private double _cy;
        private double _planetWidth;
        private double _zoom;

        public UserInterface()
        {
            InitializeComponent();
        }

        public void PaintPlanets(Graphics g)
        {
            DrawPlanets(g);
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {
            button1.Text = LBL_SINGLE_TICK;
            button2.Text = LBL_START_AUTO_TICK;

            _controller.MakeSolarSystem();
            _planetWidth = 3;
            _cx = 350.0;
            _cy = 350.0;
            _zoom = 7.0;
            BackColor = Color.Black;
            Width = 800;
            Height = 800;

            var newThread = new Thread(Run);
            newThread.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            PaintPlanets(g);
        }

        public void Run()
        {
            while (true)
            {
                if (_tick)
                {
                    BeginInvoke((MethodInvoker) delegate
                                                    {
                                                        _controller.Tick();
                                                        Refresh();
                                                    });
                    if (!_auto)
                    {
                        _tick = false;
                    }
                }

                try
                {
                    Thread.Sleep(SLEEP_BETWEEN_TICKS);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void DrawPlanets(Graphics g)
        {
            for (int i = 0; i < _controller.GetPlanetarySystem().Size(); i++)
            {
                DrawPlanet(g, i);
            }
        }

        public void DrawPlanet(Graphics g, int planetID)
        {
            var a = new Pen(Color.Red);
            double x = _controller.GetPlanetarySystem().GetElement(planetID).GetX();
            double y = _controller.GetPlanetarySystem().GetElement(planetID).GetY();
            double[] newCoordinates = ConvCoords(x, y);
            g.DrawEllipse(a, (int) newCoordinates[0], (int) newCoordinates[1], (int) _planetWidth, (int) _planetWidth);
        }

        public double[] ConvCoords(double x, double y)
        {
            double x0 = (_cx + x*_zoom);
            double y0 = (_cy + y*_zoom);
            double x1 = x0 + _planetWidth;
            double y1 = y0 + _planetWidth;
            return new[]
                       {
                           x0, y0, x1, y1
                       };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _auto = false;
            _tick = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_auto)
            {
                _auto = false;
                _tick = true;
                button2.Text = LBL_START_AUTO_TICK;
            }
            else
            {
                _auto = true;
                _tick = true;
                button2.Text = LBL_STOP_AUTO_TICK;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}