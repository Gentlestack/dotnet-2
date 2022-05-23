﻿using Lab2Server.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Lab2Server
{
    public class TelegramUpdateHandler : IUpdateHandler
    {
        readonly private IUserRepository _userRepository;
        public TelegramUpdateHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task IUpdateHandler.HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != UpdateType.Message)
                return;
            if (update.Message!.Type != MessageType.Text)
                return;

            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;
            var username = update.Message.From.FirstName;
            var userId = update.Message.From.Id;
            _userRepository.AddNewUser(new Models.User()
            {
                ChatId = chatId,
                UserId = userId,
                UserName = username
            }
            );
            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "You have successfully registered",
                cancellationToken: cancellationToken);
        }
    }
}
