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
        public List<Project> projects;
        string ProjectTitle = "";
        string projectTag = "Project";
        int startProjectIndex =0;
        int endProjecttIndex = 0;
        List<string> data;
        // multi project
        public ProjectManager(){
            projects = new List<Project>();
        }

        public void initiallize(string pdfFilePath)
        {
            data = taskManager.ReadPDFData(pdfFilePath);
            Dictionary<string, int[]> listProject = getProjectsIndexs(data);
            foreach (string key  in listProject.Keys)
            {
                Project project = new Project();
                project.ProjectTitle = key;
                project.SubTask = taskManager.GetListSubTask(data, listProject[key][0], listProject[key][1]);
                projects.Add(project);
            }
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
                    startProjectIndex = endProjecttIndex+3;
                }
            }
            return listProject;
        }
    }
}
