using System.IO;

namespace TextEditorLib
{
    public class TxtFile : File
    {
        public TxtFile() { }

        public TxtFile(string path)
        {
            //TODO Проверки на доступность файла или папки
        }
        
        public override void Open()
        {
            using var file = new StreamReader(_path);
            _content = file.ReadToEnd();
        }

        public override void Create()
        {
            
        }

        public override void Close()
        {
            
        }

        public override void Save()
        {
            
        }

        public override void SaveAs(string new_path)
        {
            
        }
    }
}