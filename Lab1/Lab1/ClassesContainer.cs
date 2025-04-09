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

    public ElectronicDevice this[int index]
    {
        get => electronicDevices[index];
        set => electronicDevices[index] = value;
    }
    
    public void ChangeParameters(int index, string valueName, string newValue)
    {
        var property = electronicDevices[index].GetType().GetProperty(valueName);
        if (valueName != null)
        {
            try
            {
                property.SetValue(electronicDevices[index], Convert.ChangeType(newValue.ToLower(), property.PropertyType));
            }
            catch
            {
                MessageBox.Show("Некорректное значение");
            }
        }
        else
        {
            MessageBox.Show("Свойство не найдено");
        }
    }
}