namespace RentEasy.Shared.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(bool success, string message, object data = null, object errors = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public object Errors { get; set; }
    }
}
