using System;

namespace ai_gomoku.Command
{
    class PreviousActionCommand : CommandBase
    {
        public bool IsEnemyAi { get; private set; }

        public PreviousActionCommand(String name, bool isEnemyAi) : base(name)
        {
            IsEnemyAi = isEnemyAi;
        }
    }
}
