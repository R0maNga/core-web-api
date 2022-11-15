using System.Data;
using DAL.Models;
using Microsoft.Data.SqlClient;

namespace DAL.Contracts.Procedures;

public class ProcedureProcessor : IProcedureProcessor
{
    public IEnumerable<ProcedureOutput> GetDataFromProcedure(string cn)
    {
        var sqlConnection = new SqlConnection(cn);
        var cmd = new SqlCommand("Procedure", sqlConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        sqlConnection.Open();
        cmd.ExecuteNonQuery();
        var rd = cmd.ExecuteReader();

        if (rd.HasRows)
            while (rd.Read())
            {
                var cupboardId = rd.GetGuid(0);
                var clothesId = rd.GetGuid(1);
                var defaultQuantity = rd.GetInt32(2);
                var id = rd.GetGuid(3);
                yield return new ProcedureOutput
                {
                    Id = id,
                    ClothesId = clothesId,
                    DefaultQuantity = defaultQuantity,
                    CupboardId = cupboardId
                };
            }
    }
}