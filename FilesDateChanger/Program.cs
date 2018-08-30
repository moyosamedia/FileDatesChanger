using System;
using System.IO;
using CommandLine;

namespace FilesDateChanger
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CmdOptions>(args)
                .WithParsed(Run);
        }

        private static void Run(CmdOptions options)
        {
            string fullPath = Path.GetFullPath(options.path);
            if (!(File.Exists(fullPath) || Directory.Exists(fullPath)))
            {
                Console.WriteLine("Path '{0}' does not exist!", fullPath);
                return;
            }

            DateTime setTime = options.date;
            if (setTime == new DateTime())
                setTime = DateTime.Now;

            if (options.recursive)
            {
                FileUtils.SetDatesRecursive(fullPath, setTime);
            }
            else
            {
                FileAttributes fileAttributes = File.GetAttributes(fullPath);
                bool isDirectory = fileAttributes.HasFlag(FileAttributes.Directory);
                FileUtils.SetTime(fullPath, setTime, isDirectory);
            }
        }
    }
}