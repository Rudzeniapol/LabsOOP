namespace Lab1;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox textBoxOutput;
    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        comboBox1 = new System.Windows.Forms.ComboBox();
        comboBox2 = new System.Windows.Forms.ComboBox();
        button1 = new System.Windows.Forms.Button();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        listBox1 = new System.Windows.Forms.ListBox();
        button2 = new System.Windows.Forms.Button();
        textBoxOutput = new System.Windows.Forms.TextBox();
        ShowHierarchy = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        button3 = new System.Windows.Forms.Button();
        FieldsComboBox = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        FieldButton = new System.Windows.Forms.Button();
        ErrorFieldLabel = new System.Windows.Forms.Label();
        FieldTextBox = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(12, 12);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(210, 28);
        comboBox1.TabIndex = 0;
        // 
        // comboBox2
        // 
        comboBox2.FormattingEnabled = true;
        comboBox2.Location = new System.Drawing.Point(228, 12);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new System.Drawing.Size(184, 28);
        comboBox2.TabIndex = 1;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(419, 7);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(368, 36);
        button1.TabIndex = 2;
        button1.Text = "Вызвать метод";
        button1.UseVisualStyleBackColor = true;
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new System.Drawing.Point(12, 46);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(400, 400);
        pictureBox1.TabIndex = 3;
        pictureBox1.TabStop = false;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.Location = new System.Drawing.Point(419, 120);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(368, 104);
        listBox1.TabIndex = 4;
        listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(419, 46);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(368, 43);
        button2.TabIndex = 5;
        button2.Text = "Добавить объект";
        button2.UseVisualStyleBackColor = true;
        // 
        // textBoxOutput
        // 
        textBoxOutput.Location = new System.Drawing.Point(9, 453);
        textBoxOutput.Multiline = true;
        textBoxOutput.Name = "textBoxOutput";
        textBoxOutput.ReadOnly = true;
        textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        textBoxOutput.Size = new System.Drawing.Size(404, 65);
        textBoxOutput.TabIndex = 0;
        // 
        // ShowHierarchy
        // 
        ShowHierarchy.Location = new System.Drawing.Point(419, 280);
        ShowHierarchy.Name = "ShowHierarchy";
        ShowHierarchy.Size = new System.Drawing.Size(369, 51);
        ShowHierarchy.TabIndex = 6;
        ShowHierarchy.Text = "Показать иерархию";
        ShowHierarchy.UseVisualStyleBackColor = true;
        ShowHierarchy.Click += ShowHierarchy_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(419, 92);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(368, 25);
        label1.TabIndex = 7;
        label1.Text = "Список объектов:";
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(419, 231);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(368, 43);
        button3.TabIndex = 8;
        button3.Text = "Удалить объект";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // FieldsComboBox
        // 
        FieldsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        FieldsComboBox.FormattingEnabled = true;
        FieldsComboBox.Location = new System.Drawing.Point(419, 376);
        FieldsComboBox.Name = "FieldsComboBox";
        FieldsComboBox.Size = new System.Drawing.Size(369, 28);
        FieldsComboBox.TabIndex = 9;
        FieldsComboBox.SelectedIndexChanged += FieldsComboBox_SelectedIndexChanged;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(419, 348);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(368, 25);
        label2.TabIndex = 10;
        label2.Text = "Поля:";
        // 
        // FieldButton
        // 
        FieldButton.Location = new System.Drawing.Point(652, 410);
        FieldButton.Name = "FieldButton";
        FieldButton.Size = new System.Drawing.Size(136, 36);
        FieldButton.TabIndex = 11;
        FieldButton.Text = "Присвоить";
        FieldButton.UseVisualStyleBackColor = true;
        FieldButton.Click += FieldButton_Click;
        // 
        // ErrorFieldLabel
        // 
        ErrorFieldLabel.Location = new System.Drawing.Point(419, 453);
        ErrorFieldLabel.Name = "ErrorFieldLabel";
        ErrorFieldLabel.Size = new System.Drawing.Size(368, 65);
        ErrorFieldLabel.TabIndex = 12;
        // 
        // FieldTextBox
        // 
        FieldTextBox.Location = new System.Drawing.Point(418, 419);
        FieldTextBox.Name = "FieldTextBox";
        FieldTextBox.Size = new System.Drawing.Size(227, 27);
        FieldTextBox.TabIndex = 13;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(800, 530);
        Controls.Add(FieldTextBox);
        Controls.Add(ErrorFieldLabel);
        Controls.Add(FieldButton);
        Controls.Add(label2);
        Controls.Add(FieldsComboBox);
        Controls.Add(button3);
        Controls.Add(label1);
        Controls.Add(ShowHierarchy);
        Controls.Add(textBoxOutput);
        Controls.Add(button2);
        Controls.Add(listBox1);
        Controls.Add(pictureBox1);
        Controls.Add(button1);
        Controls.Add(comboBox2);
        Controls.Add(comboBox1);
        Location = new System.Drawing.Point(19, 19);
        Text = "Программка";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox FieldTextBox;

    private System.Windows.Forms.Button ShowHierarchy;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.ComboBox FieldsComboBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button FieldButton;
    private System.Windows.Forms.Label ErrorFieldLabel;

    private System.Windows.Forms.Button button2;
    
    private System.Windows.Forms.ListBox listBox1;

    public static System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.ComboBox comboBox2;

    private System.Windows.Forms.ComboBox comboBox1;

    #endregion
}