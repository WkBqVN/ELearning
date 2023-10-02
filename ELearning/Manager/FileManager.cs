using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ELearning.Manager
{
    internal class FileManager
    {
        public List<string> directories;
        public List<string> folders;
        public FileInfo[] files;
        public  FileManager() {
            directories = new List<string>();
            folders = new List<string>();
        }
        public String openFileWord(string fileWordPath)
        {
            try
            {
                Process.Start("C:\\Program Files\\LibreOffice\\program\\soffice.exe", $"\"{fileWordPath}\"");
            }catch(Exception e)
            {
                Process.Start(fileWordPath);
                return e.Message;
            }
            return "Hello world";
        } 
        private void readDirectoryData(string path)
        {
            // full path of files
            directories = Directory.GetDirectories(path).ToList();
        }

        public List<string> getFolders(string path)
        {
            readDirectoryData(path); 
            foreach (string dir in directories)
            {
                folders.Add(dir.Split(Path.DirectorySeparatorChar).Last());
            }
            return folders;
        }

        public void GetFileData(string path)
        {
            DirectoryInfo director = new DirectoryInfo(path); 
            files = director.GetFiles();
        }

        public List<string> getListFile() {
            List<string> listFile = new List<string>();
            foreach(FileInfo file in files)
            {
                listFile.Add(file.Name);
            }
            return listFile;
        }
           
    }
}
