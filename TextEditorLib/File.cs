using System.IO;

namespace TextEditorLib
{
    public abstract class File
    {
        protected string _content;
        protected string _path;
        protected string _name;
        protected string _extension;
        protected FileInfo FInfo;

        public File() {}
        public abstract void CreateFile();
        public abstract void ReadFile();
        public abstract void EditContentFile();
        public abstract void Close();
        public abstract void Save();
        public abstract void SaveAs(string new_path);
    }
}
