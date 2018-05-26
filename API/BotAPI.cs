using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKApiCore;

namespace API
{
    public class BotAPI: IBotAPI
    {
        private static readonly Dictionary<string, Func<string[], Task>> Commands
            = new Dictionary<string, Func<string[], Task>>();

        static BotAPI()
        {
            var vks = new VkService();
            Commands["call"] = async args =>
            {
                var users = await vks.GetGroupUsers();
                foreach (var user in users)
                {
                    await vks.SendMessageById(user, args[0]);
                }
            };

            Commands["ok"] = async args =>
            {
                await vks.SendMessageById(args[0], "Ok. Request is processing");
            };
        }

        public async Task ExecuteCommand(string[] args)
        {
            var command = args[0];
            if (!Commands.ContainsKey(command))
            {
                throw new ArgumentException("Command is not found");
            }
            var list = args.Skip(1).ToArray();
            await Commands[command](list);
        }
    }
}
