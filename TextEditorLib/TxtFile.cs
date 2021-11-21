using System;
using System.IO;

namespace TextEditorLib
{
    public class TxtFile : File
    {
        protected bool _exFile = false; //флаг, определяющий, какая реализация будет доступна для объекта

        //true - будут доступны методы ReadFile, EditContentFile, SaveAs, GetFileInfo
        //false - будут доступен только метод CreateFile, после которого флаг будет переопределен

        public TxtFile(string path, string content) //конструктор для еще несозданного файла
        {
            FInfo = new FileInfo(path);
            
            _path = path;
            _content = content;
            
            string[] subs = FInfo.Name.Split('.');
            
            _name = subs[0];
            _extension = subs[1];
        }
        public TxtFile(string path) //конструктор для уже существующего файла
        {
            //Проверка на доступность файла или папки
            if (System.IO.File.Exists(path))
            {
                Console.WriteLine("File does exist.");
                FInfo = new FileInfo(path);
                _exFile = true; //переопределение флага

                using (StreamReader sr = FInfo.OpenText())
                    _content = sr.ReadLine();
                
                string[] subs = FInfo.Name.Split('.');
                _name = subs[0];
                _extension = subs[1];
            } else throw new Exception("File does not exist.");
        }

        public override void ReadFile() //открытие файла для чтения
        {
            if (!_exFile)
                throw new Exception("File has not been created yet.");
            else
            {
                using (StreamReader sr = FInfo.OpenText())
                {
                    string _content = "";
                    while ((_content = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(_content);
                    }
                }
            }
        }
        
        public override void CreateFile()
        {
            if (_exFile)
                throw new Exception("File already created.");
            else
            {
                FInfo.Create();
                _exFile = true;
                Console.WriteLine("File has been created.");
            }
        }

        public override void EditContentFile()
        {
            if (!_exFile)
                throw new Exception("File has not been created yet.");
            else
            {
                string opt, tempContent;
                Console.WriteLine(
                    "Wdym?\n\n1.Write text into empty file\n2.Add text into file\n3.Clear context file\n\n");
                opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        using (FileStream fs = System.IO.File.Create(_path)) {} //костыль?
                        
                        using (StreamWriter sw = FInfo.CreateText())
                        {
                            Console.WriteLine("Write a message here: ");
                            tempContent = Console.ReadLine();
                            sw.WriteLine(tempContent);
                        }

                        break;
                    case "2":
                        using (StreamWriter sw = FInfo.AppendText())
                        {
                            Console.WriteLine("Write a message here: ");
                            tempContent = Console.ReadLine();
                            sw.WriteLine(tempContent);
                        }

                        break;
                    case "3":
                        using (FileStream fs = System.IO.File.Create(_path)) {} //костыль?
                        break;
                    default:
                        throw new Exception("No such option.");
                }
            }
        }

        public override void Close()
        {
            //не знаю что писать тут
        }

        public override void Save()
        {
            //не знаю что писать тут
        }

        public override void SaveAs(string new_path)
        {
            if (!_exFile)
                throw new Exception("File has not been created yet.");
            else
            {
                try
                {
                    Console.WriteLine("Save changes to the old file location? (0 - no / [1:9] - yes)");
                    int opt = Convert.ToChar(Console.ReadLine());
                    
                    FInfo.CopyTo(new_path, Convert.ToBoolean(opt));
                    Console.WriteLine("File was saved to {0}.", new_path);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
            }
        }

        public void GetFileInfo()
        {
            if (!_exFile)
                throw new Exception("File has not been created yet.");
            else
            {
                Console.WriteLine("Information about file:");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Name - " + _name);
                Console.WriteLine("Extension - " + _extension);
                Console.WriteLine("Path - " + _path);
                Console.WriteLine("Content - " + _content);
            }
        }
    }
}
