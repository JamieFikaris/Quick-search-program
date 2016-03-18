using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Dads_Program
{
    class Functions
    {
        public Functions(string inputFromTB)
        {
            this.input = inputFromTB;
            int num = createFolder();
            this.fileNum = num;
        }

        public List<string> fileNames = new List<string>();
        public string input;
        public int fileNum;
        public List<string> foundStuff = new List<string>();

        public int createFolder()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            string dir = @".\Data";
            int fileCount = 0;

            if (!Directory.Exists(System.IO.Path.Combine(path, dir)))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(path, dir));
            }
            else
            {
                fileCount = Directory.GetFiles(@".\Data").Length;
                foreach (string name in Directory.GetFiles(@".\Data", "*.txt",SearchOption.TopDirectoryOnly))
                {
                    fileNames.Add(name);
                }
            }
            return fileCount;
        }

        public void read()
        {
            foreach (string fn in fileNames)
            {
                TextReader text = new StreamReader(Path.Combine(fn));
                string currentLine;
                while ((currentLine = text.ReadLine()) != null)
                {
                    if (currentLine.Contains(input))
                    {
                        foundStuff.Add(currentLine);
                    }
                    else
                        continue;
                }
                text.Close();
            }

            if (foundStuff.Count == 0)
            {
                MessageBox.Show("Input was not found in any of the text files!");
            }

        }
    }
}
