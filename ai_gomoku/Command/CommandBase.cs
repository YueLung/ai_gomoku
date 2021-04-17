using System;

namespace ai_gomoku.Command
{
    public abstract class CommandBase
    {
        public String Name { get; }
        public CommandBase(String name)
        {
            Name = name;
        }
    }
}
