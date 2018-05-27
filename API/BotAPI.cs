using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKApiCore;
using GIFService;

namespace API
{
    public class BotAPI: IBotAPI
    {
        private static readonly Dictionary<string, Func<string[], Task>> Commands
            = new Dictionary<string, Func<string[], Task>>();

        private static readonly VkService vkService;
        private static readonly GifService gifService;

        static BotAPI()
        {
            vkService = new VkService();
            gifService = new GifService();

            Commands["call"] = async args =>
            {
                var users = await vkService.GetGroupUsers();
                await vkService.SendMessagesByIds(users, args[0]);
            };

            Commands["ok"] = async args =>
            {
                await vkService.SendMessageById(args[0], "Ok. Request is processing");
            };

            Commands["error"] = async args =>
            {
                await vkService.SendMessageById(args[0], "Command not found. Send help");
            };

            Commands["anime"] = async args =>
            {
                await vkService.SendMessageById(args[0], AnimeList.Urls[new Random().Next(0, AnimeList.Urls.Count)]);
            };

            Commands["help"] = async args =>
            {
                await vkService.SendMessageById(args[0], HelpText.Text);
            };

            Commands["gg"] = async args =>
            {
                string userId;
                string gifLink;
                if (args.Length > 1)
                {
                    userId = args[1];
                    gifLink = gifService.GetGifByCategory(args[0]);
                }
                else
                {
                    userId = args[0];
                    gifLink = gifService.GetRandomGif();
                }

                if (gifLink == null)
                    await Commands["help"](new[] { userId });
                else
                    await vkService.SendGifById(userId, gifLink);
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
