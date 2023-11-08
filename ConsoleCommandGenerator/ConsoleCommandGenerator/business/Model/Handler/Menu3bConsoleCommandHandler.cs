/*           
* Author                             : Metehan PATACI
* Date                               : 12/16/2020 1:45:45 PM
* Description     		     :               
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Handler
{
    public class Menu3bConsoleCommandHandler : ConsoleCommandHandler
    {
        public override List<int> UpdateCommandStaticParam()
        {
            return ConsoleCommandParam.GenerateConsoleCommandParamIndexList((int)ParameterIndex.ParamIndex0);
        }

        public override string UniqueID()
        {
            return "Menu3b";
        }
    }
}
