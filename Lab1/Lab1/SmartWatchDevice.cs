namespace Lab1;

public class SmartWatchDevice : CallDevice, IDevice
{
    private bool _isConnectedToPhone;

    public bool IsConnectedToPhone
    {
        get
        {
            return _isConnectedToPhone;
        }
        set
        {
            try
            {
                _isConnectedToPhone = value;
            }
            catch
            {
                throw new InvalidCastException("Значение должно быть либо true, либо false");
            }
        }
    }
    
    public SmartWatchDevice()
    {
        _isConnectedToPhone = false;
    }
    public override void Property()
    {
        MainForm.Instance.Output("Портативные часы, способные взаимодействовать со смартфоном.");
    }

    public virtual void ConnectToSmartphone()
    {
        if (!_isConnectedToPhone)
        {
            _isConnectedToPhone = true;
            MainForm.Instance.Output("Часы подключились к смартфону.");
        }
        else
        {
            MainForm.Instance.Output("Часы уже подключены к смартфону.");
        }
    }

    public virtual void DisconnectFromSmartphone()
    {
        if (_isConnectedToPhone)
        {
            _isConnectedToPhone = false;
            MainForm.Instance.Output("Часы отключились от смартфона.");
        }
        else
        {
            MainForm.Instance.Output("Часы не подключены к смартфону.");
        }
    }

    public override void Call(string? phone)
    {
        if (_isConnectedToPhone)
        {
            base.Call(phone);
        }
        else
        {
            MainForm.Instance.Output("Вы не подключены к смартфону.");
        }
    }

    public void GetTime()
    {
        MainForm.Instance.Output($"Текущее время: {DateTime.Now:HH:mm:ss}.");
    }

    public void GetHeartRate()
    {
        Random random = new Random();
        MainForm.Instance.Output($"Текущая частота биения сердца: {random.Next(70, 100).ToString()} ударов в минуту.");
    }
}