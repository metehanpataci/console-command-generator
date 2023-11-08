/*           
* Author                             : Metehan PATACI
* Date                               : 11/17/2020 7:21:11 PM
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
    public abstract class ConsoleCommand : IConsoleCommand, IConsoleCommandAdviser
    {
        private String _name;

        private String _alias;

        private ConsoleCommands _commandType = ConsoleCommands.Normal;

        private ConsoleCommand _parent = null;

        public string Name { get => _name; set => _name = value; }
        public string Alias { get => _alias; set => _alias = value; }
        public ConsoleCommands CommandType { get => _commandType; set => _commandType = value; }
        public ConsoleCommand Parent { get => _parent; set => _parent = value; }

        public ConsoleCommand(String name, String alias) 
        {
            this.Name = name;

            this.Alias = alias;
        }

        public ConsoleCommand(String name, String alias, ConsoleCommands cmdType):this(null,name, alias, cmdType)
        {
        }

        public ConsoleCommand(ConsoleCommand parent,String name, String alias, ConsoleCommands cmdType) : this(name, alias)
        {
            _commandType = cmdType;
            _parent = parent;
        }

        public virtual bool Exec(List<String> consoleCmd) 
        {
            return true;
        }

        public bool isEqual(string inName) 
        {
            if (inName == null)
                return false;

            if (Name.ToLower().Equals(inName.ToLower()))
                return true;

            return false;
        }

        public virtual bool Valid(List<string> cmdStrList)
        {
            if (cmdStrList == null)
                return false;

            return isEqual(cmdStrList.ElementAt(0));
        }

        public abstract List<string> CommandNamesStartsWith(string srcTxt);


        public abstract List<string> Advise(List<string> srcTxt);

    }
}
