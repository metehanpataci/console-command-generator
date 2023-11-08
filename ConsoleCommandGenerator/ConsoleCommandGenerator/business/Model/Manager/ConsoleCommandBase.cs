/*           
* Author                             : Metehan PATACI
* Date                               : 11/17/2020 8:16:57 PM
* Description     		     :               
*/


using OperatorMainScreen.ConsoleCommandMng.Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model
{
    public class ConsoleCommandBase : ConsoleCommand 
    {

        //private ConsoleCommand _subCommandMenu = null;

        private List<ConsoleCommand> _commands = new List<ConsoleCommand>();

        private ConsoleCommandHandler _handler = null;

        public ConsoleCommandBase(ConsoleCommand parent, String name, String alias) : this(parent,name, alias, ConsoleCommands.Normal) 
        {
        }

        public ConsoleCommandBase(ConsoleCommand parent, String name, String alias, ConsoleCommands cmdType) : base(parent,name, alias, cmdType)
        {
        }

        public List<ConsoleCommand> Commands { get => _commands; set => _commands = value; }
        public ConsoleCommandHandler Handler { get => _handler; set => _handler = value; }

        public void AddConsoleCommand(ConsoleCommand consCommand) 
        {
            _commands.Add(consCommand);
        }

        public bool Valid(String inMenuName)
        {
            foreach (var cmds in Commands) 
            {
                if (cmds.Name.ToLower().Equals(inMenuName.ToLower())) 
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Valid(List<string> cmdStrList)
        {
            if (cmdStrList == null || cmdStrList.Count == 0)
                return false;

            List<String> firstList = new List<string>();
            firstList.Add(cmdStrList.ElementAt(0));

            if (base.Valid(firstList)) 
            {
                if (cmdStrList.Count > 1)
                {
                    List<String> subString = cmdStrList.GetRange(1, cmdStrList.Count - 1);
                    foreach (var currCommands in Commands)
                    {
                        if (currCommands.Valid(subString))
                            return true;
                    }
                }
                else 
                {
                    return true;
                }
 
            }

            return false;
        }

        public bool PartiallyValid(String inMenuName)
        {
            foreach (var cmds in Commands)
            {
                if (cmds.Name.ToLower().StartsWith(inMenuName.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        public List<String> GetMenuStrings() 
        {
            List<String> menuNames = new List<String>();

            foreach (var cmds in Commands)
            {
                menuNames.Add(cmds.Name);
            }

            return menuNames;
        }

        public override bool Exec(List<String> cmdStrList)
        {
            if (cmdStrList == null || cmdStrList.Count == 0)
                return false;

            List<String> firstList = new List<string>();
            firstList.Add(cmdStrList.ElementAt(0));

            if (base.Valid(firstList))
            {
                if (cmdStrList.Count > 1)
                {
                    List<String> subString = cmdStrList.GetRange(1, cmdStrList.Count - 1);
                    foreach (var currCommands in Commands)
                    {
                        if (currCommands.Valid(subString)) 
                        {
                            return currCommands.Exec(subString);
                            
                        }                    
                    }
                }
                else
                {
                    if (Handler != null)
                    {
                        //ConsoleCommandParam.GenerateConsoleCommandParamList(null);
                        Handler.CommandHandle(null, null);
                        return true;
                    }
                    return false;
                }

            }

            return false;
        }

        public override List<string> CommandNamesStartsWith(string srcTxt)
        {
            List<String> commandCandidates = new List<string>();

            foreach (var item in Commands)
            {
                if (item.Name.ToLower().StartsWith(srcTxt.ToLower()))
                {
                    commandCandidates.Add(item.Name);
                }
            }

            return commandCandidates;
        }

        protected ConsoleCommand GetConsoleCommand(String commandName) 
        {
            foreach (var item in Commands)
            {
                if (item.isEqual(commandName))
                    return item;
            }

            return null;
        }

        public override List<string> Advise(List<string> srcTxt)
        {
            if (srcTxt == null || srcTxt.Count == 1 || srcTxt.ElementAt(0)=="")
            {
                return CommandNamesStartsWith(srcTxt.ElementAt(0));
            }
            else 
            {
                ConsoleCommandBase consCmdBase = (ConsoleCommandBase)GetConsoleCommand(srcTxt.ElementAt(0));

                if (consCmdBase == null)
                    return null;

                List<string> subString = srcTxt.GetRange(1, srcTxt.Count - 1);

                return consCmdBase.Advise(subString);
            }

        }
    }
}
