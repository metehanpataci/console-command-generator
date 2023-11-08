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
    public class SpecialConsoleCommand : ConsoleCommand
    {
        public SpecialConsoleCommand(string name, string alias) : base(name, alias)
        {
        }

        public override List<string> Advise(List<string> srcTxt)
        {
            throw new NotImplementedException();
        }

        public override List<string> CommandNamesStartsWith(string srcTxt)
        {
            throw new NotImplementedException();
        }
    }
}
