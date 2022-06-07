using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using System.IO;

namespace Helppad
{
    /// <summary>
    /// IO helpers to work with files, directories and streams.
    /// </summary>
    public static class IO
    {
        /// <summary>
        /// Finds all files in a directory and its subdirectories using a filter.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <param name="filter">The filter to use.</param>
        /// <returns>A list of files.</returns>
        public static IEnumerable<string> FindFiles(string directory, Predicate<string> filter)
        {
            return Directory.GetFiles(directory, "*", SearchOption.AllDirectories).Where(f => filter(f));
        }

        /// <summary>
        /// Finds all files in a directory and its subdirectories using a extension filter.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <param name="extensions">The extensions to use.</param>
        /// <returns>A list of files.</returns>
        public static IEnumerable<string> FindFiles(string directory, params string[] extensions)
        {
            return FindFiles(directory, f => extensions.Any(e => f.EndsWith(e, StringComparison.OrdinalIgnoreCase)));
        }

        /// <summary>
        /// Finds all files in a directory and its subdirectories that cannot be written to.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <returns>A list of files.</returns>
        public static IEnumerable<string> FindReadOnlyFiles(string directory)
        {
            return FindFiles(directory, f => !File.GetAttributes(f).HasFlag(FileAttributes.ReadOnly));
        }

        /// <summary>
        /// Finds all files in a directory and its subdirectories by created DateTime.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <param name="created">The created DateTime to use.</param>
        /// <returns>A list of files.</returns>
        public static IEnumerable<string> FindFilesByCreated(string directory, DateTime created)
        {
            return FindFiles(directory, f => File.GetCreationTime(f) == created);
        }

        /// <summary>
        /// Finds all files in a directory and its subdirectories with x days without modification.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <param name="days">The days to use.</param>
        /// <returns>A list of files.</returns>
        public static IEnumerable<string> FindFilesByDays(string directory, int days)
        {
            return FindFiles(directory, f => File.GetLastWriteTime(f) < DateTime.Now.AddDays(-days));
        }

        /// <summary>
        /// Finds all files in a directory and its subdirectories with x days without access.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <param name="days">The days to use.</param>
        /// <returns>A list of files.</returns>
        public static IEnumerable<string> FindFilesByDaysWithoutAccess(string directory, int days)
        {
            return FindFiles(directory, f => File.GetLastAccessTime(f) < DateTime.Now.AddDays(-days));
        }

        /// <summary>
        /// Validate a stream that should be a readable and seekable stream.
        /// </summary>
        /// <param name="stream">The stream to validate.</param>
        /// <returns>True if is valid.</returns>
        public static bool ValidateStream(Stream stream)
        {
            return stream != null && stream.CanRead && stream.CanSeek;
        }
    }
}