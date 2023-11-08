

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Commands
{
    public class ConsoleCommandFactory : IConsoleCommandController
    {

        public static Object padLock = new object();

        private static ConsoleCommandFactory instance;

        private ConsoleCommandFactory()
        {
            Init();
        }

        public static ConsoleCommandFactory Instance
        {
            get
            {
                lock (padLock)
                {
                    if (instance == null)
                    {
                        instance = new ConsoleCommandFactory();
                    }
                    return instance;
                }
            }
        }

        protected override void Init()
        {

        }
    }
}
