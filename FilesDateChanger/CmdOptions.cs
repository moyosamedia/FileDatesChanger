using System;
using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace FilesDateChanger
{
    public class CmdOptions
    {
        [Option('p', "path", Required = true,
            HelpText = "Path to the file or directory you want to change the date of")]
        public string path { get; set; }

        [Option('r', "recursive", HelpText = "If the path is a directory, should it also change the files inside it")]
        public bool recursive { get; set; }

        [Option('d', "date", HelpText =
            "Target date and time (in UTC), if not set, it will use the current date & time")]
        public DateTime date { get; set; }

        [Usage(ApplicationAlias = "FileDateChanger")]
        public static IEnumerable<Example> examples
        {
            get
            {
                yield return new Example("Change directory recursively",
                    new CmdOptions
                    {
                        path = "MyDirectory",
                        recursive = true,
                        date = new DateTime(2010, 02, 15)
                    });
                yield return new Example("Change file's date to current",
                    new CmdOptions
                    {
                        path = "MyFile"
                    });
            }
        }
    }
}