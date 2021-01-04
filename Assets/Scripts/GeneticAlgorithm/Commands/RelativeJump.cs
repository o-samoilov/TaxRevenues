namespace GeneticAlgorithm.Commands
{
    public class RelativeJump : AbstractCommand
    {
        public override string GetName()
        {
            return "relative_jump";
        }

        public override int GetMinCoefficient()
        {
            return 1;
        }

        public override int GetMaxCoefficient()
        {
            return GenFactory.BasicSize - 1;
        }
        
        public override bool IsFinished()
        {
            return false;
        }

        public override int Process(Manufacture manufacture, GenElement genElement)
        {
            return genElement.Coefficient;
        }
    }
}