using System.Text;

namespace Module_15._6_FinalTask_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var classes = new[]
            {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
            };
            var allStudents = GetAllStudents(classes);

            Console.WriteLine(string.Join(" ", allStudents));
        }
        //Напишите метод, который соберет всех учеников всех классов в один список, используя LINQ.
        //Видимо можно както полегче это все сделать?
        static string[] GetAllStudents(Classroom[] classes)
        {
            StringBuilder sb = new StringBuilder();
        
            var names = from s in classes select s.Students;
            foreach(var name in names)
            {
                sb.Append(string.Join(" ", name.ToArray()));
                sb.Append(" ");
            }

            return sb.ToString().Split(Environment.NewLine.ToCharArray());

            /* 2nd Method
            var studentByClassroom = from stud in classes
                                group stud by stud.Students;

            foreach (var grouping in studentByClassroom)
            {
                // внутри каждой группы пробежимся по элементам
                foreach (var stud in grouping)
                {
                    sb.Append(string.Join(" ", stud.Students.ToArray()));
                }
                sb.Append(" ");
            }
            return sb.ToString().Split(Environment.NewLine.ToCharArray());
            */          
        }
        /*static string[] GetAllStudents(Classroom[] classes)
        {
            var oldStud = from student in classes // Пробегаюсь по классам со студентами
                          from stud in student.Students // Добавляю студентов из всех классов
                          select stud; // Включаю результат в выборку

            return oldStud.ToArray(); // Возыращаю новый список студентов
        }*/        

        public class Classroom
        {
            public List<string> Students = new List<string>();
        }
    }
}
