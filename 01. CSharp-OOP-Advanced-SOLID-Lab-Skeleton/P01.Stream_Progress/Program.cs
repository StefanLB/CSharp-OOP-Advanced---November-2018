using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            File file = new File("e-book", 20, 10);
            Music song = new Music("Vesko M.", "unknown", 30, 20);
            Video video = new Video("Tarantino", 1_000_000, 1900, 310);

            Calculate(file);
            Calculate(song);
            Calculate(video);
        }

        static void Calculate(IStreamable streamable)
        {
            StreamProgressInfo stream = new StreamProgressInfo(streamable);
            Console.WriteLine(stream.CalculateCurrentPercent());
        }
    }
}
