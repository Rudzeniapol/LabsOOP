using Common;

namespace Plugin_v2;

[Serializable]
public class MacBook : ElectronicDevice
{
    public override void Property()
    {
        Console.WriteLine("I think now I can afford it :o");
    }
}