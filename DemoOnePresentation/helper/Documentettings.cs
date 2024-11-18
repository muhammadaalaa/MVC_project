using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace DemoOnePresentation.helper
{
    public class Documentettings
    {
        // to upload document you have five steps to do this process
        public static string uploadFile(IFormFile File, string FolderName)
        {
            //1- get located folder Path
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);
            //2- get file name and make it unique
            string FileName = $"{Guid.NewGuid().ToString()}{File.FileName}";
            //3-get folderPath
            string FilePath = Path.Combine(FolderPath, FileName);
            //4- save file as stram
            using var fs = new FileStream(FilePath, FileMode.Create);
            File.CopyTo(fs);
            //5- return fiel Name
            return FileName;
            // create show if the image is exist at the folder with the same Name will delete the old image and but the new image 
            // createNew will give an exception if find the same image at the folder
        }

        public static void deleteFile(string fileName, string FolderName)
        {
            // get FilePath
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName, fileName);
            //2- check this file is exist or not 
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
