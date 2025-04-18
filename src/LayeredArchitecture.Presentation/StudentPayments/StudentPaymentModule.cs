using LayeredArchitecture.Application.StudentPayments.Command.CreateStudentPayment;
using LayeredArchitecture.Application.StudentPayments.Command.DeleteStudentPayment;
using LayeredArchitecture.Application.StudentPayments.Command.UpdateStudentPayment;
using LayeredArchitecture.Application.StudentPayments.Queries.GetAllStudentPayment;
using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitecture.WebApi.StudentPayments;

public static class StudentPaymentModule
{
    public static void AddStudentPaymentEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/studentPayment")
                        .WithTags("StudentPayment");
                        
        group.MapGet("/", (GetAllStudentPaymentsQuery command) =>
        {
            var result = command.Handle();
            return Results.Ok(result);
        });
        group.MapPut("/{studentPaymentId :guid}" , ([FromBody] UpdateStudentPaymentCommand updateStudentPaymentCommand , Guid studentPaymentId   , UpdateStudentPaymentHandler handler ) =>
        {
            handler.Handle(studentPaymentId,updateStudentPaymentCommand);
            return Results.Ok();
        });
        group.MapPost("/", ([FromBody]CreateStudentPaymentCommand createStudentPaymentCommand , CreateStudentPaymentHandler handler) =>
        {
            var result = handler.Handle(createStudentPaymentCommand);
            return Results.Ok(result); 
        });
        group.MapDelete("/{studentPaymentId:guid}" , ([FromRoute] Guid studentPaymentId , DeleteStudentPaymentHandler handler) =>
        {
            handler.Handle(studentPaymentId);
            return Results.NoContent();
        });
        group.MapDelete("/" , (DeleteAllStudentPaymentHandler handler)=>
        {
            handler.Handle();
            return Results.NoContent();
        });
    }
}