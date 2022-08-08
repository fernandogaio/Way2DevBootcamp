using MediatR;
using System.Collections.ObjectModel;

namespace Way2DevBootcamp.Application.Core.Notifications;
public class ErrorNotification : INotification {
    private readonly List<string> _errors = new();

    public IEnumerable<string> Errors { get; }

    public ErrorNotification() => Errors = new ReadOnlyCollection<string>(_errors);

    public ErrorNotification AddError(string error) {
        _errors.Add(error);
        return this;
    }

    public ErrorNotification AddErrors(IEnumerable<string> errors) {
        _errors.AddRange(errors);
        return this;
    }
}