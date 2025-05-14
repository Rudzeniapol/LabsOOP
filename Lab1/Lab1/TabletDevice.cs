namespace Lab1;
[Serializable]
public class TabletDevice : SmartDevice
{
    public override void Property()
    {
        Console.WriteLine("Это планшет: умное устройство (имеет возможность взаимодействовать с Интернетом).");
    }
}