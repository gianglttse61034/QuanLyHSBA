using BLL.DO;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Interface
{
    public partial class frmDanhMuc : DevExpress.XtraEditors.XtraForm
    {
        private ActionStatus currentActionStatus;
        private MasterData obj;
        private bool isChangeData = false;
        public enum ActionStatus
        {
            Normal = 0,
            AddNew = 1,
            Update = 2
        }
        public frmDanhMuc()
        {
            InitializeComponent();
        }
        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void frmDanhMuc_Shown(object sender, EventArgs e)
        {
            ShownData();
        }
        public void LoadData()
        {

        }
        public void ShownData()
        {
            DataTable dt = new DataTable();
            DataTable dtParentId = new DataTable();
            BackgroundWorker bw = new BackgroundWorker();
            frmWaiting frmWait = new frmWaiting { StartPosition = FormStartPosition.CenterScreen };
            bw.DoWork += delegate { dt = BLL.QueryData.getInstance().getListViTriLuuKho(); };
            bw.DoWork += delegate
            {
                dtParentId = BLL.QueryData.getInstance().getListKho();
                dtParentId.Rows.InsertAt(dtParentId.NewRow(), 0);
            };
            bw.RunWorkerCompleted += delegate
             {
                 frmWait.Close();

                 lkpParentId.Properties.Columns.Clear();
                 lkpParentId.Properties.Columns.AddRange(new LookUpColumnInfo[]
                 {
                     new LookUpColumnInfo("master_data_name", 250, "Tên"),
                     new LookUpColumnInfo("freefield1", 100, "STT")
                 });
                 lkpParentId.Properties.DisplayMember = "master_data_name";
                 lkpParentId.Properties.ValueMember = "master_data_id";
                 lkpParentId.Properties.PopupFilterMode = PopupFilterMode.Contains;
                 lkpParentId.Properties.NullText = "";
                 lkpParentId.Properties.ShowHeader = false;
                 lkpParentId.Properties.DataSource = dtParentId;
                 lkpParentId.EditValue = "";

                 treeList1.BeginUpdate(); treeList1.DataSource = null;
                 treeList1.DataSource = dt;
                 treeList1.BestFitColumns();
                 treeList1.EndUpdate();

                 LoadLayout();
                 ChangeControlStatus(ActionStatus.Normal);
             };
            bw.RunWorkerAsync();
            frmWait.ShowDialog();
            bw.Dispose();
        }
        private void LoadLayout()
        {
            treeList1.OptionsBehavior.PopulateServiceColumns = true;
            treeList1.OptionsBehavior.EnableFiltering = true;
            treeList1.KeyFieldName = "id";
            treeList1.ParentFieldName = "parent_id";
            foreach (DevExpress.XtraTreeList.Columns.TreeListColumn col in treeList1.Columns)
            {
                col.OptionsColumn.ReadOnly = true;
                col.OptionsColumn.AllowEdit = false;
                col.Visible = false;
                switch (col.FieldName)
                {

                    case "master_data_name":
                        col.Caption = "Tên";
                        col.Visible = true;
                        break;
                    case "master_data_id":
                        col.Caption = "Ký Hiệu";
                        col.Visible = true;
                        break;
                    case "freefield1":
                        col.Caption = "Thứ tự";
                        col.Visible = true;
                        break;
                    case "description":
                        col.Caption = "Ghi chú";
                        col.Visible = true;
                        break;

                }
            }
            treeList1.ExpandAll();
            treeList1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f);
            treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            treeList1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            treeList1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            treeList1.ColumnPanelRowHeight = 40;
            treeList1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            treeList1.Appearance.HeaderPanel.Options.UseTextOptions = true;


        }
        private void SetNodeToObject(TreeListNode node)
        {
            if (node == null) return;
            obj = new MasterData();
            obj.MasterDataName = node["master_data_name"] == null || node["master_data_name"].Equals(DBNull.Value) ? "" : node["master_data_name"].ToString(); // Tên
            obj.Id = node["id"] == null || node["id"].Equals(DBNull.Value) ? "" : node["id"].ToString(); // Id 
            obj.ParentId = node["parent_id"] == null || node["parent_id"].Equals(DBNull.Value) ? "" : node["parent_id"].ToString(); // parent_id 
            obj.Description = node["description"] == null || node["description"].Equals(DBNull.Value) ? "" : node["description"].ToString(); // Chi tiết
            obj.Freefield1 = node["freefield1"] == null || node["freefield1"].Equals(DBNull.Value) ? "" : node["freefield1"].ToString(); // Số thứ tự. Tự đặt
            obj.Freefield2 = node["freefield2"] == null || node["freefield2"].Equals(DBNull.Value) ? "" : node["freefield2"].ToString(); // Tên hiển thi combobox
            obj.Freefield3 = node["freefield3"] == null || node["freefield3"].Equals(DBNull.Value) ? "" : node["freefield3"].ToString();// Level
        }
        private MasterData SetDataFromControl()
        {
            MasterData temp = new MasterData();
            try
            {
                if (currentActionStatus == ActionStatus.AddNew)
                {
                    temp.Id = Guid.NewGuid().ToString().ToLower();
                    temp.Description = txtDescription.Text;
                    temp.MasterDataName = txtMasterDataName.Text;
                    temp.CreateBy = DataAccount.User.UserId;
                    temp.CreateDate = DateTime.Now;
                    temp.UpdateBy = DataAccount.User.UserId;
                    temp.UpdateDate = DateTime.Now;
                    temp.Freefield1 = txtSTT.Text;
                    temp.GroupId = "74c788c0-9c2f-44fc-9e1f-108f60a1909c"; // ID KHO LUU TRONG DATABASE
                    temp.IsUsed = 1;
                    temp.ParentId = lkpParentId.EditValue == null ? "" : lkpParentId.EditValue.ToString();
                    temp.MasterDataId= txtKyHieu.Text;
                }

                if (currentActionStatus == ActionStatus.Update)
                {
                    temp.Description = txtDescription.Text;
                    temp.MasterDataName = txtMasterDataName.Text;
                    temp.MasterDataId = txtKyHieu.Text;
                    temp.CreateBy = obj.CreateBy;
                    temp.CreateDate = obj.CreateDate;
                    temp.UpdateBy = DataAccount.User.UserId;
                    temp.UpdateDate = DateTime.Now;
                    temp.Freefield1 = txtSTT.Text;
                    temp.Freefield2 = obj.Freefield2;
                    temp.Freefield3 = obj.Freefield3;
                    temp.GroupId = "74c788c0-9c2f-44fc-9e1f-108f60a1909c"; // ID KHO LUU TRONG DATABASE
                    temp.IsUsed = 1;
                    temp.ParentId = obj.ParentId;
                    temp.Id = obj.Id;
                }
            }
            catch (Exception e)
            {
            }
            return temp;
        }
        private void RefeshData(MasterData obj = null)
        {
            DataTable dt = new DataTable();
            DataTable dtParentId = new DataTable();
            BackgroundWorker bw = new BackgroundWorker();
            frmWaiting frmWait = new frmWaiting { StartPosition = FormStartPosition.CenterScreen };
            bw.DoWork += delegate { dt = BLL.QueryData.getInstance().getListViTriLuuKho(); };
            bw.DoWork += delegate
            {
                dtParentId = BLL.QueryData.getInstance().getListKho();
                dtParentId.Rows.InsertAt(dtParentId.NewRow(), 0);
            };
            bw.RunWorkerCompleted += delegate
            {
                frmWait.Close();
                treeList1.BeginUpdate();
                treeList1.DataSource = null;
                treeList1.DataSource = dt;
                treeList1.BestFitColumns();
                treeList1.EndUpdate();
                lkpParentId.Properties.DataSource = dtParentId;
                LoadLayout();

                if (obj != null)
                {
                    treeList1.FocusedNode = getNodeById(obj.Id.ToString());
                }
            };
            bw.RunWorkerAsync();
            frmWait.ShowDialog();
            bw.Dispose();
        }
        private void LoadDataToControl()
        {
            if (obj != null)
            {
                txtDescription.Text = obj.Description;
                txtMasterDataName.Text = obj.MasterDataName;
                lkpParentId.EditValue = obj.ParentId.ToUpper();
                txtSTT.Text = obj.Freefield1;
                txtKyHieu.Text= obj.MasterDataId ;
            }
        }
        private void ChangeControlStatus(ActionStatus status)
        {
            currentActionStatus = status;
            switch (status)
            {
                case ActionStatus.Normal:
                    layoutCancle.Visibility = LayoutVisibility.Never;
                    layoutSave.Visibility = LayoutVisibility.Never;
                    layoutNew.Visibility = LayoutVisibility.Always;
                    layoutRefesh.Visibility = LayoutVisibility.Always;
                    layoutEdit.Visibility = LayoutVisibility.Always;

                    if (treeList1.Nodes.Count > 0)
                    {
                        layoutEdit.Visibility = LayoutVisibility.Always;
                        layoutDelete.Visibility = LayoutVisibility.Always;
                    }
                    else
                    {
                        layoutEdit.Visibility = LayoutVisibility.Never;
                        layoutDelete.Visibility = LayoutVisibility.Never;
                    }
                    treeList1.Enabled = true;
                    txtMasterDataName.ReadOnly = true;
                    txtSTT.ReadOnly = true;
                    txtDescription.ReadOnly = true;
                    break;
                case ActionStatus.Update:
                    layoutCancle.Visibility = LayoutVisibility.Always;
                    layoutSave.Visibility = LayoutVisibility.Always;
                    layoutDelete.Visibility = LayoutVisibility.Never;
                    layoutNew.Visibility = LayoutVisibility.Never;
                    layoutRefesh.Visibility = LayoutVisibility.Never;
                    layoutEdit.Visibility = LayoutVisibility.Never;
                    txtMasterDataName.ReadOnly = false;
                    treeList1.Enabled = false;
                    txtMasterDataName.ReadOnly = false;
                    txtSTT.ReadOnly = false;
                    txtDescription.ReadOnly = false;
                    break;
                case ActionStatus.AddNew:
                    layoutCancle.Visibility = LayoutVisibility.Always;
                    layoutSave.Visibility = LayoutVisibility.Always;
                    layoutDelete.Visibility = LayoutVisibility.Never;
                    layoutNew.Visibility = LayoutVisibility.Never;
                    layoutRefesh.Visibility = LayoutVisibility.Never;
                    layoutEdit.Visibility = LayoutVisibility.Never;
                    treeList1.Enabled = false;
                    txtMasterDataName.ReadOnly = false;
                    txtSTT.ReadOnly = false;
                    txtDescription.ReadOnly = false;
                    break;
            }
        }
        private void ClearData()
        {
            txtSTT.Text = string.Empty;
            txtMasterDataName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            lkpParentId.EditValue = "";
        }

        private void UpdateData()
        {
            try
            {
                MasterData insertObj = SetDataFromControl();
                if (obj.Id == "F60A6394-72FE-4541-B77E-3AE68058D1E0")
                {
                    MessageBox.Show("Dữ liệu gốc không thể chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (lkpParentId.EditValue.Equals(obj.Id))
                {
                    MessageBox.Show("Không thể chọn mã cha vì là mã đang sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isChangeData)
                {
                    TreeListNode nodeParent = getNodeById(lkpParentId.EditValue.ToString());
                    if (nodeParent != null)
                    {
                        insertObj.ParentId = nodeParent["id"] == null || nodeParent["id"].Equals(DBNull.Value) ? "" : nodeParent["id"].ToString();
                        string freefield = getFreeField2(nodeParent);
                        if (freefield.Equals(string.Empty))
                        {
                            freefield = txtMasterDataName.Text;
                        }
                        else
                        {
                            freefield = freefield + " - " + txtMasterDataName.Text;
                        }

                        insertObj.Freefield2 = freefield;
                        insertObj.Freefield3 = (nodeParent.Level + 1).ToString();
                    }
                }

                if (BLL.QueryData.getInstance().UpdateDanhMuc(insertObj))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangeControlStatus(ActionStatus.Normal);
                    RefeshData();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

            }
        }

        private void InsertData()
        {
            MasterData insertObj = SetDataFromControl();
            try
            {
                TreeListNode nodeParent = getNodeById(insertObj.ParentId);
                if (nodeParent != null)
                {
                    string freefield = getFreeField2(nodeParent);
                    if (freefield.Equals(string.Empty))
                    {
                        freefield = txtMasterDataName.Text;
                    }
                    else
                    {
                        freefield = freefield + " - " + txtMasterDataName.Text;
                    }

                    insertObj.Freefield2 = freefield;
                    insertObj.Freefield3 = (nodeParent.Level + 1).ToString();
                }

                if (BLL.QueryData.getInstance().InsertDanhMuc(insertObj))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangeControlStatus(ActionStatus.Normal);
                    RefeshData(insertObj);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

            }
        }
        #region Event
        private void btnNew_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.AddNew);
            ClearData();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.Update);

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.Normal);
            if (MessageBox.Show("Bạn có muốn chắc chắn xóa kho này!", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (obj == null || obj.Id == string.Empty) return;
                if (!BLL.QueryData.getInstance().CheckDataDelete())
                {
                    MessageBox.Show("Mã kho đã được sử dụng. Không thể xóa", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }

                if (obj.Id == "F60A6394-72FE-4541-B77E-3AE68058D1E0")
                {
                    MessageBox.Show("Dữ liệu gốc không thể chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                obj.UpdateBy = Lib.DataAccount.User.UserId;
                obj.UpdateDate = DateTime.Now;
                if (BLL.QueryData.getInstance().Delete_DanhMuc(obj))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangeControlStatus(ActionStatus.Normal);
                    RefeshData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentActionStatus == ActionStatus.Normal) return;
            if (currentActionStatus == ActionStatus.Update && CheckData())
            {
                UpdateData();
            }
            if (currentActionStatus == ActionStatus.AddNew && CheckData())
            {
                InsertData();
            }
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            ChangeControlStatus(ActionStatus.Normal);
        }
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            RefeshData();
        }
        private void treeList1_GetCustomSummaryValue(object sender, GetCustomSummaryValueEventArgs e)
        {
            if (e.Column.FieldName == "master_data_name")
            {
                e.CustomValue = e.Nodes.Count;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Control && keyData == Keys.S && (currentActionStatus == ActionStatus.AddNew || currentActionStatus == ActionStatus.Update))
            {
                btnSave_Click(new object(), EventArgs.Empty);
            }
            if (keyData == Keys.Control && keyData == Keys.E && currentActionStatus == ActionStatus.Normal)
            {
                btnEdit_Click(new object(), EventArgs.Empty);
            }
            if (keyData == Keys.Control && keyData == Keys.N && currentActionStatus == ActionStatus.Normal)
            {
                btnNew_Click(new object(), EventArgs.Empty);
            }
            if (keyData == Keys.Escape && (currentActionStatus == ActionStatus.AddNew || currentActionStatus == ActionStatus.Update))
            {
                btnCancle_Click(new object(), EventArgs.Empty);
            }
            if (keyData == Keys.F5 && currentActionStatus == ActionStatus.Normal)
            {
                btnRefesh_Click(new object(), EventArgs.Empty);
            }
            if (keyData == Keys.Delete && currentActionStatus == ActionStatus.Normal)
            {
                btnDelete_Click(new object(), EventArgs.Empty);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        private TreeListNode getNodeById(string id)
        {
            IList<TreeListNode> lst = treeList1.GetNodeList();
            for (int i = 0; i < lst.Count; i++)
            {
                TreeListNode node = lst[i];
                if (node != null && node["id"].ToString().ToLower() == id.ToLower())
                {
                    return node;
                }
            }
            return null;
        }
        private string getFreeField2(TreeListNode node)
        {
            TreeListNode curNode = node;
            TreeListNode root = curNode.RootNode;
            string strName = string.Empty;
            if (curNode != null)
            {
                obj.Freefield3 = curNode.Level.ToString();
                //Lấy node cha
                while (true)
                {
                    if (curNode["id"].Equals(root["id"]))
                    {
                        if (strName.Equals(string.Empty))
                        {
                            strName = curNode["master_data_name"].ToString();
                        }
                        else
                        {
                            strName = root["master_data_name"] + " - " + strName;
                        }
                        break;
                    }

                    if (strName == string.Empty)
                        strName = curNode.GetDisplayText("master_data_name");
                    else
                        strName = curNode.GetDisplayText("master_data_name") + " - " + strName;
                    curNode = curNode.ParentNode;

                }
            }
            return strName;
        }
        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (currentActionStatus == ActionStatus.Normal)
                {
                    if (treeList1.Nodes.Count > 0 && e.Node.Focused)
                    {
                        SetNodeToObject(e.Node);
                        LoadDataToControl();
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void lkpParentId_EditValueChanged(object sender, EventArgs e)
        {
            if (currentActionStatus == ActionStatus.AddNew || currentActionStatus == ActionStatus.Update)
            {
                if (currentActionStatus == ActionStatus.Update && lkpParentId.EditValue.Equals(obj.Id.ToUpper()))
                {
                    MessageBox.Show("Không thể chọn mã đang sửa làm mã cha.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lkpParentId.EditValue = "";
                    return;
                }
                isChangeData = true;

            }
            else
            {
                isChangeData = false;
            }
        }

        private bool CheckData()
        {
            if (txtMasterDataName.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập tên Kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasterDataName.Focus();
                return false;
            }
            if (txtSTT.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập số thứ tự để tiện sắp xếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasterDataName.Focus();
                return false;
            }

            return true;
        }
    }
}