using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBot.API
{
    public interface IBotAPI
    {
       Task ExecuteCommand(string[] args);
    }
}
