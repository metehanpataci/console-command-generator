/*           
* Author                             : Metehan PATACI
* Date                               : 12/16/2020 1:04:38 PM
* Description     		     :               
*/


using OperatorMainScreen.ConsoleCommandMng.Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Adviser
{
    public class ConsoleCommandStringGenerator
    {

        public static String ToString(List<String> strList) 
        {
            String str = "";

            for (int i = 0; i < strList.Count; i++)
            {
                str += strList[i];
                if (i != (strList.Count - 1))
                {
                    str += " ";
                }
            }

            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <returns></returns>
        public static List<String> CommandString(ConsoleCommandManager ccManager,String uniqueID)
        {
            foreach (var item in ccManager.CommandControllers)
            {
                List<String> cmdList = new List<string>();
                cmdList = GetCommandString(item, uniqueID);
                if (cmdList != null)
                    return cmdList;
            }

            return null;
        }

        /// <summary>
        ///  Recursive Command İd search to update static params
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <returns></returns>
        private static List<String> GetCommandString(ConsoleCommandController cmdController, String uniqueID)
        {
            List<String> commandStrings = new List<string>();
            ConsoleCommand currCommand = cmdController.Command;

            if (currCommand == null)
                return null;

            if (currCommand is ConsoleCommandEnd)
            {
                ConsoleCommandEnd consCommEnd = (ConsoleCommandEnd)currCommand;
                if (consCommEnd.Handler == null)
                    return null;

                if (consCommEnd.Handler.UniqueID().ToLower() == uniqueID.ToLower())
                {
                    commandStrings.Add(consCommEnd.Name);
                    return commandStrings;
                }

                return null;
            }

            ConsoleCommandBase baseCommand = (ConsoleCommandBase)currCommand;
            commandStrings.Add(baseCommand.Name);

            return GetCommandSubstring(baseCommand, uniqueID, commandStrings);
        }

        private static List<String> GetCommandSubstring(ConsoleCommandBase ccBase, String uniqueID, List<String> baseStr)
        {
            ConsoleCommandBase baseCommand = (ConsoleCommandBase)ccBase;
            List<String> substr = new List<string>(baseStr);

            if (baseCommand == null || baseCommand.Commands == null)
                return null;

            foreach (var item in baseCommand.Commands)
            {

                if (item is ConsoleCommandEnd)
                {
                    ConsoleCommandEnd consCommEnd = (ConsoleCommandEnd)item;
                    if (consCommEnd.Handler == null)
                        continue;

                    if (consCommEnd.Handler.UniqueID().ToLower() == uniqueID.ToLower())
                    {
                        substr.Add(item.Name);
                        return substr;
                    }
                }
                else if (item is ConsoleCommandBase)
                {
                    substr.Add(item.Name);
                    List<String> currStr = GetCommandSubstring((ConsoleCommandBase)item, uniqueID, substr);
                    if (currStr != null)
                        return currStr;
                    else
                        substr.RemoveAt(substr.Count - 1);

                }
            }

            return null;
        }
    }
}
