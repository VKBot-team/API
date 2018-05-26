using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using KBot.API;


namespace KBot
{
    class BotAPI:IBotAPI
    {
        private static readonly Dictionary<string, Action<string[]>> Commands
            = new Dictionary<string, Action<string[]>>();

        public void ExecuteCommand(string[] args)
        {
            var command = args[0];
            if (!Commands.ContainsKey(command))
            {
                throw new ArgumentException("Command is not found");
            }
            var list = args.Skip(1).ToArray();
            Commands[command](list);
        }
    }
}

