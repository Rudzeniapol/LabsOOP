namespace Lab1;

public class ClassesContainer
{
    private List<ElectronicDevice> electronicDevices = new List<ElectronicDevice>();

    public void AddElectronicDevice(ElectronicDevice electronicDevice)
    {
        electronicDevices.Add(electronicDevice);
    }

    public void RemoveElectronicDevice(ElectronicDevice electronicDevice)
    {
        electronicDevices.Remove(electronicDevice);
    }

    public List<ElectronicDevice> GetDevices()
    {
        return electronicDevices;
    }

    public void CallMethod(int index, string methodName, object[] parameters = null)
    {
        var method = electronicDevices[index].GetType().GetMethod(methodName);
        if (method != null)
        {
            method.Invoke(electronicDevices[index], parameters);
        }
        else
        {
            MessageBox.Show("Метод не найден.");
        }
    }
}