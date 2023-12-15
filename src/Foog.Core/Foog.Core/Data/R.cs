using Foog.Core.Utilities.Enums;

namespace Foog.Core.Data
{
    public static class R
    {
        public static Dictionary<OperationStatus, string> DescriptionsDictionary = EnumHelper.GetDescriptions<OperationStatus>();

        public static OperationResult Ok()
        {
            return new OperationResult(true);
        }
        public static OperationResult<T> Ok<T>(T data)
        {
            return new OperationResult<T>(true, data);
        }
        public static OperationResult Error()
        {
            return new OperationResult(false);
        }
        public static OperationResult Error(OperationStatus resultCode)
        {
            return new OperationResult(false, resultCode);
        }
        public static OperationResult Error(OperationStatus resultCode, string msg)
        {
            return new OperationResult(false, resultCode, msg);
        }
        public static OperationResult Error(string msg)
        {
            return new OperationResult(false, msg);
        }
        public static OperationResult Warning(string message)
        {
            return new OperationResult(false, OperationStatus.PartialSuccess, message);
        }
    }
}
