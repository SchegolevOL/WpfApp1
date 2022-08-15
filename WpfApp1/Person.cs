using System;
using System.ComponentModel;

namespace WpfApp1;

public class Person : INotifyPropertyChanged
{
    private int _id;
    public int Id
    {
        get => _id;
        set
        {
            if (value == null) throw new ArgumentNullException(nameof(Id));
            if (value == _id) return;

            _id = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
        }
    }

    private string _first;
    public string FirstName
    {
        get => _first;
        set
        {
            if (value == null) throw new ArgumentNullException(nameof(FirstName));
            if (value == _first) return;

            _first = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
        }
    }
    
    private string _last;
    public string LastName
    {
        get => _last;
        set
        {
            if (value == null) throw new ArgumentNullException(nameof(LastName));
            if (value == _last) return;

            _last = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
        }
    }
    
    private DateTime _birth;
    public DateTime DateOfBirth
    {
        get => _birth;
        set
        {
            if (value == null) throw new ArgumentNullException(nameof(DateOfBirth));
            if (value == _birth) return;

            _birth = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateOfBirth)));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}