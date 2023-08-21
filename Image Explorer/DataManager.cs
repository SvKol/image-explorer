using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Image_Explorer
{
    [System.Serializable]
    internal static class DataManager
    {
        private static List<string> ManagedFolders = new List<string>();
        private static List<string> ManagedDirectories = new List<string>();
        private static List<string> ExceptionDirectories = new List<string>();

        public static string DirectoriesPath = $"{Environment.CurrentDirectory}/ManagedDirectories.bin";
        public static string ImageDataPath = $"{Environment.CurrentDirectory}//ManagedImagesData.bin";
        public static string TagsDataPath = $"{Environment.CurrentDirectory}/TagsList.bin";

        public static string? focusedFolder = null;

        public static string[] GetFolders()
        {
            if (!String.IsNullOrEmpty(focusedFolder))
                return new string[] { focusedFolder };
            return GetManagedFolders();
        }

        public static string[] GetManagedFolders()
        {
            List<string> list = new List<string>();
            foreach (var dir in ManagedDirectories)
                BrowseDirectory(dir, in list);
            list.AddRange(ManagedFolders);
            if (list.Count == 0)
            {
                ManagedDirectories.Clear();
                ManagedFolders.Clear();
                ExceptionDirectories.Clear();
            }
            return list.ToArray();
        }

        private static void BrowseDirectory(string dir, in List<string> list)
        {
            if (ExceptionDirectories.Contains(dir)) return;
            if (!(ManagedFolders.Contains(dir) || list.Contains(dir))) list.Add(dir);
            try
            {
                string[] subDirectories = Directory.GetDirectories(dir);
                foreach (var subDirectory in subDirectories)
                    BrowseDirectory(subDirectory, in list);
            }
            catch (IOException e)
            {
                MessageBox.Show("An error has occured. Perhaps your drive is locked. Unlock it and restart the program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private static void ManageSubDirectory(string directory)
        {
            if (ExceptionDirectories.Contains(directory)) ExceptionDirectories.Remove(directory);
            if (ManagedFolders.Contains(directory)) ManagedFolders.Remove(directory);
            string[] subDirectories = Directory.GetDirectories(directory);
            foreach (var subDirectory in subDirectories)
                ManageSubDirectory(subDirectory);
        }

        private static void RemoveSubDirectory(string directory)
        {
            if (ManagedDirectories.Contains(directory)) ManagedDirectories.Remove(directory);
            if (ManagedFolders.Contains(directory)) ManagedFolders.Remove(directory);
            string[] subDirectories = Directory.GetDirectories(directory);
            foreach (var subDirectory in subDirectories)
                RemoveSubDirectory(subDirectory);
        }

        public static void ManageDirectory(string directory)
        {
            if (!ManagedDirectories.Contains(directory)) ManagedDirectories.Add(directory);
            ManageSubDirectory(directory);
        }

        public static void RemoveDirectory(string directory)
        {
            if (!ExceptionDirectories.Contains(directory)) ExceptionDirectories.Add(directory);
            RemoveSubDirectory(directory);
        }

        public static void ManageFolder(string folder)
        {
            if(!ManagedFolders.Contains(folder)) ManagedFolders.Add(folder);
        }

        public static void RemoveFolder(string folder)
        {
            if (ManagedFolders.Contains(folder)) ManagedFolders.Remove(folder);
            else
            {
                string[] folders = GetManagedFolders();
                if (folders.Contains(folder))
                {
                    foreach(var subFolder in Directory.GetDirectories(folder))
                        if (!ManagedDirectories.Contains(subFolder) && folders.Contains(subFolder))
                            ManagedDirectories.Add(subFolder);
                    ExceptionDirectories.Add(folder);
                }
            }
        }

        public static byte[] Serialize()
        {
            StringBuilder sb = new StringBuilder("", 1024);
            int i = 0;
            while (i < ManagedDirectories.Count)
            {
                sb.Append(ManagedDirectories[i]);
                if (++i < ManagedDirectories.Count)
                    sb.Append('/');
            }
            sb.Append('|');
            i = 0;
            while (i < ExceptionDirectories.Count)
            {
                sb.Append(ExceptionDirectories[i]);
                if (++i < ExceptionDirectories.Count)
                    sb.Append('/');
            }
            sb.Append('|');
            i = 0;
            while (i < ManagedFolders.Count)
            {
                sb.Append(ManagedFolders[i]);
                if (++i < ManagedFolders.Count)
                    sb.Append('/');
            }
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                    bw.Write(Encoding.UTF8.GetBytes(sb.ToString()));
                }
                return ms.ToArray();
            }
        }

        public static void Deserialize(byte[] data)
        {
            string str = Encoding.UTF8.GetString(data);
            string[] lines = str.Split('|');
            if (lines.Length > 0)
            {
                if (ManagedDirectories.Count > 0) ManagedDirectories.Clear();
                if (!String.IsNullOrEmpty(lines[0])) ManagedDirectories.AddRange(lines[0].Split('/'));
            }
            if (lines.Length > 1)
            {
                if (ExceptionDirectories.Count > 0) ExceptionDirectories.Clear();
                if (!String.IsNullOrEmpty(lines[1])) ExceptionDirectories.AddRange(lines[1].Split('/'));
            }
            if (lines.Length < 3) return;
            if (ManagedFolders.Count > 0) ManagedFolders.Clear();
            if (!String.IsNullOrEmpty(lines[2])) ManagedFolders.AddRange(lines[2].Split('/'));
        }

        public static void SaveState()
        {
            DirectoriesPath.Save(Serialize());
        }

        public static void LoadState()
        {
            if (!File.Exists(DirectoriesPath)) return;
            Deserialize(File.ReadAllBytes(DirectoriesPath).Decompress());
        }

        public static void Save(this string dir, byte[] data)
        {
            File.WriteAllBytes(dir, data.Compress());
        }

        public static void Save(this string dir, string str)
        {
            dir.Save(Encoding.UTF8.GetBytes(str));
        }

        public static byte[] Load(this string dir)
        {
            if (!File.Exists(dir)) return default;
            return File.ReadAllBytes(dir);
        }

        public static string LoadString(this string dir)
        {
            if (!File.Exists(dir)) return "";
            return Encoding.UTF8.GetString(File.ReadAllBytes(dir).Decompress());
        }

        public static byte[] Compress(this byte[] bytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionLevel.Optimal))
                {
                    gzipStream.Write(bytes, 0, bytes.Length);
                }
                return memoryStream.ToArray();
            }
        }

        public static byte[] Decompress(this byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {

                using (var outputStream = new MemoryStream())
                {
                    using (var decompressStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        decompressStream.CopyTo(outputStream);
                    }
                    return outputStream.ToArray();
                }
            }
        }


    }
}
