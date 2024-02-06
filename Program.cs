using System;
using System.Diagnostics;

namespace YoutubeLivestreamChatUrl
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Get current public livestream chat Url from Youtube channel.");
            Console.WriteLine("Compatible formats:");
            Console.WriteLine("  https://www.youtube.com/@YouTube");
            Console.WriteLine("  youtube.com/YouTube");
            Console.WriteLine($"  https://www.youtube.com/channel/UCBR8-60-B28hp2BmDPdntcQ");
            Console.WriteLine($"  youtube.com/channel/UCBR8-60-B28hp2BmDPdntcQ\n");

            Console.WriteLine("Insert Youtube channel:");
            var url = Console.ReadLine().ToLower();

            if (url.Contains("youtube.com/"))
            {
                var livestream = Livestream.GetChatUrl(url);

                Console.WriteLine($"This is the live stream URL:\n{livestream}\n\nCopy to the clipboard?: (y/n)");
                var key = Console.ReadKey().Key.ToString().ToLower();

                if (key.Equals("y"))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "clip.exe",
                        RedirectStandardInput = true,
                        UseShellExecute = false
                    }).StandardInput.Write(livestream);
                }
            }
            else
            {
                Console.WriteLine("Check the url and the compatible formats before use it.");
            }
        }
    }
}
