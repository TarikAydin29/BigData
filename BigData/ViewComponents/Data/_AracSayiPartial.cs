using BigData.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BigData.ViewComponents.Data
{
    public class _AracSayiPartial : ViewComponent
    {
        private readonly string connectionString = "server =DESKTOP-D8QVUIQ\\MSSQLSERVER1; initial Catalog=CARPLATES; integrated security=true";
        public async Task< IViewComponentResult> InvokeAsync()
        {
            await using var connection = new SqlConnection(connectionString);
            var value = await connection.QueryFirstAsync<int>("select* from vw_ArabaSayısı");
            CarCount count = new CarCount()
            {
                Count = value
            };
            return View(count);
        }
    }
}
