using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KeyBoxEncryption
{
    public static class KeyExpansionHandler
    {
        private static Random r; //this seed
        public static int[,] GetBox1(string password)
        {
            //use seed to create random numbers from the ASCII Values
            //if repeat ASCII Values, do a while to check for duplicate and 
            int passwordCharIndex = 0;
            int passwordInterations = 0;

            List<int> listOfASCII = new List<int>();
            for (int i = 0; i < password.Length; i++)
            {
                listOfASCII.Add(Convert.ToInt32(password[i]));
            }
            int[,] box1Array = new int[15,15];
            
            List<int> firstRow = new List<int>();
            for(int i=0; i<15; i++){
                for (int v = 0; v < 15; v++)
                {
                    int seed = Box1Algorithm(listOfASCII, passwordInterations, passwordCharIndex);
                    
                    r = new Random(seed);
                    box1Array[i,v] = r.Next(0, 999);
                    passwordCharIndex++;
                    if (passwordCharIndex >= listOfASCII.Count)
                    {
                        passwordCharIndex = 0;
                        passwordInterations++;
                    }
                }
            }
            return box1Array;
        }

        public static int[,] GetBox2(string password)
        {
            //use seed to create random numbers from the ASCII Values
            //if repeat ASCII Values, do a while to check for duplicate and 
            int passwordCharIndex = 0;
            int passwordInterations = 0;

            List<int> listOfASCII = new List<int>();
            for (int i = 0; i < password.Length; i++)
            {
                listOfASCII.Add(Convert.ToInt32(password[i]));
            }
            int[,] box2Array = new int[15, 15];

            List<int> firstRow = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                for (int v = 0; v < 15; v++)
                {
                    int seed = Box2Algorithm(listOfASCII, passwordInterations, passwordCharIndex);

                    r = new Random(seed);
                    box2Array[i, v] = r.Next(0, 999);
                    passwordCharIndex++;
                    if (passwordCharIndex >= listOfASCII.Count)
                    {
                        passwordCharIndex = 0;
                        passwordInterations++;
                    }
                }
            }
            return box2Array;
        }

        public static int[,] GetBox3(string password)
        {
            //use seed to create random numbers from the ASCII Values
            //if repeat ASCII Values, do a while to check for duplicate and 
            int passwordCharIndex = 0;
            int passwordInterations = 0;

            List<int> listOfASCII = new List<int>();
            for (int i = 0; i < password.Length; i++)
            {
                listOfASCII.Add(Convert.ToInt32(password[i]));
            }
            int[,] box3Array = new int[15, 15];

            List<int> firstRow = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                for (int v = 0; v < 15; v++)
                {
                    int seed = Box3Algorithm(listOfASCII, passwordInterations, passwordCharIndex);

                    r = new Random(seed);
                    box3Array[i, v] = r.Next(0, 999);
                    passwordCharIndex++;
                    if (passwordCharIndex >= listOfASCII.Count)
                    {
                        passwordCharIndex = 0;
                        passwordInterations++;
                    }
                }
            }
            return box3Array;
        }

        public static int[,] GetBox4(string password)
        {
            //use seed to create random numbers from the ASCII Values
            //if repeat ASCII Values, do a while to check for duplicate and 
            int passwordCharIndex = 0;
            int passwordInterations = 0;

            List<int> listOfASCII = new List<int>();
            for (int i = 0; i < password.Length; i++)
            {
                listOfASCII.Add(Convert.ToInt32(password[i]));
            }
            int[,] box4Array = new int[15, 15];

            List<int> firstRow = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                for (int v = 0; v < 15; v++)
                {
                    int seed = Box4Algorithm(listOfASCII, passwordInterations, passwordCharIndex);

                    r = new Random(seed);
                    box4Array[i, v] = r.Next(0, 999);
                    passwordCharIndex++;
                    if (passwordCharIndex >= listOfASCII.Count)
                    {
                        passwordCharIndex = 0;
                        passwordInterations++;
                    }
                }
            }
            return box4Array;
        }

        public static int[] GetKeyPos(string password)
        {
            int passwordCharIndex = 0;
            int passwordInterations = 0;

            List<int> listOfASCII = new List<int>();
            for (int i = 0; i < password.Length; i++)
            {
                listOfASCII.Add(Convert.ToInt32(password[i]));
            }

            return listOfASCII.ToArray();
        }

        public static int Box1Algorithm(List<int> listOfASCII, int passwordInterations, int passwordCharIndex)
        {
            if (passwordInterations == 0)
                    {
                        return listOfASCII[passwordCharIndex];
                    }
                    else if (passwordInterations == 1)
                    {
                        if (passwordCharIndex < listOfASCII.Count-1)
                        {
                            //one and consecturive
                            return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]; 
                        }
                        else
                        {
                            //first and last
                            return listOfASCII[passwordCharIndex] + listOfASCII[0];
                        }
                    }
                    else if (passwordInterations == 2)
                    {
                        if (passwordCharIndex < listOfASCII.Count - 1)
                        {
                            //one and consecturive
                            return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1];
                        }
                        else
                        {
                            //first and last
                            return listOfASCII[passwordCharIndex] * listOfASCII[0];
                        }
                    }
                    else if(passwordInterations == 3)
                    {
                        if (passwordCharIndex < listOfASCII.Count - 1)
                        {
                            //one and consecturive
                            return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] + listOfASCII[passwordCharIndex];
                        }
                        else
                        {
                            //first and last
                            return listOfASCII[passwordCharIndex] * listOfASCII[0] + listOfASCII[1];
                        }
                    }
                    else if (passwordInterations == 4)
                    {
                        if (passwordCharIndex < listOfASCII.Count - 1)
                        {
                            //one and consecturive
                            return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] * listOfASCII[passwordCharIndex];
                        }
                        else
                        {
                            //first and last
                            return listOfASCII[passwordCharIndex] + listOfASCII[0] * listOfASCII[1];
                        }
                    }
                    else if (passwordInterations == 5)
                    {
                        if (passwordCharIndex < listOfASCII.Count - 1)
                        {
                            //one and consecturive
                            return listOfASCII[passwordCharIndex] *listOfASCII[passwordCharIndex + 1] * listOfASCII[passwordCharIndex] % 999;
                        }
                        else
                        {
                            //first and last
                            return listOfASCII[passwordCharIndex] * listOfASCII[0] * listOfASCII[1] % 999;
                        }
                    }
                    else if (passwordInterations == 6)
                    {
                        if (passwordCharIndex < listOfASCII.Count - 1)
                        {
                            //one and consecturive
                            return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] - listOfASCII[passwordCharIndex] % 1020;
                        }
                        else
                        {
                            //first and last
                            return listOfASCII[passwordCharIndex] * listOfASCII[0] - listOfASCII[1] % 1020;
                        }
                    }
                    else if (passwordInterations == 7)
                    {
                        if (passwordCharIndex < listOfASCII.Count - 1)
                        {
                            //one and consecturive
                            return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] - listOfASCII[passwordCharIndex] % 450;
                        }
                        else
                        {
                            //first and last
                            return listOfASCII[passwordCharIndex] * listOfASCII[0] * listOfASCII[1] % 450;
                        }
                    }
                    else if (passwordInterations == 8)
                    {
                        if (passwordCharIndex < listOfASCII.Count - 1)
                        {
                            //one and consecturive
                            return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] * listOfASCII[passwordCharIndex] % 750;
                        }
                        else
                        {
                            //first and last
                            return listOfASCII[passwordCharIndex] * listOfASCII[0] * listOfASCII[1] % 750;
                        }
                    }
                    else if (passwordInterations == 9)
                    {
                        if (passwordCharIndex < listOfASCII.Count - 1)
                        {
                            //one and consecturive
                            return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] + listOfASCII[passwordCharIndex] % 100;
                        }
                        else
                        {
                            //first and last
                            return listOfASCII[passwordCharIndex] + listOfASCII[0] + listOfASCII[1] % 100;
                        }
                    }
                    else if (passwordInterations == 10)
                    {
                        if (passwordCharIndex < listOfASCII.Count - 1)
                        {
                            //one and consecturive
                            return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] + listOfASCII[passwordCharIndex] % 2000;
                        }
                        else
                        {
                            //first and last
                            return listOfASCII[passwordCharIndex] * listOfASCII[0] + listOfASCII[1] % 2000;
                        }
                    }
            else if (passwordInterations == 11)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex] % 399;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] % 399;
                }
            }
            else if (passwordInterations == 12)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] / 2 % 300;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0] / 2  % 300;
                }
            }
            else if (passwordInterations == 13)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] / 4 % 777;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] / 4 % 777;
                }
            }
            else if (passwordInterations == 14)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] / 5 % 989;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] / 5 % 989;
                }
            }
            else if (passwordInterations == 15)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] * 3 % 454;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * 3 % 454;
                }
            }
            else if (passwordInterations == 16)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]) * 4 % 333;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + listOfASCII[0]) * 4 / 5 % 333;
                }
            }
            else if (passwordInterations == 17)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]) / 4 % 454;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + listOfASCII[0]) / 4 % 454;
                }
            }
            else if (passwordInterations == 18)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]) * 6 % 555;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + listOfASCII[0]) * 6 % 555;
                }
            }
            else if (passwordInterations == 19)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] * (listOfASCII[passwordCharIndex + 1] * 2)) / 2 % 233;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] * (listOfASCII[0] * 2)) / 2 % 233;
                }
            }
            else if (passwordInterations == 20)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + (listOfASCII[passwordCharIndex + 1] * 3)) / 4 % 777;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + (listOfASCII[0] * 3)) / 4 % 777;
                }
            }
            return 0;
        }

        public static int Box2Algorithm(List<int> listOfASCII, int passwordInterations, int passwordCharIndex)
        {
            if (passwordInterations == 0)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1];
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0];
                }
                
            }
            else if (passwordInterations == 1)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] - listOfASCII[passwordCharIndex] % 450;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * listOfASCII[1] % 450;
                }
                
            }
            else if (passwordInterations == 2)
            {
                return listOfASCII[passwordCharIndex];
            }
            else if (passwordInterations == 3)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] + listOfASCII[passwordCharIndex] % 100;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0] + listOfASCII[1] % 100;
                }
                
            }
            else if (passwordInterations == 4)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex] % 399;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] % 399;
                }
                
            }
            else if (passwordInterations == 5)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] * listOfASCII[passwordCharIndex] % 999;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * listOfASCII[1] % 999;
                }
            }
            else if (passwordInterations == 6)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] + listOfASCII[passwordCharIndex] % 2000;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] + listOfASCII[1] % 2000;
                }
                
            }
            else if (passwordInterations == 7)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] / 2 % 300;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0] / 2 % 300;
                }
                
            }
            else if (passwordInterations == 8)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] / 5 % 989;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] / 5 % 989;
                }
                
            }
            else if (passwordInterations == 9)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]) * 4 % 333;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + listOfASCII[0]) * 4 / 5 % 333;
                }
                
            }
            else if (passwordInterations == 10)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] - listOfASCII[passwordCharIndex] % 1020;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] - listOfASCII[1] % 1020;
                }
            }
            else if (passwordInterations == 11)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] * listOfASCII[passwordCharIndex];
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0] * listOfASCII[1];
                }
            }
            else if (passwordInterations == 12)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1];
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0];
                }
            }
            else if (passwordInterations == 13)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] * 3 % 454;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * 3 % 454;
                }
            }
            else if (passwordInterations == 14)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] * listOfASCII[passwordCharIndex] % 750;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * listOfASCII[1] % 750;
                }
            }
            else if (passwordInterations == 15)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] / 4 % 777;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] / 4 % 777;
                }
               
            }
            else if (passwordInterations == 16)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] + listOfASCII[passwordCharIndex];
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] + listOfASCII[1];
                }
            }
            else if (passwordInterations == 17)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] * (listOfASCII[passwordCharIndex + 1] * 2)) / 2 % 233;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] * (listOfASCII[0] * 2)) / 2 % 233;
                }
            }
            else if (passwordInterations == 18)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + (listOfASCII[passwordCharIndex + 1] * 3)) / 4 % 777;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + (listOfASCII[0] * 3)) / 4 % 777;
                }
            }
            else if (passwordInterations == 19)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]) / 4 % 454;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + listOfASCII[0]) / 4 % 454;
                }
                
            }
            else if (passwordInterations == 20)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]) * 6 % 555;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + listOfASCII[0]) * 6 % 555;
                }
                
            }
            return 0;
        }

        public static int Box3Algorithm(List<int> listOfASCII, int passwordInterations, int passwordCharIndex)
        {
            if (passwordInterations == 0)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] * 3 % 454;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * 3 % 454;
                }
                

            }
            else if (passwordInterations == 1)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]) / 4 % 454;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + listOfASCII[0]) / 4 % 454;
                }
                

            }
            else if (passwordInterations == 2)
            {
                return listOfASCII[passwordCharIndex];
            }
            else if (passwordInterations == 3)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] * listOfASCII[passwordCharIndex] % 750;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * listOfASCII[1] % 750;
                }
                

            }
            else if (passwordInterations == 4)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex] % 399;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] % 399;
                }

            }
            else if (passwordInterations == 5)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] * listOfASCII[passwordCharIndex];
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0] * listOfASCII[1];
                }
                
            }
            else if (passwordInterations == 6)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + (listOfASCII[passwordCharIndex + 1] * 3)) / 4 % 777;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + (listOfASCII[0] * 3)) / 4 % 777;
                }               

            }
            else if (passwordInterations == 7)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]) * 4 % 333;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + listOfASCII[0]) * 4 / 5 % 333;
                }
                

            }
            else if (passwordInterations == 8)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] / 5 % 989;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] / 5 % 989;
                }

            }
            else if (passwordInterations == 9)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] / 2 % 300;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0] / 2 % 300;
                }

            }
            else if (passwordInterations == 10)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] - listOfASCII[passwordCharIndex] % 1020;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] - listOfASCII[1] % 1020;
                }
            }
            else if (passwordInterations == 11)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] * (listOfASCII[passwordCharIndex + 1] * 2)) / 2 % 233;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] * (listOfASCII[0] * 2)) / 2 % 233;
                }
                
            }
            else if (passwordInterations == 12)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] + listOfASCII[passwordCharIndex] % 2000;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] + listOfASCII[1] % 2000;
                }
            }
            else if (passwordInterations == 13)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1];
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0];
                }
            }
            else if (passwordInterations == 14)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] + listOfASCII[passwordCharIndex] % 100;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0] + listOfASCII[1] % 100;
                }
            }
            else if (passwordInterations == 15)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] / 4 % 777;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] / 4 % 777;
                }

            }
            else if (passwordInterations == 16)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1];
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0];
                }
                
                
            }
            else if (passwordInterations == 17)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]) * 6 % 555;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + listOfASCII[0]) * 6 % 555;
                }
                
            }
            else if (passwordInterations == 18)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] + listOfASCII[passwordCharIndex];
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] + listOfASCII[1];
                }
            }
            else if (passwordInterations == 19)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] - listOfASCII[passwordCharIndex] % 450;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * listOfASCII[1] % 450;
                }

            }
            else if (passwordInterations == 20)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] * listOfASCII[passwordCharIndex] % 999;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * listOfASCII[1] % 999;
                }

            }
            return 0;
        }

        public static int Box4Algorithm(List<int> listOfASCII, int passwordInterations, int passwordCharIndex)
        {
            if (passwordInterations == 0)
            {

                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]) * 6 % 555;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + listOfASCII[0]) * 6 % 555;
                }

            }
            else if (passwordInterations == 1)
            {

                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] + listOfASCII[passwordCharIndex] % 2000;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] + listOfASCII[1] % 2000;
                }

            }
            else if (passwordInterations == 2)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] + listOfASCII[passwordCharIndex] % 100;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0] + listOfASCII[1] % 100;
                }
            }
            else if (passwordInterations == 3)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] / 4 % 777;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] / 4 % 777;
                }
            }
            else if (passwordInterations == 4)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1];
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0];
                }

            }
            else if (passwordInterations == 5)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] * (listOfASCII[passwordCharIndex + 1] * 2)) / 2 % 233;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] * (listOfASCII[0] * 2)) / 2 % 233;
                }

            }
            else if (passwordInterations == 6)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] / 2 % 300;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0] / 2 % 300;
                }

            }
            else if (passwordInterations == 7)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] * listOfASCII[passwordCharIndex] % 999;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * listOfASCII[1] % 999;
                }
            }
            else if (passwordInterations == 8)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] - listOfASCII[passwordCharIndex] % 450;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * listOfASCII[1] % 450;
                }

            }
            else if (passwordInterations == 9)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1];
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0];
                }

            }
            else if (passwordInterations == 10)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] + listOfASCII[passwordCharIndex];
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] + listOfASCII[1];
                }
            }
            else if (passwordInterations == 11)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1] * listOfASCII[passwordCharIndex];
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] + listOfASCII[0] * listOfASCII[1];
                }
                

            }
            else if (passwordInterations == 12)
            {

                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]) / 4 % 454;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + listOfASCII[0]) / 4 % 454;
                }
                
            }
            else if (passwordInterations == 13)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + (listOfASCII[passwordCharIndex + 1] * 3)) / 4 % 777;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + (listOfASCII[0] * 3)) / 4 % 777;
                }
                
                
            }
            else if (passwordInterations == 14)
            {
                return listOfASCII[passwordCharIndex];
                
            }
            else if (passwordInterations == 15)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] * listOfASCII[passwordCharIndex] % 750;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * listOfASCII[1] % 750;
                }
                

            }
            else if (passwordInterations == 16)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex] % 399;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] % 399;
                }
                


            }
            else if (passwordInterations == 17)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] * 3 % 454;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] * 3 % 454;
                }
                

            }
            else if (passwordInterations == 18)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] - listOfASCII[passwordCharIndex] % 1020;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] - listOfASCII[1] % 1020;
                }
                
            }
            else if (passwordInterations == 19)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return listOfASCII[passwordCharIndex] * listOfASCII[passwordCharIndex + 1] / 5 % 989;
                }
                else
                {
                    //first and last
                    return listOfASCII[passwordCharIndex] * listOfASCII[0] / 5 % 989;
                }
                

            }
            else if (passwordInterations == 20)
            {
                if (passwordCharIndex < listOfASCII.Count - 1)
                {
                    //one and consecturive
                    return (listOfASCII[passwordCharIndex] + listOfASCII[passwordCharIndex + 1]) * 4 % 333;
                }
                else
                {
                    //first and last
                    return (listOfASCII[passwordCharIndex] + listOfASCII[0]) * 4 / 5 % 333;
                }
                

            }
            return 0;
        }

        public static string GetLogTextTesting(string password)
        {
            string debugText = "";
            List<int> listOfASCII = new List<int>();
            byte[] asciiBytes = Encoding.Unicode.GetBytes(password);
            foreach (byte b in asciiBytes)
            {
                listOfASCII.Add(int.Parse(b.ToString("X")));
                debugText += b.ToString("X") + Environment.NewLine;

            }
            return debugText;
        }


        //*Row and Column numbers are flipped as displays on the matrix are flipped
        public static int[,] GetMatrix(int[] keyTable, int noOfIterations, int indexPos, int[,] box1, int[,] box2, int[,] box3, int[,] box4, int totalConversion)
        {
            int[,] firstMatrix = new int[2, 2];
            int rowNum = 0;
            int columnNum = 0;
            int boxNumber = 0;

            if (noOfIterations == 1 || noOfIterations == 5)
            {
                
                if (indexPos < keyTable.Length - 1)
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    rowNum = (int)rowNumL % 14;
                    long colNumL = maxfactor(Convert.ToInt64(keyTable[indexPos+1]));
                    columnNum = (int)colNumL % 14;
                    boxNumber = ((rowNum + columnNum) * noOfIterations) % 4;
                }
                else
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    rowNum = (int)rowNumL % 14;
                    long colNumL = maxfactor(Convert.ToInt64(keyTable[0]));
                    columnNum = (int)colNumL % 14;
                    boxNumber = ((rowNum + columnNum) * noOfIterations) % 4;
                }
            }
            else if (noOfIterations == 2 || noOfIterations == 6)
            {
                if (indexPos < keyTable.Length - 1)
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    int firstNum = (int)rowNumL;
                    
                    long colNumL = maxfactor(Convert.ToInt64(keyTable[indexPos + 1]));
                    int secondNum = (int)colNumL;

                    rowNum = (firstNum + secondNum * (noOfIterations == 6 ? 4 : 1)) % 14;
                    columnNum = Math.Abs(firstNum - secondNum) % 14;
                    boxNumber = ((rowNum + columnNum) * 5) % 4;
                }
                else
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    int firstNum = (int)rowNumL;

                    long colNumL = maxfactor(Convert.ToInt64(keyTable[0]));
                    int secondNum = (int)colNumL;

                    rowNum = (firstNum + secondNum * (noOfIterations == 6 ? 4 : 1)) % 14;
                    columnNum = Math.Abs(firstNum - secondNum) % 14;
                    boxNumber = ((rowNum + columnNum) * 5) % 4;
                }
            }
            else if (noOfIterations == 3 || noOfIterations == 7)
            {
                if (indexPos < keyTable.Length - 1)
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    int firstNum = (int)rowNumL;

                    long colNumL = maxfactor(Convert.ToInt64(keyTable[indexPos + 1]));
                    int secondNum = (int)colNumL;

                    rowNum = (firstNum * secondNum + (noOfIterations == 7 ? 6 : 0)) % 14;
                    columnNum = ((firstNum + secondNum) * firstNum) % 14;
                    boxNumber = ((rowNum + columnNum) * noOfIterations) % 4;
                }
                else
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    int firstNum = (int)rowNumL;

                    long colNumL = maxfactor(Convert.ToInt64(keyTable[0]));
                    int secondNum = (int)colNumL;

                    rowNum = (firstNum * secondNum + (noOfIterations == 7 ? 6 : 0)) % 14;
                    columnNum = ((firstNum + secondNum) * firstNum) % 14;
                    boxNumber = ((rowNum + columnNum) * noOfIterations) % 4;
                }
            }
            else if (noOfIterations == 4 || noOfIterations == 8)
            {
                if (indexPos < keyTable.Length - 1)
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    int firstNum = (int)rowNumL;

                    long colNumL = maxfactor(Convert.ToInt64(keyTable[indexPos + 1]));
                    int secondNum = (int)colNumL;

                    rowNum = (firstNum * (noOfIterations * (noOfIterations-1))) % 14;
                    columnNum = (secondNum * (noOfIterations * (noOfIterations-1))) % 14;
                    boxNumber = ((rowNum + columnNum) * totalConversion) % 4;
                }
                else
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    int firstNum = (int)rowNumL;

                    long colNumL = maxfactor(Convert.ToInt64(keyTable[0])); 
                    int secondNum = (int)colNumL;

                    rowNum = (firstNum * secondNum) % 14;
                    columnNum = ((firstNum + secondNum) * firstNum) % 14;
                    boxNumber = ((rowNum + columnNum) * totalConversion) % 4;
                }
            }
            else if (noOfIterations > 8)
            {
                rowNum = totalConversion * noOfIterations * (noOfIterations % 2 == 0 ? 6 : 2) % 14;
                columnNum = totalConversion / noOfIterations * (noOfIterations % 2 == 0 ? 5 : 1) % 14;
                boxNumber = ((rowNum + columnNum) * totalConversion) % 4;
            }
            else
            {
                rowNum = totalConversion % 13;
                columnNum = totalConversion % 13;
                boxNumber = ((rowNum + columnNum) * totalConversion) % 4;
            }

            
            switch (boxNumber)
            {
                case 0:
                    
                    firstMatrix[0, 0] = box1[columnNum, rowNum];
                    firstMatrix[1, 0] = box1[columnNum + 1, rowNum];
                    firstMatrix[0, 1] = box1[columnNum, rowNum + 1];
                    firstMatrix[1, 1] = box1[columnNum + 1, rowNum + 1];
                    break;

                case 1:
                    firstMatrix[0, 0] = box2[columnNum, rowNum];
                    firstMatrix[1, 0] = box2[columnNum + 1, rowNum];
                    firstMatrix[0, 1] = box2[columnNum, rowNum + 1];
                    firstMatrix[1, 1] = box2[columnNum + 1, rowNum + 1];
                    break;

                case 2:
                    firstMatrix[0, 0] = box3[columnNum, rowNum];
                    firstMatrix[1, 0] = box3[columnNum + 1, rowNum];
                    firstMatrix[0, 1] = box3[columnNum, rowNum + 1];
                    firstMatrix[1, 1] = box3[columnNum + 1, rowNum + 1];
                    break;

                case 3:
                    firstMatrix[0, 0] = box4[columnNum, rowNum];
                    firstMatrix[1, 0] = box4[columnNum + 1, rowNum];
                    firstMatrix[0, 1] = box4[columnNum, rowNum + 1];
                    firstMatrix[1, 1] = box4[columnNum + 1, rowNum + 1];
                    break;
            }
            return firstMatrix;
        }

        //*Row and Column numbers are flipped as displays on the matrix are flipped
        public static string GetMatrixData(int[] keyTable, int noOfIterations, int indexPos, int[,] box1, int[,] box2, int[,] box3, int[,] box4, int totalConversion)
        {
            string mData = "";
            int rowNum = 0;
            int columnNum = 0;
            int boxNumber = 0;

            if (noOfIterations == 1 || noOfIterations == 5)
            {

                if (indexPos < keyTable.Length - 1)
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    rowNum = (int)rowNumL % 14;
                    long colNumL = maxfactor(Convert.ToInt64(keyTable[indexPos + 1]));
                    columnNum = (int)colNumL % 14;
                    boxNumber = ((rowNum + columnNum) * noOfIterations) % 4;
                    mData += "Factors: " + rowNumL.ToString() + " x " + colNumL.ToString() + Environment.NewLine +
                             "Algorithm: (HPF 1 % 14 + HPF 2 % 14" + Environment.NewLine;
                }
                else
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    rowNum = (int)rowNumL % 14;
                    long colNumL = maxfactor(Convert.ToInt64(keyTable[0]));
                    columnNum = (int)colNumL % 14;
                    boxNumber = ((rowNum + columnNum) * noOfIterations) % 4;
                    mData += "Factors: " + rowNumL.ToString() + " x " + colNumL.ToString() + Environment.NewLine +
                             "Algorithm: (HPF 1 % 14 + HPF 2 % 14" + Environment.NewLine;
                }
            }
            else if (noOfIterations == 2 || noOfIterations == 6)
            {
                if (indexPos < keyTable.Length - 1)
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    int firstNum = (int)rowNumL;

                    long colNumL = maxfactor(Convert.ToInt64(keyTable[indexPos + 1]));
                    int secondNum = (int)colNumL;

                    rowNum = (firstNum + secondNum * (noOfIterations == 6 ? 4 : 1)) % 14;
                    columnNum = Math.Abs(firstNum - secondNum) % 14;
                    boxNumber = ((rowNum + columnNum) * noOfIterations) % 4;


                    mData += "Factors: " + rowNumL.ToString() + " x " + colNumL.ToString() + Environment.NewLine +
                             "Algorithm: (HPF 1 % 14 + HPF 2 % 14 * 4 % 14" + Environment.NewLine;

                }
                else
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    int firstNum = (int)rowNumL;

                    long colNumL = maxfactor(Convert.ToInt64(keyTable[0]));
                    int secondNum = (int)colNumL;

                    rowNum = (firstNum + secondNum * (noOfIterations == 6 ? 4 : 1)) % 14;
                    columnNum = Math.Abs(firstNum - secondNum) % 14;
                    boxNumber = ((rowNum + columnNum) * noOfIterations) % 4;
                    mData += "Factors: " + rowNumL.ToString() + " x " + colNumL.ToString() + Environment.NewLine +
                             "Algorithm: (HPF 1 % 14 + HPF 2 % 14 * 4 % 14" + Environment.NewLine;
                }
            }
            else if (noOfIterations == 3 || noOfIterations == 7)
            {
                if (indexPos < keyTable.Length - 1)
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    int firstNum = (int)rowNumL;

                    long colNumL = maxfactor(Convert.ToInt64(keyTable[indexPos + 1]));
                    int secondNum = (int)colNumL;

                    rowNum = (firstNum * secondNum + (noOfIterations == 7 ? 6 : 0)) % 14;
                    columnNum = ((firstNum + secondNum) * firstNum) % 14;
                    boxNumber = ((rowNum + columnNum) * noOfIterations) % 4;

                    mData += "Factors: " + rowNumL.ToString() + " x " + colNumL.ToString() + Environment.NewLine +
                             "Algorithm: (HPF 1 % 14 * HPF 2 % 14 + 7 % 14" + Environment.NewLine;
                }
                else
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    int firstNum = (int)rowNumL;

                    long colNumL = maxfactor(Convert.ToInt64(keyTable[0]));
                    int secondNum = (int)colNumL;

                    rowNum = (firstNum * secondNum + (noOfIterations == 7 ? 6 : 0)) % 14;
                    columnNum = ((firstNum + secondNum) * firstNum) % 14;
                    boxNumber = ((rowNum + columnNum) * noOfIterations) % 4;

                    mData += "Factors: " + rowNumL.ToString() + " x " + colNumL.ToString() + Environment.NewLine +
                             "Algorithm: (HPF 1 % 14 * HPF 2 % 14 + 7 % 14" + Environment.NewLine;
                }
            }
            else if (noOfIterations == 4 || noOfIterations == 8)
            {
                if (indexPos < keyTable.Length - 1)
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    int firstNum = (int)rowNumL;

                    long colNumL = maxfactor(Convert.ToInt64(keyTable[indexPos + 1]));
                    int secondNum = (int)colNumL;

                    rowNum = (firstNum * (noOfIterations * (noOfIterations - 1 + (noOfIterations == 8 ? 12 : 2)))) % 14;
                    columnNum = (secondNum * (noOfIterations * (noOfIterations - 1))) % 14;
                    boxNumber = ((rowNum + columnNum) * noOfIterations) % 4;

                    mData += "Factors: " + rowNumL.ToString() + " x " + colNumL.ToString() + Environment.NewLine +
                             "Algorithm: (HPF 1 * n * n -1 % 14" + Environment.NewLine;
                }
                else
                {
                    long rowNumL = maxfactor(Convert.ToInt64(keyTable[indexPos]));
                    int firstNum = (int)rowNumL;

                    long colNumL = maxfactor(Convert.ToInt64(keyTable[0]));
                    int secondNum = (int)colNumL;

                    rowNum = (firstNum * secondNum * (noOfIterations == 8 ? 12 : 2)) % 14;
                    columnNum = ((firstNum + secondNum) * firstNum) % 14;
                    boxNumber = ((rowNum + columnNum) * totalConversion) % 4;
                    mData += "Factors: " + rowNumL.ToString() + " x " + colNumL.ToString() + Environment.NewLine +
                             "Algorithm: (HPF 1 * n * n -1 % 14" + Environment.NewLine;
                }
            }
            else if (noOfIterations > 8)
            {
                rowNum = totalConversion * noOfIterations % 14;
                columnNum = totalConversion / noOfIterations % 14;
                boxNumber = ((rowNum + columnNum) * noOfIterations) % 4;
                mData += "Factors: None x None" + Environment.NewLine +
                             "Algorithm: (Total Conversion % 14" + Environment.NewLine;
            }

            mData += "RowNumber: " + rowNum + " | ColumnNumber: " + columnNum + " | BoxNumber: " + boxNumber + Environment.NewLine;

            return mData;
        }

        #region MathFunctions
        private static long maxfactor(long n)
        {
            long k = 2;
            while (k * k <= n)
            {
                if (n % k == 0)
                {
                    n /= k;
                }
                else
                {
                    ++k;
                }
            }

            return n;

        }

        private static bool primo(long x)
        {
            bool sp = true;
            for (long i = 2; i <= x / 2; i++)
            {
                if (x % i == 0)
                    sp = false;
            }
            return sp;
        }
        #endregion
    }

   
}
