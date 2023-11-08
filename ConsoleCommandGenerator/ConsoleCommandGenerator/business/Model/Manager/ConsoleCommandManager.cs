/*           
* Author                             : Metehan PATACI
* Date                               : 11/17/2020 7:21:11 PM
* Description     		     :               
*/


using OperatorMainScreen.ConsoleCommandMng.Model.Adviser;
using OperatorMainScreen.ConsoleCommandMng.Model.Commands;
using OperatorMainScreen.ConsoleCommandMng.Model.Handler;
using OperatorMainScreen.ConsoleCommandMng.Model.Manager;
using OperatorMainScreen.ConsoleCommandMng.Model.Splitter;
using OperatorMainScreen.ConsoleCommandMng.Model.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model
{
    public class ConsoleCommandManager : IConsoleCommandAdviser
    {
        private List<ConsoleCommandController> _commandControllers = new List<ConsoleCommandController>();

        public List<ConsoleCommandController> CommandControllers { get => _commandControllers; set => _commandControllers = value; }

        public static Object padLock = new object();

        private static ConsoleCommandManager instance;

        public static ConsoleCommandManager Instance
        {
            get
            {
                lock (padLock)
                {
                    if (instance == null)
                    {
                        instance = new ConsoleCommandManager();
                    }
                    return instance;
                }
            }
        }

        private ConsoleCommandManager() 
        {
            initCommands();


        }

        private void initCommands() 
        {
            
        }

        public void initMenuCommandSample() 
        {
            //Two Menu Sample Command
            // MENU1 MENU2 MENU3 STATICPARAMS DYNAMICPARAMS
            // Test
            List<List<ConsoleCommandParam>> testNames = new List<List<ConsoleCommandParam>>();
            testNames.Add(new List<ConsoleCommandParam>());
            testNames.Add(new List<ConsoleCommandParam>());


            testNames[0].Add(new ConsoleCommandParam("30001"));
            testNames[0].Add(new ConsoleCommandParam("30002"));
            testNames[0].Add(new ConsoleCommandParam("30003"));
            testNames[0].Add(new ConsoleCommandParam("30004"));
            testNames[0].Add(new ConsoleCommandParam("30005"));
            testNames[1].Add(new ConsoleCommandParam("second-1"));
            testNames[1].Add(new ConsoleCommandParam("second-2"));
            testNames[1].Add(new ConsoleCommandParam("second-3"));
            testNames[1].Add(new ConsoleCommandParam("second-4"));
            testNames[1].Add(new ConsoleCommandParam("second-5"));

            ConsoleCommandBase dublestaticEnd = new ConsoleCommandEnd("DUBLESTATIC", "DUBLESTATIC", testNames, new ConsoleCommandSetting(0, 2), null, new SampleConsoleCommandHandler(), false); // BlockSwitch
            ConsoleCommandBase dublestaticEndInf = new ConsoleCommandEnd("DUBLESTATICINF", "DUBLESTATICINF", testNames, new ConsoleCommandSetting(0, 0), null, new SampleConsoleCommandHandler(), false); // BlockSwitch
            ConsoleCommandBase dublestaticEndFour = new ConsoleCommandEnd("DUBLESTATICFOUR", "DUBLESTATICFOUR", testNames, new ConsoleCommandSetting(0, 3), null, new SampleConsoleCommandHandler(), false); // BlockSwitch

            ConsoleCommandBase menu1CommandBase = new ConsoleCommandBase(null,"MENU1", "MENU1"); // BlockSwitch
            ConsoleCommandBase menu2CommandEnd = new ConsoleCommandEnd("MENU2", "MENU2", testNames, new ConsoleCommandSetting(0, 0), null, new SampleConsoleCommandHandler(), true); // BlockSwitch

            ConsoleCommandBase menu2aCommandBase = new ConsoleCommandBase(null,"MENU1-1a", "MENU1-1a"); // BlockSwitch
            ConsoleCommandBase menu2bCommandBase = new ConsoleCommandBase(null,"MENU1-1b", "MENU1-1b"); // BlockSwitch
            ConsoleCommandEnd menu3aCommandEnd = new ConsoleCommandEnd("MENU3a", "MENU3a", testNames, new ConsoleCommandSetting(0, 0), null, new SampleConsoleCommandHandler(), true);
            ConsoleCommandEnd menu3bCommandEnd = new ConsoleCommandEnd("MENU3b", "MENU3b", testNames, new ConsoleCommandSetting(0, 0), null, new Menu3bConsoleCommandHandler(), true);

            menu1CommandBase.AddConsoleCommand(menu2aCommandBase);
            menu1CommandBase.AddConsoleCommand(menu2bCommandBase);

            menu2aCommandBase.AddConsoleCommand(menu3aCommandEnd);

            menu2bCommandBase.AddConsoleCommand(menu3bCommandEnd);

            //MENU 3
            List<ConsoleCommandParam> emptyNames = new List<ConsoleCommandParam>();
            ConsoleCommandEnd duyguCommandEnd = new ConsoleCommandEnd("DUYGU", "DUYGU", null, new ConsoleCommandSetting(0, -1), null, new SampleConsoleCommandHandler(), false);

            ConsoleCommandController staticDoublecont1 = new ConsoleCommandController(ConsoleCommands.Normal, dublestaticEnd);
            ConsoleCommandController staticDoublecont2 = new ConsoleCommandController(ConsoleCommands.Normal, dublestaticEndInf);
            ConsoleCommandController staticDoublecont3 = new ConsoleCommandController(ConsoleCommands.Normal, dublestaticEndFour);

            ConsoleCommandController menu1Controller = new ConsoleCommandController(ConsoleCommands.Special, menu1CommandBase);
            ConsoleCommandController menu2Controller = new ConsoleCommandController(ConsoleCommands.Normal, menu2CommandEnd);
            ConsoleCommandController duyguController = new ConsoleCommandController(ConsoleCommands.Normal, duyguCommandEnd);

            //ConsoleCommandBase tpsdbase = new ConsoleCommandBase(null, "TPSD", "TPSD");
            //ConsoleCommandEnd ecocmd = new ConsoleCommandEnd("ECO", "ECO", testNames, 0, null, new SampleConsoleCommandHandler(), false);
            //ConsoleCommandEnd yavascmd = new ConsoleCommandEnd("YAVAS", "YAVAS", testNames, 0, null, new SampleConsoleCommandHandler(), false);
            //ConsoleCommandEnd ortacmd = new ConsoleCommandEnd("ORTA", "ORTA", testNames, 0, null, new SampleConsoleCommandHandler(), false);
            //ConsoleCommandEnd hizlicmd = new ConsoleCommandEnd("HIZLI", "HIZLI", testNames, 0, null, new SampleConsoleCommandHandler(), false);
            //tpsdbase.AddConsoleCommand(ecocmd);
            //tpsdbase.AddConsoleCommand(yavascmd);
            //tpsdbase.AddConsoleCommand(ortacmd);
            //tpsdbase.AddConsoleCommand(hizlicmd);
            //ConsoleCommandController tpsdController = new ConsoleCommandController(ConsoleCommands.Special, tpsdbase);
            //CommandControllers.Add(tpsdController);

            CommandControllers.Add(staticDoublecont1);
            CommandControllers.Add(staticDoublecont2);
            CommandControllers.Add(staticDoublecont3);

            CommandControllers.Add(duyguController);
            CommandControllers.Add(menu1Controller);
            CommandControllers.Add(menu2Controller);
        }

        public bool Exec(String commandStr) 
        {
            List<String> commandList = ConsoleCommandSplitter.Split(commandStr);

            if (!ConsoleCommandValidator.Valid(this, commandList))
                return false;

            ConsoleCommandController cmdController = GetCommandController(commandList.ElementAt(0));

            return cmdController.Exec(commandList);

        }

        public ConsoleCommandController GetCommandController(String commandHead) 
        {
            foreach (var item in CommandControllers)
            {
                if (item.Command.isEqual(commandHead))
                    return item;
            }

            return null;
        }

        public ConsoleCommands GetCommandType(String commandHead)
        {
            foreach (var item in CommandControllers)
            {
                if (item.Command.isEqual(commandHead))
                    return item.CommandType;
            }

            return ConsoleCommands.Normal;
        }

        public List<string> CommandNamesStartsWith(String srcTxt)
        {
            List<String> commandCandidates = new List<string>();

            foreach (var item in CommandControllers)
            {
                if (item.Command.Name.ToLower().StartsWith(srcTxt.ToLower())) 
                {
                    commandCandidates.Add(item.Command.Name);
                }
            }

            return commandCandidates;
        }

        public List<string> Advise(List<string> srcTxt)
        {
            throw new Exception();
        }

        public List<string> Advice(String commandsStr) 
        {
            return ConsoleCommandAdviser.Advice(this, commandsStr);
        }

        public bool Add(ConsoleCommandController controller) 
        {
            foreach (var item in CommandControllers)
            {
                if (item.Command.isEqual(controller.Command.Name))
                    return false;
            }

            CommandControllers.Add(controller);

            return true;
        }

        public bool UpdateStaticParamList(String uniqueID, List<ConsoleCommandParam> staticParams,int index) 
        {
            foreach (var item in CommandControllers)
            {
                item.UpdateStaticParamList(uniqueID, staticParams,index);
            }

            return true;
        }


        public bool UpdateStaticParamList(String uniqueID, List<List<ConsoleCommandParam>> staticParams)
        {
            foreach (var item in CommandControllers)
            {
                item.UpdateStaticParamList(uniqueID, staticParams);
            }

            return true;
        }

        public List<String> CommandString( String uniqueID)
        {
            return ConsoleCommandStringGenerator.CommandString(this,uniqueID);
        }

        public List<List<ConsoleCommandParam>> UpdateCommandStaticList<T>(List<List<ConsoleCommandParam>> staticParamList, List<T> paramList)
        {
            List<ConsoleCommandParam> consoleCommandParamList = new List<ConsoleCommandParam>();

            foreach (var item in paramList)
            {
                ConsoleCommandParam consoleCommandParam = new ConsoleCommandParam(item.ToString());
                consoleCommandParamList.Add(consoleCommandParam);
            }
            staticParamList.Add(consoleCommandParamList);
            return staticParamList;
        }

    }
}
