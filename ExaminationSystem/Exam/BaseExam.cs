using ExaminationSystem.QuestionFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Exam
{
    public abstract class BaseExam
    {
        public TimeSpan TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public abstract List<Question> Questions {  get; set; }
 

     

        public abstract void ShowExam();
        public void EnterTime()
        {
            (int min,int max) timeValidRange = (30, 180);
            string message = $"Please Enter the Time for Exam from ({timeValidRange.min} min to {timeValidRange.max} min)";
            TimeOfExam =TimeSpan.FromMinutes( Helper.GetvalidInput(message, timeValidRange, Helper.IsValidInput));
        }
        public void EnterNumberOfQuestions()
        {
            NumberOfQuestions = Helper.ReadInt("Please Enter the Number of Questions");
        }

        public void StartExam(out TimeSpan actualTimeOfExam)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(stopwatch);
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"{Questions[i].HeaderOfQuestion}\t {Questions[i].Mark} mark\n");
                Console.WriteLine(Questions[i].BodyOfQuestion);
                for(int j = 0; j < Questions[i].Answers.Length; j++)
                {
                    Console.WriteLine($"{j+1}-{Questions[i].Answers[j]}");
                   
                }
               Questions[i].UserAnswerId= Helper.GetvalidInput("Please Enter The Answer Id", (1,Questions[i].Answers.Length),Helper.IsValidInput);
                //if (Questions[i].UserAnswerId == Questions[i].RightAnswerId)
                //{
                //    Grade += Questions[i].Mark;
                //}
                //TotalGrade += Questions[i].Mark;
                Console.WriteLine("==========================================");
                            
            }
            stopwatch.Stop();
            actualTimeOfExam= stopwatch.Elapsed;
        }

        public abstract void ShowExamResult(TimeSpan actualTimeOfExam);
        


        
        

    }
}
