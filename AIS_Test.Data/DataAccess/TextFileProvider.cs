using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AIS_Test.Data.Model;

namespace AIS_Test.Data.DataAccess
{
    public class TextFileProvider:IFileProvider
    {
        public string fileName;

        public TextFileProvider(string fileName)
        {
            this.fileName = fileName;
        }
        public void WriteData(IBase obj)
        {
            using (TextWriter tw = new StreamWriter(fileName,true))
            {
                tw.WriteLine(obj.getData());
                tw.Close();
            }
        }

        public void UpdateData(int id, IBase obj)
        {
            StringBuilder strBldr = new StringBuilder("");
            using (StreamReader sr = new StreamReader(fileName))
            {
                string data;
                while ((data = sr.ReadLine()) != null)
                {
                    if (data != string.Empty)
                    {
                        if (Convert.ToInt32(data.Split(',')[0]) == obj.Id)
                        {
                            strBldr.AppendLine(obj.getData());
                        }
                        else
                        {
                            strBldr.AppendLine(data);
                        }
                    }
                }
                sr.Close();
            }
            using (TextWriter tw = new StreamWriter(fileName,false))
            {
                tw.WriteLine(strBldr.ToString());
                tw.Close();
            }
        }

        public void DeleteData(int id)
        {
            StringBuilder strBldr = new StringBuilder("");
            using (StreamReader sr = new StreamReader(fileName))
            {
                string data;
                while ((data = sr.ReadLine()) != null)
                {
                    if (data != string.Empty)
                    {
                        if (Convert.ToInt32(data.Split(',')[0]) != id)
                        {
                            strBldr.AppendLine(data);
                        }
                    }
                }
                sr.Close();
            }
            using (TextWriter tw = new StreamWriter(fileName, false))
            {
                tw.WriteLine(strBldr.ToString());
                tw.Close();
            }
        }

        public List<string> getData()
        {
            List<string> result = new List<string>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string data;
                while ((data = sr.ReadLine()) != null)
                {
                    if(data!=string.Empty)
                        result.Add(data);
                }
                sr.Close();
            }
            return result;
        }
    }
}
