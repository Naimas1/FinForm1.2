using static System.Net.Mime.MediaTypeNames;

namespace ResumeMessageBox
{
    public partial class MainForm : Form
    {
        private object MessageBox;
        private object MessageBoxButtons;
        private object MessageBoxIcon;

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
            string resume = "Це моє коротке резюме. Я програміст з досвідом у різних областях розробки. " +
                "Я володію знаннями з C#,Pyton." +
                "окрім цих програм я вмію працювати з 1С,та розбираюсь в бугалтерській справі";

            int totalCharacters = resume.Length;
            int messageBoxCount = 3;
            int averageCharactersPerMessageBox = totalCharacters / messageBoxCount;

            for (int i = 0; i < messageBoxCount - 1; i++)
            {
                object value = MessageBox.Show(
                    resume,
                    "Резюме",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            MessageBox.Show(resume, "Резюме - Середній символів: " + averageCharactersPerMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [STAThread]
        
        private static void NewMethod2()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }
}

