using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mission_board
{
    public class missionary
    {
        private string display_name;
        private string mission_field;
        private string first_name;
        private string last_name;
        private string letter_alias;
        private string email;
        private string profile_picture;
        private double latitude;
        private double longitude;
        private List<FileInfo> letters;

        public missionary()
        {
            display_name = "";
            mission_field = "";
            first_name = "";
            last_name = "";
            letter_alias = "";
            profile_picture = "";
            email = "";
            latitude = 0;
            longitude = 0;
            letters = new List<FileInfo>();
        }

        public List<FileInfo> Letters
        {
            get { return letters; }
            set { letters = value; }
        }

        public string DisplayName
        {
            get { return display_name; }
            set { display_name = value; }
        }

        public string MissionField
        {
            get { return mission_field; }
            set { mission_field = value; }
        }

        public string FirstName
        {
            get { return first_name; }
            set { first_name = value; }
        }

        public string LastName
        {
            get { return last_name; }
            set { last_name = value; }
        }

        public string LetterAlias
        {
            get { return letter_alias; }
            set { letter_alias = value; }
        }

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public string ProfilePicture
        {
            get { return profile_picture; }
            set { profile_picture = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
