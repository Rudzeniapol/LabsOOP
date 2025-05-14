using System.Text.RegularExpressions;
using System;

namespace Lab1;

[Serializable]
public class CallDevice : PortableDevice
{
    private const string _Pattern = @"^\+375(29|33|44|25)\d{7}$";
    [NonSerialized]
    private readonly Regex _regex = new Regex(_Pattern);
    
    public string Pattern {
        get
        {
            return _Pattern;
        }
        set
        {
            throw new InvalidCastException("Значение является константным");
        }
    }

    public virtual void Call(string? phone)
    {
        if (phone == null || phone.Trim().Equals("") || !_regex.IsMatch(phone))
        {
            MainForm.Instance.Output("Неверный номер телефона (Формат: +375...).");
        }
        else
        {
            MainForm.Instance.Output($"Звоним на {phone}...");
        }
    }
    
    public override void Property()
    {
        Console.WriteLine("Устройство позволяет совершать звонки.");
    }
}