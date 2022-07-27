using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PolicyRepo : IPolicy
    {
         private readonly ConnectionFactory _connectionFactory;
    }
     public PolicyRepo(ConnectionFactory factory)
    {
        _connectionFactory = factory;
    }
    public Pokemon GetPolicyByPolicyId(int policyID)
    {
         List<Policy> policy = new();
        using SqlCommand conn = new SqlCommand("Select * From Policy where policyID = @ID", _connectionFactory.GetConnection());
        command.Parameters.AddWithValue("@ID", policyID);
        
        conn.Connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
         if(reader.Read())
        {
            return new Policy{
                Id = (int) reader["policyID"],
                Insurance = (int) reader["policyInsurance"],
                coverage = (Filestream) reader["coverage"],
                userID = (int) reader["userID"]
            };
        }

        return Policy;
    }
}

