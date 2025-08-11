namespace Clas.Model.MailBs24x7
{
    public class ResultModel
    {
        public ResultModel(bool success = true, string errorMessage = null, object data = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
            Data = data;
        }

        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}