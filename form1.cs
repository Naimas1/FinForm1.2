using MouseEventsExample;
using static System.Net.Mime.MediaTypeNames;

namespace NumberGuessingGame
{
    public partial class MainForm : Form
    {
        private int numberToGuess;
        private int numberOfTries;
        private object MessageBox;

        public object MessageBoxButtons { get; private set; }
        public object MessageBoxIcon { get; private set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            Random random = new Random();
            numberToGuess = random.Next(1, 2001);
            numberOfTries = 0;

            GuessNumber();
        }

        private void GuessNumber()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введіть число в діапазоні від 1 до 2000:", "Угадайте число", "");

            if (int.TryParse(input, out int userGuess))
            {
                numberOfTries++;

                if (userGuess < numberToGuess)
                {
                    MessageBox.Show("Загадане число більше.", "Угадайте число", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GuessNumber();
                }
                else if (userGuess > numberToGuess)
                {
                    MessageBox.Show("Загадане число менше.", "Угадайте число", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GuessNumber();
                }
                else
                {
                    MessageBox.Show($"Ви вгадали число {numberToGuess} за {numberOfTries} спроб!", "Вітаємо!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult result = MessageBox.Show("Бажаєте спробувати ще раз?", "Нова гра", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        StartNewGame();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректне число.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuessNumber();
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

    internal class DialogResult
    {
    }

    public class Form
    {
        public Action<object, MouseEventArgs> MouseDown { get => mouseDown; private set => mouseDown = value; }
    }
}
