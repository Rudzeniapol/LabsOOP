namespace Lab1;

public class StaticDevice : ElectronicDevice, IDevice
{
    public override void Property()
    {
        MainForm.Instance.Output("Статическое устройство, установленное в определенном месте.");
    }
}