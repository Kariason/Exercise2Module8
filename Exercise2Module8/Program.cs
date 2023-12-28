using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2Module8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки");
            string path = Console.ReadLine();
            Console.WriteLine($"\nИсходный размер папки: {FolderSize(path)} байт");
        }

        public static long FolderSize(string path)
        {
            long i = 0;
            DirectoryInfo newDir = new DirectoryInfo(path);
            DirectoryInfo[] folder = newDir.GetDirectories();
            FileInfo[] newFile = newDir.GetFiles();
            if (Directory.Exists(path))
            {
                try
                {
                    foreach (FileInfo f in newFile)
                    {
                        i += f.Length;
                    }

                    for (int j = 0; j < folder.Length; j++)
                    {
                        i += FolderSize(path + "\\" + folder[j].Name);
                    }
                    return i;
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
                    return 0;
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                    return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
