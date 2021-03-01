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

    namespace Core.Utilities.Helpers
    {
        public class FileHelper
        {
            public static IResult Add(string filePath, IFormFile file)
            {
                var sourcepath = Path.GetTempFileName();
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(sourcepath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                File.Move(sourcepath, filePath);

                if (!File.Exists(filePath))
                {
                    return new ErrorResult();
                }
                return new SuccessResult();
            }

            public static IResult Delete(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    return new ErrorResult("Dosya Bulunamadı.");
                }
                File.Delete(filePath);
                return new SuccessResult();
            }

            public static string GenerateGUIDFileName(IFormFile file, int length)
            {
                return Guid.NewGuid().ToString().Substring(0, length) + new FileInfo(file.FileName).Extension;
            }

            public static IResult CheckFileType(IFormFile file, string[] extensions)
            {
                var extension = new FileInfo(file.FileName).Extension;
                foreach (var ext in extensions)
                {
                    if (ext == extension)
                    {
                        return new SuccessResult();
                    }
                }
                return new ErrorResult($"Desteklenmeyen Dosya Formatı: {extension}");
            }


        }

    }
}
