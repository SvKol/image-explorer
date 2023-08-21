using IWshRuntimeLibrary;

namespace Image_Explorer
{
    public class ImageData
    {
        public const int THUMBNAIL_SIZE = 154;

        public string path;
        public string artist;
        public List<string> keywords = new List<string>();
        private short _isImage = 0;

        public bool managed = false;

        private Image _thumbnail;
        private FileInfo _fileInfo;
        private Point _imageSize = Point.Empty;

        public short isImage { get { return _isImage; } }

        public string imageName {  get {  return Path.GetFileNameWithoutExtension(path); } }

        public string fileName {  get { return Path.GetFileName(path); } }

        public string folder { get { return Path.GetDirectoryName(path); } }

        public long size { get { return _fileInfo.Length; } }

        public Point imageSize { get { return _imageSize; } }

        public FileInfo fileInfo { get { return _fileInfo; } }

        public Image image { get 
            {
                if (isImage != 0)
                {
                    if (isImage < 0) return null;
                }
                else
                {
                    try
                    {
                        using (Image img = Image.FromFile(path))
                            _isImage = 1;
                    }
                    catch (Exception e)
                    {
                        _isImage = -1;
                    }
                }
                try
                {
                    using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                        return new Bitmap(memoryStream);
                    }
                } 
                catch (Exception e) { }
                return null; 
            } 
        }

        public Image thumbnail
        {
            get
            {
                if (_thumbnail == null)
                    LoadThumbnail();
                return _thumbnail;
            }
        }

        public ImageData (string path, string artist = "")
        {
            this.path = path;
            this.artist = artist;
            _fileInfo = new FileInfo(path);
        }

        public void LoadThumbnail()
        {
            if (_thumbnail != null) return;
            Image img = image;
            if (_imageSize == Point.Empty)
                _imageSize = new Point(image.Width, image.Height);
            if (img == null) return;
            float ratio = (float)image.Width / (float)image.Height;
            int h = THUMBNAIL_SIZE;
            int w = THUMBNAIL_SIZE;
            if (ratio > 1)
                h = (int)(THUMBNAIL_SIZE / ratio);
            else
                w = (int)(THUMBNAIL_SIZE * ratio);
            _thumbnail = new Bitmap(img, w, h);
            img.Dispose();
        }

        public void CopyAttributes(ImageData origin)
        {
            if (keywords.Count > 0) keywords.Clear();
            this.keywords.AddList(origin.keywords);
            this.artist = origin.artist;
        }

        public void SetKeywords(string[] keywords)
        {
            this.keywords.AddRange(keywords);
        }

        private string mergeKeywords(string splitter = ";")
        {
            string result = "";
            bool first = true;
            foreach (string keyword in this.keywords)
            {
                if (first) first = false;
                else result += splitter;
                result += keyword;
            }
            return result;
        }

        public override string ToString()
        {
            return $"{path}|{artist}|{mergeKeywords()}";
        }

        public void Rename(string newName)
        {
            if (newName.Equals(imageName)) return;
            try
            {
                System.IO.File.Move(path, $"{folder}\\{newName}{Path.GetExtension(path)}");
                path = $"{folder}\\{newName}{Path.GetExtension(path)}";
            }
            catch (Exception e) { }
        }

        public bool Move(string newLocation)
        {
            if (folder.Equals(newLocation)) return false;
            string newPath = $"{newLocation}\\{fileName}";
            try
            {
                System.IO.File.Move(path, newPath);
                path = newPath;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public ImageData Copy(string copyLocation)
        {
            if (folder.Equals(copyLocation)) return null;
            string copyPath = $"{copyLocation}\\{fileName}";
            try
            {
                System.IO.File.Copy(path, copyPath);
                ImageData copy = new ImageData(copyPath);
                copy.CopyAttributes(this);
                return copy;
            } 
            catch (Exception e) 
            { 
                return null;
            }
        }

        public ImageData Duplicate(string dupName)
        {
            if (dupName.Equals(imageName)) dupName += " Copy";
            string dupPath = $"{path}\\{dupName}{Path.GetExtension(path)}";
            try
            {
                System.IO.File.Copy(path, dupPath, true);
                ImageData duplicate = new ImageData(dupPath);
                duplicate.CopyAttributes(this);
                return duplicate;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void CreateShortcut(string location)
        {
            string scPath = $"{location}\\{imageName}.lnk";
            WshShell shell = new WshShell();
            IWshShortcut sc = shell.CreateShortcut(scPath);
            sc.TargetPath = path;
            sc.Save();
        }
    }
}
