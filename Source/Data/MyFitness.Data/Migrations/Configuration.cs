namespace MyFitness.Data.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<MyFitnessDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MyFitnessDbContext context)
        {
         //  var category = new Category
         //  {
         //      Name = "WeightLoss"
         //  };
         //
         //  context.Categories.Add(category);
         //
         //  context.SaveChanges();
         //
         //  var exercise = new Exercise
         //  {
         //      Category = category,
         //      Description = "Run is very good exercise",
         //      Name = "Run"
         //  };
         //
         //  var exercise2 = new Exercise
         //  {
         //      Category = category,
         //      Description = "Jump to get higher :D",
         //      Name = "Jump"
         //  };
         //
         //  context.Exercises.Add(exercise);
         //  context.Exercises.Add(exercise2);
         //
         //  context.SaveChanges();
         //
         //  var fitnessProgram = new FitnessProgram
         //  {
         //      Name = "Stupid program",
         //      Description = "Really  good program that is very stupid",
         //      SuitableFor = Suitable.Novice,
         //      Category = category
         //  };
         //
         //  fitnessProgram.Exercises.Add(exercise);
         //  fitnessProgram.Exercises.Add(exercise2);
         //
         //  context.FitnessPrograms.Add(fitnessProgram);
         //
         //  context.SaveChanges();
        }
    }
}