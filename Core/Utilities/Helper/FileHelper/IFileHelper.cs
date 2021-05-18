using Core.Utilities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helper.FileHelper.Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        IResult Upload(IFormFile file, string path);
        IResult Delete(string filePath);
        IResult Update(IFormFile file, string original, string root);
    }
}