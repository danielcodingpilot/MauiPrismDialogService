using PrismSample.Views;

namespace PrismApp1.ViewModels;

public class MainPageViewModel : BindableBase
{
    private ISemanticScreenReader _screenReader { get; }
    private int _count;

    public MainPageViewModel(ISemanticScreenReader screenReader, IDialogService dialogService)
    {
        _screenReader = screenReader;
        this.dialogService = dialogService;
        CountCommand = new DelegateCommand(async () => await OnCountCommandExecuted());
    }

    public string Title => "Main Page";

    private string _text = "Click me";
    private readonly IDialogService dialogService;

    public string Text
    {
        get => _text;
        set => SetProperty(ref _text, value);
    }

    public DelegateCommand CountCommand { get; }

    private async Task OnCountCommandExecuted()
    {
        _count++;
        if (_count == 1)
            Text = "Clicked 1 time";
        else if (_count > 1)
            Text = $"Clicked {_count} times";

        _screenReader.Announce(Text);

        var parameters = new DialogParameters
        {
            { "title", "Connection Lost!" },
            { "message", "We seem to have lost network connectivity" }
        };
        dialogService.ShowDialog(nameof(DemoDialog), parameters);

        //var d = await dialogService.ShowDialogAsync("LockingDialog?Question=Can navigate away?");
    }
}
