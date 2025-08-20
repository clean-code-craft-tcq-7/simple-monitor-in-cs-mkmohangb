using System;
using System.Diagnostics;

public interface ICheckerDisplay
{
    void DisplayVitalsAlert(string message);
}

public class ConsoleCheckerDisplay : ICheckerDisplay
{
    public void DisplayVitalsAlert(string message)
    {
        Console.WriteLine(message);
        for (int i = 0; i < 6; i++)
        {
            Console.Write("\r* ");
            System.Threading.Thread.Sleep(1000);
            Console.Write("\r *");
            System.Threading.Thread.Sleep(1000);
        }
    }
}

public class Checker
{
    private readonly ICheckerDisplay _display;

    public Checker(ICheckerDisplay display)
    {
        _display = display;
    }

    public bool VitalsOk(float temperature, int pulseRate, int spo2)
    {
        if(temperature >102 || temperature < 95)
        {
            _display.DisplayVitalsAlert("Temperature is out of range!");
            return false;
        }
        else if (pulseRate < 60 || pulseRate > 100)
        {
            _display.DisplayVitalsAlert("Pulse rate is out of range!");
            return false;
        }
        else if (spo2 < 90)
        {
            _display.DisplayVitalsAlert("Oxygen saturation is out of range!");
            return false;
        }
        Console.WriteLine("Vitals received within normal range");
        Console.WriteLine("Temperature: {0} Pulse: {1}, SO2: {2}", temperature, pulseRate, spo2);
        return true;
    }
}
