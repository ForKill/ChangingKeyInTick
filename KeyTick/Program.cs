using System.Diagnostics;

namespace KeyTick
{
  internal class Program
  {
    /// <summary>
    /// Список клавиш на которые будет тригер
    /// </summary>
    public static char[] KeyChar = new char[] { 'w', 'a', 's', 'd' };
    
    static void Main(string[] args)
    {
      Stopwatch stopwatch = new Stopwatch(); // Для измерения затраченного времени
      stopwatch.Start(); // Запускаем часы
      long tickTime = stopwatch.ElapsedMilliseconds + 1000; // Устанавливаем время срабатывания первого тика
      
      while (true)
      {
        if(stopwatch.ElapsedMilliseconds >= tickTime) // Если прошла 1000 мс, то обновляем tickTime на след триггер
        {
          tickTime = stopwatch.ElapsedMilliseconds + 1000; // Первым делом обновляем время, иначе погрешность времени будет расти
          Console.WriteLine($"Двигаем змейку! (След. тик в {tickTime} мс.)");
          // Змейка должна двигаться
          // MoveSnake....
          continue;
        }

        if(Console.KeyAvailable)
        {
          int keyIndex = GetKeyWhitelist(Console.ReadKey(true).KeyChar);
          if (keyIndex != -1)
          {
            Console.WriteLine($"Нажали нашу клавишу {KeyChar[keyIndex]}");
          }
        }
      }
      stopwatch.Stop(); // Ну оно тут нафиг не нужно, но при завершение игры надо вызывать
    }

    /// <summary>
    /// Метод которые проверяет нажатие клавиши из требуемого списка
    /// </summary>
    /// <param name="pressKey">Символ нажатой клавиши</param>
    /// <returns>Возвращает индекс нажатой клавиши</returns>
    public static int GetKeyWhitelist(char pressKey) 
    {
      for(int i = 0; i < KeyChar.Length; i++)
      {
        if (KeyChar[i] == pressKey)
          return i;
      }
      return -1;
    }
  }
}