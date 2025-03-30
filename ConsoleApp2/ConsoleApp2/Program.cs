using System;

interface IRobot
{
    string GetStatus();
}

class BasicRobot : IRobot
{
    public string GetStatus()
    {
        return "Базовый робот: выполняет стандартные функции";
    }
}
abstract class RobotDecorator : IRobot
{
    protected IRobot _robot;

    public RobotDecorator(IRobot robot)
    {
        _robot = robot;
    }

    public virtual string GetStatus()
    {
        return _robot.GetStatus();
    }
}

class VoiceControlDecorator : RobotDecorator
{
    public VoiceControlDecorator(IRobot robot) : base(robot) { }

    public override string GetStatus()
    {
        return base.GetStatus() + " + голосовое управление";
    }
}

class NavigationDecorator : RobotDecorator
{
    public NavigationDecorator(IRobot robot) : base(robot) { }

    public override string GetStatus()
    {
        return base.GetStatus() + " + улучшенная навигация";
    }
}

class SensorDecorator : RobotDecorator
{
    public SensorDecorator(IRobot robot) : base(robot) { }

    public override string GetStatus()
    {
        return base.GetStatus() + " + дополнительные датчики";
    }
}
class Program
{
    static void Main()
    {
        IRobot robot = new BasicRobot();
        Console.WriteLine(robot.GetStatus());

        robot = new VoiceControlDecorator(robot);
        Console.WriteLine(robot.GetStatus());

        robot = new NavigationDecorator(robot);
        Console.WriteLine(robot.GetStatus());

        robot = new SensorDecorator(robot);
        Console.WriteLine(robot.GetStatus());
    }
}

