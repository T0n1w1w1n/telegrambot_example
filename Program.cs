using System;
using Telegram.Bot;
using Telegram.Bot.Args;
namespace TelegramBoot
{
    class Program
    {
        private static readonly TelegramBotClient bot = new TelegramBotClient("1483847690:AAEo-OYXZAkE-uFMGbg2-zxJWiJRGqIB7lE");
        /// <summary>
        /// csharp corner chat bot web hook
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // var botClient = new TelegramBotClient("1483847690:AAEo-OYXZAkE-uFMGbg2-zxJWiJRGqIB7lE");
            // var me = botClient.GetMeAsync().Result;
            // Console.WriteLine(
            //   $" Username {me.Username} I am user {me.Id} and my name is {me.FirstName}."
            // );

            // Console.ReadKey();
            var me = bot.GetMeAsync().Result;
            Console.WriteLine(
              $" Username {me.Username} I am user {me.Id} and my name is {me.FirstName}."
            );

            bot.OnMessage += Bot_OnMessage;
            bot.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bot.StopReceiving();
        }
        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            string keyMsg = string.Empty;
            string respon = string.Empty;
            if (e.Message.Text != null)
            {
                keyMsg = e.Message.Text;
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
                if (keyMsg.ToLower() == "perintah")
                {
                    respon = "myid : Check Id Telegram anda \n"
                           + "myakun : Check info akun anda";
                   
                }
                else if (keyMsg.ToLower() == "myid")
                {
                    respon = "Id telegram anda adalah : " + e.Message.Chat.Id;
                }
                else if (keyMsg.ToLower() == "myakun")
                {
                    respon = "Id Akun : 1DAC01 \n"
                           + "Nama : Devel \n"
                           + "Tlp : 085794888604 \n"
                           + "Email : toni.wazni@gmail.com";

                }
                else
                {
                    respon = "Perintah tidak ditemukan. \n"
                           + "ketik 'perintah' untuk informasi perintah";

                    // await bot.SendTextMessageAsync(
                    //                   chatId: e.Message.Chat,
                    //                   text: "You said:\n" + e.Message.Text
                    //                 );
                }

                //kirim response
                await bot.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: respon
                            );

            }
        }

    }
}
