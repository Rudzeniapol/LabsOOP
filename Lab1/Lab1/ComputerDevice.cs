namespace Lab1;

public class ComputerDevice : StaticDevice, IPowerable, IDevice
{
    protected bool _power = false;
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
    
    public override void Property()
    {
        MainForm.Instance.Output("Это компьютер. Стационарная мощная вычислительная машина.");
    }

    public void UpgradeRam()
    {
        MainForm.Instance.Output("RAM upgraded.");
    }
}