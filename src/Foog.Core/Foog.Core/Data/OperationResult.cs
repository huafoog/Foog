using Newtonsoft.Json;
using System.ComponentModel;

namespace Foog.Core.Data
{
    public enum OperationStatus
    {
        [Description("操作成功！")]
        Success = 0,
        [Description("操作失败！")]
        Failure = 1,
        [Description("部分操作成功！")]
        PartialSuccess = 2
    }
    public class OperationResult : OperationResult<string>
    {
        public OperationResult()
        {

        }
        public OperationResult(bool success) : base(success)
        {

        }
        public OperationResult(bool success, string msg) : base(success, msg)
        {
        }
        public OperationResult(bool success, OperationStatus resultEnum) : base(success, resultEnum)
        {
        }
        public OperationResult(bool success, OperationStatus resultEnum, string msg) : base(success, resultEnum, msg)
        {
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string? Msg { get; set; }
        public T? Data { get; set; }
        public OperationResult() { }
        public OperationResult(bool success)
        {
            Success = success;
            Code = success ? (int)OperationStatus.Success : (int)OperationStatus.Failure;
            Msg = R.DescriptionsDictionary[(OperationStatus)Code];
        }
        public OperationResult(bool success, string msg)
        {
            Success = success;
            Code = success ? (int)OperationStatus.Success : (int)OperationStatus.Failure;
            Msg = msg;
        }
        public OperationResult(bool success, OperationStatus resultEnum)
        {
            Success = success;
            Code = success ? (int)OperationStatus.Success : (int)resultEnum;
            Msg = R.DescriptionsDictionary[(OperationStatus)Code];
        }
        public OperationResult(bool success, T data)
        {
            Success = success;
            Code = success ? (int)OperationStatus.Success : (int)OperationStatus.Failure;
            Msg = R.DescriptionsDictionary[(OperationStatus)Code];
            Data = data;
        }
        public OperationResult(bool success, OperationStatus resultEnum, T data)
        {
            Success = success;
            Code = success ? (int)OperationStatus.Success : (int)resultEnum;
            Msg = R.DescriptionsDictionary[(OperationStatus)Code];
            Data = data;
        }
        public OperationResult(bool success, OperationStatus resultEnum, string msg)
        {
            Success = success;
            Code = success ? (int)OperationStatus.Success : (int)resultEnum;
            this.Msg = msg;
        }
        public OperationResult(bool success, OperationStatus resultEnum, T data, string msg)
        {
            Success = success;
            Code = success ? (int)OperationStatus.Success : (int)resultEnum;
            this.Msg = msg;
            Data = data;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
