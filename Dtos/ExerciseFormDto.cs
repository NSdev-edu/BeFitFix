using System.ComponentModel.DataAnnotations;

namespace BeFit.Dtos
{
    public class ExerciseFormDto
    {
        public int Id {get;set;}
        public int Weight {get;set;}
        public int NumOfReps {get;set;}
        public int NumOfSeries {get;set;}

        public int ExerciseTypeId {get;set;}
        public int SessionId {get;set;}
    }
}