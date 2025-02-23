namespace Lab1;

public class LaptopDevice : SmartphoneDevice, IPowerable, IDevice
{
    private bool _power = false;

    public void PowerOn()
    {
        if (!_power)
        {
            _power = true;
            MainForm.Instance.Output("Устройство включено.");
        }
        else
        {
            MainForm.Instance.Output("Устройство уже включено.");
        }
    }

    public void PowerOff()
    {
        if (_power)
        {
            _power = false;
            MainForm.Instance.Output("Устройство выключено.");
        }
        else
        {
            MainForm.Instance.Output("Устройство не включено.");
        }
    }

    public override void Disconnect()
    {
        if (_power)
        {
            base.Disconnect();
        }
        else
        {
            MainForm.Instance.Output("Устройство не включено.");
        }
    }

    public override void TakePhoto(Bitmap image)
    {
        if (_power)
        {
            base.TakePhoto(image);
        }
        else
        {
            MainForm.Instance.Output("Устройство не включено.");
            return;
        }
    }

    public override void Connect()
    {
        if (_power)
        {
            base.Connect();
        }
        else
        {
            MainForm.Instance.Output("Устройство не включено.");
        }
    }
    
    public override void BrowseInternet()
    {
        if (_power)
        {
            base.BrowseInternet();
        }
        else
        {
            MainForm.Instance.Output("Устройство не включено.");
        }
    }
    
    public override void Property()
    {
        MainForm.Instance.Output("Это ноутбук. Портативная и мощная вычислительная машина.");
    }

    public override void Call(string? phone)
    {
        if (_power && IsConnected)
        {
            base.Call(phone);
        }
        else
        {
            MainForm.Instance.Output(!_power ? "Устройство не включено." : "Устройство не подключено к сети.");
        }
    }
}