/*           
* Author                             : Metehan PATACI
* Date                               : 11/20/2020 4:34:02 PM
* Description     		     :               
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model
{
    public class ConsoleCommandExecuter
    {
        public static bool Exec(String commandStr) 
        {
            return ConsoleCommandManager.Instance.Exec(commandStr);
        }
    }
}
