using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using MySql.Data;

namespace WebAPI
{
    public class EmployeePersistence
    {
        private MySql.Data.MySqlClient.MySqlConnection conns;

        public EmployeePersistence()
        {
            string myConnection;
            myConnection = "server=localhost;port=3306;database=db_testing;username=root;password=123aSd!@#;";
            try
            {
                conns = new MySql.Data.MySqlClient.MySqlConnection();
                conns.ConnectionString = myConnection;
                conns.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
        }

        public long saveEmployee(Employee EmployeeToSave)
        {
            string sqlString = "INSERT into employees (DirectManager,CountryID,DepartmentID,empTADAID,GIN,Alias,DisplayName,UserPrincipalName,JobCode,MobilePhone,GOLDMedalOwner,QuestOTC) values(" + EmployeeToSave._DirectManager + "," + EmployeeToSave._CountryID + "," + EmployeeToSave._DepartmentID + "," + EmployeeToSave._empTADAID + ",'" + EmployeeToSave._GIN + "','" + EmployeeToSave._Alias + "','" + EmployeeToSave._DisplayName + "','" + EmployeeToSave._UserPrincipalName + "','" + EmployeeToSave._JobCode + "','" + EmployeeToSave._MobilePhone + "','" + EmployeeToSave._GOLDMedalOwner + "'," + EmployeeToSave._QuestOTC + "); ";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conns);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return id;
        }
    }
}