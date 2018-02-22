using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalTravisReedCSI155
{

    //1.	Add class Person
    public class Person
    {
        private string _phone; //choose the phone to be the primary key
        private string _firstname;
        private string _lastname;
        private DateTime _dateOfBirth;
       

        public Person(string phone, string firstname, string lastname, DateTime dateOfBirth )
        {
            _phone = phone;
            _firstname = firstname;
            _lastname = lastname;
            _dateOfBirth = dateOfBirth;
          
        }

        public string Phone
        { get { return _phone; } }

        public string Firstname
        { get { return _firstname; } }

        public string Lastname
        { get { return _lastname; } }

        public DateTime DateOfBirth
        { get { return _dateOfBirth; } }


        
    }
}
