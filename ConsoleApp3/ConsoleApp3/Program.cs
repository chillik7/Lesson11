using System;

interface ICommand
{
    void Execute();
}

class Television
{
    private bool isOn = false;
    private int volume = 10;

    public void PowerOn()
    {
        isOn = true;
        Console.WriteLine("Телевизор включен");
    }

    public void PowerOff()
    {
        isOn = false;
        Console.WriteLine("Телевизор выключен");
    }

    public void IncreaseVolume()
    {
        if (isOn)
        {
            volume++;
            Console.WriteLine("Громкость увеличена до " + volume);
        }
    }

    public void DecreaseVolume()
    {
        if (isOn)
        {
            volume--;
            Console.WriteLine("Громкость уменьшена до " + volume);
        }
    }
}
class TVPowerOnCommand : ICommand
{
    private Television _tv;

    public TVPowerOnCommand(Television tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.PowerOn();
    }
}

class TVPowerOffCommand : ICommand
{
    private Television _tv;

    public TVPowerOffCommand(Television tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.PowerOff();
    }
}

class VolumeUpCommand : ICommand
{
    private Television _tv;

    public VolumeUpCommand(Television tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.IncreaseVolume();
    }
}

class VolumeDownCommand : ICommand
{
    private Television _tv;

    public VolumeDownCommand(Television tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.DecreaseVolume();
    }
}

class TVRemote
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }
}

class Program
{
    static void Main()
    {
        Television tv = new Television();
        TVRemote remote = new TVRemote();

        remote.SetCommand(new TVPowerOnCommand(tv));
        remote.PressButton();

        remote.SetCommand(new VolumeUpCommand(tv));
        remote.PressButton();
        remote.PressButton();

        remote.SetCommand(new VolumeDownCommand(tv));
        remote.PressButton();

        remote.SetCommand(new TVPowerOffCommand(tv));
        remote.PressButton();
    }
}
