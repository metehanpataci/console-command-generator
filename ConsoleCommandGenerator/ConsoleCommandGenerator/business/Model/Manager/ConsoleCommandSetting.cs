/*           
* Author                             : Metehan PATACI
* Date                               : 9/21/2021 2:08:35 PM
* Description     		     :               
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Manager
{
    public class ConsoleCommandSetting
    {
        private int _maxParamCount = 0;

        private int _minParamCount = 0;

        public int MaxParamCount { get => _maxParamCount; set => _maxParamCount = value; }
        public int MinParamCount { get => _minParamCount; set => _minParamCount = value; }

        private bool adviceLastParam = false;
        public ConsoleCommandSetting(int minParam, int maxParam) {
            
            MinParamCount = minParam;

            MaxParamCount = maxParam;
        }
        public void SetAdviceLastParam(bool _adviceLastParam)
        {
            adviceLastParam = _adviceLastParam;
        }
        public bool GetAdviceLastParam()
        {
            return adviceLastParam;
        }
    }
}
