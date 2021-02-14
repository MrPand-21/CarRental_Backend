using System;
namespace Core.Utilities.Abstract
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
