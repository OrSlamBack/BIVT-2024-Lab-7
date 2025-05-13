using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace Lab_7
{
    public class White_3
    {
        public class Student
        {
            private string surname, name;
            protected private int skipped = 0;
            protected private double[] Marks;
            public string Surname => surname;
            public string Name => name;
            public int Skipped { get { return skipped; } }
            public double AvgMark
            {
                get
                {
                    if (Marks == null)
                    {
                        return 0;
                    }
                    if (Marks.Length == 0)
                    {
                        return 0;
                    }
                    double sum = 0;
                    for (int i = 0; i < Marks.Length; i++)
                    {
                        sum += Marks[i];
                    }
                    return sum / ((double)(Marks.Length));
                }
            }
            public void Lesson(int mark)
            {
                if (Marks == null)
                {
                    Marks = new double[0];
                }

                if (mark == 0)
                {
                    skipped++;
                    return;
                }
                if (mark == 2 || mark == 3 || mark == 4 || mark == 5)
                {
                    double[] t = Marks;
                    Marks = new double[t.Length + 1];
                    for (int i = 0; i < t.Length; i++)
                    {
                        Marks[i] = t[i];
                    }
                    Marks[t.Length] = mark;
                }
            }
            public Student(string _Name, string _Surname)
            {
                surname = _Surname;
                name = _Name;
                skipped = 0;
                Marks = new double[0];
            }

            public virtual void Print()
            {
                if (surname == null || name == null) return;
                Console.Write(Name);
                Console.Write(" ");
                Console.Write(Surname);
                Console.Write(" ");
                Console.Write(AvgMark);
                Console.Write(" ");
                Console.WriteLine(Skipped);
            }
            public static void SortBySkipped(Student[] array)
            {
                if (array == null)
                {
                    return;
                }
                for (int i = 1; i < array.Length; i++)
                {
                    for (int j = i; j - 1 >= 0; j--)
                    {
                        if (array[j].Skipped > array[j - 1].Skipped)
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
            protected Student(Student other)
            {
                surname = other.surname;
                name = other.name;
                skipped = other.skipped;
                if(other.Marks == null)
                {
                    other.Marks = new double[0];
                }
                Marks = (double[])other.Marks.Clone();
            }

        };
        public class Undergraduate : Student
        {
            public Undergraduate(string _Name, string _Surname) : base(_Name, _Surname) { }
            public Undergraduate(Student student) : base(student) { }

            public void WorkOff(int mark)
            {
                if (mark == 2 || mark == 3 || mark == 4 || mark == 5)
                {
                    if (skipped > 0)
                    {
                        skipped--;
                        Lesson(mark);
                    }
                    else
                    {
                        if(Marks == null)
                        {
                            Marks = new double[0];
                        }
                        for (int i = 0; i < Marks.Length; i++)
                        {
                            if (Marks[i] == 2)
                            {
                                Marks[i] = mark;
                                break;
                            }
                        }
                    }
                }
            }
            public override void Print()
            {
                base.Print();
            }
        }
    }

}
