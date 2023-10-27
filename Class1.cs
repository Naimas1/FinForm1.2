using EO.Base.UI;
using NumberGuessingGame;
using System.Drawing;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace RectangleCreationApp
{
    public partial class MainForm : Form
    {
        private int rectangleCounter = 0;
        private Rectangle selectedRectangle = null;
        private Point initialPoint;

        public MainForm()
        {
            InitializeComponent();
            this.MouseDown += MainForm_MouseDown;
            this.MouseUp += MainForm_MouseUp;
            this.MouseDoubleClick += MainForm_MouseDoubleClick;
            this.Paint += MainForm_Paint;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                initialPoint = e.Location;
                selectedRectangle = null;
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int width = e.X - initialPoint.X;
                int height = e.Y - initialPoint.Y;

                if (Math.Abs(width) >= 10 && Math.Abs(height) >= 10)
                {
                    rectangleCounter++;
                    Rectangle newRectangle = new Rectangle(initialPoint.X, initialPoint.Y, width, height);
                    Controls.Add(new Label
                    {
                        Location = initialPoint,
                        Size = new Size(Math.Abs(width), Math.Abs(height)),
                        Text = rectangleCounter.ToString(),
                        BorderStyle = BorderStyle.FixedSingle,
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.LightBlue,
                    });
                }
                else
                {
                    MessageBox.Show("Розмір прямокутника повинен бути не менше 10x10.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control controlToRemove = null;
                foreach (Control control in Controls)
                {
                    if (control is Label label && label.ClientRectangle.Contains(e.Location))
                    {
                        if (controlToRemove == null || int.Parse(label.Text) < int.Parse(controlToRemove.Text))
                        {
                            controlToRemove = label;
                        }
                    }
                }
                if (controlToRemove != null)
                {
                    Controls.Remove(controlToRemove);
                }
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is Label label)
                {
                    e.Graphics.DrawRectangle(Pens.Black, label.Left - 1, label.Top - 1, label.Width + 1, label.Height + 1);
                }
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
