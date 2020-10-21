using System;
using System.Text;

namespace SCVPreview.SCV
{
    public class SCV
    {
        public SCV()
        { }

        public SCV(string line)
        {
            var split = line.Split("|");

            Identifier = split[0];
            Title = split[1];
            Forename = split[2];
            Surname = split[5];
            NationInsuranceNumber = split[9];
            CompanyNumber = split[13];
            Address1 = split[14];
            Address2 = split[15];
            Address3 = split[16];
            Address4 = split[17];
            Address5 = split[18];
            Address6 = split[19];
            PostCode = split[20];
            Country = split[21];
            Email = split[22];
            ProductName = split[33];
            RecentTransactions = split[37].Equals("Yes");
            Currency = split[43];

            if (!string.IsNullOrEmpty(split[12]))
            {
                DateOfBirth = new DateTime(long.Parse(split[12]));
            }

            if (!string.IsNullOrEmpty(split[44]))
            {
                try
                {
                    Balance = decimal.Parse(split[44]);
                }
                catch (FormatException)
                {
                    Balance = 0;
                }
            }
        }

        public string Identifier { get; set; }

        public string Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string NationInsuranceNumber { get; set; }

        public string CompanyNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Address4 { get; set; }

        public string Address5 { get; set; }

        public string Address6 { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string ProductName { get; set; }

        public bool RecentTransactions { get; set; }

        public string AccountTitle { get; set; }

        public string AccountNumber { get; set; }

        public string Currency { get; set; }

        public decimal Balance { get; set; }

        public bool IsCompany()
        {
            return !string.IsNullOrEmpty(CompanyNumber); 
        }

        public string NameFormatted()
        {
            return $"{Title}. {Forename} {Surname}";
        }

        public string Age()
        {
            if (DateOfBirth.HasValue)
            {
                DateTime zeroTime = new DateTime(1, 1, 1);

                var span = DateTime.Now - DateOfBirth.Value;
                var years = (zeroTime + span).Year - 1;

                return years.ToString();
            }

            return string.Empty;
        }

        public string AddressFormatted()
        {
            var sb = new StringBuilder(Address1);

            if (!string.IsNullOrEmpty(Address2))
            {
                sb.Append("<br>");
                sb.Append(Address2);
            }

            if (!string.IsNullOrEmpty(Address3))
            {
                sb.Append("<br>");
                sb.Append(Address3);
            }

            if (!string.IsNullOrEmpty(PostCode))
            {
                sb.Append("<br>");
                sb.Append(PostCode);
            }

            if (!string.IsNullOrEmpty(Country))
            {
                sb.Append("<br>");
                sb.Append(Country);
            }

            return sb.ToString();
        }
    }
}
