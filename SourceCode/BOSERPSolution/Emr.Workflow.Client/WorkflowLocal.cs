using System;
using System.Activities;
using System.Activities.XamlIntegration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emr.Base.Models.Abp;
using Emr.Workflow.Client.Models;

namespace Emr.Workflow.Client
{
    public class WorkflowLocal : IWorkflowInvoker
    {
        private readonly string _appDir;
        private readonly string _workflowDir = "Workflows";

        public WorkflowLocal(string appDir)
        {
            _appDir = appDir;
        }
        public string[] GetAllowActions(string workflowName, IDictionary<string, object> poolParams)
        {
            var result = InvokePrivate(workflowName + "_AllowActions", poolParams);
            if (result.TryGetValue("_AllowActions", out object actions))
            {
                return (string[])actions;
            }
            else
            {
                return new string[] { };
            }
        }

        public InvokeResult Invoke(string workflowName, IDictionary<string, object> poolParams)
        {
            return InvokePrivate(workflowName, poolParams) as InvokeResult;
        }

        private IDictionary<string, object> InvokePrivate(string wfName, IDictionary<string, object> poolParams)
        {
            try
            {
                var settings = new ActivityXamlServicesSettings
                {
                    CompileExpressions = true
                };
                var file = Path.Combine(_appDir, _workflowDir, wfName + ".xaml");
                if (!File.Exists(file))
                    throw new UserFriendlyException(1, $"File cấu hình Workflow {wfName} không tồn tại trong thư mục ứng dụng");

                var wfStr = File.ReadAllText(file);
                DynamicActivity wf = ActivityXamlServices.Load(new StringReader(wfStr), settings) as DynamicActivity;
                var wfParams = new Dictionary<string, object>();
                foreach (var p in wf.Properties)
                {
                    if (p.Type.BaseType == typeof(OutArgument))
                        continue;
                    if (!poolParams.ContainsKey(p.Name))
                    {
                        throw new UserFriendlyException(1, $"Workflow yêu cầu tham số {p.Name} nhưng tham số này chưa được cấu hình. " +
                            $"Vui lòng kiểm tra lại danh sách tham số");
                    }
                    wfParams.Add(p.Name, poolParams[p.Name]);
                }
                return WorkflowInvoker.Invoke(wf, wfParams, TimeSpan.FromSeconds(30));
            }
            catch (UserFriendlyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(1, "Có lỗi khi gọi Workflow.", ex.Message);
            }
        }
    }
}
