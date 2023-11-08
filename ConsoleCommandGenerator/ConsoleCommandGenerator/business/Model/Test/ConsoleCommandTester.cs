/*           
* Author                             : Metehan PATACI
* Date                               : 11/21/2020 12:13:52 AM
* Description     		     :               
*/


using OperatorMainScreen.ConsoleCommandMng.Model.Adviser;
using OperatorMainScreen.ConsoleCommandMng.Model.Commands;
using OperatorMainScreen.ConsoleCommandMng.Model.Splitter;
using OperatorMainScreen.ConsoleCommandMng.Model.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Test
{
    public class ConsoleCommandTester
    {
        public static void StartTest() 
        {
            ConsoleCommandManager consoleCmdManager = ConsoleCommandManager.Instance;
            consoleCmdManager.initMenuCommandSample();

            //Test1();
            Test2();

        }

        private static void Test2()
        {
            Console.WriteLine("Tests were started");
            ConsoleCommandManager consoleCmdManager = ConsoleCommandManager.Instance;

            // Advice
            List<String> consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "MAIN ");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "MAIN x");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1 abc   ");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1 123");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1 .");

            // Validate
            List<String> splittedCmdList = ConsoleCommandSplitter.Split("MAIN ");
            bool res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            splittedCmdList = ConsoleCommandSplitter.Split("MAIN   ");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            splittedCmdList = ConsoleCommandSplitter.Split("MAIN xyz");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            splittedCmdList = ConsoleCommandSplitter.Split("MAIN 123");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            //Advice
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "DUBLESTATIC ");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "DUBLESTATIC x");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "DUBLESTATIC abc   ");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "DUBLESTATIC 123");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "DUBLESTATIC 30001 ");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "DUBLESTATIC 30001 3");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "DUBLESTATIC 30001 4");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "DUBLESTATIC 30001 second-1");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "DUBLESTATIC 30001 second-1 ");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "DUBLESTATIC 30001 second-1  ");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "DUBLESTATIC 30001 second-1 second-2");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "DUBLESTATIC 30001 second-1 abc");

            //Validate
            splittedCmdList = ConsoleCommandSplitter.Split("DUBLESTATIC ");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            splittedCmdList = ConsoleCommandSplitter.Split("DUBLESTATIC   ");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            splittedCmdList = ConsoleCommandSplitter.Split("DUBLESTATIC xyz");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            splittedCmdList = ConsoleCommandSplitter.Split("DUBLESTATIC 30");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            splittedCmdList = ConsoleCommandSplitter.Split("DUBLESTATIC 30001");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            splittedCmdList = ConsoleCommandSplitter.Split("DUBLESTATIC 30001 second-1");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            splittedCmdList = ConsoleCommandSplitter.Split("DUBLESTATIC 30001 second-1   ");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            splittedCmdList = ConsoleCommandSplitter.Split("DUBLESTATIC 30001 second-1 second-2");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            splittedCmdList = ConsoleCommandSplitter.Split("DUBLESTATIC 30001 second-1 a");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            Console.WriteLine("Tests were executed..");

        }


            private static void Test1() 
        {
            //sduvarci 
            ConsoleCommandManager consoleCmdManager = ConsoleCommandManager.Instance;
 

            string commandStr = "MENU1 MENU2 MENU3 30001 30002 1 2";
            List<String> splittedCmdList = ConsoleCommandSplitter.Split(commandStr);
            bool res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);
            if (res)
                consoleCmdManager.Exec(commandStr);
            else
                Console.Write("Invalid Command..");

            List<String> consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1 M");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1  ");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1    ");
            consoleListsub = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1 .,   ");

            List<String> consoleList = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1 MENU2 MENU3 ");


            List<String> consoleList2 = ConsoleCommandAdviser.Advice(consoleCmdManager, "");
            List<String> consoleList3 = ConsoleCommandAdviser.Advice(consoleCmdManager, "    ");
            List<String> consoleList4 = ConsoleCommandAdviser.Advice(consoleCmdManager, " . . .");
            List<String> consoleList9 = ConsoleCommandAdviser.Advice(consoleCmdManager, "ME");
            List<String> consoleList5 = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1 ");
            List<String> consoleList6 = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1.");
            List<String> consoleList7 = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1  ");
            List<String> consoleList8 = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1  M");
            List<String> consoleList10 = ConsoleCommandAdviser.Advice(consoleCmdManager, "MENU1 .;");

            splittedCmdList = ConsoleCommandSplitter.Split("");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);
            splittedCmdList = ConsoleCommandSplitter.Split("..");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);
            splittedCmdList = ConsoleCommandSplitter.Split("   ");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);
            splittedCmdList = ConsoleCommandSplitter.Split("ME ");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);
            splittedCmdList = ConsoleCommandSplitter.Split("MENU1 ");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);
            splittedCmdList = ConsoleCommandSplitter.Split("MENU1  ");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);
            splittedCmdList = ConsoleCommandSplitter.Split("MENU1 .");
            res = ConsoleCommandValidator.Valid(consoleCmdManager, splittedCmdList);

            if (consoleList != null)
            {

                foreach (var item in consoleList)
                {
                    Console.WriteLine(" {item}");
                }
            }

            List<String> lstStr = ConsoleCommandManager.Instance.CommandString("GT");
            if (lstStr != null)
                Console.WriteLine(lstStr.ToString());

        }
    }
}
