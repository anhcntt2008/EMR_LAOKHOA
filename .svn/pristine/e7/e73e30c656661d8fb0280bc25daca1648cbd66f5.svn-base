using Clas.Emr.Intergration;
using Emr.Base.Models.Abp;
using Emr.Workflow.Client.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Workflow.Client
{
    public class WorkflowClient: IWorkflowInvoker
    {
        private ApiHelper _apiEmr;
        public WorkflowClient(string endpoint, string authToken)
        {
            this._apiEmr = new ApiHelper(endpoint, authToken, "EMR");
        }

        public string[] GetAllowActions(string workflowName, IDictionary<string, object> poolParams)
        {
            var body = new { WorkflowName = workflowName, PoolParams = poolParams };
            try
            {
                var response = _apiEmr.Post<AjaxResponse, IDictionary<string, object>>("workflows/getallowactions", null, body);
                if (response != null)
                {
                    if (response.Success)
                    {
                        if (response.Result.TryGetValue("_AllowActions", out object actions))
                        {
                            return ((JToken)actions).Values<string>().ToArray();
                        }
                    }
                    else
                    {
                        // empty array to disable all toolbar actions
                        return new string[] { };
                    }
                }
                else
                {
                    throw GetNullResultException();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
        public InvokeResult Invoke(string workflowName, IDictionary<string, object> poolParams)
        {
            var body = new { WorkflowName = workflowName, PoolParams = poolParams };
            try
            {
                var response = _apiEmr.Post<AjaxResponse, InvokeResult>("workflows/invoke", null, body);
                if (response != null)
                {
                    if (response.Success)
                    {
                        return response.Result;
                    }
                    if (response.Error != null)
                        throw new UserFriendlyException(response.Error.Code, response.Error.Message, response.Error.Details);
                    throw GetNullResultException();
                }
                else
                {
                    throw GetNullResultException();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private Exception GetNullResultException()
        {
            return new Exception("KHÔNG CÓ KẾT QUẢ TRẢ VỀ TỪ API");
        }
    }
}
