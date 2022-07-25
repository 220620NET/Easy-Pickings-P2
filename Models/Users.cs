namespace Models;

public enum Role
{
    Patient, Employee, Doctor
}
public class Users
{
    public int userID { get; set; }
    public string firstName { get; set; }
    public char middleInit { get; set; }
    public string lastName { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public DateOnly DoB { get; set; }
    public int contactFk { get; set; }
    public Role role { get; set; }

    // This is for reading from a Json
    public Users()
    {
        userID = 0;
        firstName = "";
        middleInit = 'a';
        lastName = "";
        username = "";
        password = "";
        role = Role.Patient;
        DoB= new DateOnly();
        contactFk = 0;
    }

    // Login Information
    public Users(string username,string password):this()
    {
        this.username = username;
        this.password = password;
    }
    // Registering new user
    public Users(string firstName, char middleInit, string lastName, string username,string password, DateOnly DoB, int contactFk,int role):this()
    {
        this.firstName = firstName;
        this.middleInit = middleInit;
        this.lastName = lastName;
        this.username=username;
        this.password = password;
        this.DoB = DoB;
        this.contactFk = contactFk;
        this.role = (Role)role;
    }

    
}
