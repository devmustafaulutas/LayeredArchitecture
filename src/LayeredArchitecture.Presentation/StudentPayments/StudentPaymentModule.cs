using LayeredArchitecture.Application.StudentPayments.Command.CreateStudentPayment;
using LayeredArchitecture.Application.StudentPayments.Command.DeleteStudentPayment;
using LayeredArchitecture.Application.StudentPayments.Command.UpdateStudentPayment;
using LayeredArchitecture.Application.StudentPayments.Commands.DeleteStudentPayment;
using LayeredArchitecture.Application.StudentPayments.Queries.GetAllStudentPayment;
using LayeredArchitecture.Application.Students.Queries.GetAllStudents;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace LayeredArchitecture.WebApi.StudentPayments;

public static class StudentPaymentModule
{
    public static void AddStudentPaymentEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/studentPayment")
                        .WithTags("StudentPayment");
                        
        group.MapGet("/",async (IMessageBus bus) =>
        {
            var result = await bus.InvokeAsync<List<StudentCommand>>(new GetAllStudentPaymentsQuery());
            return Results.Ok(result);
        });
        group.MapPut("/{studentPaymentId :guid}" ,async ([FromBody] UpdateStudentPaymentCommand command , Guid studentPaymentId   , IMessageBus bus) =>
        {
            var result = await bus.InvokeAsync<Guid>(command);
            return Results.Ok();
        });
        group.MapPost("/", async ([FromBody]CreateStudentPaymentCommand command ,IMessageBus bus) =>
        {
            var result = await bus.InvokeAsync<Guid>(command); 
            return Results.Ok(result); 
        });
        group.MapDelete("/{studentPaymentId:guid}" ,async  ([FromRoute] Guid studentPaymentId , IMessageBus bus) =>
        {
            await bus.InvokeAsync<Guid>(studentPaymentId);
            return Results.NoContent();
        });
        group.MapDelete("/" , async (IMessageBus bus)=>
        {
            await bus.InvokeAsync(new DeleteAllStudentPaymentCommand());
            return Results.NoContent();
        });
    }
}