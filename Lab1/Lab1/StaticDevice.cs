using Common;

namespace Lab1;
[Serializable]
public class StaticDevice : ElectronicDevice
{
    public override void Property()
    {
        Console.WriteLine("Статическое устройство, установленное в определенном месте.");
    }
}