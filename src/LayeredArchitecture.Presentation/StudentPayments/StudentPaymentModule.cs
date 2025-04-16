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
        group.MapPut("/{studentPaymentId :guid}" , ([FromBody] UpdateStudentPaymentDto updateStudentPaymentDto , Guid studentPaymentId   , UpdateStudentPaymentCommand command ) =>
        {
            command.Handle(studentPaymentId,updateStudentPaymentDto);
            return Results.Ok();
        });
        group.MapPost("/", ([FromBody]CreateStudentPaymentDto createStudentPaymentDto , CreateStudentPaymentCommand command) =>
        {
            var result = command.Handle(createStudentPaymentDto);
            return Results.Ok(result); 
        });
        group.MapDelete("/{studentPaymentId:guid}" , ([FromRoute] Guid studentPaymentId , DeleteStudentPaymentCommand command) =>
        {
            command.Handle(studentPaymentId);
            return Results.NoContent();
        });
        group.MapDelete("/" , (DeleteAllStudentPaymentCommand command)=>
        {
            command.Handle();
            return Results.NoContent();
        });
    }
}