using System.Collections.ObjectModel;

namespace Way2DevBootcamp.Application.Core;
public class CommandResponse {
    private readonly List<string> _messages = new();

    public IEnumerable<string> Errors { get; }
    public object Result { get; }

    public CommandResponse() => Errors = new ReadOnlyCollection<string>(_messages);

    public CommandResponse(object result) : this() => Result = result;

    public CommandResponse AddError(string message) {
        _messages.Add(message);
        return this;
    }

    public CommandResponse AddErrors(IEnumerable<string> messages) {
        _messages.AddRange(messages);
        return this;
    }
}