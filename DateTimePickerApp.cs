using NumberGuessingGame;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace DateTimePickerApp
{
    public partial class MainForm : Form
    {
        private DateTimePicker dateTimePicker;
        private Button openCalendarButton;
        private Label selectedDateLabel;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dateTimePicker = new DateTimePicker
            {
                Location = new System.Drawing.Point(20, 20),
                Format = DateTimePickerFormat.Short,
                Width = 100,
            };

            openCalendarButton = new Button
            {
                Text = "Вибрати дату",
                Location = new System.Drawing.Point(140, 20),
            };
            openCalendarButton.Click += OpenCalendarButton_Click;

            selectedDateLabel = new Label
            {
                Text = "Вибрана дата: ",
                Location = new System.Drawing.Point(20, 60),
                AutoSize = true,
            };

            this.Controls.Add(dateTimePicker);
            this.Controls.Add(openCalendarButton);
            this.Controls.Add(selectedDateLabel);
        }

        private void OpenCalendarButton_Click(object sender, EventArgs e)
        {
            dateTimePicker.Visible = true;
            dateTimePicker.Focus();
            dateTimePicker.CloseUp += DateTimePicker_CloseUp;
        }

        private void DateTimePicker_CloseUp(object sender, EventArgs e)
        {
            selectedDateLabel.Text = "Вибрана дата: " + dateTimePicker.Text;
            dateTimePicker.Visible = false;
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

