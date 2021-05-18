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
        public class FileUpload : IFileHelper
        {

            public IResult Delete(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    return new ErrorResult();
                }
                File.Delete(filePath);
                return new SuccessResult();
            }

            public IResult Update(IFormFile file, string original, string root)
            {
                if (!File.Exists(original))
                {
                    return new ErrorResult();
                }
                File.Delete(original);
                return Upload(file, root);
            }

            public IResult Upload(IFormFile file, string path)
            {
                try
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);


                    var extension = Path.GetExtension(file.FileName);
                    var guid = Guid.NewGuid().ToString() + extension;
                    var fileName = Path.Combine(path + guid);

                    if (file.FileName == null) return new ErrorResult("No file detected");

                    using var stream = new FileStream(file.FileName, FileMode.Create);

                    file.CopyTo(stream);
                    stream.Flush();
                    stream.Close();
                    File.Copy(file.FileName, fileName);
                    File.Delete(stream.Name);
                    return new SuccessResult(fileName);
                }
                catch (Exception e)
                {
                    return new ErrorResult(e.Message);
                }
            }
        }
    }
}