namespace GenerativeAIResearch.Application.Handlers;

public interface IRequestHandler<in TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request);
}
