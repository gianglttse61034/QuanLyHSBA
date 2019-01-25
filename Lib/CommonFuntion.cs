using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System.Security.Cryptography;
using BLL.DO;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;

namespace Lib
{
    public static class CommonFuntion
    {

        public static string EncodeMD5(string str)
        {
            return MD5Encode(str);
        }
        private static string MD5Encode(string password)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password + Constants.KeyMD5 + Constants.KeyHash);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private static string Encode64(byte[] input, int count)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            do
            {
                int value = (int)input[i++];
                sb.Append(Constants.KeyMD5[value & 0x3f]); // to uppercase
                if (i < count)
                    value = value | ((int)input[i] << 8);
                sb.Append(Constants.KeyMD5[(value >> 6) & 0x3f]);
                if (i++ >= count)
                    break;
                if (i < count)
                    value = value | ((int)input[i] << 16);
                sb.Append(Constants.KeyMD5[(value >> 12) & 0x3f]);
                if (i++ >= count)
                    break;
                sb.Append(Constants.KeyMD5[(value >> 18) & 0x3f]);
            } while (i < count);

            return sb.ToString();
        }
    }
    public static class Constants
    {
        public const string Numeric_N0 = "N0";
        public const string Numeric_N1 = "N0";
        public const string Numeric_N2 = "N0";
        public const string KeyMD5 = "AGSAFDJHASTDQWUEYTKAJSDHIOQWE";
        public const string KeyHash = "ASDFG!@#$%";
        public const string DateTimeFormat = "dd/MM/yyyy HH:mm";
        public const string DateFormat = "dd/MM/yyyy";
    }

    public static class DataAccount
    {
        public static BLL.DO.User user;

        public static User User
        {
            get { return user; }
            set { user = value; }
        }
    }

    public class GridHelper
    {
        private static GridHelper _instance = null;
        public GridHelper() { }
        public static GridHelper getInstance()
        {
            try
            {
                if (_instance == null)
                {
                    _instance = new GridHelper();
                }
            }
            catch
            {

            }
            return _instance;
        }

        public enum GridHelperType
        {
            Numberic = 1,
            DateTime = 2,
            LookupEdit = 3,
            TextEdit = 4,
            HTML = 5
        }

        public GridColumn Format(string field, string name, GridHelperType type, string displayFormat = "", int colWidth = 0, int maxWidth = 0, bool visible = true, bool readOnly = true, bool allowEdit = false, bool wrapHeader = false)
        {
            GridColumn col = new GridColumn();
            try
            {
                col.FieldName = field;
                col.Caption = name;
                col.Visible = visible;
                col.OptionsColumn.ReadOnly = readOnly;
                col.OptionsColumn.AllowEdit = allowEdit;
                if (colWidth != 0)
                    col.Width = colWidth;
                if (maxWidth != 0)
                    col.MaxWidth = maxWidth;
                switch (type)
                {
                    case GridHelperType.DateTime:
                        col.DisplayFormat.FormatType = FormatType.DateTime;
                        if (displayFormat != string.Empty)
                            col.DisplayFormat.FormatString = displayFormat;
                        break;
                    case GridHelperType.Numberic:
                        col.DisplayFormat.FormatType = FormatType.Numeric;
                        if (displayFormat != string.Empty)
                            col.DisplayFormat.FormatString = displayFormat;
                        break;
                    case GridHelperType.TextEdit:
                        break;
                    case GridHelperType.HTML:
                        RepositoryItemRichTextEdit richEdit = new RepositoryItemRichTextEdit();
                        richEdit.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Html;
                        richEdit.OptionsBehavior.FontSource = DevExpress.XtraRichEdit.RichEditBaseValueSource.Control;
                        richEdit.Encoding = Encoding.UTF8;
                        richEdit.ReadOnly = readOnly;
                        richEdit.ExportMode = ExportMode.DisplayText;
                        richEdit.OptionsHorizontalScrollbar.Visibility = RichEditScrollbarVisibility.Auto;
                        richEdit.OptionsVerticalScrollbar.Visibility = RichEditScrollbarVisibility.Auto;
                        col.ColumnEdit = richEdit;
                        break;

                }
            }
            catch (Exception)
            {

            }
            return col;

        }
        public GridColumn FormatWraptext(string field, string name, int colWidth = 0, int maxWidth = 0, bool visible = true, bool readOnly = true, bool allowEdit = false, bool wrapHeader = false)
        {
            GridColumn col = new GridColumn();
            try
            {
                col.Visible = visible;
                col.OptionsColumn.ReadOnly = readOnly;
                col.OptionsColumn.AllowEdit = allowEdit;
                col.FieldName = field;
                col.Caption = name;
                if (colWidth != 0)
                    col.Width = colWidth;
                if (maxWidth != 0)
                    col.MaxWidth = maxWidth;
                RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
                memo.WordWrap = true;
                memo.ReadOnly = readOnly;
                col.ColumnEdit = memo;
            }
            catch (Exception)
            {

            }
            return col;

        }
        public GridColumn FormatLookupEdit(string field, string name, DataTable sourceTable, string valueMember, string displayMember, int colWidth = 0, int maxWidth = 0, bool visible = true, bool readOnly = true, bool allowEdit = false, bool wrapHeader = false)
        {
            GridColumn col = new GridColumn();
            try
            {
                col.Visible = visible;
                col.OptionsColumn.ReadOnly = readOnly;
                col.OptionsColumn.AllowEdit = allowEdit;
                col.FieldName = field;
                col.Caption = name;
                if (colWidth != 0)
                    col.Width = colWidth;
                if (maxWidth != 0)
                    col.MaxWidth = maxWidth;
                RepositoryItemLookUpEdit lookUpEdit = new RepositoryItemLookUpEdit();
                lookUpEdit.DataSource = sourceTable;
                lookUpEdit.DisplayMember = displayMember;
                lookUpEdit.ValueMember = valueMember;
                col.ColumnEdit = lookUpEdit;
            }
            catch (Exception)
            {

            }
            return col;

        }
    }
    // Vẽ header theo column chọn

    /*
     * Bên hàm cần vẽ header => gọi hàm dưới. Các 
                //Vẽ header
                GridCheckMarksSelection selection = new GridCheckMarksSelection(gridView_DanhSachPhanAnh, HorzAlignment.Near);
                selection.CheckMarkColumn.VisibleIndex = 0;
     */
    public class GridCheckMarksSelection
    {
        protected GridView view;
        protected ArrayList selection;
        private GridColumn column;
        private RepositoryItemCheckEdit edit;


        public GridCheckMarksSelection() : base()
        {
            selection = new ArrayList();
        }

        public GridCheckMarksSelection(GridView view) : this()
        {
            View = view;
        }

        public GridCheckMarksSelection(GridView view, HorzAlignment GlyphAlignment)
            : this(view)
        {
            edit.GlyphAlignment = GlyphAlignment;
            edit.Caption = string.Empty;
        }

        protected virtual void Attach(GridView view)
        {
            if (view == null) return;
            selection.Clear();
            this.view = view;
            view.BeginUpdate();
            try
            {
                edit = view.GridControl.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
                edit.EditValueChanged += new EventHandler(edit_EditValueChanged);

                column = view.Columns.Add();
                column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                column.VisibleIndex = int.MaxValue;
                column.FieldName = "chon";
                //column.Caption = "";
                column.OptionsColumn.ShowCaption = false;
                column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
                column.ColumnEdit = edit;


                view.Click += new EventHandler(View_Click);
                view.CustomDrawColumnHeader += new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
                //view.CustomDrawGroupRow += new RowObjectCustomDrawEventHandler(View_CustomDrawGroupRow);
                view.CustomUnboundColumnData += new CustomColumnDataEventHandler(view_CustomUnboundColumnData);
                //view.RowStyle += new RowStyleEventHandler(view_RowStyle);
            }
            finally
            {
                view.EndUpdate();
            }
        }

        protected virtual void Detach()
        {
            if (view == null) return;
            if (column != null)
                column.Dispose();
            if (edit != null)
            {
                view.GridControl.RepositoryItems.Remove(edit);
                edit.Dispose();
            }

            view.Click -= new EventHandler(View_Click);
            view.CustomDrawColumnHeader -= new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
            //view.CustomDrawGroupRow -= new RowObjectCustomDrawEventHandler(View_CustomDrawGroupRow);
            view.CustomUnboundColumnData -= new CustomColumnDataEventHandler(view_CustomUnboundColumnData);
            //view.RowStyle -= new RowStyleEventHandler(view_RowStyle);

            view = null;
        }

        protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
            info = edit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
            painter = edit.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
            info.EditValue = Checked;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }

        private void View_Click(object sender, EventArgs e)
        {
            GridHitInfo info;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            info = view.CalcHitInfo(pt);
            if (info.InColumn && info.Column == column)
            {
                if (SelectedCount == view.DataRowCount)
                    ClearSelection();
                else
                    SelectAll();
            }
            if (info.InRow && view.IsGroupRow(info.RowHandle) && info.HitTest != GridHitTest.RowGroupButton)
            {
                bool selected = IsGroupRowSelected(info.RowHandle);
                SelectGroup(info.RowHandle, !selected);
            }
        }

        private void View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == column)
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                edit.Caption = e.Column.Caption;
                DrawCheckBox(e.Graphics, e.Bounds, SelectedCount == view.DataRowCount);
                edit.Caption = string.Empty;
                e.Handled = true;
            }
        }

        //private void View_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        //{
        //    DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info;
        //    info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;

        //    info.GroupText = "         " + info.GroupText.TrimStart();
        //    e.Info.Paint.FillRectangle(e.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds);
        //    e.Painter.DrawObject(e.Info);

        //    Rectangle r = info.ButtonBounds;
        //    r.Offset(r.Width * 2, 0);
        //    DrawCheckBox(e.Graphics, r, IsGroupRowSelected(e.RowHandle));
        //    e.Handled = true;
        //}

        //private void view_RowStyle(object sender, RowStyleEventArgs e)
        //{
        //    if (IsRowSelected(e.RowHandle))
        //    {
        //        //e.Appearance.BackColor = SystemColors.Highlight;
        //        //e.Appearance.ForeColor = SystemColors.HighlightText;
        //    }
        //}

        public GridView View
        {
            get
            {
                return view;
            }
            set
            {
                if (view != value)
                {
                    Detach();
                    Attach(value);
                }
            }
        }

        public GridColumn CheckMarkColumn
        {
            get
            {
                return column;
            }
        }

        public int SelectedCount
        {
            get
            {
                return selection.Count;
            }
        }

        public object GetSelectedRow(int index)
        {
            return selection[index];
        }

        public int GetSelectedIndex(object row)
        {
            return selection.IndexOf(row);
        }

        public void ClearSelection()
        {
            for (int i = 0; i < view.DataRowCount; i++)
            {
                if (view.Columns[column.VisibleIndex].FieldName == "chon")
                {
                    view.SetRowCellValue(i, "chon", 0);

                }
            }
            selection.Clear();
            Invalidate();
        }

        private void Invalidate()
        {
            view.BeginUpdate();
            view.EndUpdate();
        }

        public void SelectAll()
        {
            selection.Clear();
            for (int i = 0; i < view.DataRowCount; i++)
            {
                if (view.Columns[column.VisibleIndex].FieldName == "chon")
                {
                    view.SetRowCellValue(i, "chon", 1);

                }
                selection.Add(view.GetRow(i));
            }
            Invalidate();
        }

        public void SelectGroup(int rowHandle, bool select)
        {
            if (IsGroupRowSelected(rowHandle) && select) return;
            for (int i = 0; i < view.GetChildRowCount(rowHandle); i++)
            {
                int childRowHandle = view.GetChildRowHandle(rowHandle, i);
                if (view.IsGroupRow(childRowHandle))
                    SelectGroup(childRowHandle, select);
                else
                    SelectRow(childRowHandle, select, false);
            }
            Invalidate();
        }

        public void SelectRow(int rowHandle, bool select)
        {
            SelectRow(rowHandle, select, true);
        }

        private void SelectRow(int rowHandle, bool select, bool invalidate)
        {
            if (IsRowSelected(rowHandle) == select) return;
            object row = view.GetRow(rowHandle);
            if (select)
            {
                selection.Add(row);
                view.SetRowCellValue(rowHandle, "chon", 1);
            }
            else
            {
                selection.Remove(row);
                view.SetRowCellValue(rowHandle, "chon", 0);
            }

            if (invalidate)
            {
                Invalidate();
            }
        }

        public bool IsGroupRowSelected(int rowHandle)
        {
            for (int i = 0; i < view.GetChildRowCount(rowHandle); i++)
            {
                int row = view.GetChildRowHandle(rowHandle, i);
                if (view.IsGroupRow(row))
                {
                    if (!IsGroupRowSelected(row)) return false;
                }
                else
                    if (!IsRowSelected(row)) return false;
            }
            return true;
        }

        public bool IsRowSelected(int rowHandle)
        {
            if (view.IsGroupRow(rowHandle))
                return IsGroupRowSelected(rowHandle);

            object row = view.GetRow(rowHandle);
            return GetSelectedIndex(row) != -1;
        }

        private void view_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == CheckMarkColumn)
            {
                if (e.IsGetData)
                    e.Value = IsRowSelected(e.ListSourceRowIndex);
                else
                    SelectRow(e.ListSourceRowIndex, (bool)e.Value);
            }
        }

        private void edit_EditValueChanged(object sender, EventArgs e)
        {
            view.PostEditor();
        }
    }
}


