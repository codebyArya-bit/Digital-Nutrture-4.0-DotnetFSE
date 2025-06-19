using System;

public class Logger
{
    private static Logger instance;
    private Logger()
    {
        Console.WriteLine("Logger Initialized");
    }

    public static Logger GetInstance()
    {
        if (instance == null)
        {
            instance = new Logger();
        }
        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine("Log: " + message);
    }
}

public class SingletonExample
{
    public static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("Logging from instance 1");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("Logging from instance 2");

        Console.WriteLine("Are both instances the same? " + (logger1 == logger2));
    }
}