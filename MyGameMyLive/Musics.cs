using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MyGameMyLive
{
    public class Musics
    {
        private WaveOutEvent backgroundMusicDevice;
        private AudioFileReader backgroundMusicFile;
        private Thread backgroundMusicThread;

        private List<string> musicFiles = new List<string>();
        private int currentTrackIndex = 0;
        private bool isPlaying = false; // Флаг для контроля воспроизведения

        public float volume = 0.1f; // Громкость по умолчанию

        public void PlayBackgroundMusic()
        {
            isPlaying = true;

            backgroundMusicThread = new Thread(() =>
            {
                while (isPlaying) // Цикл работает, пока isPlaying = true
                {
                    string folderPath = AppDomain.CurrentDomain.BaseDirectory;
                    string musicFileName = musicFiles[currentTrackIndex];
                    string musicFilePath = Path.Combine(folderPath, musicFileName);

                    if (File.Exists(musicFilePath))
                    {
                        try
                        {
                            backgroundMusicFile = new AudioFileReader(musicFilePath);
                            backgroundMusicDevice = new WaveOutEvent();
                            backgroundMusicDevice.Init(backgroundMusicFile);

                            backgroundMusicDevice.Volume = volume; // Установка громкости
                            backgroundMusicDevice.Play();

                            // Ожидание завершения трека или остановки воспроизведения
                            while (backgroundMusicDevice.PlaybackState == PlaybackState.Playing && isPlaying)
                            {
                                Thread.Sleep(100);
                            }
                        }
                        catch (Exception ex)
                        {
                           /* Console.WriteLine($"Ошибка воспроизведения: {ex.Message}");*/
                        }
                        finally
                        {
                            DisposeBackgroundMusic();
                        }

                        currentTrackIndex++;
                        if (currentTrackIndex >= musicFiles.Count)
                        {
                            currentTrackIndex = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Файл {musicFilePath} не найден.");
                    }
                }
            });

            backgroundMusicThread.IsBackground = true;
            backgroundMusicThread.Start();
        }

        public void AddMusicFile(string fileName)
        {
            musicFiles.Add(fileName);
        }

        public void SetVolume(float newVolume)
        {
            if (newVolume < 0.0f || newVolume > 1.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(newVolume), "Громкость должна быть в пределах от 0.0 до 1.0");
            }

            volume = newVolume;

            if (backgroundMusicDevice != null)
            {
                backgroundMusicDevice.Volume = volume;
            }
        }

        public void StopBackgroundMusic()
        {
            isPlaying = false; // Останавливаем цикл воспроизведения

            if (backgroundMusicDevice != null && backgroundMusicDevice.PlaybackState == PlaybackState.Playing)
            {
                backgroundMusicDevice.Stop();
            }

            DisposeBackgroundMusic(); // Освобождение ресурсов
        }

        private void DisposeBackgroundMusic()
        {
            if (backgroundMusicDevice != null)
            {
                backgroundMusicDevice.Dispose();
                backgroundMusicDevice = null;
            }

            if (backgroundMusicFile != null)
            {
                backgroundMusicFile.Dispose();
                backgroundMusicFile = null;
            }
        }
        // Метод для воспроизведения коротких звуков (например, шагов)
        public void PlaySoundEffect(string soundFileName)
        {
            // Запускаем звук в отдельном потоке
            new Thread(() =>
            {
                string folderPath = AppDomain.CurrentDomain.BaseDirectory;
                string soundFilePath = Path.Combine(folderPath, soundFileName);

                if (File.Exists(soundFilePath))
                {
                    using (var soundFile = new AudioFileReader(soundFilePath))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Init(soundFile);
                        outputDevice.Play();

                        // Не ждем окончания воспроизведения, оно идет параллельно
                        while (outputDevice.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(100);
                        }
                    }
                }
            }).Start(); // Запуск нового потока
        }
    }




}
