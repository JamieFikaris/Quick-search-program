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
        private string input;
        public String Input
        {
            get{ return this.input; }
            set
            {
                if (value == "")
                    throw new Exception("Empty input!");
                else
                this.input = value;
            } 
        }

        private List<string> fileNames = new List<string>();
        private List<string> foundStuff = new List<string>();
        public List<string> MyList
        {
            get { return foundStuff; }
        }

        public void createFolder()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory; //set directory to folder app is in
            string dir = @".\Data";

            if (!Directory.Exists(System.IO.Path.Combine(path, dir))) //if the data folder doesn't exist in the directory
            {
                Directory.CreateDirectory(System.IO.Path.Combine(path, dir)); //create it
            }
            else
            {
                foreach (string name in Directory.GetFiles(@".\Data", "*.txt", SearchOption.TopDirectoryOnly))//get all file names in the data folder
                {
                    fileNames.Add(name);
                }
            }
        }
        public void readAndSearch()
        {
            foreach (string fn in fileNames) //for every text file in the data folder
            {
                TextReader text = new StreamReader(Path.Combine(fn));
                string currentLine;
                while ((currentLine = text.ReadLine()) != null) //while there is still text in the text file
                {
                    if (currentLine.Contains(input)) //if the input is in the current line
                    {
                        foundStuff.Add(currentLine); //add to foundstuff list
                    }
                    else
                        continue; //if input is not found go to the next line in the text file
                }
                text.Close();
            }

            if (foundStuff.Count == 0) //if no lines containing the input is found
            {
                MessageBox.Show("Input was not found in any of the text files!");
            }
        }
    }
}
