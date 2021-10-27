using robotManager.Helpful;

namespace SetLootRange
{
  public class Helpers
  {
    public static void Logger(string message)
    {
      Logging.Write("[SetLootRange] " + message, Logging.LogType.Normal, System.Drawing.Color.ForestGreen);
    }
  }
}
