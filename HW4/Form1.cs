using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SimpleFileExplorer
{
    public partial class Form1 : Form
    {
        private Stack<string> backStack = new Stack<string>();
        private Stack<string> forwardStack = new Stack<string>();
        private string currentPath = "C:\\";

        public Form1()
        {
            InitializeComponent();
            InitializeFileExplorer();
        }

        private void InitializeFileExplorer()
        {
            // 初始化C盘目录结构
            TreeNode rootNode = new TreeNode("C:\\");
            rootNode.Tag = "C:\\";
            treeViewFolders.Nodes.Add(rootNode);
            rootNode.Expand();
            LoadDirectories(rootNode);
        }

        // 加载文件夹到树形视图
        private void LoadDirectories(TreeNode node)
        {
            string path = (string)node.Tag;
            try
            {
                string[] directories = Directory.GetDirectories(path);
                foreach (var dir in directories)
                {
                    TreeNode dirNode = new TreeNode(Path.GetFileName(dir));
                    dirNode.Tag = dir;
                    node.Nodes.Add(dirNode);
                }
            }
            catch (UnauthorizedAccessException) { }
        }

        // 当展开节点时，加载子文件夹
        private void treeViewFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                LoadDirectories(e.Node);
            }
        }

        // 选择节点后加载该目录下的文件
        private void treeViewFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = (string)e.Node.Tag;
            NavigateToPath(path);
        }

        private void ClickFolder(object sender, EventArgs e)
        {
            TreeNode node = treeViewFolders.SelectedNode;
            if (node!= null)
            {
                string path = (string)node.Tag;
                NavigateToPath(path);
            }
        }

        // 加载文件到列表视图，并显示大小
        private void LoadFiles(string path)
        {
            listViewFiles.Items.Clear();
            try
            {
                // 显示文件夹
                string[] directories = Directory.GetDirectories(path);
                foreach (var dir in directories)
                {
                    ListViewItem item = new ListViewItem(Path.GetFileName(dir), 0);
                    item.Tag = dir;
                    item.SubItems.Add("");  // 文件夹没有大小
                    listViewFiles.Items.Add(item);
                }

                // 显示文件
                string[] files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    ListViewItem item = new ListViewItem(Path.GetFileName(file), 1);
                    item.Tag = file;
                    long fileSize = new FileInfo(file).Length;
                    item.SubItems.Add(fileSize.ToString());  // 显示文件大小
                    listViewFiles.Items.Add(item);
                }
            }
            catch (UnauthorizedAccessException) { }
        }

        // 双击文件处理逻辑
        private void listViewFiles_ItemActivate(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewFiles.SelectedItems[0];
                string path = (string)selectedItem.Tag;

                if (Directory.Exists(path))
                {
                    NavigateToPath(path);
                }
                else if (File.Exists(path))
                {
                    // 对 .exe 和 .txt 文件进行特殊处理
                    if (Path.GetExtension(path) == ".exe")
                    {
                        Process.Start(path);
                    }
                    else if (Path.GetExtension(path) == ".txt")
                    {
                        Process.Start("notepad.exe", path);
                    }
                    else
                    {
                        MessageBox.Show("此文件类型未定义操作。");
                    }
                }
            }
        }

        // 导航到指定路径，并记录回退信息
        private void NavigateToPath(string path)
        {
            if (!string.IsNullOrEmpty(currentPath))
            {
                backStack.Push(currentPath); // 记录当前路径到回退栈
            }

            forwardStack.Clear(); // 清空前进栈，因为每次新导航都会使前进栈无效
            currentPath = path;
            LoadFiles(path); // 加载文件
        }

        // 刷新按钮功能
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentPath))
            {
                LoadFiles(currentPath); // 重新加载当前选中的目录
            }
        }

        // 回退功能
        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            if (backStack.Count > 0)
            {
                forwardStack.Push(currentPath); // 当前路径推入前进栈
                string previousPath = backStack.Pop(); // 获取回退栈的路径
                currentPath = previousPath;
                LoadFiles(previousPath); // 导航到之前的路径
            }
            else
            {
                MessageBox.Show("没有可以回退的路径。");
            }
        }

        // 撤销回退（前进）功能
        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            if (forwardStack.Count > 0)
            {
                backStack.Push(currentPath); // 当前路径推入回退栈
                string nextPath = forwardStack.Pop(); // 获取前进栈的路径
                currentPath = nextPath;
                LoadFiles(nextPath); // 导航到下一路径
            }
            else
            {
                MessageBox.Show("没有可以前进的路径。");
            }
        }
    }
}

