namespace DIME.Model
{
    public class Name
    {
        public string First { get; set; }
        public string Last { get; set; }

        public override string ToString()
        {
            return First + " " + Last;
        }
    }
}
