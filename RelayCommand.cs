public class RelayCommand
{
    public RelayCommand(Action addContact)
    {
        AddContact = addContact;
    }

    public Action AddContact { get; }

    internal void Execute(object value)
    {
        throw new NotImplementedException();
    }
}