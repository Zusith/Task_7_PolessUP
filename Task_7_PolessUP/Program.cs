    int num = 2871;
    Console.WriteLine($"Ввод: \t{num}");
    int creatednumber = FindNearestNumberSameDigits(num);
    Console.WriteLine($"Вывод: \t{creatednumber}");


    static int FindNearestNumberSameDigits(int num)
    {
        char[] number = num.ToString().ToCharArray();

        for (int digitindex = number.Length - 2; digitindex >= 0; digitindex--)
        {
            if (number[digitindex] < number[digitindex + 1])
            {
                Array.Sort(number, digitindex + 1, number.Length - digitindex - 1);
                int replaceindex = digitindex + 1;
                for (; ; replaceindex++)
                {
                    if (number[replaceindex] > number[digitindex])
                    {
                        break;
                    }
                }
                char temp = number[replaceindex];
                number[replaceindex] = number[digitindex];
                number[digitindex] = temp;
                try
                {
                    return Convert.ToInt32(new string(number));
                }
                catch (OverflowException)
                {
                    return 0;
                }
            }
        }
        return 0;
    }