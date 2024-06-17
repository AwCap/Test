using System;
using System.Linq;

class TableChips
{
    public static int MinMoves(int[] chips)
    {
        int totalChips = chips.Sum();
        int numSeats = chips.Length;
        int idealChipsPerSeat = totalChips / numSeats;
        int remainder = totalChips % numSeats;
        int minMoves = 0;

        // Распределяем остаток фишек, начиная с места, где их меньше всего
        Array.Sort(chips);
        for (int i = 0; i < remainder; i++)
        {
            chips[i]++;
        }

        // После распределения остатка, повторно вычисляем количество перемещений
        foreach (var chipCount in chips)
        {
            minMoves += Math.Abs(chipCount - idealChipsPerSeat);
        }

        // Поскольку каждое перемещение фишки учитывается дважды, делим на 2
        return minMoves / 2;
    }

    static void Main()
    {
        Console.WriteLine(MinMoves(new int[] { 1, 5, 9, 10, 5 })); // Ожидаемый результат: 12
        Console.WriteLine(MinMoves(new int[] { 1, 2, 3 })); // Ожидаемый результат: 1
        Console.WriteLine(MinMoves(new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 2 })); // Ожидаемый результат: 1
    }
}