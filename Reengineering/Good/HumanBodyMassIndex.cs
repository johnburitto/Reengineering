namespace Reengineering.Good
{
    public class HumanBodyMassIndex
    {
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Index => Weight / (Height * Height);

        public string Result()
        {
            if (Index >= 18.5 & Index < 25)
            {
                return "Norm";
            }
            else if (Index >= 25 & Index < 30)
            {
                return "Warning!";
            }
            else if (Index >= 30)
            {
                return "Fat";
            }
            else
            {
                return "Deficit";
            }
        }
    }
}
