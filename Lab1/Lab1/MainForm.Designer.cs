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
        comboBox2.Size = new System.Drawing.Size(203, 28);
        comboBox2.TabIndex = 1;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(437, 7);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(350, 36);
        button1.TabIndex = 2;
        button1.Text = "Вызвать метод";
        button1.UseVisualStyleBackColor = true;
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new System.Drawing.Point(12, 46);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(419, 333);
        pictureBox1.TabIndex = 3;
        pictureBox1.TabStop = false;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.Location = new System.Drawing.Point(436, 121);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(351, 104);
        listBox1.TabIndex = 4;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(437, 46);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(350, 43);
        button2.TabIndex = 5;
        button2.Text = "Добавить объект";
        button2.UseVisualStyleBackColor = true;
        // 
        // textBoxOutput
        // 
        textBoxOutput.Location = new System.Drawing.Point(12, 385);
        textBoxOutput.Multiline = true;
        textBoxOutput.Name = "textBoxOutput";
        textBoxOutput.ReadOnly = true;
        textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        textBoxOutput.Size = new System.Drawing.Size(780, 50);
        textBoxOutput.TabIndex = 0;
        // 
        // ShowHierarchy
        // 
        ShowHierarchy.Location = new System.Drawing.Point(437, 280);
        ShowHierarchy.Name = "ShowHierarchy";
        ShowHierarchy.Size = new System.Drawing.Size(351, 51);
        ShowHierarchy.TabIndex = 6;
        ShowHierarchy.Text = "Показать иерархию";
        ShowHierarchy.UseVisualStyleBackColor = true;
        ShowHierarchy.Click += ShowHierarchy_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(436, 92);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(351, 25);
        label1.TabIndex = 7;
        label1.Text = "Список объектов:";
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(436, 231);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(351, 43);
        button3.TabIndex = 8;
        button3.Text = "Удалить объект";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
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
        Text = "OOP_Lab_1";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button ShowHierarchy;

    private System.Windows.Forms.Button button2;
    
    private System.Windows.Forms.ListBox listBox1;

    public static System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.ComboBox comboBox2;

    private System.Windows.Forms.ComboBox comboBox1;

    #endregion
}