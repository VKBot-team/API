using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public interface IBotAPI
    {
        Task ExecuteCommand(string[] args);
    }
}
