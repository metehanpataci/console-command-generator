/*           
* Author                             : Metehan PATACI
* Date                               : 11/19/2020 11:33:28 AM
* Description     		     :               
*/


using OperatorMainScreen.ConsoleCommandMng.Model.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Manager
{
    public class ConsoleCommandController
    {
        private ConsoleCommand _command;

        private ConsoleCommands _commandType;

        public ConsoleCommand Command { get => _command; set => _command = value; }
        public ConsoleCommands CommandType { get => _commandType; set => _commandType = value; }

        public ConsoleCommandController(ConsoleCommands consCommands, ConsoleCommand comm) 
        {
            //CommandType = consCommands; sduvarci
            Command = comm;
            Command.CommandType = consCommands;
        }

        public bool Exec(List<String> cmdStrList) 
        {
            return Command.Exec(cmdStrList);
        }

        /// <summary>
        ///  Recursive Command İd search to update static params
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <param name="staticParams"></param>
        /// <returns></returns>
        public void UpdateStaticParamList(String uniqueID, List<ConsoleCommandParam> staticParams,int index ) 
        {
            ConsoleCommand currCommand = _command;

            if (currCommand == null)
                return;

            if (currCommand is ConsoleCommandEnd) 
            {
                ConsoleCommandEnd consCommEnd = (ConsoleCommandEnd)currCommand;
                if (consCommEnd.Handler == null)
                    return;
              
                if (consCommEnd.Handler.UniqueID().ToLower() == uniqueID.ToLower())
                {                  
                    consCommEnd.UpdateConsoleCommandStaticParamList(staticParams);
                    return;
                }

                return;
            }

            

            ConsoleCommandBase baseCommand = (ConsoleCommandBase)currCommand;

            UpdateStaticParamList(baseCommand, uniqueID, staticParams,index);
            /*
            foreach (var item in baseCommand.Commands)
            {
                if(item.UpdateStaticParamList(uniqueID, staticParams))
                {
                    return true;
                }
            }

            return false;
            */
        }

        private bool UpdateStaticParamList(ConsoleCommandBase ccBase, String uniqueID, List<ConsoleCommandParam> staticParams,int index) 
        {
            ConsoleCommandBase baseCommand = (ConsoleCommandBase)ccBase;

            if (baseCommand == null || baseCommand.Commands ==null) 
                return false;

            foreach (var item in baseCommand.Commands)
            {
                if (item is ConsoleCommandEnd)
                {
                    ConsoleCommandEnd consCommEnd = (ConsoleCommandEnd)item;
                    if (consCommEnd.Handler == null)
                        continue; // mpupdate

                    if (consCommEnd.Handler.UniqueID().ToLower() == uniqueID.ToLower())
                    {
                        consCommEnd.StatikParams[index] = staticParams;
                        continue;
                        //return true; //mpupdate
                    }

                    // return false; //mpupdate
                }
                else if (item is ConsoleCommandBase)
                {
                    bool status =  UpdateStaticParamList((ConsoleCommandBase)item, uniqueID, staticParams,index);
                    if (status)
                        return true;
                }
                if(baseCommand.Commands.Last() == item)
                    return true;
            }


            return false; //no update 
        }

        public void UpdateStaticParamList(String uniqueID, List<List<ConsoleCommandParam>> staticParams)
        {
            ConsoleCommand currCommand = _command;

            if (currCommand == null)
                return;

            if (currCommand is ConsoleCommandEnd)
            {
                ConsoleCommandEnd consCommEnd = (ConsoleCommandEnd)currCommand;
                if (consCommEnd.Handler == null)
                    return;

                if (consCommEnd.Handler.UniqueID().ToLower() == uniqueID.ToLower())
                {
                    consCommEnd.UpdateConsoleCommandParamIndexList(staticParams);
                    return;
                }

                return;
            }
        }
        public void UpdateRequestedList(ConsoleCommandEnd consCommEnd, String uniqueID, List<ConsoleCommandParam> staticParams, int index)
        {
            if (consCommEnd.Handler == null)
                return;

            if (consCommEnd.Handler.UniqueID().ToLower() == uniqueID.ToLower())
            {
                consCommEnd.StatikParams[index] = staticParams;
               
            }
        }
    }
}
