namespace $rootnamespace$.Abstractions;

public interface IUnitOfWork
{
    System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken ct = default);
}
