using BigData.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;


namespace BigData.Controllers
{
    public class DataController : Controller
    {

        private readonly string connectionString = "server =DESKTOP-D8QVUIQ\\MSSQLSERVER1; initial Catalog=CARPLATES; integrated security=true";
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Deneme()
        {
            await using var connection = new SqlConnection(connectionString);
            var values = await connection.QueryAsync<Plate>("select top 100 * from vw_MarkayaGoreArama ");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Deneme(string Brand)
        {
            await using var connection = new SqlConnection(connectionString);
            var value = await connection.QueryAsync<Plate>($"select * from vw_MarkayaGoreArama where BRAND='{Brand}'");

            return View(value);
        }
        public async Task<IActionResult> CountCars()
        {
            await using var connection = new SqlConnection(connectionString);
            var values = await connection.QueryFirstAsync<int>("select * from vw_2012UzeriArabalarınSayısı");
            NewCars c = new NewCars()
            {
                CarCount = values
            };
            return View(c);
        }
    }
}
