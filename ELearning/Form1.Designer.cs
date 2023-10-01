using System.Runtime.CompilerServices;

namespace ELearning
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Label projectSelect;
        private ComboBox comboBoxProjects;
        private TabControl tabControl;
        private TabPage[] tabs;
        //private TabPage tabPage1;
        //private TabPage tabPage2;
        private Button checkTest;
        private Button reTest;
        private Button newTest;
        private Label resultLabel;
        private TextBox resultMessage;
    }
}