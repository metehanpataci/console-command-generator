/*           
* Author                             : Metehan PATACI
* Date                               : 11/17/2020 7:21:11 PM
* Description     		     :               
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model
{
    public interface IConsoleCommand
    {
        bool Valid(List<String> cmdStrList);
    }
}
