using Services;
using NewModels;
using DataAccess;
using WebAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InsuranceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("P2DB")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowAllHeadersPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200/", "https://yellow-tree-02390bb10.1.azurestaticapps.net/")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
/*
 *      DataAccess Layer scoping
*/
builder.Services.AddScoped<ITicket, TicketRepo>();
builder.Services.AddScoped<IPolicy, PolicyRepo>();
builder.Services.AddScoped<IClaimRepo, ClaimsRepo>();
builder.Services.AddScoped<IContactRepo, ContactRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();
builder.Services.AddScoped<IDiscussionRepo, DiscussionRepo>();

/*
 *      Service Layer Scoping    
*/
builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<TicketService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<ClaimService>();
builder.Services.AddTransient<ContactService>();
builder.Services.AddTransient<PolicyService>();
builder.Services.AddTransient<CommentService>();
builder.Services.AddScoped<DiscussionService>();
/*
 *      Controler Layer Scoping
*/
builder.Services.AddScoped<AuthController>();
builder.Services.AddScoped<TicketController>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<PolicyController>();
builder.Services.AddScoped<ClaimController>();
builder.Services.AddScoped<ContactController>();
builder.Services.AddScoped<CommentController>();
builder.Services.AddScoped<DiscussionController>();

/*
 *      Setting up web app
 */
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("MyAllowAllHeadersPolicy");
app.MapGet("/", () => "Hello World!");

/*
 *      AuthController End Points
*/
app.MapPost("/login", (User user, AuthController controller) => controller.Login(user));
app.MapPost("/register", (User newUser, AuthController controller) => controller.Register(newUser));
app.MapPut("/reset", (User update, AuthController controller) => controller.ResetPassword(update));

/*
 *      UserController End Points
*/
app.MapDelete("/delete/user", (int userID, UserController controller) => controller.DeleteUser(userID));
app.MapGet("/user", (UserController controller) => controller.GetAllUsers());
app.MapGet("/user/ID/{userID}", (int userID, UserController controller) => controller.GetUserById(userID));
app.MapGet("/user/username/{username}", (string username, UserController controller) => controller.GetUserByName(username));


/*
 *      TicketController End Points
 */
app.MapPost("/submit/ticket", (Ticket newTicket, TicketController controller) => controller.CreateTicket(newTicket));
app.MapPut("/update/ticket", (Ticket ticket, TicketController controller) => controller.UpdateTicket(ticket));
app.MapDelete("/delete/ticket", (int ID, TicketController controller) => controller.DeleteTicket(ID));
app.MapGet("/ticket", (TicketController controller) => controller.GetAllTickets());
app.MapGet("/ticket/id/{ticketID}", (int ticketID,TicketController controller) => controller.GetTicketByID(ticketID));
app.MapGet("/ticket/claim/{ID}", (int ID, TicketController controller) => controller.GetTicketByClaim(ID));
app.MapGet("/ticket/patient/{ID}", (int ID, TicketController controller) => controller.GetTicketByPatient(ID));
app.MapGet("/ticket/policy/{ID}", (int ID, TicketController controller) => controller.GetTicketByPolicy(ID));

/*
 *      PolicyController End Points
 */
app.MapPost("/submit/policy", (Policy newPolicy, PolicyController controller) => controller.CreatePolicy(newPolicy));
app.MapPut("/update/policy", (Policy policy, PolicyController controller) => controller.UpdatePolicy(policy));
app.MapDelete("/delete/policy", (int ID, PolicyController controller) => controller.DeletePolicy(ID));
app.MapGet("/policy", (PolicyController controller) =>controller.GetAllPolicy());
app.MapGet("/policy/ID/{ID}", (int policyID, PolicyController controller) => controller.GetPolicyByID(policyID));
app.MapGet("/policy/insurance/{insurance}", (int insurance, PolicyController controller) => controller.GetPolicyByInsurance(insurance));
app.MapGet("/policy/coverage/{coverage}", (string coverage, PolicyController controller) => controller.GetPolicyBycoverage(coverage));

/*
 *      ClaimsController End Points
 */
app.MapPost("/submit/Claim",(Claim newClaim, ClaimController controller) => controller.CreateClaims(newClaim));
app.MapPut("/update/claim",(Claim claim, ClaimController controller) => controller.UpdateClaims(claim));
app.MapDelete("/delete/claim", (int ID, ClaimController controller) => controller.DeleteClaims(ID));
app.MapGet("/claims", (ClaimController controller) => controller.GetAllClaims());
app.MapGet("/claim{ID}",(int Id, ClaimController controller ) => controller.GetClaimById(Id));
app.MapGet("/claim/patient{ID}",(int Id, ClaimController controller) => controller.GetUserByPatientId(Id));
app.MapGet("/claim/status{status}", (string status, ClaimController controller) => controller.GetClaimByStatus(status));
/*
 *      ContactController End Points
 */
app.MapPost("/submit/contact", (Contact newContact, ContactController controller) => controller.CreateContactInfo(newContact));
app.MapPut("/update/contact", (Contact contact, ContactController controller) => controller.UpdateContactInfo(contact));
app.MapDelete("/delete/contact", (int contactID, ContactController controller) => controller.DeleteContactInfo(contactID));
app.MapGet("/contactinfo", (ContactController controller) =>controller.GetAllContactInfo());
app.MapGet("/contact/ID/{contactID}", (int contactID, ContactController controller) => controller.GetContactInfoById(contactID));
app.MapGet("/contact/user/{userID}", (int userID, ContactController controller) => controller.GetContactInfoByUserId(userID));

app.MapGet("/contact/email/{email}", (string email, ContactController controller) => controller.GetContactInfoByEmail(email));
app.MapGet("/contact/phone/{phone}", (int phone, ContactController controller) => controller.GetContactInfoByPhone(phone));
/*
 *      DiscussionController End Points
 */
app.MapPost("/submit/discussion", (Discussion discussion, DiscussionController controller) => controller.CreateDiscussion(discussion));
app.MapPut("/update/discussion", (Discussion discussion, DiscussionController controller) => controller.UpdateDiscussion(discussion));
app.MapDelete("/delete/discussion", (int discussionID, DiscussionController controller) => controller.DeleteDiscussion(discussionID));
app.MapGet("/discussion", (DiscussionController controller) => controller.GetAllDiscussions());
app.MapGet("/discussion/id/{discussionID}", (int discussionID, DiscussionController controller) => controller.GetByID(discussionID));
app.MapGet("/discussion/userid/{userID}", (int userID, DiscussionController controller) => controller.GetByUserID(userID));

/*
 *      CommentController End Points
 */
app.MapPost("/submit/comment", (Comment comment, CommentController controller) => controller.CreateComment(comment));
app.MapPut("/update/comment", (Comment comment, CommentController controller) => controller.UpdateComment(comment));
app.MapDelete("/delete/comment", (int commentID, CommentController controller) => controller.DeleteComment(commentID));
app.MapGet("/comment", (CommentController controller) => controller.GetAllComments());
app.MapGet("/comment/id/{commentID}", (int commentID, CommentController controller) => controller.GetCommentById(commentID));
app.MapGet("/comment/user/{userID}", (int userID, CommentController controller) => controller.GetCommentByUser(userID));
app.MapGet("/comment/discussion/{postID}", (int postID, CommentController controller) => controller.GetCommentByPost(postID));
app.Run();
