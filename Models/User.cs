using System.ComponentModel.DataAnnotations;
namespace Models;

public enum Role
{
    Patient, Employee, Doctor
}
public class User
{
    [Key]
    public int userID { get; set; }
    public string firstName { get; set; }
    public char middleInit { get; set; }
    public string lastName { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public DateOnly DoB { get; set; }
    public int contactID { get; set; }
    public Role role { get; set; }

    // This is for reading from a Json
    public User()
    {
        userID = 0;
        firstName = "";
        middleInit = 'a';
        lastName = "";
        username = "";
        password = "";
        role = Role.Patient;
        DoB= new DateOnly();
        contactID = 0;
    }

    // Login Information
    public User(string username,string password):this()
    {
        this.username = username;
        this.password = password;
    }
    // Registering new user
    public User(string firstName, char middleInit, string lastName, string username,string password, DateOnly DoB, int contactFk,int role):this()
    {
        this.firstName = firstName;
        this.middleInit = middleInit;
        this.lastName = lastName;
        this.username=username;
        this.password = password;
        this.DoB = DoB;
        this.contactID = contactFk;
        this.role = (Role)role;
    }

    
}
