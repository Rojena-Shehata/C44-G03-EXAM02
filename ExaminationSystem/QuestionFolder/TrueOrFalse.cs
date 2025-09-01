using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.QuestionFolder
{
    public class TrueOrFalse : Question
    {
        public TrueOrFalse()
        {
            
        }
        
        public override void AddQuestion(QuestionType questionType)
        {
            Answers = new Answer[2]
            {
                new Answer (1,"True"),
                new Answer (2,"False")

            };

            AddQuestionsAttributes(questionType);
            AddQuestionMark();
            RightAnswerId = getRightAnswerId("Please Enter The Right Answer ID (1 for True | 2 for False)",Answers.Length);
            


        }
    }
}
