using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP
{
    public class MsgContentDto
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime ReceivedTime { get; set; }
        public string Time { get { return ReceivedTime.ToShortTimeString(); } }
    }


    public interface IResponse
    {
        string Message { get; set; }

        bool IsSuccess { get; set; }

        string ErrorMessage { get; set; }
    }

    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Data { get; set; }
    }

    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Data { get; set; }
    }

    public interface IPagedResponse<TModel> : IListResponse<TModel>
    {
        int ItemsCount { get; set; }

        double PageCount { get; }
    }

    public class Response : IResponse
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class SingleResponse<TModel> : ISingleResponse<TModel>
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public TModel Data { get; set; }
    }
}
