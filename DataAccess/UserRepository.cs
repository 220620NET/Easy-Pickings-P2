using Models;
using CustomExceptions;
using Microsoft.Data.SqlClient;

namespace DataAccess;
public class UserRepository : IUserRepository
{
    private readonly ConnectionFactory _connectionFactory;

    public UserRepository(ConnectionFactory factory)
    {
        _connectionFactory = factory;
    }
    public List<Users> GetAllUsers()
    {
        List<Users> users = new List<Users>();
        SqlConnection conn = _connectionFactory.GetConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from p2.users", conn);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            users.Add(new Users((string)reader[1], (char)reader[2], (String)reader[3], (string)reader[4], (string)reader[5], (DateOnly)reader[6], (int)reader[7], (int)reader[8]));
        }
        reader.Close();
        conn.Close();
        return users;
    }
    public Users GetUserById(int userID);
    public Users GetUserByName(string userName);
    public Users GetUserByEmail(string email);
    public Users CreateUser(Users user);
    public void ResetPassword(Users user);
}
