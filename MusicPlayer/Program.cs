
namespace App
{
    public delegate void MusicPlayerHandler(string song);

    public class MusicPlayer
    {
        public event MusicPlayerHandler SongPlayed;
        public event MusicPlayerHandler SongPaused;
        public event MusicPlayerHandler SongStopped;
        public event MusicPlayerHandler SongSkipped;


        public void Play(string song)
        {
            Console.WriteLine("Played song " + song);
            SongPlayed?.Invoke(song);
        }
        public void Pause(string song)
        {

            Console.WriteLine("Paused song " + song);
            SongPaused?.Invoke(song);

        }


        public void Stop(string song)
        {
            Console.WriteLine("Stopped song " + song);
            SongStopped?.Invoke(song);
        }

        public void Skip(string currSong, string nextSong)
        {
            Console.WriteLine("Skipped song " + currSong + ". Played song " + nextSong);
            SongSkipped?.Invoke(song: nextSong);
        }



    }

    public class Subscriber
    {
        public string Name { get; }
        public Subscriber(string name)
        {
            Name = name;
        }

        public void SongPlayedHandler(string song)

        {
            Console.WriteLine($"{Name} enjoying: {song}");
        }

        public void SongPausedHandler(string song)

        {
            Console.WriteLine($"{Name} paused: {song}");
        }

        public void SongStoppedHandler(string song)

        {
            Console.WriteLine($"{Name} stopped: {song}");
        }

        public void SongSkippedHandler(string nextSong)

        {
            Console.WriteLine($"{Name} skipped to: {nextSong}");
        }
    }

    class Program
    {
        static void Main()
        {
            MusicPlayer musicPlayer = new MusicPlayer();

            Console.WriteLine("Enter your name:");
            string username = Console.ReadLine();

            Subscriber s1 = new Subscriber(username);

            musicPlayer.SongPlayed += s1.SongPlayedHandler;
            musicPlayer.SongPaused += s1.SongPausedHandler;
            musicPlayer.SongStopped += s1.SongStoppedHandler;
            musicPlayer.SongSkipped += s1.SongSkippedHandler;

            while (true)
            {
                Console.WriteLine("\nEnter the action (play, pause, stop, skip) or 'exit' to end:");

                string action = Console.ReadLine().ToLower();

                if (action == "exit")
                {
                    Console.WriteLine("Bye " + s1.Name);
                    break;
                }

                if (action != "play" && action != "pause" && action != "stop" && action != "skip" && action != "exit")
                {
                    Console.WriteLine("Invalid action. Please try again.");
                    continue;
                }

                Console.WriteLine("\nEnter the song title:");

                string songTitle = Console.ReadLine();

                switch (action)

                {
                    case "play":
                        musicPlayer.Play(songTitle);
                        break;

                    case "pause":
                        musicPlayer.Pause(songTitle);
                        break;

                    case "stop":
                        musicPlayer.Stop(songTitle);
                        break;

                    case "skip":
                        Console.WriteLine("Enter the next song title:");
                        string nextSong = Console.ReadLine();
                        musicPlayer.Skip(songTitle, nextSong);
                        break;

                    default:
                        // Unreachable
                        Console.WriteLine("action: " + action);
                        break;
                }
            }
        }
    }
}