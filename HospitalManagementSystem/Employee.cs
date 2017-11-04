using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem
{
    public class EmployeeObj
    {
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

        private string empType;

        public string EmpType
        {
            get { return empType; }
            set { empType = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string fullname;

        public string Fullname
        {
            get { return fullname; }
            set { fullname = FirstName + LastName; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string nic;

        public string NIC
        {
            get { return nic; }
            set { nic = value; }
        }

        private DateTime dob;

        public DateTime DOB
        {
            get { return dob; }
            set { dob = value; }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string contact;

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        private float salary;

        public float Basic_Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        private string slmcNo;

        public string SLMC_No
        {
            get { return slmcNo; }
            set { slmcNo = value; }
        }
    }
}