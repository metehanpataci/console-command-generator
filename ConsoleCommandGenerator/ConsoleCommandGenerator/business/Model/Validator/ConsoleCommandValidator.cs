/*           
* Author                             : Metehan PATACI
* Date                               : 11/19/2020 12:26:25 PM
* Description     		     :               
*/


using OperatorMainScreen.ConsoleCommandMng.Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Validator
{
    public class ConsoleCommandValidator
    {
        public static bool Valid(ConsoleCommandManager manager, List<String> commandsStr) 
        {
            if (commandsStr == null || commandsStr.Count == 0)
                return false;

            // get HEAD
            String firstMenu = commandsStr.ElementAt(0).ToLower();
            bool firstMenuFound = false;
            ConsoleCommand consoleCommand = null;

            foreach(var cont in manager.CommandControllers) 
            {
                if (cont.Command.Name.ToLower().Equals(firstMenu.ToLower()))
                {
                    firstMenuFound = true;
                    consoleCommand = cont.Command;
                    break;
                }
            }

            if (firstMenuFound == false)
                return false;
            /*
            List<ConsoleCommand> srcCommands = new List<ConsoleCommand>();
            srcCommands.Add(consoleCommand);
            */
            return consoleCommand.Valid(commandsStr);  // duygu burada sadece ilk komuta bbakıyor o yuzden hep true dönüyor


            /*
             bool menuFound = false;
            for (int i = 0; i <commandsStr.Count; i++)
            {
                String commStr = commandsStr[i];
                menuFound = false;

                for (int j = 0; j < srcCommands.Count; j++) 
                {
                    ConsoleCommand consComm = srcCommands[j];

                    if (consComm is ConsoleCommandBase)
                    {
                        ConsoleCommandBase baseCmd = (ConsoleCommandBase)consoleCommand;

                        if (consComm.isEqual(commStr))
                        {
                            if (baseCmd.Handler != null && i == (commandsStr.Count -1)) // Last Command
                                return true;

                            srcCommands.Clear();
                            srcCommands.AddRange(baseCmd.Commands);
                            break;
                        }                        
                    }
                    else if (consComm is ConsoleCommandEnd)
                    {
                        ConsoleCommandEnd endCmd = (ConsoleCommandEnd)consoleCommand;

                        if (consComm.isEqual(commStr))
                        {
                            if (baseCmd.Handler != null && i == (commandsStr.Count - 1)) // Last Command
                                return true;

                            srcCommands.Clear();
                            srcCommands.AddRange(baseCmd.Commands);
                            break;
                        }
                    }

                    return false;
                }

                if (menuFound == false)
                    return false;
            }
            
            return true;
            */
        }


    }
}
