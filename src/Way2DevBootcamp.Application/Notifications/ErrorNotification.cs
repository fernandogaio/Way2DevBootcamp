using MediatR;

namespace Way2DevBootcamp.Application.Notifications;
public class ErrorNotification : INotification {
    public List<string> Errors { get; }

    public ErrorNotification AddError(string error) {
        Errors.Add(error);
        return this;
    }

    public ErrorNotification AddErrors(IEnumerable<string> errors) {
        Errors.AddRange(errors);
        return this;
    }
}