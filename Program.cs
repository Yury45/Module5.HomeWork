namespace Module5.HomeWork.git
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = SetInfo();
            Print(user);
        }

        private static ConsoleColor[] SetFavColors(ConsoleColor[] favColors)
        {
            ConsoleColor color;
            bool flag = false;
            Console.WriteLine("Введите любимые цвета");
            for (int counter = 0; counter < favColors.Length;)
            {

                Console.WriteLine($"Укажите любимый цвет №{counter + 1}:\n1. Красный\n2. Зеленый\n3. Синий\n4. Желтый\n5. Голубой\n6. Розовый\n7. Серый\n8. Белый");

                char number = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (number)
                {
                    case '1':
                        flag = true;
                        favColors[counter] = ConsoleColor.Red;
                        counter++;
                        break;

                    case '2':
                        flag = true;
                        favColors[counter] = ConsoleColor.Green;
                        counter++;
                        break;

                    case '3':
                        flag = true;
                        favColors[counter] = ConsoleColor.Blue;
                        counter++;
                        break;

                    case '4':
                        flag = true;
                        favColors[counter] = ConsoleColor.Yellow;
                        counter++;
                        break;

                    case '5':
                        flag = true;
                        favColors[counter] = ConsoleColor.Cyan;
                        counter++;
                        break;

                    case '6':
                        flag = true;
                        favColors[counter] = ConsoleColor.Magenta;
                        counter++;
                        break;

                    case '7':
                        flag = true;
                        favColors[counter] = ConsoleColor.Gray;
                        counter++;
                        break;

                    case '8':
                        flag = true;
                        favColors[counter] = ConsoleColor.White;
                        counter++;
                        break;

                    default:
                        Console.WriteLine("Неверный вариант ответа - выберите повторно!");
                        break;
                }
            }

            return favColors;
        }

        private static bool SetPetStatus()
        {
            bool flag = false;
            bool result = true;

            do
            {
                Console.WriteLine("У вас есть питомец? Y/N");
                char answer = Char.ToLower(Console.ReadKey().KeyChar);
                Console.Clear();

                switch (answer)
                {

                    case 'y':
                        flag = true;
                        result = true;
                        break;

                    case 'n':
                        flag = true;
                        result = false;
                        break;

                    default:
                        Console.WriteLine("Неверный вариант ответа - выберите повторно!");
                        break;
                }
            } while (!flag);

            return result;
        }

        public static void Print((string FirstName, string LastName, int Age, bool HasPet, int PetsCount, string[] PetsNames, int ColorsCount, ConsoleColor[] FavColors) dataTuple)
        {
            PrintFavColor($"Имя: {dataTuple.FirstName}", dataTuple.FavColors);
            PrintFavColor($"Фамилия: {dataTuple.LastName}", dataTuple.FavColors);
            PrintFavColor($"Возраст: {dataTuple.Age}", dataTuple.FavColors);
            PrintFavColor($"Наличие питомца: {dataTuple.HasPet}", dataTuple.FavColors);
            if (dataTuple.HasPet)
            {
                PrintFavColor($"Количество питомцев: {dataTuple.PetsCount}", dataTuple.FavColors);
                PrintFavColor($"Клички питомцев:", dataTuple.FavColors);
                for (int i = 0; i < dataTuple.PetsNames.Length; i++)
                {
                    PrintFavColor($"Питомец {i+1}:{dataTuple.PetsNames[i]}", dataTuple.FavColors);
                }
            }
            PrintFavColor($"Цвета:", dataTuple.FavColors);
            foreach (var color in dataTuple.FavColors)
            {
                PrintFavColor(color.ToString(), dataTuple.FavColors);
            }
        }

        public static (string FirstName, string LastName, int Age, bool HasPet, int PetsCount, string[] PetsNames, int ColorsCount, ConsoleColor[] FavColors) SetInfo()
        {
            (string FirstName, string LastName, int Age, bool HasPet, int PetsCount, string[] PetsNames,
                int ColorsCount, ConsoleColor[] FavColors) dataTuple;

            Console.WriteLine("Введите имя:");
            dataTuple.FirstName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Введите фамилию:");
            dataTuple.LastName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Введите возраст:");
            dataTuple.Age = GetAge();

            Console.WriteLine("Есть ли у вас животные:");
            dataTuple.HasPet = SetPetStatus();
            if (dataTuple.HasPet)
            {
                Console.WriteLine("Введите количество питомцев:");
                while (!Int32.TryParse(Console.ReadLine(), result: out dataTuple.PetsCount) || dataTuple.PetsCount <= 1 || dataTuple.PetsCount >= 10)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода - введите количество повторно! Не более 10.");
                }
                Console.Clear();

                Console.WriteLine("Введите их клички:");
                dataTuple.PetsNames = new string[dataTuple.PetsCount];

                for (int i = 0; i < dataTuple.PetsNames.Length; i++)
                {
                    dataTuple.PetsNames[i] = Console.ReadLine();
                }

            }
            else
            {
                dataTuple.PetsCount = 0;
                dataTuple.PetsNames = null;
            }
            Console.Clear();

            Console.WriteLine("Введите количество любимых цветов");
            while (!Int32.TryParse(Console.ReadLine(), result: out dataTuple.ColorsCount) || dataTuple.ColorsCount <= 1 || dataTuple.ColorsCount >= 8)
            {
                Console.Clear();
                Console.WriteLine("Ошибка ввода - введите количество повторно! Не более 8.");
            }
            Console.Clear();

            dataTuple.FavColors = new ConsoleColor[dataTuple.ColorsCount];
            dataTuple.FavColors = SetFavColors(dataTuple.FavColors);

            return dataTuple;
        }

        public static void PrintFavColor(string message, ConsoleColor[] colors)
        {
            Random random = new Random();
            for (int i = 0; i < message.Length; i++)
            {
                Console.ForegroundColor = colors[random.Next(colors.Length)];
                Console.Write(message[i]);
            }
            Console.WriteLine();
        }
        public static int GetAge()
        {
            string age = Console.ReadLine();
            int result;
            Console.Clear();
            while (!Int32.TryParse(age, result: out result) || result < 0 || result > 130)
            {
                Console.WriteLine("Ошибка ввода - введите возраст повтроно!");
                age = Console.ReadLine();
                Console.Clear();
            }

            return result;
        }
    }
}