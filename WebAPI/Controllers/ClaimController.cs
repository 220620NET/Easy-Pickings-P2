using Services;
using NewModels;
namespace WebAPI.Controllers;

public class ClaimController
{
    private readonly ClaimService _service;
    /// <summary>
    /// This connects to the database
    /// </summary>
    /// <param name="service"></param>
    public ClaimController(ClaimService service)
    {
    _service = service;
    }
    /// <summary>
    /// Get all Claims
    /// </summary>
    /// <returns>List of claims</returns>
    public IResult GetAllClaims()
    { 
        try
        {
            return Results.Accepted("/claims", _service.GetAllClaims());
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }
    /// <summary>
    /// Create a claim
    /// </summary>
    /// <param name="claim"></param>
    /// <returns>200 success</returns>
    public IResult CreateClaims(Claim claim)
    {
        try
        {
            return Results.Accepted("/submit/claim", _service.CreateClaims(claim));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }
    /// <summary>
    /// Update a claim
    /// </summary>
    /// <param name="claim"></param>
    /// <returns>202 with an updated claim</returns>
    public IResult UpdateClaims(Claim claim)
    { 
        try
        {
            return Results.Accepted("/update/claim", _service.UpdateClaims(claim));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }
    /// <summary>
    /// Delete a claim
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>202 with a boolean verfication</returns>
    public IResult DeleteClaims(int ID)
    {
        try
        {
            return Results.Accepted("/delete/claim", _service.DeleteClaims(ID));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }
    /// <summary>
    /// Get the claim by Id
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>202 with claim id </returns>
    public IResult GetClaimById(int ID)
    { 
        try
        {
            return Results.Accepted("/claim{ID}", _service.GetClaimById(ID));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }
    /// <summary>
    /// get a user by ID
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Returns 202 with a list of user claims with given ID</returns>
    public IResult GetUserByPatientId(int ID)
    { 
        try
        {
            return Results.Accepted("/claim/patient{ID}", _service.GetClaimByPatientID(ID));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }
    /// <summary>
    ///  Get claims by status
    /// </summary>
    /// <param name="status"></param>
    /// <returns>200 claim by status</returns>
    public IResult GetClaimByStatus(string status)
    { 
        try
        {
            return Results.Accepted("/claim/status{status}", _service.GetClaimByStatus(status));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }

}

   

