using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku
{
    public abstract class RoleBase
    {
        public String Name { get; }

        public delegate bool isAllowFun();
        public delegate bool onFun(Command command);

        protected Form1 View;

        protected Model Model;

        protected RoleMgr RoleMgr;

        protected ChessType MyChessType;

        private Dictionary<String, Tuple<isAllowFun, onFun>> CommandMap = new Dictionary<String, Tuple<isAllowFun, onFun>>();

        public RoleBase(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType)
        {
            Name = name;
            View = view;
            Model = model;
            RoleMgr = roleMgr;
            MyChessType = chessType;

            addCommand("RenewCommand", isAllowRenewCommand, onRenewCommand);
        }

        protected void addCommand(String commandName, isAllowFun isAllowFun, onFun onFun)
        {
            if (CommandMap.ContainsKey(commandName) == false)
            {
                CommandMap.Add(commandName, new Tuple<isAllowFun, onFun>(isAllowFun, onFun));

                System.Console.WriteLine($"{Name} add Command : {commandName}");
            }
            else
            {
                System.Console.WriteLine($"Command : {commandName} is repeated");
            }
        }

        public void onCommand(Command command)
        {
            System.Console.WriteLine($"{Name} onCommand : {command.Name}");

            if (CommandMap.ContainsKey(command.Name))
            {
                if ((CommandMap[command.Name].Item1).Invoke())
                {
                    (CommandMap[command.Name].Item2).Invoke(command);
                }
            }
            else
            {
                System.Console.WriteLine($"{Name} onCommand : Cannot find the {command.Name}");
            }
        }
        public virtual void onMyTurn()
        {
            System.Console.WriteLine($"{Name} onMyTurn");
        }
        private bool isAllowRenewCommand()
        {
            return true;
        }
        private bool onRenewCommand(Command command)
        {
            RoleMgr.RenewGame();
            return true;
        }
    }
}
