using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Maui.InputKit;

public class MainPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string _text;
    private bool _isValid;
    private string _isValidResult;
    private int _counter;

    public MainPageViewModel()
    {
        SubmitCommand = new Command(_ =>
        {
            _counter++;
            if (IsValid)
            {
                IsValidResult = "Is Valid " + _counter;
            }
            else
            {
                IsValidResult = "Not Valid " + _counter;
            }
        });
    }

    public ICommand SubmitCommand { get; }

    public string Text
    {
        get => _text;
        set
        {
            if (value != _text)
            {
                _text = value;
                NotifyPropertyChanged();
            }
        }
    }

    public bool IsValid
    {
        get => _isValid;
        set
        {
            if (value != _isValid)
            {
                _isValid = value;
                NotifyPropertyChanged();
            }
        }
    }

    public string IsValidResult
    {
        get => _isValidResult;
        set
        {
            if(value != _isValidResult)
            {
                _isValidResult = value;
                NotifyPropertyChanged();
            }
        }
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
