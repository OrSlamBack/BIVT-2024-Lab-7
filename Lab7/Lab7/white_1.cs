using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Lab_7
{
    public class White_1
    {
        public class Participant
        {
            // лаба 7 ниже
            private string surname, club;
            private double firstJump, secondJump;
            public string Surname { get { return surname; } }
            public string Club { get { return club; } }
            public double FirstJump { get { return firstJump; } }
            public double SecondJump { get { return secondJump; } }

            public double JumpSum { get { return (FirstJump + SecondJump); } }
            public Participant(string _Surname, string _Club)
            {
                surname = _Surname;
                club = _Club;
                firstJump = 0;
                secondJump = 0;
            }
            public void Jump(double result)
            {
                if (firstJump == 0)
                {
                    firstJump = result;
                }

                else if (secondJump == 0)
                {
                    secondJump = result;
                }
            }
            public void Print()
            {
                if (Surname == null || Club == null)
                {
                    return;
                }
                Console.Write(Surname);
                Console.Write(" ");
                Console.Write(Club);
                Console.Write(" ");
                Console.Write(FirstJump);
                Console.Write(" ");
                Console.WriteLine(SecondJump);
            }

            public static void Sort(Participant[] array)
            {
                if (array == null)
                {
                    return;
                }
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j].JumpSum > array[i].JumpSum)
                        {
                            (array[i], array[j]) = (array[j], array[i]);
                        }
                    }
                }
            }

            private static double standard;
            private static int jumpers;
            private static int disqualified;
            public static int Jumpers => jumpers;
            public static int Disqualified => disqualified;
            static Participant()
            {
                standard = 5.0; // норматив
                jumpers = 0;
                disqualified = 0;
            }
            public static void Disqualify(ref Participant[] participants)
            {
                if(participants == null)
                {
                    return;
                }
                int n = 0;
                for (int i = 0; i < participants.Length; i++) {
                    if (participants[i].firstJump >= standard || participants[i].secondJump >= standard)
                    {
                        n++;
                    }
                }
                Participant[] t = new Participant[n];
                int j = 0;
                for (int i = 0; i < participants.Length; ++i) {
                    if (participants[i].firstJump >= standard || participants[i].secondJump >= standard)
                    {
                        t[j++] = participants[i];
                    }
                    else
                    {
                        disqualified++;
                    }
                }
                participants = t;
                jumpers = participants.Length;
            }
        };

    }
}
