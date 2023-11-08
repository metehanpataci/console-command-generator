/*           
* Author                             : Metehan PATACI
* Date                               : 11/20/2020 7:29:55 PM
* Description     		     :               
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Manager
{
    public interface IConsoleCommandAdviser
    {
        List<String> CommandNamesStartsWith(String srcTxt);

        List<String> Advise(List<String> srcTxt);
    }
}
