using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Lab1
{
    public partial class ParameterInputForm : Form
    {
        private ParameterInfo[] parameterInfos;
        private List<TextBox> textBoxes = new List<TextBox>();
        public object[] Parameters { get; private set; }

        public ParameterInputForm(ParameterInfo[] parametersInfo)
        {
            parameterInfos = parametersInfo;
            InitializeComponent();
            SetupControls();
        }

        private void SetupControls()
        {
            TableLayoutPanel panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                AutoSize = true,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            
            for (int i = 0; i < parameterInfos.Length; i++)
            {
                Label label = new Label
                {
                    Text = $"{parameterInfos[i].Name} ({parameterInfos[i].ParameterType.Name}):",
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    Margin = new Padding(3)
                };

                TextBox textBox = new TextBox
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Width = 200,
                    Margin = new Padding(3)
                };
                textBoxes.Add(textBox);
                panel.Controls.Add(label, 0, i);
                panel.Controls.Add(textBox, 1, i);
            }

            FlowLayoutPanel buttonsPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Bottom,
                AutoSize = true,
                Padding = new Padding(10)
            };

            Button okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Margin = new Padding(5),
                Height = 50,
                Width = 100
            };
            okButton.Click += OkButton_Click;

            Button cancelButton = new Button
            {
                Text = "Отмена",
                DialogResult = DialogResult.Cancel,
                Margin = new Padding(5),
                Height = 50,
                Width = 100
            };

            buttonsPanel.Controls.Add(okButton);
            buttonsPanel.Controls.Add(cancelButton);
            
            this.Controls.Add(panel);
            this.Controls.Add(buttonsPanel);

            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;
            this.StartPosition = FormStartPosition.CenterParent;
            this.AutoSize = true;
            this.Text = "Введите параметры";
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Parameters = new object[parameterInfos.Length];
            try
            {
                for (int i = 0; i < parameterInfos.Length; i++)
                {
                    string input = textBoxes[i].Text;
                    object value = Convert.ChangeType(input, parameterInfos[i].ParameterType);
                    Parameters[i] = value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при конвертации параметров: " + ex.Message);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
