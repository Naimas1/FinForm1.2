using NumberGuessingGame;
using System.Drawing;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace RunawayControlApp
{
    public partial class MainForm : Form
    {
        private Label runawayLabel;
        private Action<object, EventArgs> Load;
        private Action<object, MouseEventArgs> MouseMove;
        private const int labelSize = 50;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            this.MouseMove += MainForm_MouseMove;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            runawayLabel = new Label
            {
                Text = "Статик",
                AutoSize = true,
                BackColor = Color.LightBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
            };

            runawayLabel.Location = new Point(this.ClientSize.Width / 2 - labelSize / 2, this.ClientSize.Height / 2 - labelSize / 2);
            this.Controls.Add(runawayLabel);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (runawayLabel.Bounds.Contains(e.Location))
            {
                Random random = new Random();
                int newX = random.Next(0, this.ClientSize.Width - labelSize);
                int newY = random.Next(0, this.ClientSize.Height - labelSize);

                runawayLabel.Location = new Point(newX, newY);
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
