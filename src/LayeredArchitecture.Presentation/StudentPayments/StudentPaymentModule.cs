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
        app.MapGet("/studentPayment", (GetAllStudentPaymentsQuery command) =>
        {
            var result = command.Handle();
            return Results.Ok(result);
        });
        app.MapPut("studentPayment/{studentPaymentId :guid}" , ([FromBody] UpdateStudentPaymentDto updateStudentPaymentDto , Guid studentPaymentId   , UpdateStudentPaymentCommand command ) =>
        {
            command.Handle(studentPaymentId,updateStudentPaymentDto);
            return Results.Ok();
        });
        app.MapPost("/studentPayment", ([FromBody]CreateStudentPaymentDto createStudentPaymentDto , CreateStudentPaymentCommand command) =>
        {
            var result = command.Handle(createStudentPaymentDto);
            return Results.Ok(result); 
        });
        app.MapDelete("/studentPayments/{studentPaymentId:guid}" , ([FromRoute] Guid studentPaymentId , DeleteStudentPaymentCommand command) =>
        {
            command.Handle(studentPaymentId);
            return Results.NoContent();
        });
        app.MapDelete("/studentPayments" , (DeleteAllStudentPaymentCommand command)=>
        {
            command.Handle();
            return Results.NoContent();
        });
    }
}