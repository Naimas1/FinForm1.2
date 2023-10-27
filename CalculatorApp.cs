using NumberGuessingGame;
using static System.Net.Mime.MediaTypeNames;

namespace CalculatorApp
{
    public partial class MainForm : Form
    {
        private TextBox inputTextBox;
        private TextBox historyTextBox;

        private string currentNumber = string.Empty;
        private string currentOperator = string.Empty;
        private double result = 0.0;

        public MainForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Калькулятор";

            inputTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(200, 30),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
            };

            historyTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 50),
                Size = new System.Drawing.Size(200, 30),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
            };

            CreateButtons();

            this.Controls.Add(inputTextBox);
            this.Controls.Add(historyTextBox);
        }

        private void CreateButtons()
        {
            string[] buttonLabels = { "7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", ".", "=", "+" };

            int x = 10;
            int y = 90;
            int buttonWidth = 40;
            int buttonHeight = 40;

            foreach (string label in buttonLabels)
            {
                Button button = new Button
                {
                    Text = label,
                    Location = new System.Drawing.Point(x, y),
                    Size = new System.Drawing.Size(buttonWidth, buttonHeight),
                };

                button.Click += Button_Click;
                this.Controls.Add(button);

                x += buttonWidth + 10;

                if (x >= 200)
                {
                    x = 10;
                    y += buttonHeight + 10;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            if (IsNumber(buttonText) || buttonText == ".")
            {
                currentNumber += buttonText;
                inputTextBox.Text = currentNumber;
            }
            else if (IsOperator(buttonText))
            {
                if (!string.IsNullOrEmpty(currentOperator))
                {
                    result = PerformOperation(result, double.Parse(currentNumber), currentOperator);
                    historyTextBox.Text = result.ToString() + " " + currentOperator;
                    currentNumber = string.Empty;
                }
                else
                {
                    result = double.Parse(currentNumber);
                    currentNumber = string.Empty;
                }

                currentOperator = buttonText;
                inputTextBox.Text = result.ToString();
            }
            else if (buttonText == "=")
            {
                if (!string.IsNullOrEmpty(currentOperator))
                {
                    result = PerformOperation(result, double.Parse(currentNumber), currentOperator);
                    historyTextBox.Text = string.Empty;
                    currentNumber = result.ToString();
                    currentOperator = string.Empty;
                    inputTextBox.Text = result.ToString();
                }
            }
            else if (buttonText == "CE")
            {
                currentNumber = string.Empty;
                inputTextBox.Text = string.Empty;
            }
            else if (buttonText == "C")
            {
                result = 0.0;
                currentNumber = string.Empty;
                currentOperator = string.Empty;
                inputTextBox.Text = string.Empty;
                historyTextBox.Text = string.Empty;
            }
            else if (buttonText == "<")
            {
                if (!string.IsNullOrEmpty(currentNumber))
                {
                    currentNumber = currentNumber.Substring(0, currentNumber.Length - 1);
                    inputTextBox.Text = currentNumber;
                }
            }
        }

        private bool IsNumber(string text)
        {
            double result;
            return double.TryParse(text, out result);
        }

        private bool IsOperator(string text)
        {
            return text == "+" || text == "-" || text == "*" || text == "/";
        }

        private double PerformOperation(double left, double right, string op)
        {
            switch (op)
            {
                case "+":
                    return left + right;
                case "-":
                    return left - right;
                case "*":
                    return left * right;
                case "/":
                    if (right != 0)
                        return left / right;
                    else
                        return double.NaN;
                default:
                    return right;
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
