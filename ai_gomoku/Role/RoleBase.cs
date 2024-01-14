using ai_gomoku.Command;
using ai_gomoku.Models;
using System;
using System.Collections.Generic;

namespace ai_gomoku.Role
{
    public abstract class RoleBase
    {
        public delegate bool isAllowFun();
        public delegate bool onFun(CommandBase command);

        public String Name { get; protected set; }

        protected Form1 View;

        protected GameModel Model;

        protected RoleMgr RoleMgr;

        protected ChessType MyChessType;

        protected int TurnCount { get; private set; }

        private Dictionary<String, Tuple<isAllowFun, onFun>> CommandMap = new Dictionary<String, Tuple<isAllowFun, onFun>>();

        public RoleBase(String name, Form1 view, GameModel model, RoleMgr roleMgr, ChessType chessType)
        {
            Name = name;
            View = view;
            Model = model;
            RoleMgr = roleMgr;
            MyChessType = chessType;
            TurnCount = 0;

            AddCommand("RenewCommand", IsAllowRenewCommand, OnRenewCommand);
            AddCommand("ReturnHomeCommand", IsAllowReturnHomeCommand, OnReturnHomeCommand);
        }

        public ChessType GetChessType()
        {
            return MyChessType;
        }

        protected void AddCommand(String commandName, isAllowFun isAllowFun, onFun onFun)
        {
            if (CommandMap.ContainsKey(commandName) == false)
            {
                CommandMap.Add(commandName, new Tuple<isAllowFun, onFun>(isAllowFun, onFun));

                Console.WriteLine($"{Name} add Command : {commandName}");
            }
            else
            {
                Console.WriteLine($"Command : {commandName} is repeated");
            }
        }

        public void OnCommand(CommandBase command)
        {
            if (CommandMap.ContainsKey(command.Name))
            {
                if ((CommandMap[command.Name].Item1).Invoke())
                {
                    Console.WriteLine($"{Name} onCommand : {command.Name}");
                    (CommandMap[command.Name].Item2).Invoke(command);
                }
                else
                {
                    Console.WriteLine($"{Name} not allow Command : {command.Name}");
                }
            }
            else
            {
                Console.WriteLine($"{Name} onCommand : Cannot find the {command.Name}");
            }
        }

        public virtual void OnMyTurn()
        {
            TurnCount++;
            System.Console.WriteLine($"{Name} onMyTurn");
        }

        public virtual void AppendName(string appendName)
        {
        }

        protected virtual bool IsAllowRenewCommand()
        {
            return true;
        }

        protected virtual bool IsAllowReturnHomeCommand()
        {
            return true;
        }

        protected virtual bool OnRenewCommand(CommandBase command)
        {
            RoleMgr.RenewGame();
            return true;
        }

        protected virtual bool OnReturnHomeCommand(CommandBase command)
        {
            RoleMgr.ReturnHome();
            return true;
        }
    }
}
