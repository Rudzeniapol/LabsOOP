using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Common;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace Lab1
{
    public partial class MainForm : Form
    {
        
        private static MainForm _instance;
        public static MainForm Instance => _instance;

        private ClassesContainer container = new ClassesContainer();
        private FilterInfoCollection videoDevices;  
        private VideoCaptureDevice videoSource;    
        private Bitmap currentFrame;               
        private const string PluginVersion = "2";
        private Assembly assembly = Assembly.LoadFrom($"C:\\Users\\ffgg9\\OneDrive\\Desktop\\Infinite Learning\\Students package\\OOP\\Labs\\Lab1\\Plugin_v{PluginVersion}\\bin\\Debug\\net8.0\\Plugin_v{PluginVersion}.dll");
        private Type macType;
        public MainForm()
        {
            _instance = this;
            InitializeComponent();
            InitializeVideoCapture();
            var deviceTypes = Assembly.GetExecutingAssembly().GetTypes()
                                     .Where(t => t.IsClass && typeof(ElectronicDevice).IsAssignableFrom(t) && t != typeof(ElectronicDevice))
                                     .Select(t => t.Name)
                                     .ToArray();
            comboBox1.Items.AddRange(deviceTypes);

            macType = assembly.GetType($"Plugin_v{PluginVersion}.MacBook");
            if (macType != null)
            {
                comboBox1.Items.Add(macType.Name);
            }

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            button1.Click += Button1_Click;
            
            button2.Click += Button2_Click;
        }
        
        private void InitializeVideoCapture()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                MessageBox.Show("Не найдены видеоустройства.");
                return;
            }
            
            videoSource = new VideoCaptureDevice(videoDevices[1].MonikerString);
            
            if (videoSource.VideoCapabilities.Length == 0)
            {
                MessageBox.Show("Нет доступных разрешений для выбранного устройства.");
                return;
            }
            
            videoSource.VideoResolution = videoSource.VideoCapabilities
                                              .FirstOrDefault(vc => vc.FrameSize.Width == 640 && vc.FrameSize.Height == 480) 
                                          ?? videoSource.VideoCapabilities[1]; 
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            
            videoSource.Start();
        }
        
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                currentFrame = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при захвате кадра: {ex.Message}");
            }
        }
        
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            
            string selectedClass = comboBox1.SelectedItem.ToString();
            Type? type = Type.GetType($"Lab1.{selectedClass}");

            if (type == null)
            {
                type = assembly.GetType($"Plugin_v{PluginVersion}.{selectedClass}");
            }

            if (type != null)
            {
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
                                 .Where(m => !m.IsSpecialName && m.DeclaringType != typeof(object))
                                 .Select(m => m.Name)
                                 .Distinct()
                                 .ToArray();
                
                comboBox2.Items.AddRange(methods);
                comboBox2.SelectedIndex = 0;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                Output("Выберите объект из списка.");
                return;
            }

            int index = listBox1.Items.IndexOf(listBox1.SelectedItem);
            
            ElectronicDevice selectedDevice = listBox1.SelectedItem as ElectronicDevice;
            string selectedMethodName = comboBox2.SelectedItem.ToString();
            MethodInfo method = selectedDevice.GetType().GetMethod(selectedMethodName);
            if (method == null)
            {
                MessageBox.Show("Метод не найден.");
                return;
            }

            ParameterInfo[] paramsInfo = method.GetParameters();
            object[] parameters = null;
            if ((selectedDevice is SmartphoneDevice smartphone) && selectedMethodName == "TakePhoto")
            {
                if (currentFrame != null && currentFrame is Bitmap bitmapFrame)
                {
                    parameters = new object[] { bitmapFrame };
                }
                else
                {
                    MessageBox.Show("Invalid frame");
                }
            }
            else
            {
                if ((selectedDevice is LaptopDevice laptop) && selectedMethodName == "TakePhoto")
                { 
                    if (currentFrame != null)
                    {
                        parameters = new object[] { currentFrame };
                    }
                    else
                    {
                        Output("Не удалось сделать фото.");
                    }
                }
                else
                {
                    if (paramsInfo.Length > 0)
                    {
                        using (ParameterInputForm inputForm = new ParameterInputForm(paramsInfo))
                        {
                            if (inputForm.ShowDialog() == DialogResult.OK)
                            {
                                parameters = inputForm.Parameters;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
            }
            container.CallMethod(index, selectedMethodName, parameters);
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            string selectedClass = comboBox1.SelectedItem.ToString();
            Type type = Type.GetType($"Lab1.{selectedClass}");

            if (type == null)
            {
                type = assembly.GetType($"Plugin_v{PluginVersion}.{selectedClass}");
            }

            if (type != null)
            {
                ElectronicDevice newDevice = null;

                if (type == typeof(SmartphoneDevice))
                {
                    newDevice = new SmartphoneDevice();
                }
                else if (type == typeof(LaptopDevice))
                {
                    newDevice = new LaptopDevice();
                }
                else
                {
                    newDevice = Activator.CreateInstance(type) as ElectronicDevice;
                }

                if (newDevice != null)
                {
                    container.AddElectronicDevice(newDevice);
                    listBox1.Items.Add(newDevice);
                    Output($"Создан объект: {newDevice.GetType().Name}");
                }
            }
        }
        
        public void Output(string message)
        {
            textBoxOutput.AppendText(message + Environment.NewLine);
        }

        private void ShowHierarchy_Click(object sender, EventArgs e)
        {
            ClassHierarchyForm hierarchyForm = new ClassHierarchyForm();
            hierarchyForm.Show();
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            base.OnFormClosing(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                Output("Выберите объект из списка.");
                return;
            }
            
            ElectronicDevice selectedDevice = listBox1.SelectedItem as ElectronicDevice;
            container.RemoveElectronicDevice(selectedDevice);
            listBox1.Items.Remove(selectedDevice);
        }

        private void FieldButton_Click(object sender, EventArgs e)
        {
            if (FieldsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали свойство для изменения");
                return;
            }
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали объект для изменения");
            }
            int index = listBox1.Items.IndexOf(listBox1.SelectedItem);
            string newValue = FieldTextBox.Text;
            string valueName = FieldsComboBox.Text;
            container.ChangeParameters(index, valueName, newValue);
            ErrorFieldLabel.Text = $"{FieldsComboBox.Text}: {container[index].GetType().GetProperty(FieldsComboBox.Text).GetValue(container[index])}";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FieldsComboBox.Items.Clear();
                int index = listBox1.Items.IndexOf(listBox1.SelectedItem);
                Type type = container[index].GetType();
                var properties = type.GetProperties();
                var propertiesNames = properties.Select(p => p.Name).ToArray();
                FieldsComboBox.Items.AddRange(propertiesNames);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Тут нет объекта!");
            }
        }

        private void FieldsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.Items.IndexOf(listBox1.SelectedItem);
            ErrorFieldLabel.Text = $"{FieldsComboBox.Text}: {container[index].GetType().GetProperty(FieldsComboBox.Text).GetValue(container[index])}";
        }

        private void SerializeButton_Click(object sender, EventArgs e)
        {
            if (TextRadioButton.Checked) {
                    using (StreamWriter fw = new StreamWriter(FileNameTextBox.Text + ".txt"))
                    {
                        foreach (var obj in container)
                        {
                            Type type = obj.GetType();
                            var fields = type.GetProperties();
                            fw.Write(type.Name + " ");
                            foreach (var field in fields)
                            {
                                fw.Write(field.Name + ":" + field.GetValue(obj) + " ");
                            }
                            fw.WriteLine();
                        }
                        MessageBox.Show("Список сериализован!");
                    }
            }
            else if(BinaryRadioButton.Checked){
                IFormatter binaryFormatter = new BinaryFormatter();  
                using (FileStream fs = new FileStream(FileNameTextBox.Text + ".dat", FileMode.OpenOrCreate))
                {
                    binaryFormatter.Serialize(fs, container);
                    MessageBox.Show("Список сериализован!");
                }
            }
            else {
                MessageBox.Show("Вы не выбрали тип файла!");
            }
        }

        private void DeserializeButton_Click(object sender, EventArgs e)
        {
            if (TextRadioButton.Checked)
            {
                if (File.Exists(FileNameTextBox.Text + ".txt"))
                {
                    try
                    {
                        using (StreamReader fr = new StreamReader(FileNameTextBox.Text + ".txt"))
                        {
                            try
                            {
                                container.ClearDevices();
                                string line;
                                while ((line = fr.ReadLine()) != null)
                                {
                                    string[] values = line.Split(' ');
                                    Type? type = Type.GetType("Lab1." + values[0]);
                                    var fields = type.GetProperties();
                                    object obj = Activator.CreateInstance(type);
                                    for (int i = 1; i < fields.Length-1; i++)
                                    {
                                        string[] vals= values[i].Split(':');
                                        fields[i-1].SetValue(obj, Convert.ChangeType(vals[1], fields[i-1].PropertyType));
                                    }
                                    container.AddElectronicDevice(Convert.ChangeType(obj, type) as ElectronicDevice);
                                    listBox1.Items.Clear();
                                    foreach (var device in container)
                                    {
                                        listBox1.Items.Add(device);
                                    }
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Не удалось десериализовать файл");
                            }
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("Файл с таким названием не найден");
                    }
                }
            }
            else if(BinaryRadioButton.Checked)
            {
                IFormatter binaryFormatter = new BinaryFormatter();
                try
                {
                    using (FileStream fs = new FileStream(FileNameTextBox.Text + ".dat", FileMode.Open))
                    {
                        try
                        {
                            container = (ClassesContainer)binaryFormatter.Deserialize(fs);
                            listBox1.Items.Clear();
                            foreach (var obj in container)
                            {
                                listBox1.Items.Add(obj);
                            }

                            MessageBox.Show("Файл десериализован!");
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось десериализовать файл");
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Файл с таким названием не найден");
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали тип файла!");
            }
        }
    }
}