using AdoNet.Helpers;
using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Services
{
    internal class BlogService : IBaseService<Blog>
    {
        public int Create(Blog data)
        {
            string query = $"INSERT INTO Blogs VALUES(N'{data.Title}',N'{data.Description}',)";
            return SqlHelpers.Exec(query);
        }

        public ICollection<Blog>GetAll()
        {
            DataTable dt = SqlHelper.GetDatas("SELECT * FROM Blogs");
            ICollection<Blog> list = new List<Blog>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Blog)
                 {
                    Id = (int)row["Id"],

                }
            }
        }
    }
}
