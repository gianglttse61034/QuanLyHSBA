namespace Interface.Report
{
    partial class UCReport_LichSuHoSoBenhAn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl_CT = new DevExpress.XtraGrid.GridControl();
            this.gridViewCT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl_G = new DevExpress.XtraGrid.GridControl();
            this.gridViewG = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_CT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_CT
            // 
            this.gridControl_CT.Location = new System.Drawing.Point(283, 18);
            this.gridControl_CT.MainView = this.gridViewCT;
            this.gridControl_CT.Name = "gridControl_CT";
            this.gridControl_CT.Size = new System.Drawing.Size(584, 489);
            this.gridControl_CT.TabIndex = 0;
            this.gridControl_CT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCT});
            // 
            // gridViewCT
            // 
            this.gridViewCT.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridViewCT.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewCT.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.gridViewCT.Appearance.Row.Options.UseFont = true;
            this.gridViewCT.GridControl = this.gridControl_CT;
            this.gridViewCT.Name = "gridViewCT";
            this.gridViewCT.OptionsView.ShowAutoFilterRow = true;
            this.gridViewCT.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl_G);
            this.layoutControl1.Controls.Add(this.gridControl_CT);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(869, 509);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl_G
            // 
            this.gridControl_G.Location = new System.Drawing.Point(2, 18);
            this.gridControl_G.MainView = this.gridViewG;
            this.gridControl_G.Name = "gridControl_G";
            this.gridControl_G.Size = new System.Drawing.Size(272, 489);
            this.gridControl_G.TabIndex = 4;
            this.gridControl_G.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewG});
            // 
            // gridViewG
            // 
            this.gridViewG.GridControl = this.gridControl_G;
            this.gridViewG.Name = "gridViewG";
            this.gridViewG.OptionsView.ShowAutoFilterRow = true;
            this.gridViewG.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.splitterItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(869, 509);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl_CT;
            this.layoutControlItem1.Location = new System.Drawing.Point(281, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(588, 509);
            this.layoutControlItem1.Text = "Danh sách xuất kho HSBA";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(126, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl_G;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(276, 509);
            this.layoutControlItem2.Text = "Danh sách nhập kho HSBA";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(126, 13);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(276, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 509);
            // 
            // UCReport_LichSuHoSoBenhAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "UCReport_LichSuHoSoBenhAn";
            this.Size = new System.Drawing.Size(869, 509);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_CT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_CT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCT;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl_G;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewG;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
    }
}
