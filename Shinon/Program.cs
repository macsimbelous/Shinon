using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Shinon
{
    class Program
    {
        static void Main(string[] args)
        {
            string PATH = Environment.GetEnvironmentVariable("PATH");
            string[] dirs = PATH.Split(';');
            List<string> new_dirs = new List<string>();
            foreach (string s in dirs)
            {
                Console.WriteLine(s);
            }
            using (TextReader reader = File.OpenText(@".\path.txt"))
            {
                string line = reader.ReadLine();
                if (!ExistPATH(dirs, line)) 
                { 
                    new_dirs.Add(line);
                    Console.WriteLine("Add to PATH: " + line);
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(PATH);
            if (PATH[PATH.Length - 1] != ';')
            {
                sb.Append(";");
            }
            for (int i = 0; i < new_dirs.Count;i++)
            {
                if (i < (new_dirs.Count - 1))
                {
                    sb.Append(new_dirs[i]);
                    sb.Append(";");
                }
                else { sb.Append(new_dirs[i]); }
            }
            string NEW_PATH = sb.ToString();
            Console.WriteLine(NEW_PATH);
        }
        static bool ExistPATH(string[] dirs, string dir)
        {
            foreach (string s in dirs)
            {
                if (s.CompareTo(dir) == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
