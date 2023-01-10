using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Helppad.Scripts
{
    public class IO
    {
        /// <summary>
        /// This code uses the System.IO.Compression namespace, 
        /// which provides classes for working with compressed 
        /// files in .NET. The ZipDirectory method 
        /// takes three arguments: the startPath of the directory 
        /// to be zipped, the zipPath of the resulting .zip file,
        /// and the extractPath to which the .zip file will be extracted.
        /// First, the method creates a.zip file from the startPath
        /// directory using the CreateFromDirectory 
        /// method of the ZipFile class. 
        /// Then, it extracts the.zip file to the 
        /// extractPath using the ExtractToDirectory method. 
        /// Finally, it reads the names of all the files and 
        /// directories in the.zip file using a foreach loop 
        /// and the Entries property of the ZipArchive class. 
        /// The names are printed to the console using the 
        /// FullName property of the ZipArchiveEntry class.
        /// </summary>
        /// <param name="startPath"></param>
        /// <param name="zipPath"></param>
        /// <param name="extractPath"></param>
        public static void ZipDirectory(string startPath, string zipPath, string extractPath)
        {
            // Create the zip file
            ZipFile.CreateFromDirectory(startPath, zipPath);

            // Extract the zip file to the extractPath
            ZipFile.ExtractToDirectory(zipPath, extractPath);

            // Read the names of all the files and directories in the zip file
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    Console.WriteLine(entry.FullName);
                }
            }
        }

        /// <summary>
        /// Extract files and directories names.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetFiles(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            string[] subdirectories = directories.SelectMany(dir => Directory.GetDirectories(dir)).ToArray();
            string[] files = Directory.GetFiles(path);

            // Combine the directories, subdirectories, and files into a single array
            return directories.Concat(subdirectories).Concat(files);
        }

        /// <summary>
        /// This method defines a way that takes a search term
        /// and a list of file names as input, and 
        /// returns a filtered list of file names as output. 
        /// 
        /// The method uses LINQ to search the list of file names 
        /// for entries that either (1) contain the search term and
        /// do not have a dot (indicating that they are directories),
        /// or (2) contain the search term in the file name itself.
        /// </summary>
        /// <param name="term"></param>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetFiles(string term, IEnumerable<string> fileNames)
        {
            return fileNames
            .Where(fileName =>
                (Path.GetFileName(fileName).Contains(term) && !fileName.Contains(".")) ||
                Path.GetFileName(fileName).Contains(term));
        }


    }
}
