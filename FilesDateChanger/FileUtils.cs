using System;
using System.IO;

namespace FilesDateChanger
{
    public class FileUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootDir"></param>
        /// <param name="time">Be sure it is in UTC</param>
        /// <exception cref="FileNotFoundException"></exception>
        public static void SetDatesRecursive(string rootDir, DateTime time)
        {
            if (!Directory.Exists(rootDir))
                throw new FileNotFoundException("rootDir");

            Console.WriteLine("Setting the file date of '{0}' to {1} recursively", rootDir, time);
            SetTime(rootDir, time, true);
            DirectoryInfo rootDirInfo = new DirectoryInfo(rootDir);
            foreach (FileInfo file in rootDirInfo.GetFiles("*"))
            {
                SetTime(file.FullName, time, false);
            }

            foreach (DirectoryInfo dir in rootDirInfo.GetDirectories())
            {
                SetDatesRecursive(dir.FullName, time);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="time">Time in utc</param>
        /// <param name="isDirectory"></param>
        public static void SetTime(string path, DateTime time, bool isDirectory)
        {
            Console.WriteLine("Setting '{0}' to {1}", path, time);
            if (isDirectory)
            {
                Directory.SetCreationTimeUtc(path, time);
                Directory.SetLastWriteTimeUtc(path, time);
                Directory.SetLastAccessTimeUtc(path, time);
            }
            else
            {
                File.SetCreationTimeUtc(path, time);
                File.SetLastWriteTimeUtc(path, time);
                File.SetLastAccessTimeUtc(path, time);
            }
        }
    }
}