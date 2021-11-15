namespace MiniGIS
{
    partial class MiniGIS_Makenova
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_ZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Center = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Hand = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_CurrentObject = new System.Windows.Forms.ToolStripButton();
            this.RulerStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripRulerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.MifFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.map1 = new MiniGIS.Map();
            this.layerControl1 = new MiniGIS.LayerControl();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_ZoomIn,
            this.toolStripButton_ZoomOut,
            this.toolStripButton_Center,
            this.toolStripButton_Hand,
            this.toolStripButton_CurrentObject,
            this.RulerStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(10, 10);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(902, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_ZoomIn
            // 
            this.toolStripButton_ZoomIn.CheckOnClick = true;
            this.toolStripButton_ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ZoomIn.Image = global::MiniGIS.Properties.Resources.icons8_плюс_24;
            this.toolStripButton_ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ZoomIn.Name = "toolStripButton_ZoomIn";
            this.toolStripButton_ZoomIn.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton_ZoomIn.Text = "приблизить";
            this.toolStripButton_ZoomIn.Click += new System.EventHandler(this.toolStripButton_ZoomIn_Click);
            // 
            // toolStripButton_ZoomOut
            // 
            this.toolStripButton_ZoomOut.CheckOnClick = true;
            this.toolStripButton_ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ZoomOut.Image = global::MiniGIS.Properties.Resources.icons8_минус_24;
            this.toolStripButton_ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ZoomOut.Name = "toolStripButton_ZoomOut";
            this.toolStripButton_ZoomOut.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton_ZoomOut.Text = "отдалить";
            this.toolStripButton_ZoomOut.Click += new System.EventHandler(this.toolStripButton_ZoomOut_Click);
            // 
            // toolStripButton_Center
            // 
            this.toolStripButton_Center.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Center.Image = global::MiniGIS.Properties.Resources.icons8_центр_притяжения_24;
            this.toolStripButton_Center.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Center.Name = "toolStripButton_Center";
            this.toolStripButton_Center.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton_Center.Text = "toolStripButton3";
            this.toolStripButton_Center.Click += new System.EventHandler(this.toolStripButton_Center_Click);
            // 
            // toolStripButton_Hand
            // 
            this.toolStripButton_Hand.CheckOnClick = true;
            this.toolStripButton_Hand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Hand.Image = global::MiniGIS.Properties.Resources.icons8_вся_рука_24;
            this.toolStripButton_Hand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Hand.Name = "toolStripButton_Hand";
            this.toolStripButton_Hand.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton_Hand.Text = "ладошка";
            this.toolStripButton_Hand.Click += new System.EventHandler(this.toolStripButton_Hand_Click);
            // 
            // toolStripButton_CurrentObject
            // 
            this.toolStripButton_CurrentObject.CheckOnClick = true;
            this.toolStripButton_CurrentObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_CurrentObject.Image = global::MiniGIS.Properties.Resources.icons8_маркер_24__1_;
            this.toolStripButton_CurrentObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_CurrentObject.Name = "toolStripButton_CurrentObject";
            this.toolStripButton_CurrentObject.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton_CurrentObject.Text = "toolStripButton5";
            this.toolStripButton_CurrentObject.Click += new System.EventHandler(this.toolStripButton_CurrentObject_Click);
            // 
            // RulerStripButton
            // 
            this.RulerStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RulerStripButton.Image = global::MiniGIS.Properties.Resources.icons8_линейка_24;
            this.RulerStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RulerStripButton.Name = "RulerStripButton";
            this.RulerStripButton.Size = new System.Drawing.Size(29, 24);
            this.RulerStripButton.Text = "toolStripButton1";
            this.RulerStripButton.Click += new System.EventHandler(this.RulerStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripRulerLabel});
            this.statusStrip1.Location = new System.Drawing.Point(10, 522);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(902, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolStripRulerLabel
            // 
            this.toolStripRulerLabel.Name = "toolStripRulerLabel";
            this.toolStripRulerLabel.Size = new System.Drawing.Size(151, 20);
            this.toolStripRulerLabel.Text = "toolStripStatusLabel4";
            this.toolStripRulerLabel.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(10, 37);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.map1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.layerControl1);
            this.splitContainer1.Size = new System.Drawing.Size(902, 485);
            this.splitContainer1.SplitterDistance = 598;
            this.splitContainer1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MifFileDialog
            // 
            this.MifFileDialog.FileName = "testMif";
            // 
            // map1
            // 
            this.map1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.map1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map1.Location = new System.Drawing.Point(0, 0);
            this.map1.Name = "map1";
            this.map1.Size = new System.Drawing.Size(598, 485);
            this.map1.TabIndex = 0;
            this.map1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.map1_MouseDown);
            this.map1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.map1_MouseMove);
            this.map1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.map1_MouseUp);
            // 
            // layerControl1
            // 
            this.layerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layerControl1.Location = new System.Drawing.Point(0, 0);
            this.layerControl1.Name = "layerControl1";
            this.layerControl1.Size = new System.Drawing.Size(300, 485);
            this.layerControl1.TabIndex = 0;
            // 
            // MiniGIS_Makenova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(922, 558);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MiniGIS_Makenova";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "MiniGIS";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Map map1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_ZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripButton_ZoomOut;
        private System.Windows.Forms.ToolStripButton toolStripButton_Center;
        private System.Windows.Forms.ToolStripButton toolStripButton_Hand;
        private System.Windows.Forms.ToolStripButton toolStripButton_CurrentObject;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private LayerControl layerControl1;
        private System.Windows.Forms.ToolStripButton RulerStripButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripRulerLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog MifFileDialog;
    }
}

