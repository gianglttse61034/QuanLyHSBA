namespace Interface.UserControl.Kho
{
    partial class UCNhapKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCNhapKho));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefesh = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.txtBirthDay = new DevExpress.XtraEditors.TextEdit();
            this.txtLuuTru = new DevExpress.XtraEditors.TextEdit();
            this.txtTicketHospital = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutEdit = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutNew = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutRefesh = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutDelete = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutCancle = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuuTru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTicketHospital.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutRefesh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutCancle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 134);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(929, 480);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin kho HSBA";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 26);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(925, 452);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.layoutControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(929, 134);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Thông Tin Hồ Sơ Bệnh Án";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.searchLookUpEdit1);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnRefesh);
            this.layoutControl1.Controls.Add(this.btnCancle);
            this.layoutControl1.Controls.Add(this.btnNew);
            this.layoutControl1.Controls.Add(this.btnEdit);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Controls.Add(this.txtBirthDay);
            this.layoutControl1.Controls.Add(this.txtLuuTru);
            this.layoutControl1.Controls.Add(this.txtTicketHospital);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 26);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(925, 106);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(780, 57);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 38);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Lưu";
            this.btnSave.ToolTip = "Ctrl + S";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefesh
            // 
            this.btnRefesh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnRefesh.Appearance.Options.UseFont = true;
            this.btnRefesh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefesh.ImageOptions.Image")));
            this.btnRefesh.Location = new System.Drawing.Point(258, 57);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(96, 38);
            this.btnRefesh.StyleController = this.layoutControl1;
            this.btnRefesh.TabIndex = 13;
            this.btnRefesh.Text = "Làm mới";
            this.btnRefesh.ToolTip = "F5";
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnCancle.Appearance.Options.UseFont = true;
            this.btnCancle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancle.ImageOptions.Image")));
            this.btnCancle.Location = new System.Drawing.Point(849, 57);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(69, 38);
            this.btnCancle.StyleController = this.layoutControl1;
            this.btnCancle.TabIndex = 12;
            this.btnCancle.Text = "Hủy";
            this.btnCancle.ToolTip = "Esc";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnNew
            // 
            this.btnNew.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.Location = new System.Drawing.Point(7, 57);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(105, 38);
            this.btnNew.StyleController = this.layoutControl1;
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "Thêm mới";
            this.btnNew.ToolTip = "Ctrl + N";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.Location = new System.Drawing.Point(116, 57);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 38);
            this.btnEdit.StyleController = this.layoutControl1;
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.ToolTip = "Ctrl + E";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(188, 57);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 38);
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.ToolTip = "Ctrl + Del";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtBirthDay
            // 
            this.txtBirthDay.Location = new System.Drawing.Point(352, 7);
            this.txtBirthDay.Name = "txtBirthDay";
            this.txtBirthDay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtBirthDay.Properties.Appearance.Options.UseFont = true;
            this.txtBirthDay.Size = new System.Drawing.Size(89, 22);
            this.txtBirthDay.StyleController = this.layoutControl1;
            this.txtBirthDay.TabIndex = 8;
            // 
            // txtLuuTru
            // 
            this.txtLuuTru.Location = new System.Drawing.Point(688, 7);
            this.txtLuuTru.Name = "txtLuuTru";
            this.txtLuuTru.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtLuuTru.Properties.Appearance.Options.UseFont = true;
            this.txtLuuTru.Size = new System.Drawing.Size(230, 22);
            this.txtLuuTru.StyleController = this.layoutControl1;
            this.txtLuuTru.TabIndex = 7;
            // 
            // txtTicketHospital
            // 
            this.txtTicketHospital.Location = new System.Drawing.Point(520, 7);
            this.txtTicketHospital.Name = "txtTicketHospital";
            this.txtTicketHospital.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTicketHospital.Properties.Appearance.Options.UseFont = true;
            this.txtTicketHospital.Size = new System.Drawing.Size(89, 22);
            this.txtTicketHospital.StyleController = this.layoutControl1;
            this.txtTicketHospital.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(82, 7);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Size = new System.Drawing.Size(191, 22);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutEdit,
            this.layoutNew,
            this.layoutRefesh,
            this.layoutDelete,
            this.layoutCancle,
            this.layoutSave,
            this.emptySpaceItem1,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(925, 106);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txtName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(270, 26);
            this.layoutControlItem1.Text = "Họ tên";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 17);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txtTicketHospital;
            this.layoutControlItem3.Location = new System.Drawing.Point(438, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(168, 26);
            this.layoutControlItem3.Text = "Số vào viện";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txtBirthDay;
            this.layoutControlItem2.Location = new System.Drawing.Point(270, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(168, 26);
            this.layoutControlItem2.Text = "Năm sinh";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txtLuuTru;
            this.layoutControlItem4.Location = new System.Drawing.Point(606, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(309, 26);
            this.layoutControlItem4.Text = "Số lưu trữ";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 17);
            // 
            // layoutEdit
            // 
            this.layoutEdit.Control = this.btnEdit;
            this.layoutEdit.Location = new System.Drawing.Point(109, 50);
            this.layoutEdit.Name = "layoutEdit";
            this.layoutEdit.Size = new System.Drawing.Size(72, 46);
            this.layoutEdit.TextSize = new System.Drawing.Size(0, 0);
            this.layoutEdit.TextVisible = false;
            // 
            // layoutNew
            // 
            this.layoutNew.Control = this.btnNew;
            this.layoutNew.Location = new System.Drawing.Point(0, 50);
            this.layoutNew.Name = "layoutNew";
            this.layoutNew.Size = new System.Drawing.Size(109, 46);
            this.layoutNew.TextSize = new System.Drawing.Size(0, 0);
            this.layoutNew.TextVisible = false;
            // 
            // layoutRefesh
            // 
            this.layoutRefesh.Control = this.btnRefesh;
            this.layoutRefesh.Location = new System.Drawing.Point(251, 50);
            this.layoutRefesh.Name = "layoutRefesh";
            this.layoutRefesh.Size = new System.Drawing.Size(100, 46);
            this.layoutRefesh.TextSize = new System.Drawing.Size(0, 0);
            this.layoutRefesh.TextVisible = false;
            // 
            // layoutDelete
            // 
            this.layoutDelete.Control = this.btnDelete;
            this.layoutDelete.Location = new System.Drawing.Point(181, 50);
            this.layoutDelete.Name = "layoutDelete";
            this.layoutDelete.Size = new System.Drawing.Size(70, 46);
            this.layoutDelete.Text = "Xóa";
            this.layoutDelete.TextSize = new System.Drawing.Size(0, 0);
            this.layoutDelete.TextVisible = false;
            // 
            // layoutCancle
            // 
            this.layoutCancle.Control = this.btnCancle;
            this.layoutCancle.Location = new System.Drawing.Point(842, 50);
            this.layoutCancle.Name = "layoutCancle";
            this.layoutCancle.Size = new System.Drawing.Size(73, 46);
            this.layoutCancle.TextSize = new System.Drawing.Size(0, 0);
            this.layoutCancle.TextVisible = false;
            // 
            // layoutSave
            // 
            this.layoutSave.Control = this.btnSave;
            this.layoutSave.Location = new System.Drawing.Point(773, 50);
            this.layoutSave.Name = "layoutSave";
            this.layoutSave.Size = new System.Drawing.Size(69, 46);
            this.layoutSave.TextSize = new System.Drawing.Size(0, 0);
            this.layoutSave.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(351, 50);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(422, 46);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.Location = new System.Drawing.Point(82, 33);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpEdit1.Size = new System.Drawing.Size(836, 20);
            this.searchLookUpEdit1.StyleController = this.layoutControl1;
            this.searchLookUpEdit1.TabIndex = 16;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.searchLookUpEdit1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(915, 24);
            this.layoutControlItem5.Text = "Kho lưu";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(72, 13);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // UCNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.Name = "UCNhapKho";
            this.Size = new System.Drawing.Size(929, 614);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuuTru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTicketHospital.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutRefesh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutCancle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.TextEdit txtBirthDay;
        private DevExpress.XtraEditors.TextEdit txtLuuTru;
        private DevExpress.XtraEditors.TextEdit txtTicketHospital;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutNew;
        private DevExpress.XtraLayout.LayoutControlItem layoutDelete;
        private DevExpress.XtraLayout.LayoutControlItem layoutCancle;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnRefesh;
        private DevExpress.XtraLayout.LayoutControlItem layoutSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutRefesh;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
