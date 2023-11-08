/*           
* Author                             : Metehan PATACI
* Date                               : 11/18/2020 1:28:59 PM
* Description     		     :               
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model
{
    public abstract class ConsoleCommandHandler
    {
        public virtual bool CommandHandle(List<ConsoleCommandParam> staticParamList, List<ConsoleCommandParam> dynamicParamList) 
        {
            //Console.WriteLine($"Console command executed..");
            //Console.WriteLine("Console Command " + staticParamList?.ToString()," ",dynamicParamList?.ToString()) ;

            return true;
        }

        public abstract String UniqueID();
        public abstract List<int> UpdateCommandStaticParam();
    }
}
