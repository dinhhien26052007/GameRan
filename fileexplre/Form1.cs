using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace fileexplre
{
    public partial class Form1 : Form
    {
        private string currentPath = "";
        private Stack<string> backHistory = new Stack<string>();
        private Stack<string> forwardHistory = new Stack<string>();
        private string clipboardPath = "";
        private bool isCutAction = false;

        public Form1()
        {
            InitializeComponent();
            SetupFormEvents();
        }

        private void SetupFormEvents()
        {
            this.Load += Form1_Load;
            this.treeView1.BeforeExpand += TreeView1_BeforeExpand;
            this.treeView1.AfterSelect += TreeView1_AfterSelect;
            this.listView1.DoubleClick += ListView1_DoubleClick;
            this.listView1.LabelEdit = true;
            this.listView1.AfterLabelEdit += ListView1_AfterLabelEdit;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            try
            {

                if (listView1.Columns.Count >= 4)
                {
                    listView1.Columns[0].Width = 250;
                    listView1.Columns[1].Width = 100;
                    listView1.Columns[2].Width = 100;
                    listView1.Columns[3].Width = 150;
                }

                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.IsReady)
                    {
                        TreeNode node = new TreeNode(drive.Name);
                        node.Tag = drive.Name;
                        node.Nodes.Add("TempNode");
                        treeView1.Nodes.Add(node);
                    }
                }
                toolStripComboBoxView.Items.Clear();
                toolStripComboBoxView.Items.AddRange(new object[] { "Details", "Large Icons", "Small Icons", "List", "Tile" });


                toolStripComboBoxView.SelectedIndex = 0;
                toolStripComboBoxView.SelectedIndexChanged += (s, ev) =>
                {
                    string? selectedView = toolStripComboBoxView.SelectedItem?.ToString();
                    if (selectedView != null)
                    {
                        switch (selectedView)
                        {
                            case "Details": listView1.View = View.Details; break;
                            case "Large Icons": listView1.View = View.LargeIcon; break;
                            case "Small Icons": listView1.View = View.SmallIcon; break;
                            case "List": listView1.View = View.List; break;
                            case "Tile": listView1.View = View.Tile; break;
                        }
                    }
                };
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khởi động: " + ex.Message); }
        }

        private void TreeView1_BeforeExpand(object? sender, TreeViewCancelEventArgs e)
        {
            TreeNode? node = e.Node;
            if (node == null || node.Tag == null) return;
            node.Nodes.Clear();
            try
            {
                string path = node.Tag.ToString() ?? "";
                foreach (string dir in Directory.GetDirectories(path))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    TreeNode childNode = new TreeNode(dirInfo.Name);
                    childNode.Tag = dir;
                    childNode.Nodes.Add("TempNode");
                    node.Nodes.Add(childNode);
                }
            }
            catch { }
        }

        private void TreeView1_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                NavigateTo(e.Node.Tag.ToString() ?? "");
            }
        }

        private void NavigateTo(string path)
        {
            if (string.IsNullOrEmpty(path) || currentPath == path) return;
            if (!string.IsNullOrEmpty(currentPath))
            {
                backHistory.Push(currentPath);
                forwardHistory.Clear();
            }
            currentPath = path;
            LoadFilesAndFolders(currentPath);
        }

        private void LoadFilesAndFolders(string path)
        {
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path)) return;
            listView1.Items.Clear();
            try
            {
                foreach (string dir in Directory.GetDirectories(path))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    ListViewItem item = new ListViewItem(dirInfo.Name);
                    item.Tag = dir;
                    item.SubItems.Add("Folder");
                    item.SubItems.Add("");
                    item.SubItems.Add(dirInfo.LastWriteTime.ToString());
                    listView1.Items.Add(item);
                }
                foreach (string file in Directory.GetFiles(path))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    ListViewItem item = new ListViewItem(fileInfo.Name);
                    item.Tag = file;
                    item.SubItems.Add(fileInfo.Extension + " File");
                    item.SubItems.Add((fileInfo.Length / 1024).ToString() + " KB");
                    item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi truy cập: " + ex.Message); }
        }

        private void ListView1_DoubleClick(object? sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            string? selectedPath = listView1.SelectedItems[0].Tag?.ToString();
            if (string.IsNullOrEmpty(selectedPath)) return;

            if (Directory.Exists(selectedPath)) NavigateTo(selectedPath);
            else if (File.Exists(selectedPath))
            {
                try { Process.Start(new ProcessStartInfo(selectedPath) { UseShellExecute = true }); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        public void newFolderAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentPath) || !Directory.Exists(currentPath)) return;
            try
            {
                string newFolderPath = Path.Combine(currentPath, "New Folder");
                int i = 1;
                while (Directory.Exists(newFolderPath))
                {
                    newFolderPath = Path.Combine(currentPath, $"New Folder ({i})");
                    i++;
                }
                Directory.CreateDirectory(newFolderPath);
                LoadFilesAndFolders(currentPath);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tạo thư mục: " + ex.Message); }
        }


        public void newFileAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentPath) || !Directory.Exists(currentPath)) return;
            try
            {
                string newFilePath = Path.Combine(currentPath, "New Text Document.txt");
                int i = 1;
                while (File.Exists(newFilePath))
                {
                    newFilePath = Path.Combine(currentPath, $"New Text Document ({i}).txt");
                    i++;
                }
                using (File.Create(newFilePath)) { }
                LoadFilesAndFolders(currentPath);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tạo file: " + ex.Message); }
        }

        public void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            clipboardPath = listView1.SelectedItems[0].Tag?.ToString() ?? "";
            isCutAction = true;
        }

        public void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            string? target = listView1.SelectedItems[0].Tag?.ToString();
            if (string.IsNullOrEmpty(target)) return;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(target)) File.Delete(target);
                    else if (Directory.Exists(target)) Directory.Delete(target, true);
                    LoadFilesAndFolders(currentPath);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        public void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clipboardPath) || string.IsNullOrEmpty(currentPath)) return;
            try
            {
                string destPath = Path.Combine(currentPath, Path.GetFileName(clipboardPath));
                if (File.Exists(clipboardPath))
                {
                    File.Copy(clipboardPath, destPath, true);
                    if (isCutAction) File.Delete(clipboardPath);
                }
                else if (Directory.Exists(clipboardPath))
                {
                    CopyDirectory(clipboardPath, destPath);
                    if (isCutAction) Directory.Delete(clipboardPath, true);
                }
                LoadFilesAndFolders(currentPath);
                clipboardPath = "";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi dán: " + ex.Message); }
        }

        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView1_DoubleClick(sender, e);
        }

        public void toolStripButtonUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentPath)) return;
            DirectoryInfo? parent = Directory.GetParent(currentPath);
            if (parent != null) NavigateTo(parent.FullName);
        }

        public void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadFilesAndFolders(currentPath);
        }

        public void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            listView1.SelectedItems[0].BeginEdit();
        }
        private void ListView1_AfterLabelEdit(object? sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Label) || sender == null) { e.CancelEdit = true; return; }
            string? oldPath = listView1.Items[e.Item].Tag?.ToString();
            if (string.IsNullOrEmpty(oldPath)) { e.CancelEdit = true; return; }
            string? parentPath = Path.GetDirectoryName(oldPath);
            if (string.IsNullOrEmpty(parentPath)) { e.CancelEdit = true; return; }
            string newPath = Path.Combine(parentPath, e.Label);
            try
            {
                if (File.Exists(oldPath)) File.Move(oldPath, newPath);
                else if (Directory.Exists(oldPath)) Directory.Move(oldPath, newPath);
                listView1.Items[e.Item].Tag = newPath;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi đổi tên: " + ex.Message); e.CancelEdit = true; }
        }
        private void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);
            foreach (string file in Directory.GetFiles(sourceDir))
                File.Copy(file, Path.Combine(destDir, Path.GetFileName(file)), true);
            foreach (string dir in Directory.GetDirectories(sourceDir))
                CopyDirectory(dir, Path.Combine(destDir, Path.GetFileName(dir)));
        }
    }
}
