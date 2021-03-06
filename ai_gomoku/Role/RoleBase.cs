﻿using System;
using System.Collections.Generic;

using ai_gomoku.Command;

namespace ai_gomoku.Role
{
    public abstract class RoleBase
    {
        public String Name { get; protected set; }//read only

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
        public ChessType GetChessType()
        {
            return MyChessType;
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
            if (CommandMap.ContainsKey(command.Name))
            {
                if ((CommandMap[command.Name].Item1).Invoke())
                {
                    System.Console.WriteLine($"{Name} onCommand : {command.Name}");
                    (CommandMap[command.Name].Item2).Invoke(command);
                }
                else
                {
                    System.Console.WriteLine($"{Name} not allow Command : {command.Name}");
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
        public virtual void AppendName(string appendName)
        {  
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
