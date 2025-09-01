using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.QuestionFolder
{
    public class MCQ:Question
    {
        public override void AddQuestion( QuestionType questionType)
        {
            
                    AddQuestionsAttributes(questionType);
                    AddQuestionChoices(4);
                    AddQuestionMark();
                    RightAnswerId=getRightAnswerId("Please Enter The Right Answer ID", 4);                              
        }
        
        

        
        
        public void AddQuestionChoices(int numberOfChoices)
        {
            
            Answers = new Answer[numberOfChoices];
            Console.WriteLine("Choices of Question");
            for (int i = 0; i < Answers.Length; i++)
            {
                Answers[i] = new Answer();
                Answers[i].Id =1+ i;
                Answers[i].AnswerText = Helper.ReadValidString($"Please enter choice number {i+1}");               
            }

        }
    }
}
