using NumberGuessingGame;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace KeyboardTrainingApp
{
    public partial class MainForm : Form
    {
        private Label generatedTextLabel;
        private TextBox inputTextBox;
        private Button startButton;
        private Button stopButton;
        private bool isShiftPressed;
        private bool isCapsLockActive;

        public MainForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Keyboard Training App";
            this.Size = new System.Drawing.Size(800, 400);

            generatedTextLabel = new Label
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(760, 100),
                TextAlign = ContentAlignment.MiddleCenter
            };

            inputTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 120),
                Size = new System.Drawing.Size(760, 30)
            };

            startButton = new Button
            {
                Location = new System.Drawing.Point(10, 160),
                Size = new System.Drawing.Size(100, 30),
                Text = "Start"
            };

            stopButton = new Button
            {
                Location = new System.Drawing.Point(120, 160),
                Size = new System.Drawing.Size(100, 30),
                Text = "Stop",
                Enabled = false
            };

            startButton.Click += StartButton_Click;
            stopButton.Click += StopButton_Click;
            inputTextBox.KeyDown += InputTextBox_KeyDown;
            inputTextBox.KeyUp += InputTextBox_KeyUp;

            this.Controls.Add(generatedTextLabel);
            this.Controls.Add(inputTextBox);
            this.Controls.Add(startButton);
            this.Controls.Add(stopButton);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            generatedTextLabel.Text = GenerateRandomText();
            startButton.Enabled = false;
            stopButton.Enabled = true;
            inputTextBox.Enabled = true;
            inputTextBox.Focus();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;
            inputTextBox.Enabled = false;
        }

        private string GenerateRandomText()
        {
            // Генеруємо випадковий текст
 
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            isShiftPressed = e.Shift;

            isCapsLockActive = Control.IsKeyLocked(Keys.CapsLock);
у
        }

        private void InputTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            isShiftPressed = e.Shift;
            isCapsLockActive = Control.IsKeyLocked(Keys.CapsLock);
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
