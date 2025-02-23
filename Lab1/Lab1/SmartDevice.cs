namespace Lab1;

public class SmartDevice : CallDevice, IConnectable, IDevice
{
    protected bool IsConnected { get; set; }

    public SmartDevice()
    {
        IsConnected = false;
    }

    public virtual void BrowseInternet()
    {
        if (IsConnected)
        {
            MainForm.Instance.Output("Сёрфим интернет.");
        }
        else
        {
            MainForm.Instance.Output("Не подключено к сети.");
        }
    }

    public virtual void Connect()
    {
        if (!IsConnected)
        {
            IsConnected = true;
            MainForm.Instance.Output("Устройство подключено к сети.");
        }
        else
        {
            MainForm.Instance.Output("Устройство уже подключено к сети.");
        }
    }

    public virtual void Disconnect()
    {
        if (IsConnected)
        {
            IsConnected = false;
            MainForm.Instance.Output("Устройство отключено от сети.");
        }
        else
        {
            MainForm.Instance.Output("Устройство не подключено к сети.");
        }
    }
    
    public override void Property()
    {
        MainForm.Instance.Output("Умное устройство (имеет возможность взаимодействовать с Интернетом).");
    }
}