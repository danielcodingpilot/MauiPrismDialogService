namespace PrismApp1.ViewModels;

public class DemoDialogViewModel : BindableBase, IDialogAware
{
    public DemoDialogViewModel()
    {
        CloseCommand = new DelegateCommand(() => requestClose.Invoke(null));
    }

    private string title = "Alert";
    public string Title
    {
        get => title;
        set => SetProperty(ref title, value);
    }

    private string message;
    public string Message
    {
        get => message;
        set => SetProperty(ref message, value);
    }

    public DelegateCommand CloseCommand { get; }

    DialogCloseEvent requestClose;
    DialogCloseEvent IDialogAware.RequestClose { get => requestClose; set => this.requestClose = value; }

    public bool CanCloseDialog() => true;

    public void OnDialogClosed()
    {
        Console.WriteLine("The Demo Dialog has been closed...");
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
        Message = parameters.GetValue<string>("message");
        Title = parameters.GetValue<string>("title");
    }
}
