using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname; 
        private string lastname;
        private string middlename = "";

        public ContactData(string firstname, string lastname) 
        {
            this.firstname = firstname;
            this.lastname = lastname;
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

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
    }
}
