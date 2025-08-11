using Emr.Workflow.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Workflow.Client
{
    interface IWorkflowInvoker
    {
        string[] GetAllowActions(string workflowName, IDictionary<string, object> poolParams);
        InvokeResult Invoke(string workflowName, IDictionary<string, object> poolParams);

    }
}
