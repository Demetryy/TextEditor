namespace TextEditorLib
{
    public abstract class File
    {
        protected string _content;
        protected string _path;
        protected string _name;
        protected string _extension;


        public abstract void Open();
        public abstract void Create();
        public abstract void Close();
        public abstract void Save();
        public abstract void SaveAs(string new_path);
    }
}