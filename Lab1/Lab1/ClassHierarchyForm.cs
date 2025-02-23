using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Lab1
{
    public partial class ClassHierarchyForm : Form
    {
        public ClassHierarchyForm()
        {
            InitializeComponent();
            BuildClassHierarchy(typeof(ElectronicDevice), null);
            treeView1.ExpandAll();
        }

        private void BuildClassHierarchy(Type parent, TreeNode parentNode)
        {
            TreeNode newNode = new TreeNode(parent.Name);

            if (parentNode == null)
                treeView1.Nodes.Add(newNode);
            else
                parentNode.Nodes.Add(newNode);
            
            IEnumerable<Type> subclasses = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && t.BaseType == parent);

            foreach (var subclass in subclasses)
            {
                BuildClassHierarchy(subclass, newNode);
            }
        }
    }
}