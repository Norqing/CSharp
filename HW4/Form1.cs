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
            // ��ʼ��C��Ŀ¼�ṹ
            TreeNode rootNode = new TreeNode("C:\\");
            rootNode.Tag = "C:\\";
            treeViewFolders.Nodes.Add(rootNode);
            rootNode.Expand();
            LoadDirectories(rootNode);
        }

        // �����ļ��е�������ͼ
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

        // ��չ���ڵ�ʱ���������ļ���
        private void treeViewFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                LoadDirectories(e.Node);
            }
        }

        // ѡ��ڵ����ظ�Ŀ¼�µ��ļ�
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

        // �����ļ����б���ͼ������ʾ��С
        private void LoadFiles(string path)
        {
            listViewFiles.Items.Clear();
            try
            {
                // ��ʾ�ļ���
                string[] directories = Directory.GetDirectories(path);
                foreach (var dir in directories)
                {
                    ListViewItem item = new ListViewItem(Path.GetFileName(dir), 0);
                    item.Tag = dir;
                    item.SubItems.Add("");  // �ļ���û�д�С
                    listViewFiles.Items.Add(item);
                }

                // ��ʾ�ļ�
                string[] files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    ListViewItem item = new ListViewItem(Path.GetFileName(file), 1);
                    item.Tag = file;
                    long fileSize = new FileInfo(file).Length;
                    item.SubItems.Add(fileSize.ToString());  // ��ʾ�ļ���С
                    listViewFiles.Items.Add(item);
                }
            }
            catch (UnauthorizedAccessException) { }
        }

        // ˫���ļ������߼�
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
                    // �� .exe �� .txt �ļ��������⴦��
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
                        MessageBox.Show("���ļ�����δ���������");
                    }
                }
            }
        }

        // ������ָ��·��������¼������Ϣ
        private void NavigateToPath(string path)
        {
            if (!string.IsNullOrEmpty(currentPath))
            {
                backStack.Push(currentPath); // ��¼��ǰ·��������ջ
            }

            forwardStack.Clear(); // ���ǰ��ջ����Ϊÿ���µ�������ʹǰ��ջ��Ч
            currentPath = path;
            LoadFiles(path); // �����ļ�
        }

        // ˢ�°�ť����
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentPath))
            {
                LoadFiles(currentPath); // ���¼��ص�ǰѡ�е�Ŀ¼
            }
        }

        // ���˹���
        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            if (backStack.Count > 0)
            {
                forwardStack.Push(currentPath); // ��ǰ·������ǰ��ջ
                string previousPath = backStack.Pop(); // ��ȡ����ջ��·��
                currentPath = previousPath;
                LoadFiles(previousPath); // ������֮ǰ��·��
            }
            else
            {
                MessageBox.Show("û�п��Ի��˵�·����");
            }
        }

        // �������ˣ�ǰ��������
        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            if (forwardStack.Count > 0)
            {
                backStack.Push(currentPath); // ��ǰ·���������ջ
                string nextPath = forwardStack.Pop(); // ��ȡǰ��ջ��·��
                currentPath = nextPath;
                LoadFiles(nextPath); // ��������һ·��
            }
            else
            {
                MessageBox.Show("û�п���ǰ����·����");
            }
        }
    }
}

