using NumberGuessingGame;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace KeyboardTrainingApp
{
    public partial class MainForm : Form
    {
        private Label statsLabel;
        private TrackBar difficultySlider;
        private Label inputLabel;
        private Random random = new Random();
        private string generatedText;
        private int errorCount = 0;
        private int charIndex = 0;
        private DateTime startTime;

        public MainForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Keyboard Training App";
            this.Size = new System.Drawing.Size(800, 400);

            statsLabel = new Label
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(300, 30),
                Text = "Скорость: 0 зн/мин, Ошибок: 0",
                TextAlign = ContentAlignment.MiddleLeft
            };

            difficultySlider = new TrackBar
            {
                Location = new System.Drawing.Point(320, 10),
                Size = new System.Drawing.Size(300, 30),
                Minimum = 1,
                Maximum = 10,
                Value = 5
            };

            difficultySlider.Scroll += DifficultySlider_Scroll;

            inputLabel = new Label
            {
                Location = new System.Drawing.Point(10, 50),
                Size = new System.Drawing.Size(760, 100),
                TextAlign = ContentAlignment.MiddleCenter
            };

            GenerateText();

            this.Controls.Add(statsLabel);
            this.Controls.Add(difficultySlider);
            this.Controls.Add(inputLabel);

            UpdateStats();
        }

        private void DifficultySlider_Scroll(object sender, EventArgs e)
        {
            GenerateText();
        }

        private void GenerateText()
        {
            int length = difficultySlider.Value * 10;
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            char[] text = new char[length];
            for (int i = 0; i < length; i++)
            {
                text[i] = chars[random.Next(chars.Length)];
            }
            generatedText = new string(text);
            inputLabel.Text = generatedText;
            charIndex = 0;
            errorCount = 0;
            startTime = DateTime.Now;
            UpdateStats();
        }

        private void UpdateStats()
        {
            double elapsedTime = (DateTime.Now - startTime).TotalMinutes;
            double errorRate = errorCount / elapsedTime;
            int wordsPerMinute = (int)((charIndex / 5) / elapsedTime);
            statsLabel.Text = $"Скорость: {wordsPerMinute} зн/мин, Ошибок: {errorCount}, Ошибок/мин: {errorRate:F2}";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys)generatedText[charIndex])
            {
                charIndex++;
                if (charIndex == generatedText.Length)
                {
                    GenerateText();
                }
            }
            else
            {
                errorCount++;
            }

            UpdateStats();
            return base.ProcessCmdKey(ref msg, keyData);
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
