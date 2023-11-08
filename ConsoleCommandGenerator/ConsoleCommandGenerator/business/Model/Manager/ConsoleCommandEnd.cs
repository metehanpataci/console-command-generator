/*           
* Author                             : Metehan PATACI
* Date                               : 11/17/2020 8:31:14 PM
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
    public class ConsoleCommandEnd : ConsoleCommandBase
    {
       
        private bool _isDynamicParamsEnabled = true;

        private ConsoleCommandSetting _ccSetting = new ConsoleCommandSetting(0,0);

        private List<List<ConsoleCommandParam>> _statikParams = new List<List<ConsoleCommandParam>>();

        private List<ConsoleCommandParam> _dynamicParams = new List<ConsoleCommandParam>();

        public string UniqueID { get; private set; }

        public ConsoleCommandEnd(ConsoleCommand parent,String name, String alias,List<List<ConsoleCommandParam>> staticParameters, ConsoleCommandSetting ccSetting, List<ConsoleCommandParam> dynParams, ConsoleCommandHandler hand, bool isDynamicParamExist) :this( parent,name,  alias, staticParameters, ccSetting, dynParams, hand, ConsoleCommands.Normal, isDynamicParamExist)
        {

        }

        public ConsoleCommandEnd(String name, String alias, List<List<ConsoleCommandParam>> staticParameters, ConsoleCommandSetting ccSetting, List<ConsoleCommandParam> dynParams, ConsoleCommandHandler hand, bool isDynamicParamExist) : this(null, name, alias, staticParameters, ccSetting, dynParams, hand, ConsoleCommands.Normal, isDynamicParamExist)
        {

        }

        public ConsoleCommandEnd(ConsoleCommand parent,String name, String alias, List<List<ConsoleCommandParam>> staticParameters, ConsoleCommandSetting inCCSetting, List<ConsoleCommandParam> dynParams, ConsoleCommandHandler hand, ConsoleCommands cmdType,bool isDynamicParamExist) : base(parent,name, alias, cmdType )
        {
            _isDynamicParamsEnabled = isDynamicParamExist;
            _statikParams = staticParameters;
            _dynamicParams = dynParams;
            CcSetting = inCCSetting;
            Handler = hand;
            Commands = null;
            if(hand != null)
                UniqueID = hand.UniqueID();
        }


        public List<List<ConsoleCommandParam>> StatikParams { get => _statikParams; set => _statikParams = value; }
        public List<ConsoleCommandParam> DynamicParams { get => _dynamicParams; set => _dynamicParams = value; }
        public ConsoleCommandSetting CcSetting { get => _ccSetting; set => _ccSetting = value; }

        public void Exec() 
        {
            Console.WriteLine(@"No action ConsoleCOmmandEnd..");
            //Handler.CommandHandle(_statikParams, _dynamicParams);
        }

        public List<String> GetStatikParamStrings(int index) 
        {
            List<String> statikNames = new List<String>();

            foreach (var param in StatikParams[index])
            {
                statikNames.Add(param.Param);
            }

            return statikNames;
        }

        public override bool Valid(List<string> cmdStrList)
        {
            if (cmdStrList == null || cmdStrList.Count == 0)
                return false;

            List<String> firstList = new List<string>();
            firstList.Add(cmdStrList.ElementAt(0));
            int foundStaticParamCount = 0;

            if (base.Valid(firstList))
            {
                if (cmdStrList.Count > 1)
                {
                    List<String> subString = cmdStrList.GetRange(1, cmdStrList.Count - 1);

                    int staticListCnt = StatikParams == null ? 0 : StatikParams.Count; 
                    int currParamCount = 0;
                   

                    foreach (var staticParamString in subString)
                    {
                        bool isExist = false;

                        currParamCount++;

                        int staticParamListIndex = currParamCount > staticListCnt ? (staticListCnt - 1) : (currParamCount - 1);

                        // Dynamic params not checked
                        if (_isDynamicParamsEnabled == false && (StatikParams == null || StatikParams.Count() < 0))//mpataciduygu 04.03.2021
                            return false;

                        // Check static params
                        if (StatikParams != null) { 
                            foreach (var sParams in StatikParams[staticParamListIndex])
                            {
                                if (sParams.Valid(staticParamString))
                                {
                                    isExist = true;
                                    foundStaticParamCount++;
                                    continue;
                                }
                            }
                        }

                        if (_isDynamicParamsEnabled == false && CcSetting.MaxParamCount < 0)
                            return false;

                        if (CcSetting.MaxParamCount > 0 && foundStaticParamCount > CcSetting.MaxParamCount && _isDynamicParamsEnabled == false)//mpataciduygu 04.03.2021
                            return false;

                        if (!isExist && !_isDynamicParamsEnabled)
                            return false;
                    }
                }
                else 
                {
                    if (StatikParams != null && StatikParams.Count > 0)
                        return false;

                    return true;
                }
            }
            else 
            {
                return false;
            }

            return true;
        }

        public override bool Exec(List<String> consoleCmd)
        {
            if (!Valid(consoleCmd))
                return false;

            List<String> subString = consoleCmd.GetRange(1, consoleCmd.Count - 1);

            if (Handler != null)
            {
                List<string> staticLst = new List<string>();
                List<string> dynamicLst = new List<string>();

                int staticListCnt = 0;
                if(StatikParams != null)
                    staticListCnt =StatikParams.Count;

                int currParamCount = 0;

                foreach (String item in subString)
                {
                    currParamCount++;

                    int staticParamListIndex = currParamCount > staticListCnt ? (staticListCnt - 1) : (currParamCount - 1);

                    bool foundInDynList = false;
                    if(StatikParams != null)
                    {
                        foreach (var staticPar in StatikParams[staticParamListIndex])
                        {
                            if (staticPar.Valid(item))
                            {
                                staticLst.Add(item);
                                foundInDynList = true;
                                break;

                            }
                            if (CcSetting.MaxParamCount > 0 && staticLst.Count == CcSetting.MaxParamCount)
                                break;

                        }

                    }

                    if (!foundInDynList)
                        dynamicLst.Add(item);

                }

                // Check minimum parameter count at execution
                if ((staticLst.Count + dynamicLst.Count) < CcSetting.MinParamCount)
                    return false;

                return Handler.CommandHandle(ConsoleCommandParam.GenerateConsoleCommandParamList(staticLst), ConsoleCommandParam.GenerateConsoleCommandParamList(dynamicLst));
            }
                

            return false;
        }

        public override List<string> CommandNamesStartsWith(string srcTxt)
        {
            return CommandNamesStartsWith(srcTxt, 0);
        }

        public List<string> CommandNamesStartsWith(string srcTxt, int index) 
        {
            List<String> commandCandidates = new List<string>();

            if (StatikParams == null)
                return commandCandidates;

            foreach (var item in StatikParams[index])
            {
                if (item.Param.ToLower().StartsWith(srcTxt.ToLower()))
                {
                    commandCandidates.Add(item.Param);
                }
            }

            return commandCandidates;
        }
        public List<string> CommandNamesStartsWith(string srcTxt, int index, List<List<ConsoleCommandParam>> listofConsoleCommandParamList)
        {
            List<String> commandCandidates = new List<string>();

            if (StatikParams == null)
                return commandCandidates;

            foreach (var item in StatikParams[index])
            {
                if (item.Param.ToLower().StartsWith(srcTxt.ToLower()))
                {
                     if (IsParamsIncludesInList(item.Param, index, listofConsoleCommandParamList))
                        commandCandidates.Add(item.Param);    
                }
            }            
            return commandCandidates;
        }
        private bool StaticParamsIncludes(String cmdName,int index) 
        {
            foreach (var item in StatikParams[index])
            {
                //if (cmdName.ToLower().Equals(cmdName.ToLower()))
                if(cmdName.ToLower().Equals(item.Param.ToLower())) //sduvarci
                    return true;
            }

            return false;
        }

        public override List<string> Advise(List<string> srcTxt)
        {
            //  List<List<ConsoleCommandParam>> CopyOfStaticParams = new List<List<ConsoleCommandParam>>(StatikParams);
            List<List<ConsoleCommandParam>> CopyOfStaticParams = new List<List<ConsoleCommandParam>>();
            if(StatikParams!=null && StatikParams.Count>0)
            {
                foreach (List<ConsoleCommandParam> listItem in StatikParams)
                {
                    List<ConsoleCommandParam> consoleCommandParams = new List<ConsoleCommandParam>();
                    foreach (var item in listItem)
                    {
                        consoleCommandParams.Add(item);
                    }
                    CopyOfStaticParams.Add(consoleCommandParams);
                }
            }
            return Advise(srcTxt, 1, CopyOfStaticParams);
        }

        private List<string> Advise(List<string> srcTxt, int currParamCount, List<List<ConsoleCommandParam>> listofConsoleCommandParamList)
        {
            if (CcSetting.MaxParamCount > 0 && currParamCount > CcSetting.MaxParamCount) //mpataciduygu 04.03.2021
                return null;

            int staticListCnt = StatikParams == null ? 0 : StatikParams.Count;
            int staticParamListIndex = currParamCount > staticListCnt ? (staticListCnt - 1) : (currParamCount - 1);
            if(staticParamListIndex>=0)
            {
                PrepareAdvice(srcTxt, staticParamListIndex, listofConsoleCommandParamList);
            }

            if (srcTxt == null || srcTxt.Count == 1)
            {                
                  return CommandNamesStartsWith(srcTxt.ElementAt(0), staticParamListIndex, listofConsoleCommandParamList);
                 //   return CommandNamesStartsWith(srcTxt.ElementAt(0), staticParamListIndex);
            }
            else
            {
                if (StaticParamsIncludes(srcTxt.ElementAt(0), staticParamListIndex))
                {
                    List<string> subString = srcTxt.GetRange(1, srcTxt.Count - 1);
                    return Advise(subString, ++currParamCount, listofConsoleCommandParamList);
                }
                else
                {
                    return null;
                }
            }
        }
        public void RemoveFromList(String cmdName, int index, List<List<ConsoleCommandParam>> consoleCommandList)
        {
            List<ConsoleCommandParam> commandlist = new List<ConsoleCommandParam>();
            commandlist = consoleCommandList[index];
            for (int i = 0; i < commandlist.Count; i++)
            {
                if (commandlist[i].Param.ToString().ToLower().Equals(cmdName.ToLower()))
                {
                    commandlist.RemoveAt(i);                      
                    break;
                }
            }
        }
        public void AddToList(String cmdName, int index, List<List<ConsoleCommandParam>> consoleCommandList)
        {
            List<ConsoleCommandParam> commandlist = new List<ConsoleCommandParam>();
            commandlist = consoleCommandList[index];
            ConsoleCommandParam consoleCommandParam = new ConsoleCommandParam(cmdName);
            commandlist.Add(consoleCommandParam);
        }

        private bool IsParamsIncludesInList(String cmdName, int index, List<List<ConsoleCommandParam>> consoleCommandList)
        {
            foreach (var item in consoleCommandList[index])
            {
                if (cmdName.ToLower().Equals(item.Param.ToLower()))
                    return true;
            }

            return false;
        }
        public void PrepareAdviceParams(String srcTxt, int staticParamListIndex, List<List<ConsoleCommandParam>> listofConsoleCommandParamList)
        {
            if (StaticParamsIncludes(srcTxt, staticParamListIndex))
            {
                if (IsParamsIncludesInList(srcTxt, staticParamListIndex, listofConsoleCommandParamList))
                {
                    RemoveFromList(srcTxt, staticParamListIndex, listofConsoleCommandParamList);
                }
                else
                {
                    //AddToList(srcTxt, staticParamListIndex, listofConsoleCommandParamList);
                }
            }
        }
        public void PrepareAdvice(List<string> srcTxtList,int index, List<List<ConsoleCommandParam>> listofConsoleCommandParamList)
        {
            foreach(var item in srcTxtList)
            {
                PrepareAdviceParams(item, index, listofConsoleCommandParamList);
            }  
        }      
        public void UpdateConsoleCommandStaticParamList(List<ConsoleCommandParam> staticParams)
        {
            try
            {
                List<int> vs = new List<int>();
                vs = Handler.UpdateCommandStaticParam();
                if (vs != null && vs.Count != 0)
                {
                    foreach (int index in vs)
                    {
                        StatikParams[index] = staticParams;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("UpdateConsoleCommandStaticParamList for console command: {0} exception: {1}",Handler.UniqueID(), e.ToString()));
            }
        }

        public  List<int> UpdateConsoleCommandParamIndexList(List<List<ConsoleCommandParam>> staticLists)
        {
            List<int> commandParamsIndexList = new List<int>();
            try
            {
                
                    List<int> vs = new List<int>();
                    vs = Handler.UpdateCommandStaticParam();
                    foreach (List<ConsoleCommandParam> item in staticLists)

                    {
                         if (vs != null && vs.Count != 0)
                        {
                            int index = vs.First();
                            vs.RemoveAt(0);
                            StatikParams[index] = item;
                        }
                      
                    }
                

            }
            catch (Exception e)
            {
                Console.WriteLine( String.Format("UpdateConsoleCommandStaticParamList for console command: {0} exception: {1}", Handler.UniqueID(), e.ToString()));
            }
           

            return commandParamsIndexList;
        }



    }
}
