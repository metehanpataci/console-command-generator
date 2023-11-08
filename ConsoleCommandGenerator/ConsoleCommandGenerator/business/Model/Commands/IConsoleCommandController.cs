/*           
* Author                             : Metehan PATACI
* Date                               : 05/12/2020 7:21:11 PM
* Description     		     :               
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Commands
{
    public abstract class IConsoleCommandController
    {
        protected virtual void Init() 
        {
           
        }

        protected virtual void UpdateObjectList(object sender, EventArgs e) { }

 

        protected virtual List<List<ConsoleCommandParam>> CreateNewStaticParamList(List<string> objectNames)
        {
            List<ConsoleCommandParam> staticParams = ConsoleCommandParam.GenerateConsoleCommandParamList(objectNames);
            List<List<ConsoleCommandParam>> staticParamList = new List<List<ConsoleCommandParam>>();
            staticParamList.Add(staticParams);

            return (staticParamList);
        }

 

    }
}
