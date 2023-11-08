/*           
* Author                             : Metehan PATACI
* Date                               : 11/19/2020 12:21:40 PM
* Description     		     :               
*/


using OperatorMainScreen.ConsoleCommandMng.Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Splitter
{
    public class ConsoleCommandSplitter
    {
        private static char[] delimiterChars = ConsoleCommandDelimeters.Delimeters;

        public static List<String> Split(String commandStr) 
        {
            string[] words = commandStr.Split(delimiterChars);

            List<String> strList = words.ToList();

            var pList = strList.Where(a => a != "");
            List<String> prunedList = pList.ToList();

            /*if (strList.Count > 1 && strList.ElementAt(strList.Count - 1) == "")
                prunedList.Add("");
            */

            return prunedList;
        }

        public static List<String> SplitAndAddSpace(String commandStr)
        {
            string[] words = commandStr.Split(delimiterChars);

            List<String> strList = words.ToList();

            var pList = strList.Where(a => a != "");
            List<String> prunedList = pList.ToList();

            if (strList.Count > 1 && strList.ElementAt(strList.Count - 1) == "")
                prunedList.Add("");
            

            return prunedList;
        }
    }
}
