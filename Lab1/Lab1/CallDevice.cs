using System.Text.RegularExpressions;
using System;

namespace Lab1;

public class CallDevice : PortableDevice, IDevice
{
    private const string Pattern = @"^\+375(29|33|44|25)\d{7}$";
    private readonly Regex _regex = new Regex(Pattern);
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
        MainForm.Instance.Output("Устройство позволяет совершать звонки.");
    }
}