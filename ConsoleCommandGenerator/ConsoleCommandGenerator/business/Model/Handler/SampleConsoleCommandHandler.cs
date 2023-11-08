/*           
* Author                             : Metehan PATACI
* Date                               : 11/19/2020 12:04:23 PM
* Description     		     :               
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Handler
{
    public class SampleConsoleCommandHandler : ConsoleCommandHandler
    {
        public override bool CommandHandle(List<ConsoleCommandParam> staticParamList, List<ConsoleCommandParam> dynamicParamList)
        {
           base.CommandHandle(staticParamList, dynamicParamList);

            return true;
        }

        public override List<int> UpdateCommandStaticParam()
        {
            return ConsoleCommandParam.GenerateConsoleCommandParamIndexList((int)ParameterIndex.ParamIndex0);
        }

        public override string UniqueID()
        {
            return "Test1";
        }
    }
}
