using NumberGuessingGame;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace DayOfWeekApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Label label = new Label
            {
                Text = "Введіть дату:",
                Location = new System.Drawing.Point(20, 20),
            };

            DateTimePicker dateTimePicker = new DateTimePicker
            {
                Location = new System.Drawing.Point(150, 20),
                Format = DateTimePickerFormat.Short,
                Width = 100,
                MaxDate = DateTime.Now,
                ShowUpDown = true,
                Value = DateTime.Now,
                CustomFormat = "dd.MM.yyyy",
                CalendarTitleBackColor = System.Drawing.Color.LightGray
                
            };

            TextBox resultTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 60),
                Width = 230,
                ReadOnly = true,
                Multiline = true,
                WordWrap = true,
                ScrollBars = ScrollBars.Vertical,
            };

            Button calculateButton = new Button
            {
                Text = "Визначити день тижня",
                Location = new System.Drawing.Point(20, 100),
                Width = 230,
            };

            calculateButton.Click += (sender, e) =>
            {
                DateTime selectedDate = dateTimePicker.Value;
                string dayOfWeek = GetDayOfWeekInRussian(selectedDate.DayOfWeek);
                resultTextBox.Text = $"День тижня для введеної дати: {dayOfWeek}";
            };

            this.Controls.Add(label);
            this.Controls.Add(dateTimePicker);
            this.Controls.Add(resultTextBox);
            this.Controls.Add(calculateButton);
        }

        private string GetDayOfWeekInRussian(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "Неділя";
                case DayOfWeek.Monday:
                    return "Понеділок";
                case DayOfWeek.Tuesday:
                    return "Вівторок";
                case DayOfWeek.Wednesday:
                    return "Середа";
                case DayOfWeek.Thursday:
                    return "Четвер";
                case DayOfWeek.Friday:
                    return "П'ятниця";
                case DayOfWeek.Saturday:
                    return "Субота";
                default:
                    return "Помилка";
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
