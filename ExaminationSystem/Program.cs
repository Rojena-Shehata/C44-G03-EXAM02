using System.Diagnostics;

namespace ExaminationSystem
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //Console.WriteLine(stopwatch.);
            Subject sub=new Subject();
            sub.CreateExam();
            sub.StartSubjectExam();
            
        }
    }
    
}
