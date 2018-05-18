namespace MyElectronix.Models
{
    public class SubTest
    {
        public int SubTestId { get; set; }

        public string Name { get; set; }

        public virtual int TestModelId { get; set; }
    }
}