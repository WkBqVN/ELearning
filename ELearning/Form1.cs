using ELearning.Components;
using ELearning.Manager;
using System.Drawing.Text;
using System.Runtime.CompilerServices;

namespace ELearning
{
    public partial class MainForm : Form
    {
        private string srcPath = "K:\\Work\\ELearning\\Mos_data\\mos\\world\\WORD\\MOS Word  2016 - GMetrix Online Buoi 1";
        private string pdfFilePath = "K:\\Work\\ELearning\\Mos_data\\mos\\world\\WORD\\MOS Word  2016 - GMetrix Online Buoi 1\\TAI LIEU MOS WORD 2016 BUOI 1.pdf";
        private string currentProject = "";
        private FileManager fileManager;
        private ProjectManager projectManager;
        public MainForm()
        {
            fileManager = new FileManager();
            InitializeData();
            InitializeComponent();
            SetUpComponent();
        }
        private void InitializeData()
        {
            projectManager = new ProjectManager();
            projectManager.initiallize(pdfFilePath);
        }

        private void InitializeComponent()
        {
            fileManager.GetFileData(srcPath);
            projectSelect = new Label();
            comboBoxProjects = new ComboBox();
            tabControl = new TabControl();
            checkTest = new Button();
            reTest = new Button();
            newTest = new Button();
            resultLabel = new Label();
            resultMessage = new TextBox();
            SuspendLayout();
            // 
            // projectSelect
            // 
            projectSelect.AutoSize = true;
            projectSelect.Location = new Point(25, 38);
            projectSelect.Name = "projectSelect";
            projectSelect.Size = new Size(83, 15);
            projectSelect.TabIndex = 0;
            projectSelect.Text = "Select Projects";
            projectSelect.Click += projectSelect_Click_1;
            // 
            // comboBoxProjects
            // 
            comboBoxProjects.Location = new Point(158, 30);
            comboBoxProjects.Name = "comboBoxProjects";
            comboBoxProjects.Size = new Size(302, 23);
            comboBoxProjects.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Location = new Point(25, 75);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(435, 195);
            tabControl.TabIndex = 1;
            // 
            // button1
            // 
            reTest.Location = new Point(25, 299);
            reTest.Name = "button1";
            reTest.Size = new Size(122, 23);
            reTest.TabIndex = 2;
            reTest.Text = "button1";
            reTest.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            newTest.Location = new Point(178, 299);
            newTest.Name = "button2";
            newTest.Size = new Size(122, 23);
            newTest.TabIndex = 3;
            newTest.Text = "button2";
            newTest.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            checkTest.Location = new Point(338, 299);
            checkTest.Name = "button3";
            checkTest.Size = new Size(122, 23);
            checkTest.TabIndex = 4;
            checkTest.Text = "button3";
            checkTest.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(25, 368);
            resultLabel.Name = "label1";
            resultLabel.Size = new Size(38, 15);
            resultLabel.TabIndex = 5;
            resultLabel.Text = "label1";
            resultLabel.Click += label1_Click;
            // 
            // textBox1
            // 
            resultMessage.Location = new Point(25, 395);
            resultMessage.Multiline = true;
            resultMessage.Name = "textBox1";
            resultMessage.Size = new Size(435, 180);
            resultMessage.TabIndex = 6;
            // 
            // MainForm
            // 
            ClientSize = new Size(483, 599);
            //ClientSize.Width = 483;
            //ClientSize.Height = 599;
            Controls.Add(resultMessage);
            Controls.Add(resultLabel);
            Controls.Add(reTest);
            Controls.Add(checkTest);
            Controls.Add(newTest);
            Controls.Add(tabControl);
            Controls.Add(comboBoxProjects);
            Controls.Add(projectSelect);
            Name = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private void projectSelect_Click(object sender, EventArgs e)
        {
        }

        private void SetUpComponent()
        {
            InitComboBoxProjects(comboBoxProjects);
            InitTabPages(tabControl);
            InitButtons(reTest,newTest,checkTest);
            InitResult(resultLabel,resultMessage);
        }
        public List<string> getSelectBoxDisplay()
        {
            return fileManager.getFolders(srcPath);
        }

        private void InitComboBoxProjects(ComboBox comboBoxProjects)
        {
            List<string> data = getSelectBoxDisplay();
            foreach (string project in data) {

                comboBoxProjects.Items.Add(project);
            }
            comboBoxProjects.Text = data[0];
            comboBoxProjects.SelectedIndex = 0;
            comboBoxProjects.FormattingEnabled = true;
            comboBoxProjects.Location = new Point(158, 30);
            comboBoxProjects.Name = "comboBoxProjects";
            comboBoxProjects.Size = new Size(302, 23);
            comboBoxProjects.TabIndex = 0;
            comboBoxProjects.SelectedIndexChanged += comboBoxProjectsSelectedIndexChanged;
            currentProject = data[0];
        }
        private void InitTabPages(TabControl tabControl)
        {
            tabControl.Location = new Point(25, 75);
            tabControl.Name = "tabControl1";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(435, 200);
            tabControl.TabIndex = 1;

            for(int i = 0; i < projectManager.projects.Count; i++)
            {
                if (projectManager.projects[i].ProjectTitle == currentProject)
                {
                    List<TabPage> tabs = getTabPages(projectManager.projects[0].SubTask);
                    setListTabs(tabControl, tabs);
                }
            }
            //List<TabPage> tabs = getTabPages(projectManager.projects[0].SubTask);

            //setListTabs(tabControl, tabs);
        }
        private void setListTabs(TabControl tabControl, List<TabPage> tabPages)
        {
            for (int i = 0; i < tabPages.Count; i++)
            {
                tabControl.TabPages.Add(tabPages[i]);
            }
        }
        private List<TabPage> getTabPages(Dictionary<string,string> subTasks)
        {
            List<TabPage> listTab = new List<TabPage>();
            foreach (string key in subTasks.Keys)
            {
                    TabPage tabPage = new TabPage();
                    tabPage.Text = key;
                    TextBox textBox = new TextBox();
                    textBox.Text = subTasks[key];
                    textBox.Size = new Size(435, 195);
                    textBox.Multiline = true;
                    textBox.ScrollBars = ScrollBars.Vertical;
                    tabPage.Controls.Add(textBox);
                    listTab.Add(tabPage);
            }
            return listTab;
        }
       
        private void InitButtons (Button reTest, Button newTest, Button checkTest)
        {
            reTest.Location = new Point(25, 299);
            reTest.Name = "button1";
            reTest.Size = new Size(122, 23);
            reTest.TabIndex = 2;
            reTest.Text = "Thực hành lại";
            reTest.UseVisualStyleBackColor = true;
            reTest.Click += reTest_click;

            newTest.Location = new Point(178, 299);
            newTest.Name = "button2";
            newTest.Size = new Size(122, 23);
            newTest.TabIndex = 3;
            newTest.Text = "Thực hành mới";
            newTest.UseVisualStyleBackColor = true;
            newTest.Click += newTest_click;

            checkTest.Location = new Point(338, 299);
            checkTest.Name = "button3";
            checkTest.Size = new Size(122, 23);
            checkTest.TabIndex = 4;
            checkTest.Text = "Kiểm tra";
            checkTest.UseVisualStyleBackColor = true;
            checkTest.Click += checkTest_click;
        }
        private void InitResult(Label resultLabel, TextBox resultMessage)
        {
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(25, 368);
            resultLabel.Name = "label1";
            resultLabel.Size = new Size(38, 15);
            resultLabel.TabIndex = 5;
            resultLabel.Text = "Kết quả";
            resultLabel.Click += label1_Click;

            resultMessage.Location = new Point(25, 395);
            resultMessage.Multiline = true;
            resultMessage.Name = "abc xyz";
            resultMessage.Size = new Size(435, 180);
            resultMessage.TabIndex = 6;
        }

        private void reTest_click(object sender, EventArgs e)
        {
            resultMessage.Text = "OK";
        }
        private void newTest_click(object sender, EventArgs e)
        {
            resultMessage.Text = "Bắt đầu bài kiểm tra";
        }

        private void checkTest_click(object sender, EventArgs e)
        {
            resultMessage.Text = currentProject;
        }

        private void comboBoxProjectsSelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < projectManager.projects.Count; i++)
            {
                 if (projectManager.projects[i].ProjectTitle == comboBoxProjects.SelectedItem.ToString())
                 {
                    tabControl.TabPages.Clear();
                    List<TabPage> tabs = getTabPages(projectManager.projects[i].SubTask);
                    setListTabs(tabControl, tabs);
                 }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void projectSelect_Click_1(object sender, EventArgs e)
        {

        }
    }
}