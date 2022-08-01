using Services;
using NewModels;
using DataAccess;
using CustomExceptions;

namespace WebAPI.Controllers;


    public class PolicyController
    {
        private readonly PolicyService _Services;
        public PolicyController(PolicyService services)
        {
            _Services = services;
        }
        
        public IResult GetPolicyByID(int policyID)
        {
            try
            {
                List<Policy> policy = _Services.GetPolicyByID(policyID);
                return Results.Accepted("/policy/ID/{ID}", policy);
            }
            catch (InputInvalidException)
            {
                return Results.BadRequest("That policy hasn't been made yet");
            }
        }
        
        public IResult GetPolicyByInsurance(int insurance)
        {
            try
            {
                List<Policy> policy = _Services.GetPolicyByInsurance(insurance);
                return Results.Accepted("/policy/insurance/{insurance}", policy);
            }
            catch (InputInvalidException)
            {
                return Results.BadRequest("That user hasn't made any policies.");
            }
        }
        public IResult GetPolicyBycoverage(string coverage)
        {
            try
            {
                List<Policy> policy = _Services.GetPolicyBycoverage(coverage);
                return Results.Accepted("/policy/coverage/{coverage}", policy);
            }
            catch (InputInvalidException)
            {
                return Results.BadRequest("That user hasn't made any policies.");
            }
        }
        
        public IResult GetAllPolicy()
        {
            try
            {
                List<Policy> all = _Services.GetAllPolicy();
                return Results.Accepted("/policy", all);
            }
            catch (InputInvalidException )
            {
                return Results.BadRequest("There are no policies");
            }
            
        }
         public IResult CreatePolicy(Policy policy)
        {
            try
            {
                return Results.Accepted("/submit/policy", _Services.CreatePolicy(policy));
            }
            catch (NotImplementedException)
            {
                return Results.BadRequest();
            }
        }
         public IResult UpdatePolicy(Policy policy)
        {
            try
            {
                return Results.Accepted("/update/policy", _Services.UpdatePolicy(policy));
            }
            catch (NotImplementedException)
            {
                return Results.BadRequest();
            }
        }
         public IResult DeletePolicy(int policyID)
        {
            try
            {
                return Results.Accepted("/delete/policy", _Services.DeletePolicy(policyID));
            }
            catch (NotImplementedException)
            {
                return Results.BadRequest();
            }
        }
    }
