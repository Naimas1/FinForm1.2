using NumberGuessingGame;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace ColorButtonsApp
{
    public partial class MainForm : Form
    {
        private string[] colors = { "Navy", "Blue", "Aqua", "Teal", "Olive", "Green", "Lime", "Yellow", "Orange", "Red", "Maroon", "Fuchsia", "Purple", "Black", "Silver", "Gray", "White" };
        private const int buttonWidth = 100;
        private const int buttonHeight = 50;
        private const int buttonMargin = 2;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int totalColors = colors.Length;
            int buttonsPerRow = (totalColors + 2) / 3;

            for (int i = 0; i < totalColors; i++)
            {
                Button colorButton = new Button
                {
                    Text = colors[i],
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Location = new Point((i % buttonsPerRow) * (buttonWidth + buttonMargin),
                                         (i / buttonsPerRow) * (buttonHeight + buttonMargin)),
                    BackColor = Color.FromName(colors[i]),
                    ForeColor = Color.FromName(colors[i]),
                    Margin = new Padding(2)
                };

                this.Controls.Add(colorButton);
            }

            int formWidth = buttonsPerRow * (buttonWidth + buttonMargin);
            int formHeight = ((totalColors + buttonsPerRow - 1) / buttonsPerRow) * (buttonHeight + buttonMargin);
            this.ClientSize = new Size(formWidth, formHeight);
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
