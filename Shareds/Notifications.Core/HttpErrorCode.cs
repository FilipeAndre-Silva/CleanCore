namespace Notifications.Core
{
    public enum HttpErrorCode
    {
        BadRequest = 400,             // Requisição inválida
        Unauthorized = 401,           // Não autorizado
        Forbidden = 403,              // Proibido
        NotFound = 404,               // Não encontrado
        MethodNotAllowed = 405,       // Método não permitido
        Conflict = 409,               // Conflito
        UnprocessableEntity = 422,    // Entidade não processável
        TooManyRequests = 429,        // Muitas requisições
        InternalServerError = 500,    // Erro interno do servidor
        NotImplemented = 501,         // Não implementado
        BadGateway = 502,             // Bad gateway
        ServiceUnavailable = 503,     // Serviço indisponível
        GatewayTimeout = 504          // Timeout do gateway
    }
}