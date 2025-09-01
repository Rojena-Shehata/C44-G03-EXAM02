using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.QuestionFolder
{
    public class Answer
    {
        public Answer()
        {
        }

        public Answer(int id, string? answerText)
        {
            Id = id;
            AnswerText = answerText;
        }

        public  int Id { get; set; }
       public string? AnswerText {  get; set; }

        

        

        public override string ToString()
        {
            return $"{AnswerText}";
        }
        
       
        
    }
}
