using ELearning.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Manager
{
    internal class ProjectManager
    {
        TaskManager taskManager = new TaskManager();

        string ProjectTitle = "";
        string projectTag = "Project";
        int startProjectIndex =0;
        int endProjecttIndex = 0;
        List<string> data;
        // multi project
        ProjectManager(string pdfFilePath)
        {
            data = taskManager.ReadPDFData(pdfFilePath);
        }

        public List<Project> GetListProject(string projectPath) { 

        }

        public Project GetTask(string pdfFilePath)
        {
            Dictionary<string, int[]> projects;
            Project project = new Project();
            projects = getProjectsIndexs(data);
            foreach (string key in projects.Keys)
            {
                project.SubTask = taskManager.GetListSubTask(data, projects[key][0], projects[key][1]);
            }
            return project;
        }

        public Dictionary<string, int[]> getProjectsIndexs(List<string> data)
        {
            Dictionary<string, int[]> listProject = new Dictionary<string, int[]>();
            int projectCount = 1;
            int[] startEndProject = new int[2];
            for (int i = 0; i <= data.Count - 1; i++)
            {
                if (data[i] == projectTag && data[i + 1] == projectCount.ToString())
                {
                    ProjectTitle = data[i] + " " + data[i + 1];
                    startProjectIndex = i + 2;
                }
                if (data[i] == projectTag && data[i + 1] != projectCount.ToString() || i == data.Count - 1)
                {
                    if (i == data.Count - 1)
                    {
                        endProjecttIndex = i;
                    }
                    else
                    {
                        endProjecttIndex = i - 1;
                    }
                    listProject.Add(projectTag + " " + projectCount.ToString(), new int[2] { startProjectIndex, endProjecttIndex });
                    projectCount++;
                    startProjectIndex = endProjecttIndex;
                }
            }
            return listProject;
        }
    }
}
