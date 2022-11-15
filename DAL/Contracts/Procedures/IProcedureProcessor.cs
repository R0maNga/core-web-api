using DAL.Models;

namespace DAL.Contracts.Procedures;

public interface IProcedureProcessor
{
    public IEnumerable<ProcedureOutput> GetDataFromProcedure(string connection);
}