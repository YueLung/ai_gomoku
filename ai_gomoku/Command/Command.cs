using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku
{
    public abstract class Command
    {
        public String Name { get; }
        public Command(String name)
        {
            Name = name;
        }
    }
}
