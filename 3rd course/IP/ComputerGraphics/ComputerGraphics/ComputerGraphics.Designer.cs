using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ComputerGraphics
{
    partial class ComputerGraphics
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPixel = new System.Windows.Forms.Panel();
            this.panelHistogram = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2DrawLine = new System.Windows.Forms.Button();
            this.groupBox2SecondPoint = new System.Windows.Forms.GroupBox();
            this.numericUpDown2SecondY = new System.Windows.Forms.NumericUpDown();
            this.label2SecondY = new System.Windows.Forms.Label();
            this.numericUpDown2SecondX = new System.Windows.Forms.NumericUpDown();
            this.label2SecondX = new System.Windows.Forms.Label();
            this.groupBox2FirstPoint = new System.Windows.Forms.GroupBox();
            this.numericUpDown2FirstY = new System.Windows.Forms.NumericUpDown();
            this.label2FirstY = new System.Windows.Forms.Label();
            this.numericUpDown2FirstX = new System.Windows.Forms.NumericUpDown();
            this.label2FirstX = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3Ellipse = new System.Windows.Forms.GroupBox();
            this.button3DrawEllipse = new System.Windows.Forms.Button();
            this.numericUpDown3B = new System.Windows.Forms.NumericUpDown();
            this.label3B = new System.Windows.Forms.Label();
            this.numericUpDown3A = new System.Windows.Forms.NumericUpDown();
            this.label3A = new System.Windows.Forms.Label();
            this.groupBox3Circle = new System.Windows.Forms.GroupBox();
            this.button3DrawCircle = new System.Windows.Forms.Button();
            this.numericUpDown3Radius = new System.Windows.Forms.NumericUpDown();
            this.label3Radius = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listBox4Vertexes = new System.Windows.Forms.ListBox();
            this.button4FillPolygon = new System.Windows.Forms.Button();
            this.button4AddPoint = new System.Windows.Forms.Button();
            this.groupBox4AddingPoint = new System.Windows.Forms.GroupBox();
            this.numericUpDown4Y = new System.Windows.Forms.NumericUpDown();
            this.label4Y = new System.Windows.Forms.Label();
            this.numericUpDown4X = new System.Windows.Forms.NumericUpDown();
            this.label4X = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button6DrawBezierCurve = new System.Windows.Forms.Button();
            this.button6AddPoint = new System.Windows.Forms.Button();
            this.groupBox6AddingPoint = new System.Windows.Forms.GroupBox();
            this.numericUpDown6Y = new System.Windows.Forms.NumericUpDown();
            this.label6Y = new System.Windows.Forms.Label();
            this.numericUpDown6X = new System.Windows.Forms.NumericUpDown();
            this.label6X = new System.Windows.Forms.Label();
            this.listBox6Points = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.button7BuildHistogram = new System.Windows.Forms.Button();
            this.button7ChooseImage = new System.Windows.Forms.Button();
            this.pictureBox7ExploredImage = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.button8SaveImage = new System.Windows.Forms.Button();
            this.button8ChooseImage = new System.Windows.Forms.Button();
            this.pictureBox8UntreatedImage = new System.Windows.Forms.PictureBox();
            this.button8ConvertingToHalftone = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.label9UpperLimitValue = new System.Windows.Forms.Label();
            this.label9LowerLimitValue = new System.Windows.Forms.Label();
            this.label9UpperLimit = new System.Windows.Forms.Label();
            this.label9LowerLimit = new System.Windows.Forms.Label();
            this.trackBar9UpperLimit = new System.Windows.Forms.TrackBar();
            this.trackBar9LowerLimit = new System.Windows.Forms.TrackBar();
            this.comboBox9BinarizationMethods = new System.Windows.Forms.ComboBox();
            this.button9SaveImage = new System.Windows.Forms.Button();
            this.button9ChooseImage = new System.Windows.Forms.Button();
            this.button9ConvertingToBinary = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox9UntreatedImage = new System.Windows.Forms.PictureBox();
            this.tabPage10and11 = new System.Windows.Forms.TabPage();
            this.tabControl10 = new System.Windows.Forms.TabControl();
            this.tabPage10AddingNoise = new System.Windows.Forms.TabPage();
            this.button10AddNoise = new System.Windows.Forms.Button();
            this.label10ProbabilityValue = new System.Windows.Forms.Label();
            this.label10Probability = new System.Windows.Forms.Label();
            this.trackBar10Probability = new System.Windows.Forms.TrackBar();
            this.groupBox10NoiseType = new System.Windows.Forms.GroupBox();
            this.radioButton10ImpulseNoise = new System.Windows.Forms.RadioButton();
            this.radioButton10SaltAndPepperNoise = new System.Windows.Forms.RadioButton();
            this.tabPage10RemovingNoise = new System.Windows.Forms.TabPage();
            this.tabControl10RemoveNoise = new System.Windows.Forms.TabControl();
            this.tabPage10Binary = new System.Windows.Forms.TabPage();
            this.groupBox10BinaryFilterType = new System.Windows.Forms.GroupBox();
            this.radioButton10BinaryMedianFilter = new System.Windows.Forms.RadioButton();
            this.radioButton10BinaryLogicalFilter = new System.Windows.Forms.RadioButton();
            this.tabPage10Halftone = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton10HalftoneMedianFilter = new System.Windows.Forms.RadioButton();
            this.radioButton10HalftoneAveragingFilter = new System.Windows.Forms.RadioButton();
            this.label10NeighbourhoodSizeValue = new System.Windows.Forms.Label();
            this.label10NeighbourhoodSize = new System.Windows.Forms.Label();
            this.trackBar10NeighbourhoodSize = new System.Windows.Forms.TrackBar();
            this.button10RemoveNoise = new System.Windows.Forms.Button();
            this.button10SaveImage = new System.Windows.Forms.Button();
            this.button10ChooseImage = new System.Windows.Forms.Button();
            this.pictureBox10UntreatedImage = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage12and13 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonRefreshPanel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2SecondPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2SecondY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2SecondX)).BeginInit();
            this.groupBox2FirstPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2FirstY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2FirstX)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3Ellipse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3A)).BeginInit();
            this.groupBox3Circle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3Radius)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox4AddingPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4X)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox6AddingPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6X)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7ExploredImage)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8UntreatedImage)).BeginInit();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9UpperLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9LowerLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9UntreatedImage)).BeginInit();
            this.tabPage10and11.SuspendLayout();
            this.tabControl10.SuspendLayout();
            this.tabPage10AddingNoise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10Probability)).BeginInit();
            this.groupBox10NoiseType.SuspendLayout();
            this.tabPage10RemovingNoise.SuspendLayout();
            this.tabControl10RemoveNoise.SuspendLayout();
            this.tabPage10Binary.SuspendLayout();
            this.groupBox10BinaryFilterType.SuspendLayout();
            this.tabPage10Halftone.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10NeighbourhoodSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10UntreatedImage)).BeginInit();
            this.tabPage12and13.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPixel
            // 
            this.panelPixel.BackColor = System.Drawing.Color.White;
            this.panelPixel.Location = new System.Drawing.Point(0, 0);
            this.panelPixel.Name = "panelPixel";
            this.panelPixel.Size = new System.Drawing.Size(900, 600);
            this.panelPixel.TabIndex = 0;
            this.panelPixel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPixel_Paint);
            // 
            // panelHistogram
            // 
            this.panelHistogram.BackColor = System.Drawing.Color.White;
            this.panelHistogram.Location = new System.Drawing.Point(0, 0);
            this.panelHistogram.Name = "panelHistogram";
            this.panelHistogram.Size = new System.Drawing.Size(900, 600);
            this.panelHistogram.TabIndex = 1;
            this.panelHistogram.Visible = false;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(900, 600);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage6);
            this.tabControl.Controls.Add(this.tabPage7);
            this.tabControl.Controls.Add(this.tabPage8);
            this.tabControl.Controls.Add(this.tabPage9);
            this.tabControl.Controls.Add(this.tabPage10and11);
            this.tabControl.Controls.Add(this.tabPage12and13);
            this.tabControl.Controls.Add(this.tabPage14);
            this.tabControl.Controls.Add(this.tabPage15);
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl.ItemSize = new System.Drawing.Size(31, 20);
            this.tabControl.Location = new System.Drawing.Point(904, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(1);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(195, 545);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 11;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2DrawLine);
            this.tabPage2.Controls.Add(this.groupBox2SecondPoint);
            this.tabPage2.Controls.Add(this.groupBox2FirstPoint);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(187, 497);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2DrawLine
            // 
            this.button2DrawLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2DrawLine.Location = new System.Drawing.Point(14, 306);
            this.button2DrawLine.Name = "button2DrawLine";
            this.button2DrawLine.Size = new System.Drawing.Size(160, 53);
            this.button2DrawLine.TabIndex = 12;
            this.button2DrawLine.Text = "Draw line";
            this.button2DrawLine.UseVisualStyleBackColor = true;
            this.button2DrawLine.Click += new System.EventHandler(this.buttonDrawLine_Click);
            // 
            // groupBox2SecondPoint
            // 
            this.groupBox2SecondPoint.Controls.Add(this.numericUpDown2SecondY);
            this.groupBox2SecondPoint.Controls.Add(this.label2SecondY);
            this.groupBox2SecondPoint.Controls.Add(this.numericUpDown2SecondX);
            this.groupBox2SecondPoint.Controls.Add(this.label2SecondX);
            this.groupBox2SecondPoint.Location = new System.Drawing.Point(14, 175);
            this.groupBox2SecondPoint.Margin = new System.Windows.Forms.Padding(25);
            this.groupBox2SecondPoint.Name = "groupBox2SecondPoint";
            this.groupBox2SecondPoint.Size = new System.Drawing.Size(160, 103);
            this.groupBox2SecondPoint.TabIndex = 11;
            this.groupBox2SecondPoint.TabStop = false;
            this.groupBox2SecondPoint.Text = "Second point";
            // 
            // numericUpDown2SecondY
            // 
            this.numericUpDown2SecondY.Location = new System.Drawing.Point(55, 66);
            this.numericUpDown2SecondY.Margin = new System.Windows.Forms.Padding(10);
            this.numericUpDown2SecondY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown2SecondY.Name = "numericUpDown2SecondY";
            this.numericUpDown2SecondY.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown2SecondY.TabIndex = 2;
            // 
            // label2SecondY
            // 
            this.label2SecondY.AutoSize = true;
            this.label2SecondY.Location = new System.Drawing.Point(19, 68);
            this.label2SecondY.Name = "label2SecondY";
            this.label2SecondY.Size = new System.Drawing.Size(23, 13);
            this.label2SecondY.TabIndex = 5;
            this.label2SecondY.Text = "Y : ";
            // 
            // numericUpDown2SecondX
            // 
            this.numericUpDown2SecondX.Location = new System.Drawing.Point(55, 26);
            this.numericUpDown2SecondX.Margin = new System.Windows.Forms.Padding(10);
            this.numericUpDown2SecondX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown2SecondX.Name = "numericUpDown2SecondX";
            this.numericUpDown2SecondX.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown2SecondX.TabIndex = 1;
            // 
            // label2SecondX
            // 
            this.label2SecondX.AutoSize = true;
            this.label2SecondX.Location = new System.Drawing.Point(19, 28);
            this.label2SecondX.Name = "label2SecondX";
            this.label2SecondX.Size = new System.Drawing.Size(23, 13);
            this.label2SecondX.TabIndex = 4;
            this.label2SecondX.Text = "X : ";
            // 
            // groupBox2FirstPoint
            // 
            this.groupBox2FirstPoint.Controls.Add(this.numericUpDown2FirstY);
            this.groupBox2FirstPoint.Controls.Add(this.label2FirstY);
            this.groupBox2FirstPoint.Controls.Add(this.numericUpDown2FirstX);
            this.groupBox2FirstPoint.Controls.Add(this.label2FirstX);
            this.groupBox2FirstPoint.Location = new System.Drawing.Point(14, 54);
            this.groupBox2FirstPoint.Margin = new System.Windows.Forms.Padding(25);
            this.groupBox2FirstPoint.Name = "groupBox2FirstPoint";
            this.groupBox2FirstPoint.Size = new System.Drawing.Size(160, 103);
            this.groupBox2FirstPoint.TabIndex = 10;
            this.groupBox2FirstPoint.TabStop = false;
            this.groupBox2FirstPoint.Text = "First point";
            // 
            // numericUpDown2FirstY
            // 
            this.numericUpDown2FirstY.Location = new System.Drawing.Point(55, 66);
            this.numericUpDown2FirstY.Margin = new System.Windows.Forms.Padding(10);
            this.numericUpDown2FirstY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown2FirstY.Name = "numericUpDown2FirstY";
            this.numericUpDown2FirstY.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown2FirstY.TabIndex = 2;
            // 
            // label2FirstY
            // 
            this.label2FirstY.AutoSize = true;
            this.label2FirstY.Location = new System.Drawing.Point(19, 68);
            this.label2FirstY.Name = "label2FirstY";
            this.label2FirstY.Size = new System.Drawing.Size(23, 13);
            this.label2FirstY.TabIndex = 5;
            this.label2FirstY.Text = "Y : ";
            // 
            // numericUpDown2FirstX
            // 
            this.numericUpDown2FirstX.Location = new System.Drawing.Point(55, 26);
            this.numericUpDown2FirstX.Margin = new System.Windows.Forms.Padding(10);
            this.numericUpDown2FirstX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown2FirstX.Name = "numericUpDown2FirstX";
            this.numericUpDown2FirstX.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown2FirstX.TabIndex = 1;
            // 
            // label2FirstX
            // 
            this.label2FirstX.AutoSize = true;
            this.label2FirstX.Location = new System.Drawing.Point(19, 28);
            this.label2FirstX.Name = "label2FirstX";
            this.label2FirstX.Size = new System.Drawing.Size(23, 13);
            this.label2FirstX.TabIndex = 4;
            this.label2FirstX.Text = "X : ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Drawing lines";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.groupBox3Ellipse);
            this.tabPage3.Controls.Add(this.groupBox3Circle);
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(187, 497);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Drawing a circle and an ellipse";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3Ellipse
            // 
            this.groupBox3Ellipse.Controls.Add(this.button3DrawEllipse);
            this.groupBox3Ellipse.Controls.Add(this.numericUpDown3B);
            this.groupBox3Ellipse.Controls.Add(this.label3B);
            this.groupBox3Ellipse.Controls.Add(this.numericUpDown3A);
            this.groupBox3Ellipse.Controls.Add(this.label3A);
            this.groupBox3Ellipse.Location = new System.Drawing.Point(10, 204);
            this.groupBox3Ellipse.Margin = new System.Windows.Forms.Padding(25);
            this.groupBox3Ellipse.Name = "groupBox3Ellipse";
            this.groupBox3Ellipse.Size = new System.Drawing.Size(164, 161);
            this.groupBox3Ellipse.TabIndex = 7;
            this.groupBox3Ellipse.TabStop = false;
            this.groupBox3Ellipse.Text = "Ellipse";
            // 
            // button3DrawEllipse
            // 
            this.button3DrawEllipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3DrawEllipse.Location = new System.Drawing.Point(6, 99);
            this.button3DrawEllipse.Name = "button3DrawEllipse";
            this.button3DrawEllipse.Size = new System.Drawing.Size(150, 45);
            this.button3DrawEllipse.TabIndex = 9;
            this.button3DrawEllipse.Text = "Draw ellipse";
            this.button3DrawEllipse.UseVisualStyleBackColor = true;
            this.button3DrawEllipse.Click += new System.EventHandler(this.buttonDrawEllipse_Click);
            // 
            // numericUpDown3B
            // 
            this.numericUpDown3B.Location = new System.Drawing.Point(55, 66);
            this.numericUpDown3B.Margin = new System.Windows.Forms.Padding(10);
            this.numericUpDown3B.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown3B.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3B.Name = "numericUpDown3B";
            this.numericUpDown3B.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown3B.TabIndex = 2;
            this.numericUpDown3B.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3B
            // 
            this.label3B.Location = new System.Drawing.Point(25, 66);
            this.label3B.Name = "label3B";
            this.label3B.Size = new System.Drawing.Size(25, 20);
            this.label3B.TabIndex = 5;
            this.label3B.Text = "B : ";
            this.label3B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown3A
            // 
            this.numericUpDown3A.Location = new System.Drawing.Point(55, 28);
            this.numericUpDown3A.Margin = new System.Windows.Forms.Padding(10);
            this.numericUpDown3A.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown3A.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3A.Name = "numericUpDown3A";
            this.numericUpDown3A.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown3A.TabIndex = 1;
            this.numericUpDown3A.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3A
            // 
            this.label3A.Location = new System.Drawing.Point(25, 28);
            this.label3A.Name = "label3A";
            this.label3A.Size = new System.Drawing.Size(25, 20);
            this.label3A.TabIndex = 4;
            this.label3A.Text = "A : ";
            this.label3A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3Circle
            // 
            this.groupBox3Circle.Controls.Add(this.button3DrawCircle);
            this.groupBox3Circle.Controls.Add(this.numericUpDown3Radius);
            this.groupBox3Circle.Controls.Add(this.label3Radius);
            this.groupBox3Circle.Location = new System.Drawing.Point(10, 52);
            this.groupBox3Circle.Margin = new System.Windows.Forms.Padding(25);
            this.groupBox3Circle.Name = "groupBox3Circle";
            this.groupBox3Circle.Size = new System.Drawing.Size(164, 126);
            this.groupBox3Circle.TabIndex = 6;
            this.groupBox3Circle.TabStop = false;
            this.groupBox3Circle.Text = "Circle";
            // 
            // button3DrawCircle
            // 
            this.button3DrawCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3DrawCircle.Location = new System.Drawing.Point(6, 59);
            this.button3DrawCircle.Name = "button3DrawCircle";
            this.button3DrawCircle.Size = new System.Drawing.Size(150, 45);
            this.button3DrawCircle.TabIndex = 8;
            this.button3DrawCircle.Text = "Draw circle";
            this.button3DrawCircle.UseVisualStyleBackColor = true;
            this.button3DrawCircle.Click += new System.EventHandler(this.buttonDrawCircle_Click);
            // 
            // numericUpDown3Radius
            // 
            this.numericUpDown3Radius.Location = new System.Drawing.Point(55, 26);
            this.numericUpDown3Radius.Margin = new System.Windows.Forms.Padding(10);
            this.numericUpDown3Radius.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown3Radius.Name = "numericUpDown3Radius";
            this.numericUpDown3Radius.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown3Radius.TabIndex = 1;
            // 
            // label3Radius
            // 
            this.label3Radius.AutoSize = true;
            this.label3Radius.Location = new System.Drawing.Point(6, 28);
            this.label3Radius.Name = "label3Radius";
            this.label3Radius.Size = new System.Drawing.Size(49, 13);
            this.label3Radius.TabIndex = 4;
            this.label3Radius.Text = "Radius : ";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listBox4Vertexes);
            this.tabPage4.Controls.Add(this.button4FillPolygon);
            this.tabPage4.Controls.Add(this.button4AddPoint);
            this.tabPage4.Controls.Add(this.groupBox4AddingPoint);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Location = new System.Drawing.Point(4, 44);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(187, 497);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listBox4Vertexes
            // 
            this.listBox4Vertexes.FormattingEnabled = true;
            this.listBox4Vertexes.Location = new System.Drawing.Point(7, 29);
            this.listBox4Vertexes.Name = "listBox4Vertexes";
            this.listBox4Vertexes.Size = new System.Drawing.Size(174, 121);
            this.listBox4Vertexes.TabIndex = 15;
            // 
            // button4FillPolygon
            // 
            this.button4FillPolygon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4FillPolygon.Location = new System.Drawing.Point(6, 330);
            this.button4FillPolygon.Name = "button4FillPolygon";
            this.button4FillPolygon.Size = new System.Drawing.Size(174, 57);
            this.button4FillPolygon.TabIndex = 14;
            this.button4FillPolygon.Text = "Fill polygon";
            this.button4FillPolygon.UseVisualStyleBackColor = true;
            this.button4FillPolygon.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // button4AddPoint
            // 
            this.button4AddPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4AddPoint.Location = new System.Drawing.Point(7, 271);
            this.button4AddPoint.Name = "button4AddPoint";
            this.button4AddPoint.Size = new System.Drawing.Size(174, 40);
            this.button4AddPoint.TabIndex = 13;
            this.button4AddPoint.Text = "Add point";
            this.button4AddPoint.UseVisualStyleBackColor = true;
            this.button4AddPoint.Click += new System.EventHandler(this.buttonAddPoint_Click);
            // 
            // groupBox4AddingPoint
            // 
            this.groupBox4AddingPoint.Controls.Add(this.numericUpDown4Y);
            this.groupBox4AddingPoint.Controls.Add(this.label4Y);
            this.groupBox4AddingPoint.Controls.Add(this.numericUpDown4X);
            this.groupBox4AddingPoint.Controls.Add(this.label4X);
            this.groupBox4AddingPoint.Location = new System.Drawing.Point(7, 161);
            this.groupBox4AddingPoint.Margin = new System.Windows.Forms.Padding(25);
            this.groupBox4AddingPoint.Name = "groupBox4AddingPoint";
            this.groupBox4AddingPoint.Size = new System.Drawing.Size(174, 103);
            this.groupBox4AddingPoint.TabIndex = 12;
            this.groupBox4AddingPoint.TabStop = false;
            this.groupBox4AddingPoint.Text = "New point";
            // 
            // numericUpDown4Y
            // 
            this.numericUpDown4Y.Location = new System.Drawing.Point(55, 66);
            this.numericUpDown4Y.Margin = new System.Windows.Forms.Padding(10);
            this.numericUpDown4Y.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown4Y.Name = "numericUpDown4Y";
            this.numericUpDown4Y.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown4Y.TabIndex = 2;
            // 
            // label4Y
            // 
            this.label4Y.AutoSize = true;
            this.label4Y.Location = new System.Drawing.Point(19, 68);
            this.label4Y.Name = "label4Y";
            this.label4Y.Size = new System.Drawing.Size(23, 13);
            this.label4Y.TabIndex = 5;
            this.label4Y.Text = "Y : ";
            // 
            // numericUpDown4X
            // 
            this.numericUpDown4X.Location = new System.Drawing.Point(55, 26);
            this.numericUpDown4X.Margin = new System.Windows.Forms.Padding(10);
            this.numericUpDown4X.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown4X.Name = "numericUpDown4X";
            this.numericUpDown4X.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown4X.TabIndex = 1;
            // 
            // label4X
            // 
            this.label4X.AutoSize = true;
            this.label4X.Location = new System.Drawing.Point(19, 28);
            this.label4X.Name = "label4X";
            this.label4X.Size = new System.Drawing.Size(23, 13);
            this.label4X.TabIndex = 4;
            this.label4X.Text = "X : ";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Filling polygons";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Location = new System.Drawing.Point(4, 44);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(187, 497);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Clipping";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button6DrawBezierCurve);
            this.tabPage6.Controls.Add(this.button6AddPoint);
            this.tabPage6.Controls.Add(this.groupBox6AddingPoint);
            this.tabPage6.Controls.Add(this.listBox6Points);
            this.tabPage6.Controls.Add(this.label6);
            this.tabPage6.Location = new System.Drawing.Point(4, 44);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(187, 497);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // button6DrawBezierCurve
            // 
            this.button6DrawBezierCurve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6DrawBezierCurve.Location = new System.Drawing.Point(7, 330);
            this.button6DrawBezierCurve.Name = "button6DrawBezierCurve";
            this.button6DrawBezierCurve.Size = new System.Drawing.Size(174, 57);
            this.button6DrawBezierCurve.TabIndex = 19;
            this.button6DrawBezierCurve.Text = "Draw Bezier curve";
            this.button6DrawBezierCurve.UseVisualStyleBackColor = true;
            this.button6DrawBezierCurve.Click += new System.EventHandler(this.button6DrawBezierCurve_Click);
            // 
            // button6AddPoint
            // 
            this.button6AddPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6AddPoint.Location = new System.Drawing.Point(7, 271);
            this.button6AddPoint.Name = "button6AddPoint";
            this.button6AddPoint.Size = new System.Drawing.Size(174, 40);
            this.button6AddPoint.TabIndex = 18;
            this.button6AddPoint.Text = "Add point";
            this.button6AddPoint.UseVisualStyleBackColor = true;
            this.button6AddPoint.Click += new System.EventHandler(this.button6AddPoint_Click);
            // 
            // groupBox6AddingPoint
            // 
            this.groupBox6AddingPoint.Controls.Add(this.numericUpDown6Y);
            this.groupBox6AddingPoint.Controls.Add(this.label6Y);
            this.groupBox6AddingPoint.Controls.Add(this.numericUpDown6X);
            this.groupBox6AddingPoint.Controls.Add(this.label6X);
            this.groupBox6AddingPoint.Location = new System.Drawing.Point(7, 161);
            this.groupBox6AddingPoint.Margin = new System.Windows.Forms.Padding(25);
            this.groupBox6AddingPoint.Name = "groupBox6AddingPoint";
            this.groupBox6AddingPoint.Size = new System.Drawing.Size(174, 103);
            this.groupBox6AddingPoint.TabIndex = 17;
            this.groupBox6AddingPoint.TabStop = false;
            this.groupBox6AddingPoint.Text = "New point";
            // 
            // numericUpDown6Y
            // 
            this.numericUpDown6Y.Location = new System.Drawing.Point(55, 66);
            this.numericUpDown6Y.Margin = new System.Windows.Forms.Padding(10);
            this.numericUpDown6Y.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown6Y.Name = "numericUpDown6Y";
            this.numericUpDown6Y.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown6Y.TabIndex = 2;
            // 
            // label6Y
            // 
            this.label6Y.AutoSize = true;
            this.label6Y.Location = new System.Drawing.Point(19, 68);
            this.label6Y.Name = "label6Y";
            this.label6Y.Size = new System.Drawing.Size(23, 13);
            this.label6Y.TabIndex = 5;
            this.label6Y.Text = "Y : ";
            // 
            // numericUpDown6X
            // 
            this.numericUpDown6X.Location = new System.Drawing.Point(55, 26);
            this.numericUpDown6X.Margin = new System.Windows.Forms.Padding(10);
            this.numericUpDown6X.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown6X.Name = "numericUpDown6X";
            this.numericUpDown6X.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown6X.TabIndex = 1;
            // 
            // label6X
            // 
            this.label6X.AutoSize = true;
            this.label6X.Location = new System.Drawing.Point(19, 28);
            this.label6X.Name = "label6X";
            this.label6X.Size = new System.Drawing.Size(23, 13);
            this.label6X.TabIndex = 4;
            this.label6X.Text = "X : ";
            // 
            // listBox6Points
            // 
            this.listBox6Points.FormattingEnabled = true;
            this.listBox6Points.Location = new System.Drawing.Point(7, 29);
            this.listBox6Points.Name = "listBox6Points";
            this.listBox6Points.Size = new System.Drawing.Size(174, 121);
            this.listBox6Points.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Approximation of curves";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.button7BuildHistogram);
            this.tabPage7.Controls.Add(this.button7ChooseImage);
            this.tabPage7.Controls.Add(this.pictureBox7ExploredImage);
            this.tabPage7.Controls.Add(this.label7);
            this.tabPage7.Location = new System.Drawing.Point(4, 44);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(187, 497);
            this.tabPage7.TabIndex = 5;
            this.tabPage7.Text = "7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // button7BuildHistogram
            // 
            this.button7BuildHistogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7BuildHistogram.Location = new System.Drawing.Point(5, 299);
            this.button7BuildHistogram.Name = "button7BuildHistogram";
            this.button7BuildHistogram.Size = new System.Drawing.Size(175, 60);
            this.button7BuildHistogram.TabIndex = 15;
            this.button7BuildHistogram.Text = "Build a histogram";
            this.button7BuildHistogram.UseVisualStyleBackColor = true;
            this.button7BuildHistogram.Click += new System.EventHandler(this.button7BuildHistogram_Click);
            // 
            // button7ChooseImage
            // 
            this.button7ChooseImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7ChooseImage.Location = new System.Drawing.Point(5, 211);
            this.button7ChooseImage.Name = "button7ChooseImage";
            this.button7ChooseImage.Size = new System.Drawing.Size(175, 50);
            this.button7ChooseImage.TabIndex = 14;
            this.button7ChooseImage.Text = "Choose image";
            this.button7ChooseImage.UseVisualStyleBackColor = true;
            this.button7ChooseImage.Click += new System.EventHandler(this.button7ChooseImage_Click);
            // 
            // pictureBox7ExploredImage
            // 
            this.pictureBox7ExploredImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7ExploredImage.Location = new System.Drawing.Point(5, 25);
            this.pictureBox7ExploredImage.Name = "pictureBox7ExploredImage";
            this.pictureBox7ExploredImage.Size = new System.Drawing.Size(176, 165);
            this.pictureBox7ExploredImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7ExploredImage.TabIndex = 13;
            this.pictureBox7ExploredImage.TabStop = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "Building an image histogram";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.button8SaveImage);
            this.tabPage8.Controls.Add(this.button8ChooseImage);
            this.tabPage8.Controls.Add(this.pictureBox8UntreatedImage);
            this.tabPage8.Controls.Add(this.button8ConvertingToHalftone);
            this.tabPage8.Controls.Add(this.label8);
            this.tabPage8.Location = new System.Drawing.Point(4, 44);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(187, 497);
            this.tabPage8.TabIndex = 6;
            this.tabPage8.Text = "8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // button8SaveImage
            // 
            this.button8SaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8SaveImage.Location = new System.Drawing.Point(96, 205);
            this.button8SaveImage.Name = "button8SaveImage";
            this.button8SaveImage.Size = new System.Drawing.Size(85, 30);
            this.button8SaveImage.TabIndex = 14;
            this.button8SaveImage.Text = "Save";
            this.button8SaveImage.UseVisualStyleBackColor = true;
            this.button8SaveImage.Click += new System.EventHandler(this.button8Save_Click);
            // 
            // button8ChooseImage
            // 
            this.button8ChooseImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8ChooseImage.Location = new System.Drawing.Point(5, 205);
            this.button8ChooseImage.Name = "button8ChooseImage";
            this.button8ChooseImage.Size = new System.Drawing.Size(85, 30);
            this.button8ChooseImage.TabIndex = 13;
            this.button8ChooseImage.Text = "Choose image";
            this.button8ChooseImage.UseVisualStyleBackColor = true;
            this.button8ChooseImage.Click += new System.EventHandler(this.button8ChooseImage_Click);
            // 
            // pictureBox8UntreatedImage
            // 
            this.pictureBox8UntreatedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox8UntreatedImage.Location = new System.Drawing.Point(5, 35);
            this.pictureBox8UntreatedImage.Name = "pictureBox8UntreatedImage";
            this.pictureBox8UntreatedImage.Size = new System.Drawing.Size(176, 165);
            this.pictureBox8UntreatedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8UntreatedImage.TabIndex = 12;
            this.pictureBox8UntreatedImage.TabStop = false;
            // 
            // button8ConvertingToHalftone
            // 
            this.button8ConvertingToHalftone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8ConvertingToHalftone.Location = new System.Drawing.Point(5, 260);
            this.button8ConvertingToHalftone.Name = "button8ConvertingToHalftone";
            this.button8ConvertingToHalftone.Size = new System.Drawing.Size(176, 60);
            this.button8ConvertingToHalftone.TabIndex = 11;
            this.button8ConvertingToHalftone.Text = "Converting";
            this.button8ConvertingToHalftone.UseVisualStyleBackColor = true;
            this.button8ConvertingToHalftone.Click += new System.EventHandler(this.buttonConvertingToHalftone_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(187, 35);
            this.label8.TabIndex = 10;
            this.label8.Text = "Converting a color image to a halftone";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.label9UpperLimitValue);
            this.tabPage9.Controls.Add(this.label9LowerLimitValue);
            this.tabPage9.Controls.Add(this.label9UpperLimit);
            this.tabPage9.Controls.Add(this.label9LowerLimit);
            this.tabPage9.Controls.Add(this.trackBar9UpperLimit);
            this.tabPage9.Controls.Add(this.trackBar9LowerLimit);
            this.tabPage9.Controls.Add(this.comboBox9BinarizationMethods);
            this.tabPage9.Controls.Add(this.button9SaveImage);
            this.tabPage9.Controls.Add(this.button9ChooseImage);
            this.tabPage9.Controls.Add(this.button9ConvertingToBinary);
            this.tabPage9.Controls.Add(this.label9);
            this.tabPage9.Controls.Add(this.pictureBox9UntreatedImage);
            this.tabPage9.Location = new System.Drawing.Point(4, 44);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(187, 497);
            this.tabPage9.TabIndex = 7;
            this.tabPage9.Text = "9";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // label9UpperLimitValue
            // 
            this.label9UpperLimitValue.AutoSize = true;
            this.label9UpperLimitValue.Location = new System.Drawing.Point(94, 329);
            this.label9UpperLimitValue.Name = "label9UpperLimitValue";
            this.label9UpperLimitValue.Size = new System.Drawing.Size(25, 13);
            this.label9UpperLimitValue.TabIndex = 24;
            this.label9UpperLimitValue.Text = "128";
            // 
            // label9LowerLimitValue
            // 
            this.label9LowerLimitValue.AutoSize = true;
            this.label9LowerLimitValue.Location = new System.Drawing.Point(94, 265);
            this.label9LowerLimitValue.Name = "label9LowerLimitValue";
            this.label9LowerLimitValue.Size = new System.Drawing.Size(25, 13);
            this.label9LowerLimitValue.TabIndex = 23;
            this.label9LowerLimitValue.Text = "128";
            // 
            // label9UpperLimit
            // 
            this.label9UpperLimit.AutoSize = true;
            this.label9UpperLimit.Location = new System.Drawing.Point(28, 329);
            this.label9UpperLimit.Name = "label9UpperLimit";
            this.label9UpperLimit.Size = new System.Drawing.Size(62, 13);
            this.label9UpperLimit.TabIndex = 22;
            this.label9UpperLimit.Text = "Upper limit :";
            // 
            // label9LowerLimit
            // 
            this.label9LowerLimit.AutoSize = true;
            this.label9LowerLimit.Location = new System.Drawing.Point(28, 265);
            this.label9LowerLimit.Name = "label9LowerLimit";
            this.label9LowerLimit.Size = new System.Drawing.Size(62, 13);
            this.label9LowerLimit.TabIndex = 21;
            this.label9LowerLimit.Text = "Lower limit :";
            // 
            // trackBar9UpperLimit
            // 
            this.trackBar9UpperLimit.LargeChange = 32;
            this.trackBar9UpperLimit.Location = new System.Drawing.Point(7, 345);
            this.trackBar9UpperLimit.Maximum = 255;
            this.trackBar9UpperLimit.Name = "trackBar9UpperLimit";
            this.trackBar9UpperLimit.Size = new System.Drawing.Size(174, 45);
            this.trackBar9UpperLimit.SmallChange = 16;
            this.trackBar9UpperLimit.TabIndex = 20;
            this.trackBar9UpperLimit.TickFrequency = 16;
            this.trackBar9UpperLimit.Value = 128;
            this.trackBar9UpperLimit.Scroll += new System.EventHandler(this.trackBar9UpperLimit_Scroll);
            // 
            // trackBar9LowerLimit
            // 
            this.trackBar9LowerLimit.LargeChange = 32;
            this.trackBar9LowerLimit.Location = new System.Drawing.Point(7, 281);
            this.trackBar9LowerLimit.Maximum = 255;
            this.trackBar9LowerLimit.Name = "trackBar9LowerLimit";
            this.trackBar9LowerLimit.Size = new System.Drawing.Size(174, 45);
            this.trackBar9LowerLimit.SmallChange = 16;
            this.trackBar9LowerLimit.TabIndex = 19;
            this.trackBar9LowerLimit.TickFrequency = 16;
            this.trackBar9LowerLimit.Value = 128;
            this.trackBar9LowerLimit.Scroll += new System.EventHandler(this.trackBar9LowerLimit_Scroll);
            // 
            // comboBox9BinarizationMethods
            // 
            this.comboBox9BinarizationMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox9BinarizationMethods.Items.AddRange(new object[] {
            "With lower limit",
            "With upper limit",
            "Double-limited"});
            this.comboBox9BinarizationMethods.Location = new System.Drawing.Point(5, 235);
            this.comboBox9BinarizationMethods.Name = "comboBox9BinarizationMethods";
            this.comboBox9BinarizationMethods.Size = new System.Drawing.Size(176, 21);
            this.comboBox9BinarizationMethods.TabIndex = 18;
            this.comboBox9BinarizationMethods.SelectedIndexChanged += new System.EventHandler(this.comboBox9BinarizationMethods_SelectedIndexChanged);
            // 
            // button9SaveImage
            // 
            this.button9SaveImage.Location = new System.Drawing.Point(96, 195);
            this.button9SaveImage.Name = "button9SaveImage";
            this.button9SaveImage.Size = new System.Drawing.Size(85, 30);
            this.button9SaveImage.TabIndex = 17;
            this.button9SaveImage.Text = "Save";
            this.button9SaveImage.UseVisualStyleBackColor = true;
            this.button9SaveImage.Click += new System.EventHandler(this.button9SaveImage_Click);
            // 
            // button9ChooseImage
            // 
            this.button9ChooseImage.Location = new System.Drawing.Point(5, 195);
            this.button9ChooseImage.Name = "button9ChooseImage";
            this.button9ChooseImage.Size = new System.Drawing.Size(85, 30);
            this.button9ChooseImage.TabIndex = 16;
            this.button9ChooseImage.Text = "Choose image";
            this.button9ChooseImage.UseVisualStyleBackColor = true;
            this.button9ChooseImage.Click += new System.EventHandler(this.button9ChooseImage_Click);
            // 
            // button9ConvertingToBinary
            // 
            this.button9ConvertingToBinary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9ConvertingToBinary.Location = new System.Drawing.Point(5, 406);
            this.button9ConvertingToBinary.Name = "button9ConvertingToBinary";
            this.button9ConvertingToBinary.Size = new System.Drawing.Size(176, 49);
            this.button9ConvertingToBinary.TabIndex = 15;
            this.button9ConvertingToBinary.Text = "Converting";
            this.button9ConvertingToBinary.UseVisualStyleBackColor = true;
            this.button9ConvertingToBinary.Click += new System.EventHandler(this.button9ConvertingToBinary_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 25);
            this.label9.TabIndex = 14;
            this.label9.Text = "Binarization of halftone images";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox9UntreatedImage
            // 
            this.pictureBox9UntreatedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox9UntreatedImage.Location = new System.Drawing.Point(5, 25);
            this.pictureBox9UntreatedImage.Name = "pictureBox9UntreatedImage";
            this.pictureBox9UntreatedImage.Size = new System.Drawing.Size(176, 165);
            this.pictureBox9UntreatedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9UntreatedImage.TabIndex = 13;
            this.pictureBox9UntreatedImage.TabStop = false;
            // 
            // tabPage10and11
            // 
            this.tabPage10and11.Controls.Add(this.tabControl10);
            this.tabPage10and11.Controls.Add(this.button10SaveImage);
            this.tabPage10and11.Controls.Add(this.button10ChooseImage);
            this.tabPage10and11.Controls.Add(this.pictureBox10UntreatedImage);
            this.tabPage10and11.Controls.Add(this.label10);
            this.tabPage10and11.Location = new System.Drawing.Point(4, 44);
            this.tabPage10and11.Name = "tabPage10and11";
            this.tabPage10and11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10and11.Size = new System.Drawing.Size(187, 497);
            this.tabPage10and11.TabIndex = 8;
            this.tabPage10and11.Text = "10";
            this.tabPage10and11.UseVisualStyleBackColor = true;
            // 
            // tabControl10
            // 
            this.tabControl10.Controls.Add(this.tabPage10AddingNoise);
            this.tabControl10.Controls.Add(this.tabPage10RemovingNoise);
            this.tabControl10.Location = new System.Drawing.Point(7, 227);
            this.tabControl10.Name = "tabControl10";
            this.tabControl10.SelectedIndex = 0;
            this.tabControl10.Size = new System.Drawing.Size(173, 253);
            this.tabControl10.TabIndex = 19;
            // 
            // tabPage10AddingNoise
            // 
            this.tabPage10AddingNoise.Controls.Add(this.button10AddNoise);
            this.tabPage10AddingNoise.Controls.Add(this.label10ProbabilityValue);
            this.tabPage10AddingNoise.Controls.Add(this.label10Probability);
            this.tabPage10AddingNoise.Controls.Add(this.trackBar10Probability);
            this.tabPage10AddingNoise.Controls.Add(this.groupBox10NoiseType);
            this.tabPage10AddingNoise.Location = new System.Drawing.Point(4, 22);
            this.tabPage10AddingNoise.Name = "tabPage10AddingNoise";
            this.tabPage10AddingNoise.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10AddingNoise.Size = new System.Drawing.Size(165, 227);
            this.tabPage10AddingNoise.TabIndex = 0;
            this.tabPage10AddingNoise.Text = "Add noise";
            this.tabPage10AddingNoise.UseVisualStyleBackColor = true;
            // 
            // button10AddNoise
            // 
            this.button10AddNoise.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10AddNoise.Location = new System.Drawing.Point(6, 183);
            this.button10AddNoise.Name = "button10AddNoise";
            this.button10AddNoise.Size = new System.Drawing.Size(153, 38);
            this.button10AddNoise.TabIndex = 23;
            this.button10AddNoise.Text = "Add";
            this.button10AddNoise.UseVisualStyleBackColor = true;
            this.button10AddNoise.Click += new System.EventHandler(this.button10AddNoise_Click);
            // 
            // label10ProbabilityValue
            // 
            this.label10ProbabilityValue.AutoSize = true;
            this.label10ProbabilityValue.Location = new System.Drawing.Point(95, 90);
            this.label10ProbabilityValue.Name = "label10ProbabilityValue";
            this.label10ProbabilityValue.Size = new System.Drawing.Size(30, 13);
            this.label10ProbabilityValue.TabIndex = 22;
            this.label10ProbabilityValue.Text = "25 %";
            // 
            // label10Probability
            // 
            this.label10Probability.AutoSize = true;
            this.label10Probability.Location = new System.Drawing.Point(36, 90);
            this.label10Probability.Name = "label10Probability";
            this.label10Probability.Size = new System.Drawing.Size(61, 13);
            this.label10Probability.TabIndex = 21;
            this.label10Probability.Text = "Probability :";
            // 
            // trackBar10Probability
            // 
            this.trackBar10Probability.Location = new System.Drawing.Point(6, 109);
            this.trackBar10Probability.Maximum = 50;
            this.trackBar10Probability.Name = "trackBar10Probability";
            this.trackBar10Probability.Size = new System.Drawing.Size(153, 45);
            this.trackBar10Probability.SmallChange = 2;
            this.trackBar10Probability.TabIndex = 20;
            this.trackBar10Probability.TickFrequency = 5;
            this.trackBar10Probability.Value = 25;
            this.trackBar10Probability.Scroll += new System.EventHandler(this.trackBar10Probability_Scroll);
            // 
            // groupBox10NoiseType
            // 
            this.groupBox10NoiseType.Controls.Add(this.radioButton10ImpulseNoise);
            this.groupBox10NoiseType.Controls.Add(this.radioButton10SaltAndPepperNoise);
            this.groupBox10NoiseType.Location = new System.Drawing.Point(6, 6);
            this.groupBox10NoiseType.Name = "groupBox10NoiseType";
            this.groupBox10NoiseType.Size = new System.Drawing.Size(153, 71);
            this.groupBox10NoiseType.TabIndex = 0;
            this.groupBox10NoiseType.TabStop = false;
            this.groupBox10NoiseType.Text = "Noise type";
            // 
            // radioButton10ImpulseNoise
            // 
            this.radioButton10ImpulseNoise.AutoSize = true;
            this.radioButton10ImpulseNoise.Location = new System.Drawing.Point(7, 42);
            this.radioButton10ImpulseNoise.Name = "radioButton10ImpulseNoise";
            this.radioButton10ImpulseNoise.Size = new System.Drawing.Size(61, 17);
            this.radioButton10ImpulseNoise.TabIndex = 1;
            this.radioButton10ImpulseNoise.TabStop = true;
            this.radioButton10ImpulseNoise.Text = "Impulse";
            this.radioButton10ImpulseNoise.UseVisualStyleBackColor = true;
            // 
            // radioButton10SaltAndPepperNoise
            // 
            this.radioButton10SaltAndPepperNoise.AutoSize = true;
            this.radioButton10SaltAndPepperNoise.Checked = true;
            this.radioButton10SaltAndPepperNoise.Location = new System.Drawing.Point(7, 19);
            this.radioButton10SaltAndPepperNoise.Name = "radioButton10SaltAndPepperNoise";
            this.radioButton10SaltAndPepperNoise.Size = new System.Drawing.Size(100, 17);
            this.radioButton10SaltAndPepperNoise.TabIndex = 0;
            this.radioButton10SaltAndPepperNoise.TabStop = true;
            this.radioButton10SaltAndPepperNoise.Text = "Salt and pepper";
            this.radioButton10SaltAndPepperNoise.UseVisualStyleBackColor = true;
            // 
            // tabPage10RemovingNoise
            // 
            this.tabPage10RemovingNoise.Controls.Add(this.tabControl10RemoveNoise);
            this.tabPage10RemovingNoise.Controls.Add(this.label10NeighbourhoodSizeValue);
            this.tabPage10RemovingNoise.Controls.Add(this.label10NeighbourhoodSize);
            this.tabPage10RemovingNoise.Controls.Add(this.trackBar10NeighbourhoodSize);
            this.tabPage10RemovingNoise.Controls.Add(this.button10RemoveNoise);
            this.tabPage10RemovingNoise.Location = new System.Drawing.Point(4, 22);
            this.tabPage10RemovingNoise.Name = "tabPage10RemovingNoise";
            this.tabPage10RemovingNoise.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10RemovingNoise.Size = new System.Drawing.Size(165, 227);
            this.tabPage10RemovingNoise.TabIndex = 1;
            this.tabPage10RemovingNoise.Text = "Remove noise";
            this.tabPage10RemovingNoise.UseVisualStyleBackColor = true;
            // 
            // tabControl10RemoveNoise
            // 
            this.tabControl10RemoveNoise.Controls.Add(this.tabPage10Binary);
            this.tabControl10RemoveNoise.Controls.Add(this.tabPage10Halftone);
            this.tabControl10RemoveNoise.Location = new System.Drawing.Point(4, 6);
            this.tabControl10RemoveNoise.Name = "tabControl10RemoveNoise";
            this.tabControl10RemoveNoise.SelectedIndex = 0;
            this.tabControl10RemoveNoise.Size = new System.Drawing.Size(158, 107);
            this.tabControl10RemoveNoise.TabIndex = 28;
            // 
            // tabPage10Binary
            // 
            this.tabPage10Binary.Controls.Add(this.groupBox10BinaryFilterType);
            this.tabPage10Binary.Location = new System.Drawing.Point(4, 22);
            this.tabPage10Binary.Name = "tabPage10Binary";
            this.tabPage10Binary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10Binary.Size = new System.Drawing.Size(150, 81);
            this.tabPage10Binary.TabIndex = 0;
            this.tabPage10Binary.Text = "Binary";
            this.tabPage10Binary.UseVisualStyleBackColor = true;
            // 
            // groupBox10BinaryFilterType
            // 
            this.groupBox10BinaryFilterType.Controls.Add(this.radioButton10BinaryMedianFilter);
            this.groupBox10BinaryFilterType.Controls.Add(this.radioButton10BinaryLogicalFilter);
            this.groupBox10BinaryFilterType.Location = new System.Drawing.Point(6, 6);
            this.groupBox10BinaryFilterType.Name = "groupBox10BinaryFilterType";
            this.groupBox10BinaryFilterType.Size = new System.Drawing.Size(138, 69);
            this.groupBox10BinaryFilterType.TabIndex = 1;
            this.groupBox10BinaryFilterType.TabStop = false;
            this.groupBox10BinaryFilterType.Text = "Filter type";
            // 
            // radioButton10BinaryMedianFilter
            // 
            this.radioButton10BinaryMedianFilter.AutoSize = true;
            this.radioButton10BinaryMedianFilter.Location = new System.Drawing.Point(7, 42);
            this.radioButton10BinaryMedianFilter.Name = "radioButton10BinaryMedianFilter";
            this.radioButton10BinaryMedianFilter.Size = new System.Drawing.Size(60, 17);
            this.radioButton10BinaryMedianFilter.TabIndex = 1;
            this.radioButton10BinaryMedianFilter.TabStop = true;
            this.radioButton10BinaryMedianFilter.Text = "Median";
            this.radioButton10BinaryMedianFilter.UseVisualStyleBackColor = true;
            // 
            // radioButton10BinaryLogicalFilter
            // 
            this.radioButton10BinaryLogicalFilter.AutoSize = true;
            this.radioButton10BinaryLogicalFilter.Checked = true;
            this.radioButton10BinaryLogicalFilter.Location = new System.Drawing.Point(7, 19);
            this.radioButton10BinaryLogicalFilter.Name = "radioButton10BinaryLogicalFilter";
            this.radioButton10BinaryLogicalFilter.Size = new System.Drawing.Size(59, 17);
            this.radioButton10BinaryLogicalFilter.TabIndex = 0;
            this.radioButton10BinaryLogicalFilter.TabStop = true;
            this.radioButton10BinaryLogicalFilter.Text = "Logical";
            this.radioButton10BinaryLogicalFilter.UseVisualStyleBackColor = true;
            // 
            // tabPage10Halftone
            // 
            this.tabPage10Halftone.Controls.Add(this.groupBox1);
            this.tabPage10Halftone.Location = new System.Drawing.Point(4, 22);
            this.tabPage10Halftone.Name = "tabPage10Halftone";
            this.tabPage10Halftone.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10Halftone.Size = new System.Drawing.Size(150, 81);
            this.tabPage10Halftone.TabIndex = 1;
            this.tabPage10Halftone.Text = "Halftone";
            this.tabPage10Halftone.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton10HalftoneMedianFilter);
            this.groupBox1.Controls.Add(this.radioButton10HalftoneAveragingFilter);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 69);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter type";
            // 
            // radioButton10HalftoneMedianFilter
            // 
            this.radioButton10HalftoneMedianFilter.AutoSize = true;
            this.radioButton10HalftoneMedianFilter.Location = new System.Drawing.Point(7, 42);
            this.radioButton10HalftoneMedianFilter.Name = "radioButton10HalftoneMedianFilter";
            this.radioButton10HalftoneMedianFilter.Size = new System.Drawing.Size(60, 17);
            this.radioButton10HalftoneMedianFilter.TabIndex = 1;
            this.radioButton10HalftoneMedianFilter.TabStop = true;
            this.radioButton10HalftoneMedianFilter.Text = "Median";
            this.radioButton10HalftoneMedianFilter.UseVisualStyleBackColor = true;
            // 
            // radioButton10HalftoneAveragingFilter
            // 
            this.radioButton10HalftoneAveragingFilter.AutoSize = true;
            this.radioButton10HalftoneAveragingFilter.Checked = true;
            this.radioButton10HalftoneAveragingFilter.Location = new System.Drawing.Point(7, 19);
            this.radioButton10HalftoneAveragingFilter.Name = "radioButton10HalftoneAveragingFilter";
            this.radioButton10HalftoneAveragingFilter.Size = new System.Drawing.Size(73, 17);
            this.radioButton10HalftoneAveragingFilter.TabIndex = 0;
            this.radioButton10HalftoneAveragingFilter.TabStop = true;
            this.radioButton10HalftoneAveragingFilter.Text = "Averaging";
            this.radioButton10HalftoneAveragingFilter.UseVisualStyleBackColor = true;
            // 
            // label10NeighbourhoodSizeValue
            // 
            this.label10NeighbourhoodSizeValue.AutoSize = true;
            this.label10NeighbourhoodSizeValue.Location = new System.Drawing.Point(110, 116);
            this.label10NeighbourhoodSizeValue.Name = "label10NeighbourhoodSizeValue";
            this.label10NeighbourhoodSizeValue.Size = new System.Drawing.Size(30, 13);
            this.label10NeighbourhoodSizeValue.TabIndex = 27;
            this.label10NeighbourhoodSizeValue.Text = "3 x 3";
            // 
            // label10NeighbourhoodSize
            // 
            this.label10NeighbourhoodSize.AutoSize = true;
            this.label10NeighbourhoodSize.Location = new System.Drawing.Point(6, 116);
            this.label10NeighbourhoodSize.Name = "label10NeighbourhoodSize";
            this.label10NeighbourhoodSize.Size = new System.Drawing.Size(107, 13);
            this.label10NeighbourhoodSize.TabIndex = 26;
            this.label10NeighbourhoodSize.Text = "Neighbourhood size :";
            // 
            // trackBar10NeighbourhoodSize
            // 
            this.trackBar10NeighbourhoodSize.LargeChange = 1;
            this.trackBar10NeighbourhoodSize.Location = new System.Drawing.Point(6, 132);
            this.trackBar10NeighbourhoodSize.Maximum = 7;
            this.trackBar10NeighbourhoodSize.Minimum = 1;
            this.trackBar10NeighbourhoodSize.Name = "trackBar10NeighbourhoodSize";
            this.trackBar10NeighbourhoodSize.Size = new System.Drawing.Size(153, 45);
            this.trackBar10NeighbourhoodSize.TabIndex = 25;
            this.trackBar10NeighbourhoodSize.Value = 1;
            this.trackBar10NeighbourhoodSize.Scroll += new System.EventHandler(this.trackBar10NeighbourhoodSize_Scroll);
            // 
            // button10RemoveNoise
            // 
            this.button10RemoveNoise.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10RemoveNoise.Location = new System.Drawing.Point(6, 183);
            this.button10RemoveNoise.Name = "button10RemoveNoise";
            this.button10RemoveNoise.Size = new System.Drawing.Size(153, 38);
            this.button10RemoveNoise.TabIndex = 24;
            this.button10RemoveNoise.Text = "Remove";
            this.button10RemoveNoise.UseVisualStyleBackColor = true;
            this.button10RemoveNoise.Click += new System.EventHandler(this.button10RemoveNoise_Click);
            // 
            // button10SaveImage
            // 
            this.button10SaveImage.Location = new System.Drawing.Point(96, 195);
            this.button10SaveImage.Name = "button10SaveImage";
            this.button10SaveImage.Size = new System.Drawing.Size(85, 30);
            this.button10SaveImage.TabIndex = 18;
            this.button10SaveImage.Text = "Save";
            this.button10SaveImage.UseVisualStyleBackColor = true;
            this.button10SaveImage.Click += new System.EventHandler(this.button10SaveImage_Click);
            // 
            // button10ChooseImage
            // 
            this.button10ChooseImage.Location = new System.Drawing.Point(5, 195);
            this.button10ChooseImage.Name = "button10ChooseImage";
            this.button10ChooseImage.Size = new System.Drawing.Size(85, 30);
            this.button10ChooseImage.TabIndex = 17;
            this.button10ChooseImage.Text = "Choose image";
            this.button10ChooseImage.UseVisualStyleBackColor = true;
            this.button10ChooseImage.Click += new System.EventHandler(this.button10ChooseImage_Click);
            // 
            // pictureBox10UntreatedImage
            // 
            this.pictureBox10UntreatedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox10UntreatedImage.Location = new System.Drawing.Point(5, 25);
            this.pictureBox10UntreatedImage.Name = "pictureBox10UntreatedImage";
            this.pictureBox10UntreatedImage.Size = new System.Drawing.Size(176, 165);
            this.pictureBox10UntreatedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10UntreatedImage.TabIndex = 16;
            this.pictureBox10UntreatedImage.TabStop = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 25);
            this.label10.TabIndex = 15;
            this.label10.Text = "Noise elimination";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage12and13
            // 
            this.tabPage12and13.Controls.Add(this.label12);
            this.tabPage12and13.Location = new System.Drawing.Point(4, 44);
            this.tabPage12and13.Name = "tabPage12and13";
            this.tabPage12and13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12and13.Size = new System.Drawing.Size(187, 497);
            this.tabPage12and13.TabIndex = 10;
            this.tabPage12and13.Text = "12";
            this.tabPage12and13.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(187, 25);
            this.label12.TabIndex = 16;
            this.label12.Text = "Selecting object borders";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.label14);
            this.tabPage14.Location = new System.Drawing.Point(4, 44);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(187, 497);
            this.tabPage14.TabIndex = 12;
            this.tabPage14.Text = "14";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(187, 25);
            this.label14.TabIndex = 16;
            this.label14.Text = "Segmentation of images";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.label15);
            this.tabPage15.Location = new System.Drawing.Point(4, 44);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(187, 497);
            this.tabPage15.TabIndex = 13;
            this.tabPage15.Text = "15";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(187, 25);
            this.label15.TabIndex = 16;
            this.label15.Text = "Text recognition on image";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRefreshPanel
            // 
            this.buttonRefreshPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRefreshPanel.Location = new System.Drawing.Point(908, 547);
            this.buttonRefreshPanel.Margin = new System.Windows.Forms.Padding(1);
            this.buttonRefreshPanel.Name = "buttonRefreshPanel";
            this.buttonRefreshPanel.Size = new System.Drawing.Size(187, 50);
            this.buttonRefreshPanel.TabIndex = 12;
            this.buttonRefreshPanel.Text = "Refresh panel";
            this.buttonRefreshPanel.UseVisualStyleBackColor = true;
            this.buttonRefreshPanel.Click += new System.EventHandler(this.buttonRefreshPanel_Click);
            // 
            // ComputerGraphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.buttonRefreshPanel);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelHistogram);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panelPixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1116, 638);
            this.MinimumSize = new System.Drawing.Size(1116, 638);
            this.Name = "ComputerGraphics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computer graphics";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2SecondPoint.ResumeLayout(false);
            this.groupBox2SecondPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2SecondY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2SecondX)).EndInit();
            this.groupBox2FirstPoint.ResumeLayout(false);
            this.groupBox2FirstPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2FirstY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2FirstX)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3Ellipse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3A)).EndInit();
            this.groupBox3Circle.ResumeLayout(false);
            this.groupBox3Circle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3Radius)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox4AddingPoint.ResumeLayout(false);
            this.groupBox4AddingPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4X)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.groupBox6AddingPoint.ResumeLayout(false);
            this.groupBox6AddingPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6X)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7ExploredImage)).EndInit();
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8UntreatedImage)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9UpperLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9LowerLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9UntreatedImage)).EndInit();
            this.tabPage10and11.ResumeLayout(false);
            this.tabControl10.ResumeLayout(false);
            this.tabPage10AddingNoise.ResumeLayout(false);
            this.tabPage10AddingNoise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10Probability)).EndInit();
            this.groupBox10NoiseType.ResumeLayout(false);
            this.groupBox10NoiseType.PerformLayout();
            this.tabPage10RemovingNoise.ResumeLayout(false);
            this.tabPage10RemovingNoise.PerformLayout();
            this.tabControl10RemoveNoise.ResumeLayout(false);
            this.tabPage10Binary.ResumeLayout(false);
            this.groupBox10BinaryFilterType.ResumeLayout(false);
            this.groupBox10BinaryFilterType.PerformLayout();
            this.tabPage10Halftone.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10NeighbourhoodSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10UntreatedImage)).EndInit();
            this.tabPage12and13.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.tabPage15.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPixel;
        private NumericUpDown numericUpDown3Radius;
        private Label label3Radius;
        private GroupBox groupBox3Circle;
        private GroupBox groupBox3Ellipse;
        private NumericUpDown numericUpDown3B;
        private Label label3B;
        private NumericUpDown numericUpDown3A;
        private Label label3A;
        private Button button3DrawCircle;
        private Button button3DrawEllipse;
        private TabControl tabControl;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private TabPage tabPage10and11;
        private TabPage tabPage12and13;
        private TabPage tabPage14;
        private TabPage tabPage15;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2FirstPoint;
        private NumericUpDown numericUpDown2FirstY;
        private Label label2FirstY;
        private NumericUpDown numericUpDown2FirstX;
        private Label label2FirstX;
        private GroupBox groupBox2SecondPoint;
        private NumericUpDown numericUpDown2SecondY;
        private Label label2SecondY;
        private NumericUpDown numericUpDown2SecondX;
        private Label label2SecondX;
        private Button button2DrawLine;
        private Button buttonRefreshPanel;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button4FillPolygon;
        private Button button4AddPoint;
        private GroupBox groupBox4AddingPoint;
        private NumericUpDown numericUpDown4Y;
        private Label label4Y;
        private NumericUpDown numericUpDown4X;
        private Label label4X;
        private PictureBox pictureBox;
        private Label label7;
        private Label label8;
        private Button button8ConvertingToHalftone;
        private PictureBox pictureBox8UntreatedImage;
        private Button button8ChooseImage;
        private Button button8SaveImage;
        private Label label9;
        private PictureBox pictureBox9UntreatedImage;
        private Button button9SaveImage;
        private Button button9ChooseImage;
        private Button button9ConvertingToBinary;
        private ComboBox comboBox9BinarizationMethods;
        private TrackBar trackBar9LowerLimit;
        private TrackBar trackBar9UpperLimit;
        private Label label9LowerLimit;
        private Label label9UpperLimit;
        private Label label9UpperLimitValue;
        private Label label9LowerLimitValue;
        private Button button7BuildHistogram;
        private Button button7ChooseImage;
        private PictureBox pictureBox7ExploredImage;
        private Panel panelHistogram;
        private Label label10;
        private Button button10SaveImage;
        private Button button10ChooseImage;
        private PictureBox pictureBox10UntreatedImage;
        private TabControl tabControl10;
        private TabPage tabPage10AddingNoise;
        private TabPage tabPage10RemovingNoise;
        private GroupBox groupBox10NoiseType;
        private RadioButton radioButton10ImpulseNoise;
        private RadioButton radioButton10SaltAndPepperNoise;
        private Label label10ProbabilityValue;
        private Label label10Probability;
        private TrackBar trackBar10Probability;
        private Button button10AddNoise;
        private Label label10NeighbourhoodSizeValue;
        private Label label10NeighbourhoodSize;
        private TrackBar trackBar10NeighbourhoodSize;
        private Button button10RemoveNoise;
        private GroupBox groupBox10BinaryFilterType;
        private RadioButton radioButton10BinaryMedianFilter;
        private RadioButton radioButton10BinaryLogicalFilter;
        private TabControl tabControl10RemoveNoise;
        private TabPage tabPage10Binary;
        private TabPage tabPage10Halftone;
        private GroupBox groupBox1;
        private RadioButton radioButton10HalftoneMedianFilter;
        private RadioButton radioButton10HalftoneAveragingFilter;
        private Label label12;
        private Label label14;
        private Label label15;
        private ListBox listBox4Vertexes;
        private GroupBox groupBox6AddingPoint;
        private NumericUpDown numericUpDown6Y;
        private Label label6Y;
        private NumericUpDown numericUpDown6X;
        private Label label6X;
        private ListBox listBox6Points;
        private Button button6DrawBezierCurve;
        private Button button6AddPoint;
    }
}
