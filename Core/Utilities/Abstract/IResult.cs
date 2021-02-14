using System;
namespace Core.Utilities.Abstract
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get;}
    }
}
