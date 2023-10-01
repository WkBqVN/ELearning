using ELearning.Components;
using ELearning.Manager;
using System.Drawing.Text;
using System.Runtime.CompilerServices;

namespace ELearning
{
    public partial class MainForm : Form
    {
        private string srcPath = "K:\\Work\\Mos_data\\mos\\world\\WORD\\MOS Word  2016 - GMetrix Online Buoi 1";
        private string currentProject = "";
        private FileManager fileManager;
        private TaskManager taskManager;
        public MainForm()
        {
            fileManager = new FileManager();
            taskManager = new TaskManager();
            // init default set up base on design
            InitializeComponent();
            // set up default on view
            SetUpComponent();
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
            string pdfFilePath = "K:\\Work\\Mos_data\\mos\\world\\WORD\\MOS Word  2016 - GMetrix Online Buoi 1\\TAI LIEU MOS WORD 2016 BUOI 1.pdf";
            tabControl.Location = new Point(25, 75);
            tabControl.Name = "tabControl1";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(435, 200);
            tabControl.TabIndex = 1;

            TabPage tab1 = new TabPage();
            //tabPage1.Location = new Point(4, 24);
            TextBox s = new TextBox();
            Project project = taskManager.GetTask(pdfFilePath);
            //s.Text = project.ProjectTitle + project.SubTask["Project 1"];
            //s.Text = taskManager.ReadPDFData(pdfFilePath)[15]; 
            s.Size = new Size(435, 195);
            s.Multiline = true;
            s.ScrollBars = ScrollBars.Vertical;

            TextBox x = new TextBox();
            x.Text = "hellosadfksadfdsajfsdakfjsadkfjsdkafjsadkjfskdajfskadjfksdajfsdkajfsdakfsdakjfsadfkdsafkjsadfdasjkfsdkdsakfsdakjfds[";
            x.Size = new Size(435, 195);
            x.Multiline = true;
            x.ScrollBars = ScrollBars.Vertical;

            tab1.Name = "task 1";
            tab1.Padding = new Padding(3);
            tab1.Size = new Size(431, 167);
            tab1.TabIndex = 0;
            tab1.Text = "task 1";
            tab1.UseVisualStyleBackColor = true;
            tab1.Controls.Add(s);

            TabPage tab2 = new TabPage();
            tab2.Name = "task 1";
            tab2.Padding = new Padding(3);
            tab2.Size = new Size(431, 167);
            tab2.TabIndex = 0;
            tab2.Text = "task 2";
            tab2.UseVisualStyleBackColor = true;
            tab2.Controls.Add(x);

            TabPage tab3 = new TabPage();
            tab3.Name = "task 1";
            tab3.Padding = new Padding(3);
            tab3.Size = new Size(431, 167);
            tab3.TabIndex = 0;
            tab3.Text = "task 3";
            tab3.UseVisualStyleBackColor = true;

            TabPage[] tagPages = new TabPage[]
            {
                tab1,tab2,tab3
            };
            List<TabPage> tabs = setTabPages(project);

            setListTabs(tabControl, tabs);
        }
        private void setListTabs(TabControl tabControl, List<TabPage> tabPages)
        {
            for (int i = 0; i < tabPages.Count; i++)
            {
                tabControl.TabPages.Add(tabPages[i]);
            }
        }
        private List<TabPage> setTabPages(Project project)
        {
            List<TabPage> listTab = new List<TabPage>();
            //for (int i =0; i < project.getProjectsIndexs ;i++)
            //{
            //    TabPage tabPage = new TabPage();
            //    tabPage.Text = key;
            //    TextBox textBox = new TextBox();
            //    textBox.Text = project.SubTask[key];
            //    textBox.Size = new Size(435, 195);
            //    textBox.Multiline = true;
            //    textBox.ScrollBars = ScrollBars.Vertical;
            //    tabPage.Controls.Add(textBox);
            //    listTab.Add(tabPage);
            //}
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
            if (string.IsNullOrEmpty(comboBoxProjects.SelectedItem.ToString()))
            {
                currentProject = "failed to get Project data";
            }
            else
            {
                currentProject = comboBoxProjects.SelectedItem.ToString();
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