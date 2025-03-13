namespace Lab1;

public class TvDevice : StaticDevice, IPowerable, IDevice
{
    protected bool _power = false;

    public bool Power
    {
        get
        {
            return _power;
        }
        set
        {
            try
            {
                _power = value;
            }
            catch
            {
                throw new InvalidCastException("Значение должно быть либо true, либо false");
            }
        }
    }
    
    public void PowerOn()
    {
        if (!_power)
        {
            _power = true;
            MainForm.Instance.Output("Устройство включено.");
        }
        else
        {
            MainForm.Instance.Output("Устройство не выключено.");
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

    public void ChangeChannel()
    {
        Random random = new Random();
        MainForm.Instance.Output($"Телевизор переключён на {random.Next(1, 100)} канал.");
    }
    
    public override void Property()
    {
        MainForm.Instance.Output("Это телевизор. Стационарное устройство с экраном для приёма телевизионных передач.");
    }
}