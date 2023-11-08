/*           
* Author                             : Metehan PATACI
* Date                               : 12/18/2020 12:15:29 PM
* Description     		     :               
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Manager
{
    public class ConsoleCommandDelimeters
    {
        public static readonly char[] Delimeters = { ' ', ',', '.', ':', '\t', ';', '\n' };

        public static bool IsDelimeter(char character) 
        {
            return Delimeters.Contains(character);
        }
    }
}
