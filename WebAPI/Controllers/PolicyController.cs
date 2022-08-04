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
        /// <summary>
        /// This will allow the API to read all policy related to the particularID
        /// </summary>
        /// <remarks>Returns Status code 404 if there are no policywith the particularID</remarks>
        /// <param name="policyID">Active policyID</param>
        /// <returns>202 and policy</returns>
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
        /// <summary>
        /// This will allow the API to read all policy related to the insurance
        /// </summary>
        /// <remarks>Returns Status code 404 if there are no insurance</remarks>
        /// <param name="insurance">Insurance in question</param>
        /// <returns>202 and insurance</returns>
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
        /// <summary>
        /// This will allow the API to read all coverage
        /// </summary>
        /// <remarks>Returns Status Code 404 if there are no coverage</remarks>
        /// <param name="coverage">The particular coverage</param>
        /// <returns>202 and coverage</returns>
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
        /// <summary>
        /// This will allow the API to read all policy
        /// </summary>
        /// <remarks>Returns Status Code 404 if there is no policy to get</remarks>
        /// <returns>202 and all policy</returns>
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
        /// <summary>
        ///  This will allow the API to read all newly created policy 
        /// </summary>
        /// <param name="policy">new policy</param>
        /// <returns>created policy</returns>
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
        /// <summary>
        /// This will allow the API to update all policies
        /// </summary>
        ///  <remarks>Returns Status code 404 if there are no policy</remarks>
        /// <param name="policy">updated policy</param>
        /// <returns>202 and updated policy</returns>
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
        /// <summary>
        /// This will allow the API to read policy to delete
        /// </summary>
        /// <remarks>Returns Status Code 404 if there are no deleted policy</remarks>
        /// <param name="policyID">Deleted policy in question</param>
        /// <returns>202 and delete policy</returns>
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
