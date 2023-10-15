using NumberGuessingGame;
using static System.Net.Mime.MediaTypeNames;

namespace MouseEventsExample
{
    public partial class MainForm : Form
    {
        public object ClientSize { get; private set; }
        public string Text { get; private set; }

        private void SetMouseDown(Action<object, MouseEventArgs> value)
        {
            MouseDown = value;
        }

        private Action<object, MouseEventArgs> mouseMove;

        public Action<object, MouseEventArgs> GetMouseMove()
        {
            return mouseMove;
        }

        private void SetMouseMove(Action<object, MouseEventArgs> value)
        {
            mouseMove = value;
        }

        private Action<object, MouseEventArgs> mouseUp;
        private object MouseButtons;
        private object Control;
        private object Keys;
        private object MessageBox;
        private Action<object, MouseEventArgs> mouseDown;

        public Action<object, MouseEventArgs> GetMouseUp()
        {
            return mouseUp;
        }

        private void SetMouseUp(Action<object, MouseEventArgs> value)
        {
            mouseUp = value;
        }

        public MainForm()
        {
            InitializeComponent();
            this.SetMouseDown(this.MouseDown + MainForm_MouseDown);
            this.SetMouseMove(this.GetMouseMove() + MainForm_MouseMove);
            this.SetMouseUp(this.GetMouseUp() + MainForm_MouseUp);
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    MessageBox.Show("ЛКМ з натиснутою клавішею Control. Закриваю програму.");
                    Application.Exit();
                }
                else
                {
                    int mouseX = e.X;
                    int mouseY = e.Y;

                    if (mouseX >= 10 && mouseX <= this.ClientSize.Width - 10 && mouseY >= 10 && mouseY <= this.ClientSize.Height - 10)
                    {
                        MessageBox.Show("Точка знаходиться в межах прямокутника.");
                    }
                    else if (mouseX < 10 || mouseX > this.ClientSize.Width - 10 || mouseY < 10 || mouseY > this.ClientSize.Height - 10)
                    {
                        MessageBox.Show("Точка знаходиться поза межами прямокутника.");
                    }
                    else
                    {
                        MessageBox.Show("Точка знаходиться на межі прямокутника.");
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                string clientSizeInfo = $"Ширина = {this.ClientSize.Width}, Висота = {this.ClientSize.Height}";
                this.Text = clientSizeInfo;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            string mousePositionInfo = $"Координати миші: X = {e.X}, Y = {e.Y}";
            this.Text = mousePositionInfo;
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            this.Text = "Прямокутник та події миші";
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
