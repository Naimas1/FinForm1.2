using NumberGuessingGame;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace CountdownTimerApp
{
    public partial class MainForm : Form
    {
        private DateTime targetDate;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Label titleLabel = new Label
            {
                Text = "Введіть дату:",
                Location = new System.Drawing.Point(20, 20),
            };

            DateTimePicker dateTimePicker = new DateTimePicker
            {
                Location = new System.Drawing.Point(150, 20),
                Format = DateTimePickerFormat.Short,
                Width = 100,
                MaxDate = DateTime.Now.AddYears(10),
                ShowUpDown = true,
                CustomFormat = "dd.MM.yyyy",
                CalendarTitleBackColor = System.Drawing.Color.LightGray
                // Календар можна налаштувати для виводу російською мовою.
            };

            GroupBox unitGroupBox = new GroupBox
            {
                Text = "Одиниці вимірювання:",
                Location = new System.Drawing.Point(20, 60),
                Width = 230,
            };

            RadioButton yearsRadioButton = new RadioButton
            {
                Text = "Роки",
                Location = new System.Drawing.Point(10, 20),
                Checked = true,
            };

            RadioButton monthsRadioButton = new RadioButton
            {
                Text = "Місяці",
                Location = new System.Drawing.Point(10, 40),
            };

            RadioButton daysRadioButton = new RadioButton
            {
                Text = "Дні",
                Location = new System.Drawing.Point(10, 60),
            };

            RadioButton hoursRadioButton = new RadioButton
            {
                Text = "Години",
                Location = new System.Drawing.Point(10, 80),
            };

            RadioButton secondsRadioButton = new RadioButton
            {
                Text = "Секунди",
                Location = new System.Drawing.Point(10, 100),
            };

            TextBox resultTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 160),
                Width = 230,
                ReadOnly = true,
                Multiline = true,
                WordWrap = true,
                ScrollBars = ScrollBars.Vertical,
            };

            Button calculateButton = new Button
            {
                Text = "Визначити час до дати",
                Location = new System.Drawing.Point(20, 220),
                Width = 230,
            };

            calculateButton.Click += (sender, e) =>
            {
                targetDate = dateTimePicker.Value;
                TimeSpan timeRemaining = targetDate - DateTime.Now;

                if (yearsRadioButton.Checked)
                {
                    double years = timeRemaining.TotalDays / 365.0;
                    resultTextBox.Text = $"Залишилося {years:F2} років до цієї дати.";
                }
                else if (monthsRadioButton.Checked)
                {
                    double months = timeRemaining.TotalDays / 30.44;
                    resultTextBox.Text = $"Залишилося {months:F2} місяців до цієї дати.";
                }
                else if (daysRadioButton.Checked)
                {
                    int days = (int)timeRemaining.TotalDays;
                    resultTextBox.Text = $"Залишилося {days} днів до цієї дати.";
                }
                else if (hoursRadioButton.Checked)
                {
                    int hours = (int)timeRemaining.TotalHours;
                    resultTextBox.Text = $"Залишилося {hours} годин до цієї дати.";
                }
                else if (secondsRadioButton.Checked)
                {
                    int seconds = (int)timeRemaining.TotalSeconds;
                    resultTextBox.Text = $"Залишилося {seconds} секунд до цієї дати.";
                }
            };

            this.Controls.Add(titleLabel);
            this.Controls.Add(dateTimePicker);
            unitGroupBox.Controls.Add(yearsRadioButton);
            unitGroupBox.Controls.Add(monthsRadioButton);
            unitGroupBox.Controls.Add(daysRadioButton);
            unitGroupBox.Controls.Add(hoursRadioButton);
            unitGroupBox.Controls.Add(secondsRadioButton);
            this.Controls.Add(unitGroupBox);
            this.Controls.Add(resultTextBox);
            this.Controls.Add(calculateButton);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application
