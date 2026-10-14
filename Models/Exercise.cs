using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BeFit.Models
{
    public class Exercise
    {
        public int Id {get;set;}
        public int Weight {get;set;}
        public int NumOfReps {get;set;}
        public int NumOfSeries {get;set;}
        public int ExerciseTypeId {get;set;}
        public ExerciseType? ExerciseType {get;set;}
        public int SessionId {get;set;}
        public Session? Session {get;set;}

        public string CreatedById {get;set;}
        public IdentityUser? CreatedBy {get;set;}
    }
}