namespace SCVPreview.SCV
{
    public class SCV
    {
        public SCV(string line)
        {
            var split = line.Split("|");

            Identifier = split[0];
        }

        public string Identifier { get; set; }
    }
}
