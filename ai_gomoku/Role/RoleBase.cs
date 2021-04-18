using System;
using System.Collections.Generic;

using ai_gomoku.Command;

namespace ai_gomoku.Role
{
    public abstract class RoleBase
    {
        public String Name { get; }//read only

        public delegate bool isAllowFun();
        public delegate bool onFun(CommandBase command);

        protected Form1 View;

        protected Model Model;

        protected RoleMgr RoleMgr;

        protected ChessType MyChessType;

        protected int TurnCount { get; private set; }

        private Dictionary<String, Tuple<isAllowFun, onFun>> CommandMap = new Dictionary<String, Tuple<isAllowFun, onFun>>();

        public RoleBase(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType)
        {
            Name = name;
            View = view;
            Model = model;
            RoleMgr = roleMgr;
            MyChessType = chessType;
            TurnCount = 0;

            addCommand("RenewCommand", isAllowRenewCommand, onRenewCommand);
            addCommand("ReturnHomeCommand", isAllowReturnHomeCommand, onReturnHomeCommand);

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

        public void onCommand(CommandBase command)
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
            TurnCount++;
            System.Console.WriteLine($"{Name} onMyTurn");              
        }
        protected virtual bool isAllowRenewCommand()
        {
            return true;
        }
        protected virtual bool isAllowReturnHomeCommand()
        {
            return true;
        }

        protected virtual bool onRenewCommand(CommandBase command)
        {
            RoleMgr.RenewGame();
            return true;
        }
        protected virtual bool onReturnHomeCommand(CommandBase command)
        {
            RoleMgr.ReturnHome();
            return true;
        }
    }
}
