using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helper.FileHelper
{
    using global::Core.Utilities.Abstract;
    using global::Core.Utilities.Concrete;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    namespace Core.Utilities.Helper.FileHelpers
    {
        public class FileHelper
        {

            public static string Add(IFormFile file)
            {
                string path = Environment.CurrentDirectory + @"\Media\wwwroot";
                var sourcePath = Path.GetTempFileName();
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                var result = newPath(file);
                File.Move(sourcePath, path + result);
                return result.Replace("\\", "/");
            }
            public static IResult Delete(string path)
            {
                string path2 = Environment.CurrentDirectory + @"\Media\wwwroot";
                path = path.Replace("/", "\\");
                try
                {
                    File.Delete(path2 + path);
                }
                catch (Exception exception)
                {
                    return new ErrorResult(exception.Message);
                }
                return new SuccessResult();
            }
            public static string Update(string sourcePath, IFormFile file)
            {
                string path = Environment.CurrentDirectory + @"\Media\wwwroot";
                var result = newPath(file);
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(path + result, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Delete(path + sourcePath);
                return result.Replace("\\", "/");
            }
            public static string newPath(IFormFile file)
            {
                FileInfo ff = new FileInfo(file.FileName);
                string fileExtension = ff.Extension;


                var newPath = Guid.NewGuid().ToString() + fileExtension;


                return @"\Images\" + newPath;
            }
        }
    }
}