namespace Lab1;

public class PortableDevice : ElectronicDevice, IDevice
{
    public override void Property()
    {
        MainForm.Instance.Output("Устройство является переносимым.");
    }
}