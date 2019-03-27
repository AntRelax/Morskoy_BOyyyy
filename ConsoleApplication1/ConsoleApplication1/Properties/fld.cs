using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace SharedProject1
{
    public class FIELD
    {
        public void Give(ref string[,] fld)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    fld[i, j] = "-";
                }
            }
        }
        
        public void Writeln(string[,] fld)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(fld[i,j]);
                }

                Console.WriteLine();
            }
        }

        public bool Fill(int d, int y, int x, string z, ref string[,] fld)
        {
            var Field = fld;
            if (Field[y, x] == "O")
            {
                Writeln(Field);
                Console.WriteLine("{0};{1} уже занято2!\n", y, x);
                return false;
            }

            
            if (d > 1)
            {
                Console.WriteLine("Введи направление корабля\n");
                switch (z)
                {
                    case "left":
                        if ((x - d + 1) < 0)
                        {
                            Console.WriteLine("Обнаружен конец поля!/n");
                            return false;
                        }

                        try
                        {
                            if (Field[y, x + 1] == "O")
                            {
                                Console.WriteLine("Нельзя ставить корабли впритык друг к другу\n");
                                return false;
                            }
                        }

                        catch (IndexOutOfRangeException) {}
                        
                        for (int i = 0; i < d; i++)
                        {
                            if (Field[y, x - i] == "O")
                            {
                                Console.WriteLine("{0};{1} уже занято!\n", y, x - i);
                                for (int j = 0; j < i; j++)
                                {
                                    Field[y, x - j] = "-";
                                }
                                    
                                return false;
                            }

                            try
                            {
                                if (Field[y - 1, x - i] == "O")
                                {
                                    Console.WriteLine("Нельзя ставить корабли впритык друг к другу\n");
                                    for (int j = 0; j < i; j++)
                                    {
                                        Field[y, x - j] = "-";
                                    }

                                    return false;
                                }
                            }

                            catch (IndexOutOfRangeException) {}

                            try 
                            {
                                if (Field[y + 1, x - i] == "O")
                                    {
                                        Console.WriteLine("Нельзя ставить корабли впритык друг к другу\n");
                                        for (int j = 0; j < i; j++)
                                        {
                                            Field[y, x - j] = "-";
                                        }
                                    
                                    return false;
                                }
                            }
                            
                            catch (IndexOutOfRangeException) {}

                            try
                            {
                                if (Field[y, x - d] == "O")
                                {
                                    Console.WriteLine("Нельзя ставить корабли впритык друг к другу\n");
                                    for (int j = 0; j < i; j++)
                                    {
                                        Field[y, x - j] = "-";
                                    }
                                    
                                    return false;
                                }
                            }
                            
                            catch (IndexOutOfRangeException) {}
                            Field[y, x - i] = "O";
                        }

                        break;
                    
                    case "right":
                        if ((x + d - 1) > 9) //если обнаружен конец поля
                        {
                            Console.WriteLine("Обнаружен конец поля!\n");
                            return false;
                        }

                        try
                        {
                            if (Field[y, x - 1] == "O") //если слева стоит корабль
                            {
                                Console.WriteLine("Нельзя ставить корабли впритык друг к другу\n");
                                return false;
                            }
                        }
                        
                        catch (IndexOutOfRangeException) {}
                        
                        for (int i = 0; i < d; i++)
                        {
                            if (Field[y, x + i] == "O") //если по ходу заполнения был обнаружен корабль
                            {
                                Console.WriteLine("{0};{1} уже занято!", y, x + i);
                                for (int j = 0; j < i; j++)
                                {
                                    Field[y, x + j] = "-";
                                }
                                
                                return false;
                            }

                            try
                            {

                                if (Field[y + 1, x + i] == "O") //если сверху обнаружен корабль
                                {
                                    Console.WriteLine("Нельзя ставить корабли впритык друг к другу!\n");
                                    for (int j = 0; j < i; j++)
                                    {
                                        Field[y, x + j] = "-";
                                    }

                                    return false;
                                }
                            }

                            catch (IndexOutOfRangeException) {}

                            try 
                            {
                                if (Field[y - 1, x + i] == "O")   //если сверху обнаружен корабль
                                    {
                                        Console.WriteLine("Нельзя ставить корабли впритык друг к другу!\n");
                                        for (int j = 0; j < i; j++)
                                        {
                                            Field[y, x + j] = "-";
                                        }
                                    
                                    return false;
                                }
                            }

                            catch (IndexOutOfRangeException) {}

                            try
                            {
                                if (Field[y, x + d] == "O") //если справа обнаружен корабль
                                {
                                    Console.WriteLine("Нельзя ставить корабли впритык друг к другу!");
                                    for (int j = 0; j < i; j++)
                                    {
                                        Field[y, x + j] = "-";
                                    }
                                    
                                    return false;
                                }
                            }

                            catch (IndexOutOfRangeException) {}
                            
                            Field[y, x + i] = "O";
                        }

                        break;
                    
                    case "up":
                        if ((y - d + 1) < 0)
                        {
                            Console.WriteLine("Обнаружен конец поля!");
                            return false;
                        }

                        try
                        {
                            if (Field[y + 1, x] == "O")
                            {
                                Console.WriteLine("Нельзя ставить корабли впритык друг к другу!");
                                return false;
                            }
                        }

                        catch (IndexOutOfRangeException) {}
                        
                        for (int i = 0; i < d; i++)
                        {
                            if (Field[y - i, x] == "O")
                            {
                                Console.WriteLine("{0};{1} уже занято!", y - i, x);
                                for (int j = 0; j < i; j++)
                                {
                                    Field[y - j, x] = "-";
                                }
                                
                                return false;
                            }

                            try
                            {
                                if (Field[y - i, x - 1] == "O")
                                {
                                    Console.WriteLine("Нельзя ставить корабли впритык друг к другу!");
                                    for (int j = 0; j < i; j++)
                                    {
                                        Field[y + j, x] = "-";
                                    }
                                    
                                    return false;
                                }
                            }

                            catch (IndexOutOfRangeException) {}

                            try
                            {
                                if (Field[y - i, x + 1] == "O") 
                                {
                                    Console.WriteLine("Нельзя ставить корабли впритык друг к другу!");
                                    for (int j = 0; j < i; j++)
                                    {
                                        Field[y - j, x] = "-";
                                    }

                                    return false;
                                }
                            }

                            catch (IndexOutOfRangeException) {}

                            try
                            {
                                if (Field[y - d, x] == "O")
                                {
                                    Console.WriteLine("Нельзя ставить корабли впритык друг к другу!");
                                    for (int j = 0; j < i; j++)
                                    {
                                        Field[y - j, x] = "-";
                                    }

                                    return false;
                                }
                            }

                            catch (IndexOutOfRangeException) {}
                            
                            Field[y - i, x] = "O";
                        }

                        break;
                    
                    case "down":
                        if ((y + d - 1) > 9)
                        {
                            Console.WriteLine("Обнаружен конец поля!");
                            return false;
                        }

                        try
                        {
                            if (Field[y - 1, x] == "O")
                            {
                                Console.WriteLine("Нельзя ставить корабли впритык друг к другу!");
                                return false;
                            }
                        }

                        catch (IndexOutOfRangeException) {}
                        
                        
                        for (int i = 0; i < d; i++)
                        {
                            if (Field[y + i, x] == "O")
                            {
                                Console.WriteLine("{0};{1} уже занято!", y - i, x);
                                for (int j = 0; j < i; j++)
                                {
                                    Field[y + j, x] = "-";
                                }

                                return false;
                            }

                            try
                            {
                                if (Field[y + i, x - 1] == "O") 
                                {
                                    Console.WriteLine("Нельзя ставить корабли впритык друг к другу!");
                                    for (int j = 0; j < i; j++)
                                    {
                                        Field[y + j, x] = "-";
                                    }

                                    return false;
                                }
                            }

                            catch (IndexOutOfRangeException) {}

                            try
                            {
                                if (Field[y + i, x + 1] == "O")
                                {
                                    Console.WriteLine("Нельзя ставить корабли впритык друг к другу!");
                                    for (int j = 0; j < i; j++)
                                    {
                                        Field[y + j, x] = "-";
                                    }
                                    return false;
                                }
                            }

                            catch (IndexOutOfRangeException){}

                            try
                            {
                                if (Field[y + d, x] == "O")
                                {
                                    Console.WriteLine("Нельзя ставить корабли впритык друг к другу!");
                                    for (int j = 0; j < i; j++)
                                    {
                                        Field[y + j, x] = "-";
                                    }
                                    
                                    return false;
                                }
                            }
                            
                            catch (IndexOutOfRangeException) {}
                            
                            Field[y + i, x] = "O";
                        }

                        break;
                    
                    default:
                        Console.WriteLine("Неправильно введено направление!");
                        return false;
                }
            }

            else
            {
                try
                {
                    if (Field[y, x + 1] == "O")
                    {
                        Console.WriteLine("Нельзя ставить корабли впритык друг к другу\n");
                        return false;
                    }
                }

                catch (IndexOutOfRangeException) {}

                try
                {
                    if (Field[y, x - 1] == "O")
                    {
                        Console.WriteLine("Нельзя ставить корабли впритык друг к другу\n");
                        return false;
                    }
                }

                catch (IndexOutOfRangeException) {}
                
                try
                {
                    if (Field[y + 1, x] == "O")
                    {
                        Console.WriteLine("Нельзя ставить корабли впритык друг к другу\n");
                        return false;
                    }
                }

                catch (IndexOutOfRangeException) {}

                try
                {
                    if (Field[y - 1, x] == "O")
                    {
                        Console.WriteLine("Нельзя ставить корабли впритык друг к другу\n");
                        return false;
                    }
                }

                catch (IndexOutOfRangeException) {}
                
                Field[y, x] = "O";
            }
            
            return true;
        }

        public string z_Give(int bz, string z)
        {
            if (bz == 0) z = "left";
            if (bz == 1) z = "right";
            if (bz == 2) z = "down";
            if (bz == 3) z = "up";
            return z;
        }

        public bool Unknown(string[,] Field, int y, int x)
        {
            try
            {
                if (Field[y, x + 1] == "O")
                {
                    return false;
                }
            }
            
            catch (IndexOutOfRangeException) {}

            try
            {
                if (Field[y, x - 1] == "O")
                {
                    return false;
                }
            }
            
            catch (IndexOutOfRangeException) {}
            
            try
            {
                if (Field[y + 1, x] == "O")
                {
                    return false;
                }
            }
            
            catch (IndexOutOfRangeException) {}
            
            try
            {
                if (Field[y - 1, x] == "O")
                {
                    return false;
                }
            }
            
            catch (IndexOutOfRangeException) {}

            return true;
        }

        public bool Field_check(string[,] Field)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Field[i, j] == "O") return false;
                }
            }

            return true;
        }

        public bool bField_Shot(ref string[,] Field)
        {
            Random rndm = new Random();
            int y = rndm.Next(10);
            int x = rndm.Next(10);
            Console.WriteLine("Я бью в {0}; {1}!\n", y, x);
            if (Field[y, x] == "O")
            {
                Field[y, x] = "X";
                return true;
            }

            return false;
        }

        public void clear()
        {
            for (int i = 0; i < 10; i++) Console.Clear();
        }
    }
}