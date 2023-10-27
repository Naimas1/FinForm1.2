using NumberGuessingGame;

public class ContactViewModel : ViewModelBase
{
    private string fullName;
    private string address;
    private string phoneNumber;

    public string FullName
    {
        get => fullName;
        set { Set(() => FullName, ref fullName, value); }
    }

    private void Set(Func<string> value1, ref string fullName, string value2)
    {
        throw new NotImplementedException();
    }

    public string Address
    {
        get => address;
        set { Set(() => Address, ref address, value); }
    }

    public string PhoneNumber
    {
        get => phoneNumber;
        set { Set(() => PhoneNumber, ref phoneNumber, value); }
    }

    public RelayCommand AddContactCommand { get; private set; }
    public RelayCommand ClearFieldsCommand { get; private set; }

    public ContactViewModel()
    {
        AddContactCommand = new RelayCommand(AddContact);
        ClearFieldsCommand = new RelayCommand(ClearFields);
    }

    private void AddContact()
    {
        // Додавання контакту до списку або бази даних
      
    }

    private void ClearFields()
    {
        FullName = "";
        Address = "";
        PhoneNumber = "";
    }
}

public partial class MainForm : Form
{
    private ContactViewModel viewModel;

    public ContactViewModel DataContext { get; private set; }

    public MainForm()
    {
        InitializeComponent();
        viewModel = new ContactViewModel();
        DataContext = viewModel;
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    private void AddContactButton_Click(object sender, EventArgs e)
    {
        viewModel.AddContactCommand.Execute(null);
    }

    private void ClearFieldsButton_Click(object sender, EventArgs e)
    {
        viewModel.ClearFieldsCommand.Execute(null);
    }
}
