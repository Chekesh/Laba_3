using System.Diagnostics;

namespace Laba_3
{
    internal class Program
    {
        struct Student
        {
            public string FIO;
            public string GroupNumber;
            public int[] Grade;
            public Student(string FIO, string GroupNumber, int[] Grade)
            {
                this.FIO = FIO;
                this.GroupNumber = GroupNumber;
                this.Grade = Grade;
            }
        }

        static void Main(string[] args)
        {
            Student student = new Student("Чекушин Н.С.", "21ИТ17", [5, 4, 5, 5, 4]);
            Student[] students = {student,
                                    student with{FIO = "Прянин К.А.",GroupNumber = "21ИТ18", Grade = [4, 4, 3, 5, 4] },
                                    new Student("Танаисов В.С.","22ИТ35", [5, 4, 4, 3, 3]),
                                    new Student("Воздухов К.М.","21ИТ21", [5, 4, 5, 4, 4]),
                                    student with{FIO = "Некрасова М.Н.", Grade = [3, 3, 2, 3, 3]},
                                    student with{FIO = "Отличников С.К.", Grade = [5, 5, 5, 5, 5]} };

            CombSort(students);
            foreach (Student element in students)
            {
                Console.WriteLine(element.FIO);
            }
        }

        static void CombSort(Student[] array)
        {
            double factor = 1.247;
            int step = array.Length;
            while (step > 1)
            {
                step = (int)(step / factor);
                Console.WriteLine(step);
                for (int i = 0; step + i < array.Length; i++)
                {
                    if (average(array[i].Grade) > average(array[i + step].Grade))
                    {
                        swap(array, i, i + step);
                    }
                }
            }
        }
        static void swap(Student[] array, int x, int y)
        {
            Student temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }

        static int average(int[] Grade)
        {
            int sum = 0;
            foreach (int i in Grade)
            {
                sum += i;
            }
            return sum/Grade.Length;
        }
    }
}
