using ELearning.Components;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ELearning.Manager
{
    internal class TaskManager
    {
        string srcPath = "K:\\Work\\Mos_data\\mos\\world\\WORD\\MOS Word  2016 - GMetrix Online Buoi 1\\TAI LIEU MOS WORD 2016 BUOI 1.pdf";
        // index to read data (include title)
        int startOffset = 12;
        int endOffset = 0;
        //List<Task> tasks;
        public TaskManager() { }
        public List<string> ReadPDFData(string pdfFilePath)
        {
            string data="";
            var stream = File.OpenRead(pdfFilePath);
            UglyToad.PdfPig.PdfDocument doc = UglyToad.PdfPig.PdfDocument.Open(stream);
            for (int i = 0;i < doc.NumberOfPages; i++)
            {
                //data += string.Join(",",doc.GetPage(i+1).GetWords());
                data += doc.GetPage(i + 1).Text;
            }
            return data.Split(' ').ToList();
        }

        public Dictionary<string,string> GetListSubTask(List<string> data, int startIndex, int endIndex)
        {
            Dictionary<string,string> tasks = new Dictionary<string, string>();
            int taskCount = 1;
            string tagTask = "Task";
            string taskTitle = "";
            string taskDescription = "";
            for (int i = startIndex; i < endIndex; i++)
            {
                if (data[i] == tagTask && data[i + 1] == taskCount.ToString()){ 
                   taskTitle = data[i] + " " + data[++i];
                }
                else if ((data[i] == tagTask && data[i +1 ] != taskCount.ToString()) || i == endIndex-1)
                {
                    tasks.Add(taskTitle,taskDescription);
                    taskTitle = data[i] +" "+ data[++i];
                    taskDescription = "";
                    taskCount++;
                }
                else
                {
                    taskDescription += data[i] + " ";
                }
            }
            return tasks;
        }
    }
}
