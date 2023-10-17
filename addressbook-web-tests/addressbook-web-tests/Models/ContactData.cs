using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
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
    }
}
