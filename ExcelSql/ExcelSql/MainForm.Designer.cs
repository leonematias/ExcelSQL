namespace ExcelSql
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBoxTables = new System.Windows.Forms.GroupBox();
            this.listBoxTables = new System.Windows.Forms.ListBox();
            this.groupBoxQueries = new System.Windows.Forms.GroupBox();
            this.tabControlQueries = new System.Windows.Forms.TabControl();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLoadFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNewQuery = new System.Windows.Forms.ToolStripButton();
            this.splitContainerLog = new System.Windows.Forms.SplitContainer();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.groupBoxTables.SuspendLayout();
            this.groupBoxQueries.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLog)).BeginInit();
            this.splitContainerLog.Panel1.SuspendLayout();
            this.splitContainerLog.Panel2.SuspendLayout();
            this.splitContainerLog.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.groupBoxTables);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.groupBoxQueries);
            this.mainSplitContainer.Size = new System.Drawing.Size(1148, 648);
            this.mainSplitContainer.SplitterDistance = 129;
            this.mainSplitContainer.TabIndex = 1;
            // 
            // groupBoxTables
            // 
            this.groupBoxTables.Controls.Add(this.listBoxTables);
            this.groupBoxTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTables.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTables.Name = "groupBoxTables";
            this.groupBoxTables.Size = new System.Drawing.Size(129, 648);
            this.groupBoxTables.TabIndex = 0;
            this.groupBoxTables.TabStop = false;
            this.groupBoxTables.Text = "Tables";
            // 
            // listBoxTables
            // 
            this.listBoxTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTables.FormattingEnabled = true;
            this.listBoxTables.ItemHeight = 18;
            this.listBoxTables.Location = new System.Drawing.Point(3, 16);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.Size = new System.Drawing.Size(123, 629);
            this.listBoxTables.TabIndex = 8;
            this.listBoxTables.DoubleClick += new System.EventHandler(this.listBoxTables_DoubleClick);
            // 
            // groupBoxQueries
            // 
            this.groupBoxQueries.Controls.Add(this.tabControlQueries);
            this.groupBoxQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxQueries.Location = new System.Drawing.Point(0, 0);
            this.groupBoxQueries.Name = "groupBoxQueries";
            this.groupBoxQueries.Size = new System.Drawing.Size(1015, 648);
            this.groupBoxQueries.TabIndex = 0;
            this.groupBoxQueries.TabStop = false;
            this.groupBoxQueries.Text = "Queries";
            // 
            // tabControlQueries
            // 
            this.tabControlQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlQueries.Location = new System.Drawing.Point(3, 16);
            this.tabControlQueries.Name = "tabControlQueries";
            this.tabControlQueries.SelectedIndex = 0;
            this.tabControlQueries.Size = new System.Drawing.Size(1009, 629);
            this.tabControlQueries.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoadFile,
            this.toolStripButtonNewQuery});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1148, 25);
            this.toolStrip.TabIndex = 7;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonLoadFile
            // 
            this.toolStripButtonLoadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLoadFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadFile.Image")));
            this.toolStripButtonLoadFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadFile.Name = "toolStripButtonLoadFile";
            this.toolStripButtonLoadFile.Size = new System.Drawing.Size(56, 22);
            this.toolStripButtonLoadFile.Text = "Load file";
            this.toolStripButtonLoadFile.Click += new System.EventHandler(this.toolStripButtonLoadFile_Click);
            // 
            // toolStripButtonNewQuery
            // 
            this.toolStripButtonNewQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonNewQuery.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNewQuery.Image")));
            this.toolStripButtonNewQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewQuery.Name = "toolStripButtonNewQuery";
            this.toolStripButtonNewQuery.Size = new System.Drawing.Size(68, 22);
            this.toolStripButtonNewQuery.Text = "New query";
            this.toolStripButtonNewQuery.Click += new System.EventHandler(this.toolStripButtonNewQuery_Click);
            // 
            // splitContainerLog
            // 
            this.splitContainerLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLog.Location = new System.Drawing.Point(0, 25);
            this.splitContainerLog.Name = "splitContainerLog";
            this.splitContainerLog.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLog.Panel1
            // 
            this.splitContainerLog.Panel1.Controls.Add(this.mainSplitContainer);
            // 
            // splitContainerLog.Panel2
            // 
            this.splitContainerLog.Panel2.Controls.Add(this.groupBoxLog);
            this.splitContainerLog.Size = new System.Drawing.Size(1148, 751);
            this.splitContainerLog.SplitterDistance = 648;
            this.splitContainerLog.TabIndex = 1;
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.richTextBoxLog);
            this.groupBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLog.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(1148, 99);
            this.groupBoxLog.TabIndex = 0;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Log";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Enabled = false;
            this.richTextBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLog.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(1142, 80);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 776);
            this.Controls.Add(this.splitContainerLog);
            this.Controls.Add(this.toolStrip);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExcelSql";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.groupBoxTables.ResumeLayout(false);
            this.groupBoxQueries.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainerLog.Panel1.ResumeLayout(false);
            this.splitContainerLog.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLog)).EndInit();
            this.splitContainerLog.ResumeLayout(false);
            this.groupBoxLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.GroupBox groupBoxTables;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadFile;
        private System.Windows.Forms.GroupBox groupBoxQueries;
        private System.Windows.Forms.TabControl tabControlQueries;
        private System.Windows.Forms.SplitContainer splitContainerLog;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.ListBox listBoxTables;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewQuery;
    }
}

