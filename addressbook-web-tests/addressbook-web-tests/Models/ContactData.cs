using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allInOne;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return Lastname + " " + Firstname;
        }

        public int CompareTo(ContactData other) //TODO в этом методе в основном коде интереснее и по-другому
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Lastname != other.Lastname)
            {
                return Lastname.CompareTo(other.Lastname);
            }

            else
            {
                return Firstname.CompareTo(other.Firstname);
            }
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllInOne
        {
            get
            {
                if (allInOne != null)
                {
                    return allInOne;
                }
                else
                {
                    return ((CleanUpName(Firstname) + CleanUpName(Middlename) + CleanUpName(Lastname)).Trim()
                         + "\r\n"
                         + CleanUpProperty(Address)
                         + "\r\n"
                         + CleanAllPhones(HomePhone, MobilePhone, WorkPhone)
                         + CleanUpProperty(Email) + CleanUpProperty(Email2) + CleanUpProperty(Email3)).Trim();
                }
            }
            set
            {
                allInOne = value;
            }
        }

        public string CleanAllPhones(string homePhone, string mobilePhone, string workPhone)
        {
            if ((homePhone == null || homePhone == "") && (mobilePhone == null || workPhone == "") &&
                (workPhone == null || workPhone == ""))
            {
                return "";
            }

            return CleanUpHomePhone(homePhone) + CleanUpMobilePhone(mobilePhone) + CleanUpWorkPhone(workPhone) + "\r\n";
        }

        private string CleanUpName(string property)
        {
            if (property == null || property == "")
            {
                return "";
            }

            return property + " ";
        }

        private string CleanUpProperty(string property)
        {
            if (property == null || property == "")
            {
                return "";
            }

            return property + "\r\n";
        }

        private string CleanUpHomePhone(string homePhone)
        {
            if (homePhone == null || homePhone == "")
            {
                return "";
            }

            return "H: " + homePhone + "\r\n";
        }

        private string CleanUpMobilePhone(string mobilePhone)
        {
            if (mobilePhone == null || mobilePhone == "")
            {
                return "";
            }

            return "M: " + mobilePhone + "\r\n";
        }

        private string CleanUpWorkPhone(string workPhone)
        {
            if (workPhone == null || workPhone == "")
            {
                return "";
            }

            return "W: " + workPhone + "\r\n";
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }

            return Regex.Replace(phone, "[ \\-()]", "") + "\r\n";
        }
    }
}
