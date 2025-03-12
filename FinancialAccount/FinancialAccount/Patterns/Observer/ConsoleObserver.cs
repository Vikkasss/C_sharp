namespace FinancialAccount.Patterns.Observer;

public class ConsoleObserver : IObserver
{
    public void Update(string message)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"[OBSERVER] {message}");
        Console.ResetColor();
    }
}