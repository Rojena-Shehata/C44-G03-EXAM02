using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.QuestionFolder;
namespace ExaminationSystem.Exam
{
    public class PracticalExam : BaseExam
    {
        public PracticalExam()
        {
            Questions = new List<Question>() ;
        }

        public override List<Question> Questions { get ; set ; }

        public override void ShowExam()
        {
           // (int min, int max) ExamType = (1, 2);
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                //int input = Helper.GetvalidInput("Please Enter The Type Of Question (1 for MCQ | 2 for True | false)", ExamType, Helper.IsValidInput);
                Question question=new MCQ();
                question.AddQuestion(QuestionType.MCQ);
                Questions.Add(question);

            }
        }

        public override void ShowExamResult(TimeSpan actualTimeOfExam)
        {

            if (actualTimeOfExam > TimeOfExam)
            {
                Console.WriteLine("Time Ended!!!!!!");
                Console.WriteLine($"You take {actualTimeOfExam}");
                Console.WriteLine($"But exam Time ={actualTimeOfExam}");


            }

            if (Questions is null) return;
            else if (Questions.Count == 0) return;


            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i].Answers == null)
                    continue;
                else if (Questions[i].Answers.Length == 0)
                    continue;

                Console.WriteLine(Questions[i].HeaderOfQuestion);
                Console.WriteLine($"Question {i + 1}:{Questions[i].BodyOfQuestion}");
                if (Questions[i] != null)
                {

                    Console.WriteLine($"Your Answer => {Questions[i].Answers[Questions[i].UserAnswerId - 1]}");
                    Console.WriteLine($"Right Answer => {Questions[i].Answers[Questions[i].RightAnswerId - 1]}");
                }

                Console.WriteLine("============================");

            }
            Console.WriteLine();

            Console.WriteLine($"Time: {actualTimeOfExam.ToString()}");

            Console.WriteLine("\nThank you");
        }
    }
    }

