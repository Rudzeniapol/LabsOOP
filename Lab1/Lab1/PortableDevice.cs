using Common;

namespace Lab1;
[Serializable]
public class PortableDevice : ElectronicDevice
{
    public override void Property()
    {
        Console.WriteLine("Устройство является переносимым.");
    }
}