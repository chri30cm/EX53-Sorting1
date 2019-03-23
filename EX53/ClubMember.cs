using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX53
{
    public enum Gender { Male, Female };
    public class ClubMember : IComparable<ClubMember>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName} ({Gender}, {Age} years)";
        }

        public int CompareTo(ClubMember c)
        {
            return this.FirstName.CompareTo(c.FirstName);
        }

        public class SortClubMembersAfterLastName : IComparer<ClubMember>
        {
            public int Compare(ClubMember first, ClubMember second)
            {
                return string.Compare(first.LastName, second.LastName);
            }
        }

        public class SortClubMembersAfterGenderAndLastName : IComparer<ClubMember>
        {
            public int Compare(ClubMember first, ClubMember second)
            {
                int result = 0;
                int lastNameCompare = string.Compare(first.LastName, second.LastName);
                if (lastNameCompare == 1 && first.Gender == Gender.Male)
                    result = 1;
                else if (lastNameCompare == 1 && first.Gender == Gender.Female)
                {
                    if (second.Gender == Gender.Male)
                        result = -1;
                }
                else if (lastNameCompare == -1 && first.Gender == Gender.Male)
                {
                    if (second.Gender == Gender.Female)
                        result = 1;
                }
                else if (lastNameCompare == -1 && first.Gender == Gender.Female)
                    result = -1;
                else
                    result = 0;
                return result;
            }
        }
    }
}
