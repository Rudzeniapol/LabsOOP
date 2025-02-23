namespace Lab1;

public class TabletDevice : SmartDevice, IDevice
{
    public override void Property()
    {
        MainForm.Instance.Output("Это планшет: умное устройство (имеет возможность взаимодействовать с Интернетом).");
    }
}