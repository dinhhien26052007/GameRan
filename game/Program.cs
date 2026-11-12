namespace SnakeGame
{
    internal static class Program
    {
        /// <summary>
        ///  Điểm bắt đầu của ứng dụng.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new GameForm());
        }
    }
}
