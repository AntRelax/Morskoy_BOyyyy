using System;
using System.CodeDom;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Dynamic;
using SharedProject1;
using static SharedProject1.Class2;
using static SharedProject1.FIELD;

namespace CSharp_Shell
{
    public static class Program1

    {

        public static void Main()
        {
            if (GetValue2 == 0) Console.WriteLine();
            else goto end;

            string[,] pField = new string [10, 10];
            Console.WriteLine("Тебе придется сыграть в морской бой\n");
            Console.ReadLine();
            Console.Clear();
            FIELD fld = new FIELD();
            fld.Give(ref pField);
            fld.Writeln( pField);
            int one = 4;
            int two = 3;
            int three = 2;
            int four = 1;
            again: ;
            Console.WriteLine("Выбери корабль:");
            Console.WriteLine("1.Однопалубный({0}шт)\n2.Эсминец({1}шт)\n3.Крейсер({2}шт)\n4.Линкор({3}шт)\n", one, two,
                three, four);
            int prd = 0;
            try
            {
                 prd = Convert.ToInt16(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("Введите цифру от 1 до 4!!");
                Console.ReadLine();
                goto again;
            }
            
            if (prd == 666) goto bb;
            if (prd > 4 | prd == 0)
            {
                Console.WriteLine("Неправильно введено число\n");
                Console.ReadLine();
                goto again;
            }

            Console.WriteLine(
                "Введи начальные координаты y(1) и x(2)");
            int y = Convert.ToInt16(Console.ReadLine());
            int x = Convert.ToInt16(Console.ReadLine());
            string z = "Null";
            if (prd > 1)
            {
                Console.WriteLine("Введи направление корабля");
                z = Console.ReadLine();
            }
            
            switch (prd)
            {
                case 1:
                    if (one == 0)
                    {
                        Console.WriteLine("Однопалубные закончились!\n");
                        goto again;
                    }

                    if (!fld.Fill(prd,  y, x, z, ref pField))
                    {
                        goto again;
                    }

                    else
                    {
                        one--;
                        break;
                    }
                    
                case 2:
                    if (two == 0)
                    {
                        Console.WriteLine("Эсминцы закончились\n");
                        goto again;
                    }

                    if (!fld.Fill(prd,  y, x, z, ref pField))
                    {
                        goto again;
                    }

                    else
                    {
                        two--;
                        break;
                    } 
                    
                case 3:
                    if (three == 0)
                    {
                        Console.WriteLine("Крейсеры закончились\n");
                        goto again;
                    }

                    if (!fld.Fill(prd,  y, x, z, ref pField))
                    {
                        goto again;
                    }
                    
                    else 
                    {
                        three--;
                        break;
                    } 

                case 4:
                    if (four == 0)
                    {
                        Console.WriteLine("Линкор уже поставлен!");
                        goto again;
                    }

                    if (!fld.Fill(prd,  y, x, z, ref pField))
                    {
                        goto again;
                    }
                    
                    else 
                    {
                        four--;
                        break;
                    } 

            }
            
            for (int i = 0; i < 10; i++) Console.Clear();
            Console.WriteLine(pField[1,1]);
            Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(pField[i,j]);
                }
                
                Console.WriteLine();
            }
            
            if (one == 0 & two == 0 & three == 0 & four == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Поле успешно заполнено!");
                Console.ReadLine();
            }
            
            else goto again;

            bb: Console.WriteLine("You come to bb!");
            string[,] bField = new string[10, 10];
            fld.Give(ref bField);
            prd = 1;
            one = 4;
            two = 3;
            three = 2;
            four = 1;
            int bz = 0;
            Random rdm = new Random();
            y = 0;
            x = 0;
            bAgain: ;
            fld.Writeln(bField);
            Console.ReadLine();
            bz = rdm.Next(4);
            z = "null";
            z = fld.z_Give(bz, z);
            Console.WriteLine(z);
            y = rdm.Next(10);
            x = rdm.Next(10);
            switch (prd)            
            {
                case 1:
                    Console.WriteLine(1);
                    if (one == 0)
                    {
                        prd = 2;
                        goto bAgain;
                    }
                    
                    if (!fld.Fill(prd, y, x, z, ref bField))
                    {
                        Console.WriteLine("Error!");
                        goto bAgain;
                    }

                    else
                    {
                        one--;
                        break;
                    }
                    
                    case 2:
                        Console.WriteLine(2);
                        if (two == 0)
                        {
                            prd = 3;
                            goto bAgain;
                        }
                        
                        if (!fld.Fill(prd, y, x, z, ref bField))
                        {
                            goto bAgain;
                        }

                        else
                        {
                            two--;
                            break;
                        }
                        
                        case 3:
                            Console.WriteLine(3);
                            if (three == 0)
                            {
                                prd = 4;
                                goto bAgain;
                            }
                            
                            if (!fld.Fill(prd, y, x, z, ref bField))
                            {
                                goto bAgain;
                            }

                            else
                            {
                                three--;
                                break;
                            }
                            
                            case 4:
                                if (four == 0) break;
                                Console.WriteLine(4);
                                if (!fld.Fill(prd, y, x, z, ref bField))
                                {
                                    goto bAgain;
                                }

                                else
                                {
                                    four--;
                                    break;
                                }
            }

            if (one == 0 & two == 0 & three == 0 & four == 0)
            {
                fld.Writeln(bField);
                Console.WriteLine("Противник заполнил поле!\n");
            }
            
            else goto bAgain;

            Console.ReadLine();
            for (int i = 0; i < 10; i++) Console.Clear();
            Console.WriteLine("Ты бьешь первый!");
            
            Shot: ;

            Console.WriteLine("Введи координаты");
            Exception: ;
            try
            {
                y = Convert.ToInt16(Console.ReadLine());
                x = Convert.ToInt16(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("Введите цифру от 0 до 9!!");
                Console.ReadLine();
                goto Exception;
            }
            
            Console.WriteLine();
            if (bField[y, x] == "O")
            {
                if(fld.Unknown(bField, y, x)) Console.WriteLine("Убил!\n");
                else Console.WriteLine("Ранил!\n");
                bField[y, x] = "X";
                Console.ReadLine();
                fld.Writeln(bField);
            }

            else Console.WriteLine("Мимо!\n");
            
            Console.ReadLine();
            if (fld.Field_check(bField))
            {
                Console.WriteLine("Противник побежден!");
                goto end;
            }
            
            Console.WriteLine("Теперь бьет противник!\n");
            if (fld.bField_Shot(ref pField))
            {
                fld.Writeln(pField);
                Console.WriteLine("Противник попал!\n");
            }
            
            else Console.WriteLine("Противник промахнулся!\n");

            if (fld.Field_check(pField))
            {
                Console.WriteLine("Противник уничтожил все твои корабли!\nТы проиграл!");
            }

            Console.WriteLine("Теперь бьешь ты!");
            goto Shot;
            end: ;
        }
    }
}
    
    
