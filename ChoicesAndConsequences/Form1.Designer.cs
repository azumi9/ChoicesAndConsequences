namespace ChoicesAndConsequences
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new PictureBox();
            pbScene = new PictureBox();
            rtbStory = new RichTextBox();
            flpChoices = new FlowLayoutPanel();
            lbInventory = new CheckedListBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)button1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbScene).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(336, 75);
            button1.Name = "button1";
            button1.Size = new Size(125, 62);
            button1.TabIndex = 0;
            button1.TabStop = false;
            // 
            // pbScene
            // 
            pbScene.AccessibleName = "pbLocation";
            pbScene.Dock = DockStyle.Top;
            pbScene.Location = new Point(0, 0);
            pbScene.Name = "pbScene";
            pbScene.Size = new Size(1641, 737);
            pbScene.SizeMode = PictureBoxSizeMode.StretchImage;
            pbScene.TabIndex = 1;
            pbScene.TabStop = false;
            pbScene.Click += pbScene_Click;
            // 
            // rtbStory
            // 
            rtbStory.AccessibleName = "rtbSceneDescription";
            rtbStory.Font = new Font("Georgia", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rtbStory.Location = new Point(12, 743);
            rtbStory.Name = "rtbStory";
            rtbStory.ReadOnly = true;
            rtbStory.Size = new Size(1226, 81);
            rtbStory.TabIndex = 2;
            rtbStory.Text = "Ви стоїте перед старим особняком...";
            // 
            // flpChoices
            // 
            flpChoices.AccessibleName = "flpChoices";
            flpChoices.FlowDirection = FlowDirection.TopDown;
            flpChoices.Location = new Point(37, 830);
            flpChoices.Name = "flpChoices";
            flpChoices.Size = new Size(834, 71);
            flpChoices.TabIndex = 3;
            flpChoices.Paint += flpChoices_Paint;
            // 
            // lbInventory
            // 
            lbInventory.AccessibleName = "lbInventory";
            lbInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lbInventory.FormattingEnabled = true;
            lbInventory.Location = new Point(1249, 677);
            lbInventory.Name = "lbInventory";
            lbInventory.Size = new Size(392, 224);
            lbInventory.TabIndex = 0;
            lbInventory.SelectedIndexChanged += lbInventory_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AccessibleName = "Інвентар";
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans MT Ext Condensed Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1409, 658);
            label1.Name = "label1";
            label1.Size = new Size(93, 25);
            label1.TabIndex = 4;
            label1.Text = "Інвентар";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1641, 905);
            Controls.Add(label1);
            Controls.Add(lbInventory);
            Controls.Add(flpChoices);
            Controls.Add(rtbStory);
            Controls.Add(pbScene);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)button1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbScene).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox button1;
        private PictureBox pbScene;
        private RichTextBox rtbStory;
        private FlowLayoutPanel flpChoices;
        private CheckedListBox lbInventory;
        private Label label1;
    }
}
