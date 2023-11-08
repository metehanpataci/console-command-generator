/*           
* Author                             : Metehan PATACI
* Date                               : 11/17/2020 8:17:17 PM
* Description     		     :               
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model
{
    public class ConsoleCommandParam
    {
        private string _param;

        public string Param { get => _param; set => _param = value; }

        public ConsoleCommandParam(String name) 
        {
            Param = name;
        }

        public bool Valid(String inParamStr) 
        {
            return inParamStr.ToLower().Equals(Param.ToLower());
        }

        public static List<ConsoleCommandParam> GenerateConsoleCommandParamList(List<String> commandStrList) 
        {
            List<ConsoleCommandParam> commandParams = new List<ConsoleCommandParam>();
            foreach (var item in commandStrList)
            {
                commandParams.Add(new ConsoleCommandParam(item));
            }

            return commandParams;
        }

        public static List<Object> ToList(List<ConsoleCommandParam> commandStrList)
        {
            List<Object> commandParams = new List<Object>();

            if (commandStrList != null)
            {
                foreach (var item in commandStrList)
                {
                    commandParams.Add(item.Param);
                }
            }

            return commandParams;
        }
        public static List<int> GenerateConsoleCommandParamIndexList(params int[] vs)
        {
            List<int> commandParamsIndexList = new List<int>();
            foreach (int item in vs)
            {
                commandParamsIndexList.Add(item);
            }

            return commandParamsIndexList;
        }

        public static List<List<ConsoleCommandParam>> GenerateListofConsoleCommandParamList(params List<string>[] list)
        {
            List<List<ConsoleCommandParam>> paramList = new List<List<ConsoleCommandParam>>();
            foreach (List<string> item in list)
            {
                List<ConsoleCommandParam> staticParams = ConsoleCommandParam.GenerateConsoleCommandParamList(item);
                paramList.Add(staticParams);
            }
            return paramList;
        }
    }
}
