/*           
* Author                             : Metehan PATACI
* Date                               : 11/20/2020 7:23:37 PM
* Description     		     :               
*/


using OperatorMainScreen.ConsoleCommandMng.Model.Manager;
using OperatorMainScreen.ConsoleCommandMng.Model.Splitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Adviser
{
    public class ConsoleCommandAdviser
    {
        public static List<String> Advice(ConsoleCommandManager manager,String commandStr) 
        {
            if (manager == null)
                return null;

            List<String> splittedStr = ConsoleCommandSplitter.Split(commandStr);

            if (commandStr.Length!= 0 &&
                   ConsoleCommandDelimeters.IsDelimeter(commandStr.ElementAt(commandStr.Length - 1)) && 
                   splittedStr.Count!=0 && 
                   splittedStr.ElementAt(0) != "") 
            {
                splittedStr.Add("");
            }

            String srcTxt = "";

            if (splittedStr?.Count > 0)
            {
                srcTxt = splittedStr.ElementAt(0);
            }

            if (splittedStr == null || splittedStr.Count <= 1 )
            {
                return manager.CommandNamesStartsWith(srcTxt);
            }
            else
            {
                List<String> subStr = splittedStr.GetRange(1, splittedStr.Count - 1);
                ConsoleCommandController consoleCommandController = manager.GetCommandController(splittedStr.ElementAt(0));
                if (consoleCommandController == null)
                    return null;
                else
                    return consoleCommandController.Command.Advise(subStr);
                  //  return manager.GetCommandController(splittedStr.ElementAt(0)).Command.Advise(subStr);
            }

           
        }

    }
}
