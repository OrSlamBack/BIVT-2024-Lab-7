using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace Lab_7
{
    public class White_4
    {
        public class Human
        {
            private string surname;
            private string name;

            public string Surname => surname;
            public string Name => name;

            public Human(string _Name, string _Surname)
            {
                surname = _Surname;
                name = _Name;
            }

        }
        public class Participant : Human
        {
            private static int count;
            public static int Count => count;
            static Participant()
            {
                count = 0;
            }
            public Participant(string _Name, string _Surname) : base(_Name, _Surname)
            {
                scores = new double[0];
                count++;
            }

            private double[] scores;
            public double[] Scores
            {
                get
                {
                    if (scores == null) return default(double[]);
                    double[] _scores = new double[scores.Length];
                    Array.Copy(scores, _scores, scores.Length);
                    // for (int i = 0; i < _marks.Length; i++) marks[i] = _marks[i];
                    return _scores;
                }
            }
            public double TotalScore
            {
                get
                {
                    if (scores == null)
                    {
                        return 0;
                    }
                    double sum = 0;
                    for (int i = 0; i < scores.Length; i++)
                    {
                        sum += scores[i];
                    }
                    return sum;
                }
            }
            public void PlayMatch(double result)
            {
                if (result == 0 || result == 0.5 || result == 1)
                {
                    if (scores == null)
                    {
                        scores = new double[0];
                    }
                    double[] t = scores;
                    scores = new double[t.Length + 1];
                    for (int i = 0; i < t.Length; i++)
                    {
                        scores[i] = t[i];
                    }
                    scores[t.Length] = result;
                }
            }
            public void Print()
            {
                Console.Write($"{Name} {Surname}");
                Console.WriteLine($" {TotalScore}");
            }
            public static void Sort(Participant[] array)
            {
                if (array == null)
                {
                    return;
                }
                for (int i = 1; i < array.Length; i++)
                {
                    for (int j = i; j - 1 >= 0; j--)
                    {
                        if (array[j].TotalScore > array[j - 1].TotalScore)
                        {
                            (array[j], array[j - 1]) = (array[j - 1], array[j]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

        };
    }
}
