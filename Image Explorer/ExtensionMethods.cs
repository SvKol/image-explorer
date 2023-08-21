using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Image_Explorer
{
    public static class ExtensionMethods
    {
        private static List<TagData> alreadyChecked = new List<TagData>();
        private static bool breakLoop = false;
        private static bool topLevel = true;

        public static void AddTo(this string tag, ImageData img)
        {
            TagData td = TagData.Get(tag);
            if (td == null) return;
            bool master = topLevel;
            topLevel = false;
            if (!img.keywords.Contains(td.keyword)) img.keywords.Add(td.keyword);
            alreadyChecked.Add(td);
            foreach (TagData parent in td.parentTags)
            {
                if (alreadyChecked.Contains(parent) || breakLoop)
                {
                    if (master)
                    {
                        alreadyChecked.Clear();
                        breakLoop = false;
                        topLevel = true;
                    }
                    else breakLoop = true;
                    return;
                }
                parent.keyword.AddTo(img);
            }
            if (!master) return;
            alreadyChecked.Clear();
            breakLoop = false;
            topLevel = true;
        }

        public static void RemoveFrom(this string tag, ImageData img)
        {
            TagData td = TagData.Get(tag);
            if (td == null) return;
            bool master = topLevel;
            topLevel = false;
            if (img.keywords.Contains(td.keyword)) img.keywords.Remove(td.keyword);
            alreadyChecked.Add(td);
            foreach (TagData parent in td.parentTags)
            {
                if (alreadyChecked.Contains(parent) || breakLoop)
                {
                    if (master)
                    {
                        alreadyChecked.Clear();
                        breakLoop = false;
                        topLevel = true;
                    }
                    else breakLoop = true;
                    return;
                }
                parent.keyword.RemoveFrom(img);
            }
            if (!master) return;
            alreadyChecked.Clear();
            breakLoop = false;
            topLevel = true;
        }

        private static void LoadTagChain(this TagData tag)
        {
            if (tag == null) return;
            bool master = topLevel;
            topLevel = false;
            alreadyChecked.Add(tag);
            foreach (TagData parent in tag.parentTags)
            {
                if (alreadyChecked.Contains(parent) || breakLoop)
                {
                    if (master)
                    {
                        breakLoop = false;
                        topLevel = true;
                    }
                    else breakLoop = true;
                    return;
                }
                parent.LoadTagChain();
            }
            if(!master) return;
            breakLoop = false;
            topLevel = true;
        }

        public static List<string> GetTagChain(this string tag)
        {
            TagData.Get(tag).LoadTagChain();
            List<string> chain = new List<string>();
            foreach(var td in alreadyChecked)
                if (td.keyword != tag) chain.Add(td.keyword);
            alreadyChecked.Clear();
            return chain;
        }

        public static string ToKeyword(this string text, bool spaces = false)
        {
            string tag = "";
            bool capital = true;
            foreach (var c in text)
            {
                if (c == '+' || c == '-' || c == '*' || c == '/' || c == ':')
                    continue;
                if (c == ' ' || c == '_')
                {
                    capital = true;
                    tag += spaces ? ' ' : '_';
                    continue;
                }
                if (capital)
                {
                    tag += c.ToUpperCase();
                    capital = false;
                    continue;
                }
                tag += c.ToLowerCase();
            }
            return tag;
        }

        public static double DistanceTo(this Point first, Point second)
        {
            int w = first.X - second.X;
            int h = first.Y - second.Y;
            return Math.Sqrt(w * w + h * h);
        }

        public static Point Plus(this Point first, Point second)
        {
            return new Point(first.X + second.X, first.Y + second.Y);
        }

        public static Point Minus(this Point first, Point second)
        {
            return new Point(first.X - second.X, first.Y - second.Y);
        }

        public static string AsString(this Point point)
        {
            return $"{point.X}x{point.Y}";
        }

        public static string AsString(this long size)
        {
            if (size / 1073741824 >= 1)
                return String.Format("{0:0.00} GB", size / 1073741824d);
            else if (size / 1048576 >= 1)
                return String.Format("{0:0.00} MB", size / 1048576d);
            else if (size / 1024 >= 1)
                return String.Format("{0:0.00} KB", size / 1024d);
            return size.ToString() + " bytes";
        }

        public static char ToUpperCase(this char c)
        {
            if (c > 96 && c < 123)
                return (char)(c - 32);
            return c;
        }

        public static char ToLowerCase(this char c)
        {
            if(c > 64 && c < 91)
                return (char)(c + 32);
            return c;
        }

        public static int ToState(this char c)
        {
            return c switch
            {
                (char)0 => 0,
                '+' => 1,
                '-' => 2,
                '*' => 3,
                _ => -1,
            };
        }

        public static string EncodeState(this int s)
        {
            return s switch { 
                1 => "+",
                2 => "-",
                3 => "*",
                _ => "" };
        }

        public static bool IsEqualTo<K, V>(this Dictionary<K, V> d1, Dictionary<K, V> d2)
        {
            if (ReferenceEquals(d1, d2))
                return true;
            if (d1 is null || d2 is null)
                return false;
            return d1.Count == d2.Count && !d1.Except(d2).Any();
        }

        public static void Resize<T>(this List<T> list, int sz, T c = default)
        {
            if (sz < 0) return;
            int cur = list.Count;
            if (sz < cur)
                list.RemoveRange(sz, cur - sz);
            else if (sz > cur)
            {
                if (sz > list.Capacity)
                    list.Capacity = sz;
                list.AddRange(Enumerable.Repeat(c, sz - cur));
            }
        }

        public static void Grow<T>(this List<T> list, int sz, T c = default)
        {
            int cur = list.Count;
            if (sz <= cur) return;
            if (sz > list.Capacity)
                list.Capacity = sz;
            list.AddRange(Enumerable.Repeat(c, sz - cur));
        }

        public static void Replace<T>(this List<T> list, int idx, T val)
        {
            list.Grow(idx + 1);
            list[idx] = val;
        }

        public static bool ContainsList<T>(this IList<T> outer, IList<T> inner)
        {
            if (outer is null || inner is null) return false;
            if (outer.Count < inner.Count) return false;
            foreach (T item in inner)
                if (!outer.Contains(item)) return false;
            return true;
        }

        public static bool ContainsAnyFrom<T>(this IList<T> outer, IList<T> inner)
        {
            if (outer is null) return false;
            foreach (T item in inner)
                if (outer.Contains(item)) return true;
            return false;
        }

        public static void AddList<T>(this IList<T> host, IList<T> origin)
        {
            foreach (T item in origin)
                host.Add(item);
        }

        public static void Reverse<T>(this IList<T> list)
        {
            List<T> temp = new List<T>(list);
            list.Clear();
            for(int i = temp.Count - 1; i > -1; i--)
                list.Add(temp[i]);
        }

        public static void Switch<T>(this IList<T> list, int e1, int e2)
        {
            if (Math.Min(e1, e2) < 0) return;
            if (Math.Max(e1, e2) >= list.Count) return;
            T temp = list[e2];
            list[e2] = list[e1];
            list[e1] = temp;
        }
    }

    public class ImageComparer : IComparer<ImageData>
    {
        private static char _comparator = 'n';
        private static ImageComparer _instance = new ImageComparer();
        public static bool descending = false;

        public static char comparator { 
            get {
                return _comparator;
            }
            set {
                if (value == 'a' || value == 'p' || value == 's' || value == 'c' || value == 'm' || value == 'r')
                    _comparator = value;
                else 
                    _comparator = 'n';
            } 
        }

        public static ImageComparer Instance { get { return _instance; } }

        private ImageComparer() { }

        public int Compare(ImageData x, ImageData y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return _comparator switch
            {
                'n' => descending? y.imageName.CompareTo(x.imageName) : x.imageName.CompareTo(y.imageName),
                'a' => String.IsNullOrEmpty(x.artist) ? String.IsNullOrEmpty(y.artist) ? 0 : 1 : String.IsNullOrEmpty(y.artist) ? -1 : descending ? y.artist.CompareTo(x.artist) : x.artist.CompareTo(y.artist),
                'p' => descending ? y.path.CompareTo(x.path) : x.path.CompareTo(y.path),
                's' => descending ? y.fileInfo.Length.CompareTo(x.fileInfo.Length) : x.fileInfo.Length.CompareTo(y.fileInfo.Length),
                'c' => descending ? y.fileInfo.CreationTime.CompareTo(x.fileInfo.CreationTime) : x.fileInfo.CreationTime.CompareTo(y.fileInfo.CreationTime),
                'm' => descending ? y.fileInfo.LastWriteTime.CompareTo(x.fileInfo.LastWriteTime) : x.fileInfo.LastWriteTime.CompareTo(y.fileInfo.LastWriteTime),
                'r' => descending ? (y.imageSize.X * y.imageSize.Y).CompareTo(x.imageSize.X * x.imageSize.Y) : (x.imageSize.X * x.imageSize.Y).CompareTo(y.imageSize.X * y.imageSize.Y),
                _ => 0
            };

        }
    }
}
