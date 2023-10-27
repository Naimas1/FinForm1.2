using NumberGuessingGame;
using System.Drawing;
using System.Reflection.Emit;

namespace RunawayButtonsApp
{
    public partial class MainForm : Form
    {
        private Button yesButton;
        private Button noButton;
        private Label questionLabel;
        private Random random;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            random = new Random();

            yesButton = new Button
            {
                Text = "Да",
                Location = new Point(100, 50),
                Size = new Size(75, 30)
            };
            yesButton.MouseMove += Button_MouseMove;
            yesButton.Click += YesButton_Click;

            noButton = new Button
            {
                Text = "Нет",
                Location = new Point(200, 50),
                Size = new Size(75, 30)
            };
            noButton.MouseMove += Button_MouseMove;

            questionLabel = new Label
            {
                Text = "Вы довольны своей зарплатой?",
                Location = new Point(100, 100),
                AutoSize = true
            };

            this.Controls.Add(yesButton);
            this.Controls.Add(noButton);
            this.Controls.Add(questionLabel);
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            int newX = random.Next(0, this.ClientSize.Width - button.Width);
            int newY = random.Next(0, this.ClientSize.Height - button.Height);
            button.Location = new Point(newX, newY);
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ви вдовольні своєю зарплатою!");


