using SB.TelegramBot.Databases;
using SB.TelegramBot.Databases.Tables;
using SB.TelegramBot.Helpers;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotUserService : ITelegramBotUserService
    {
        /// <summary>
        /// 
        /// </summary>
        private ITelegramBotMessageService _messageService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageService"></param>
        public TelegramBotUserService(ITelegramBotMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TelegramBotUserInfo RegisterUser()
        {
            var user = new TelegramBotDbUser();
            user.ChatId = _messageService.Message.Chat.Id;
            user.Language = "uz-Latn-UZ";

            TelegramBotDb.Users.Insert(user);
            return new TelegramBotUserInfo(user.ChatId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TelegramBotUserInfo GetCurrentUserInfo()
        {
            return GetUserInfo(_messageService.Message.Chat.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        public TelegramBotUserInfo GetUserInfo(long chatId)
        {
            var user = TelegramBotDb.Users.FindOne(f => f.ChatId == chatId);
            if (user == null)
                return null;

            var userInfo = new TelegramBotUserInfo();
            userInfo.ChatId = chatId;
            userInfo.Language = user.Language;
            userInfo.CurrentCommandClrName = user.CurrentCommand;

            return userInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language"></param>
        public void SetCurrentUserLanguage(string language)
        {
            var user = TelegramBotDb.Users.FindOne(f => f.ChatId == _messageService.Message.Chat.Id);
            if (user == null)
                return;

            user.Language = language;
            TelegramBotDb.Users.Update(user);
            TelegramBotLanguageHelper.InitializeCulture(user.Language);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        public void SetCurrentUserCurrentCommand<TCommand>() where TCommand : ITelegramBotCommand
        {
            var user = TelegramBotDb.Users.FindOne(f => f.ChatId == _messageService.Message.Chat.Id);
            if (user == null)
                return;

            user.CurrentCommand = typeof(TCommand).Name;
            TelegramBotDb.Users.Update(user);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearCurrentUserCurrentCommand()
        {
            var user = TelegramBotDb.Users.FindOne(f => f.ChatId == _messageService.Message.Chat.Id);
            if (user == null)
                return;

            user.CurrentCommand = null;
            TelegramBotDb.Users.Update(user);
        }
    }
}
