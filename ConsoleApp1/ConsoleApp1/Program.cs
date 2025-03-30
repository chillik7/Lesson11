using System;

public interface IMediaFile
{
    void Play();
    string FileName { get; }
}
public class AudioFile : IMediaFile
{
    public string FileName { get; }

    public AudioFile(string fileName)
    {
        FileName = fileName;
    }
    public void Play()
    {
        Console.WriteLine($"♫ Воспроизведение аудио файла: {FileName}");
    }
}

public class VideoFile : IMediaFile
{
    public string FileName { get; }

    public VideoFile(string fileName)
    {
        FileName = fileName;
    }

    public void Play()
    {
        Console.WriteLine($"▶ Воспроизведение видео файла: {FileName}");
    }
}
public class ImageFile : IMediaFile
{
    public string FileName { get; }

    public ImageFile(string fileName)
    {
        FileName = fileName;
    }

    public void Play()
    {
        Console.WriteLine($"🖼️ Отображение изображения: {FileName}");
    }
}
public abstract class MediaFactory
{
    public abstract IMediaFile CreateMediaFile(string fileName);

    public void PlayMedia(string fileName)
    {
        var mediaFile = CreateMediaFile(fileName);
        mediaFile.Play();
    }
}
public class AudioFactory : MediaFactory
{
    public override IMediaFile CreateMediaFile(string fileName)
    {
        return new AudioFile(fileName);
    }
}
public class VideoFactory : MediaFactory
{
    public override IMediaFile CreateMediaFile(string fileName)
    {
        return new VideoFile(fileName);
    }
}
public class ImageFactory : MediaFactory
{
    public override IMediaFile CreateMediaFile(string fileName)
    {
        return new ImageFile(fileName);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Демонстрация паттерна 'Фабричный метод' для мультимедийных файлов\n");

        MediaFactory audioFactory = new AudioFactory();
        MediaFactory videoFactory = new VideoFactory();
        MediaFactory imageFactory = new ImageFactory();

        Console.WriteLine("Создание и воспроизведение аудио:");
        audioFactory.PlayMedia("song.mp3");

        Console.WriteLine("\nСоздание и воспроизведение видео:");
        videoFactory.PlayMedia("movie.mp4");

        Console.WriteLine("\nСоздание и отображение изображения:");
        imageFactory.PlayMedia("photo.jpg");

        Console.WriteLine("\nСоздание медиафайлов для последующего использования:");

        IMediaFile audio = audioFactory.CreateMediaFile("another_song.wav");
        IMediaFile video = videoFactory.CreateMediaFile("presentation.avi");
        IMediaFile image = imageFactory.CreateMediaFile("diagram.png");

        IMediaFile[] mediaLibrary = { audio, video, image };

        Console.WriteLine("\nВоспроизведение всех файлов из медиатеки:");
        foreach (var media in mediaLibrary)
        {
            media.Play();
        }
    }
}