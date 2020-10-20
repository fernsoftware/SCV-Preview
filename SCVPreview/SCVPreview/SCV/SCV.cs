using System;

namespace SCVPreview.SCV
{
    public class SCV
    {
        public SCV(string line)
        {
            var split = line.Split("|");

            Identifier = split[0];
            Title = split[1];
            Forename = split[2];
            Surname = split[7];
            NationInsuranceNumber = split[9];
            CompanyNumber = split[13];
            
            if (!string.IsNullOrEmpty(split[12]))
            {
                DateOfBirth = new DateTime(long.Parse(split[12]));
            }
        }

        public string Identifier { get; set; }

        public string Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string NationInsuranceNumber { get; set; }

        public string CompanyNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool IsCompany()
        {
            return !string.IsNullOrEmpty(CompanyNumber); 
        }

        public string NameFormatted()
        {
            return $"{Title} {Forename} {Surname}";
        }

        public string AddressFormatted()
        {
            return "401 Front Street, Toronto";
        }
    }
}
