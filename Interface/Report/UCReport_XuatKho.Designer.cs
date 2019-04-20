namespace Interface.Report
{
    partial class UCReport_XuatKho
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_CT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCT)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_CT
            // 
            this.gridControl_CT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_CT.Location = new System.Drawing.Point(0, 0);
            this.gridControl_CT.MainView = this.gridViewCT;
            this.gridControl_CT.Name = "gridControl_CT";
            this.gridControl_CT.Size = new System.Drawing.Size(869, 509);
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
            // UCReport_BaoCaoThuocCanDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl_CT);
            this.Name = "UCReport_XuatKho";
            this.Size = new System.Drawing.Size(869, 509);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_CT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_CT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCT;
    }
}
