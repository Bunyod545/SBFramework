# .NET Client for Telegram Bot API

[![package](https://img.shields.io/nuget/vpre/SB.TelegramBot.svg?label=SB.TelegramBot&style=flat-square)](https://www.nuget.org/packages/SB.TelegramBot)
[![telegram chat](https://img.shields.io/badge/Support_Chat-Telegram-blue.svg?style=flat-square)](https://t.me/joinchat/CZEOHxilcpIVWL3x_MiKpQ)

[![downloads](https://img.shields.io/nuget/dt/SB.TelegramBot.svg?style=flat-square&label=Package%20Downloads)](https://www.nuget.org/packages/SB.TelegramBot)

## 🚧 Supported Platforms

Project targets **.NET Standard 2**.

## 🔨 Getting Started

## Create the bot on telegram first

![bot-creating-in-telegram](Assets/createbot.png)

## Namespace
-------
```csharp
using SB.TelegramBot;
```
## Run telegram bot application
-------
```csharp
public static void Main()
{
    TelegramBotApplication.Run("teleram bot token here");

    Console.WriteLine("Telegram bot started!");
    Console.WriteLine("Press enter to close!");
    Console.ReadLine();
}
```
## Now go to your bot

![bot-creating-in-telegram](Assets/telegrambotversion.png)
