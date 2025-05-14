using Common;

namespace Plugin_v1;

[Serializable]
public class MacBook : ElectronicDevice
{
    public override void Property()
    {
        Console.WriteLine("Too expensive for me :(");
    }
}